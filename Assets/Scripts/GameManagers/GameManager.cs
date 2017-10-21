using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

	//======================================================




	void Awake () {
		if (manager == null) {
			DontDestroyOnLoad (gameObject);
			manager = this;
		} else if (manager != this) {
			Destroy (gameObject);
		}
	}
	

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

	//Getter method
	public float getHealth(){
		return health;
	}


	public void switchScene(int sceneNum){
		SceneManager.LoadScene (sceneNum);
	}
}
