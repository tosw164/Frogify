using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour {
	
	public static ScoreManager manager;
	public int collectableScore;
	public string choice;

	void Awake () {

		// Ensure singleton existence of the ScoreManager
		if (manager == null) {
			DontDestroyOnLoad (gameObject);
			manager = this;
		}
		else if (manager != this) {
			Destroy (gameObject);
		}
	}

	//called by the dialogue to load exit scenes
	public void saveChoice(string playerChoice){
		choice = playerChoice;
	}
}
