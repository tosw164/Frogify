using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System;

namespace POCC {

	public class GameManager {

		private static GameManager manager;


		//======================================================
		//Default Values
		private static int DEFAULT_HEALTH = 3;
		//======================================================



		//======================================================
		//Fields to be managed

		//private just to enforce that health should only be incremented
		//via use of methods - just to help debugging/controlling the value.
		private int health = DEFAULT_HEALTH;

		//Values for each respective score.
		private long argumentationScore = 0;

		//THIS MIGHT BE REDUNDANT DUE TO COLLECTABLES ELSEWHERE.
		//Stored here to potentially facilitaed consolidation of scoring.
		private long collectableScore = 0;

		//On startup the string is just main menu, as Pep progresses, shoudl
		//modify this string to know where to place him again.
		private string levelString = "MAIN_MENU";

		private string argumentationChoice = "";

		private List<string> playerItems;


		//======================================================

		//======================================================
		//Singleton Methods:

		/**
		 * Method for retrieving the singleton instance.
		 */
		public static GameManager getInstance(){
			if (manager == null) {
				manager = new GameManager();
			}
			return manager;
		}

		public GameManager() {
			playerItems = new List<string>();
		}


		//======================================================
		//Update Methods:

		public void incrementHealth(){
			health++;
		}

		public void decrementHealth(){
			health--;
			Debug.Log ("Took damage, current health is: " + health);
			if (health == 0) {
				health = DEFAULT_HEALTH;//set health BACK to default value
				//TODO: SHould this be reset by the gameover screen?
				switchScene(POCC.SceneType.GAME_OVER);//Probably a good idea to CHANGE THIS. DONT MAKE IT FULLY INDEX BASED.
			}
		}

		/**
		 * This should be called by other classes in order to reset health
		 * back to default values.
		 */
		public void resetHealth(){
			health = DEFAULT_HEALTH;
		}

		/**
		 * This should be called by other classes in order to reset score
		 * back to default values.
		 */
		public void resetScore() {
			collectableScore = 0;
			argumentationScore = 0;
		}

		public void incrementCollectableScore(POCC.Collectable collectable){
			//If it is a normal gold fly, just increment by 1
			if (collectable.Equals (POCC.Collectable.GOLDFLY)) {
				collectableScore++;
			}
		}

		public void incrementArgumentationScore(POCC.ArgumentationValue argueVal){
			//If it is a normal gold fly, just increment by 1
			if (argueVal.Equals (POCC.ArgumentationValue.FIRST_ATTEMPT)) {
				argumentationScore+=10;
			}
		}

		//TODO: Need to refactor this
		// This is the code that saves the player choice after talking to bearlana
		//called by the dialogue to load exit scenes
		public void saveChoice(string playerChoice){
			Debug.Log (playerChoice);
			argumentationChoice = playerChoice;
			Debug.Log ("choiceAssigned " + argumentationChoice);

		}

		/**
		 * Add a item to the players inventory.
		 */
		public void addPlayerItem(string itemName) {
			playerItems.Add(itemName);
		}
		//======================================================


		//======================================================
		//Getter Methods:

		public float getHealth(){
			return health;
		}

		public long getArgumentationScore() {
			return argumentationScore;
		}

		public long getCollectableScore() {
			return collectableScore;
		}

		public long getTotalScore() {
			return getCollectableScore() + getArgumentationScore();
		}

		public string getChoice() {
			return argumentationChoice;
		}

		public List<string> getPlayerItems() {
			return playerItems;
		}

		public bool playerHasItem(string itemName) {
			return playerItems.Contains(itemName);
		}
		//======================================================


		//======================================================
		//Helper Methods:

		//Helper method to switch scene when required.
		public void switchScene(SceneType newScene, Action prehooks = null, Action posthooks = null) {
			// Pre-switch opertations go here
			if (prehooks != null) {
				prehooks();
			}

			// Switch scenes
			SceneManager.LoadScene(SceneLookup.lookup(newScene));

			// Post-switch opertations go here
			if (posthooks != null) {
				posthooks();
			}
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
		 * Will be called whenever theres a change in level to persist whats needed.
		 */
		public void Save(){
			BinaryFormatter bf = new BinaryFormatter();

			//Using unity built in persistentDataPath in order to be more professional
			FileStream file = File.Open(Application.persistentDataPath + "/pepInfo.dat", FileMode.Open);

			//Now need to say WHAT data you want to save. YDou need an object you can write to the file… You need a CLEAN CLASS that will just contain data.
 			POCC.PlayerData gameData = new POCC.PlayerData(health,argumentationScore,collectableScore, levelString);

			bf.Serialize (file, gameData);
			file.Close ();

		}

		/**
		 * Method for actually loading in data and setting up the
		 */
		public void Load(){
			if (File.Exists (Application.persistentDataPath + "/pepInfo.dat")) {
				BinaryFormatter bf = new BinaryFormatter();

				//Doesn't need file mode because just opening it and KNOW it arledy exists
				FileStream saveFile = File.Open(Application.persistentDataPath + "/pepInfo.dat", FileMode.Open);

				//Reading in FROM the save file - need cast to be able to get it.
				POCC.PlayerData gameData = (POCC.PlayerData) bf.Deserialize(saveFile);
				saveFile.Close ();

				this.health = gameData.getHealth ();
				this.argumentationScore = gameData.getArgueScore ();
				this.collectableScore = gameData.getCollectScore ();
				this.levelString = gameData.getLevelString ();
			}
			//IF HERE, THEN MAYBE SAY THERES NO SAVED DATA.
			//maybe when loading sceen.
		}
		//======================================================

	}
}
