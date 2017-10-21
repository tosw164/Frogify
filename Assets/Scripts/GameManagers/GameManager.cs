using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {
	
	public static GameManager manager;


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

	//THIS MIGHT BE REDUNDANT DUE TO COLLECTIBLES ELSEWHERE.
	//Stored here to potentially facilitaed consolidation of scoring.
	private long collectibleScore = 0;


	//======================================================




	void Awake () {
		if (manager == null) {
			DontDestroyOnLoad (gameObject);
			manager = this;
		} else if (manager != this) {
			Destroy (gameObject);
		}
	}
	

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
			switchScene(POCC.SceneLookup.GAME_OVER_INDEX);//Probably a good idea to CHANGE THIS. DONT MAKE IT FULLY INDEX BASED.
		}
	}

	/**
	 * This should be called by other classes in order to reset health
	 * back to default values.
	 */
	public void resetHealth(){
		health = DEFAULT_HEALTH;	
	}

	public void incrementCollectableScore(POCC.Collectable collectable){
		//If it is a normal gold fly, just increment by 1
		if (collectable.Equals (POCC.Collectable.GOLDFLY)) {
			collectibleScore++;
		}
	}

	public void incrementArgumentationScore(POCC.ArgumentationValue argueVal){
		//If it is a normal gold fly, just increment by 1
		if (argueVal.Equals (POCC.ArgumentationValue.FIRST_ATTEMPT)) {
			argumentationScore+=10;
		}
	}


	//Getter Methods:
	public float getHealth(){
		return health;
	}




	//Helper method to switch scene when required.
	public void switchScene(int sceneNum){
		SceneManager.LoadScene (sceneNum);
	}

	//Skeleton of a method used for serialization.
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();

		//Using unity built in persistentDataPath in order to be more professional
		FileStream file = File.Open(Application.persistentDataPath + "/pepInfo.dat", FileMode.Open);

		//Now need to say WHAT data you want to save. You need an object you can write to the file… You need a CLEAN CLASS that will just contain data.

	}
}
