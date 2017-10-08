using UnityEngine;
using System.Collections;

/*
 * This is a simple manager for holding any Score that should be 
 * held by the game. Currently, this is going to be used for the Exit 
 * screen, and made be used for any GUI displays.
 * 
 * This class follows the singleton pattern, and is insipred from the
 * Unity tutorial - Data Persistence.
 */
public class OverallScoreManager : MonoBehaviour {

	//Follwoing the singeltong pattern - static variable allows the instance
	//to be obtained and then increment/decrement/get health.
	public static OverallScoreManager scoreManager;

	//Values for each respective score.
	private long argumentationScore;

	//THIS MIGHT BE REDUNDANT DUE TO COLLECTIBLES ELSEWHERE.
	//Stored here to potentially facilitaed consolidation of scoring.
	private long collectibleScore;


	//Method called to either instantiate or destroy the object to ensure
	//singleton nature.
	void Awake () {
		if (scoreManager == null) {
			DontDestroyOnLoad (gameObject);
			scoreManager = this;
		} else if (scoreManager != this) {
			Destroy (gameObject);
		}
	}

	//Methods for varying score

	public void incrementArgumentationScore(long argueAdd){
		argumentationScore = argumentationScore + argueAdd;
	}

	public void incrementCollectibleScore(long collectibleAdd){
		collectibleScore = collectibleScore + collectibleAdd;
	}


	//Getter methods

	public float getTotalScore(){
		return argumentationScore + collectibleScore;
	}

	public float getArgueScore(){
		return argumentationScore;
	}

	public float getCollectibleScore(){
		return collectibleScore;
	}
}
