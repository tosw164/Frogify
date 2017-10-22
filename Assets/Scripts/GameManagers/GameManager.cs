using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using POCC.Scenes;

namespace POCC {

	/**
	 * This class represents the overall manager for the game. It is a
	 * singleton, and holds all of the state for the game.
	 */
	public class GameManager {

		private static GameManager _manager;


		//======================================================
		// Default Values
		private static int DEFAULT_HEALTH = 3;
		//======================================================



		//======================================================
		// Fields to be managed

		//private just to enforce that health should only be incremented
		//via use of methods - just to help debugging/controlling the value.
		private int _health = DEFAULT_HEALTH;

		//Values for each respective score.
		private long _argumentationScore = 0;

		//THIS MIGHT BE REDUNDANT DUE TO COLLECTABLES ELSEWHERE.
		//Stored here to potentially facilitated consolidation of scoring.
		private long _collectableScore = 0;

		//On startup the string is just main menu, as Pep progresses, should
		//modify this string to know where to place him again.
		private SceneType _level = SceneType.MAIN_MENU;

		// For saving temporary argumentation choices.
		private string _argumentationChoice = "";

		// Represents the player's inventory.
		private List<string> _playerItems;

		private POCC.Scenes.Scene _currentScene = new POCC.Scenes.Scene();

		private Achievements.AchievementManager _achievementManger;

		private List<Achievements.Achievement> _currentAchievements = new List<Achievements.Achievement>();

		//======================================================

		//======================================================
		// Singleton Methods:

		/**
		 * Method for retrieving the singleton instance.
		 */
		public static GameManager getInstance() {
			if (_manager == null) {
				_manager = new GameManager();
			}
			return _manager;
		}

		public GameManager() {
			_playerItems = new List<string>();
			_achievementManger = new POCC.Achievements.AchievementManager ();
		}


		//======================================================
		// Update Methods:

		public void incrementHealth() {
			// Only increment health if it is less than the maximum
			if (_health < DEFAULT_HEALTH) {
				_health++;
			}
		}

		public void decrementHealth() {
			_health--;
			Debug.Log("Took damage, current health is: " + _health);

			if (_health == 0) {
				// Set scene to game over scene and reset health back to default
				switchScene(Lookup.sceneLookup(SceneType.GAME_OVER));
			}
		}

		/**
		 * This should be called by other classes in order to reset health
		 * back to default values.
		 */
		public void resetHealth(){
			_health = DEFAULT_HEALTH;
		}

		/**
		 * This should be called by other classes in order to reset score
		 * back to default values.
		 */
		public void resetScore() {
			_collectableScore = 0;
			_argumentationScore = 0;
		}

		public void incrementCollectableScore(Collectable collectable){
			_collectableScore += Lookup.collectableScoreLookup(collectable);

			//Also send a collectable event for achievements.
			_achievementManger.RegisterAchievementEvent (Achievements.AchievementType.COLLECTABLES);
		}

		public void incrementArgumentationScore(ArgumentationValue argueVal){
			_argumentationScore += Lookup.argumentationScoreLookup(argueVal);
		}

		// TODO: Need to refactor this
		// This is the code that saves the player choice after talking to bearlana
		// called by the dialogue to load exit scenes
		public void saveChoice(string playerChoice){
			Debug.Log(playerChoice);
			_argumentationChoice = playerChoice;
			Debug.Log("choiceAssigned " + _argumentationChoice);

		}

		/**
		 * Add a item to the players inventory.
		 */
		public void addPlayerItem(string itemName) {
			_playerItems.Add(itemName);
		}

		/**
		 * Clears the player's inventory
		 */
		 public void clearInventory() {
			 _playerItems.Clear();
		 }

		/**
		 * Method for handling when an achievement has occured - it will set the field
		 * in the achievement and also add it to a list such that the achievement menu
		 * can reference it.
		 */
		public void handleAchievement(Achievements.Achievement achievement){
			Debug.Log ("Achievement Get!! - " + achievement._achievementMessage);
			achievement._unlocked = true;

			//Add to the achievement list in order to then check that.
			_currentAchievements.Add (achievement);
		}
		//======================================================


		//======================================================
		// Getter Methods:

		public float getHealth(){
			return _health;
		}

		public long getArgumentationScore() {
			return _argumentationScore;
		}

		public long getCollectableScore() {
			return _collectableScore;
		}

		public long getTotalScore() {
			return getCollectableScore() + getArgumentationScore();
		}

		public string getChoice() {
			return _argumentationChoice;
		}

		public List<string> getPlayerItems() {
			return _playerItems;
		}

		public bool playerHasItem(string itemName) {
			return _playerItems.Contains(itemName);
		}
		//======================================================


		//======================================================
		// Helper Methods:

		// Helper method to switch scene when required.
		public void switchScene(POCC.Scenes.Scene scene) {
			_currentScene.getTeardownHooks()();
			SceneManager.LoadScene(scene.getLocation());
			sceneChangeHook();
			scene.getStartupHooks()();
			_currentScene = scene;
		}

		/**
		 * Hook that the game manager can use if needing to do some general setting
		 * of state
		 */
		public void sceneChangeHook() {
			// Do things here
		}

		public void testPre() {
			Debug.Log("Prehook here");
		}

		public void testPost() {
			Debug.Log("Posthook here");
		}


		/*
		 * Method of actually saving data - it instantiates another container class
		 * that will then hold the data and be serialized to disk.
		 * Will be called whenever there's a change in level to persist whats needed.
		 */
		public void Save(){
			BinaryFormatter bf = new BinaryFormatter();

			// Open the file that will be used for persistence
			FileStream file = File.Open(Config.PERSISTENCE_FILE, FileMode.Open);

			// Construct GameData object that will hold all of the information
			// for the save state
			PlayerData gameData = new PlayerData(_health, _argumentationScore, _collectableScore, _level);

			// Serialise, save and close file
			bf.Serialize(file, gameData);
			file.Close();

		}

		/**
		 * Method for actually loading in data and setting up the
		 */
		public void Load(){
			if (File.Exists(Config.PERSISTENCE_FILE)) {
				BinaryFormatter bf = new BinaryFormatter();

				//Doesn't need file mode because just opening it and KNOW it already exists
				FileStream saveFile = File.Open(Config.PERSISTENCE_FILE, FileMode.Open);

				//Reading in FROM the save file - need cast to be able to get it.
				PlayerData gameData = (PlayerData)bf.Deserialize(saveFile);
				saveFile.Close();

				_health = gameData.getHealth();
				_argumentationScore = gameData.getArgueScore();
				_collectableScore = gameData.getCollectScore();
				_level = gameData.getLevel();
			}
			//IF HERE, THEN MAYBE SAY THERE'S NO SAVED DATA.
			//maybe when loading screen.
		}
		//======================================================

	}
}
