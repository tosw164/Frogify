using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * This is a simple Health Manager class that will be used to store
 * the value of Health for Pep. Although this does not need to be 
 * implemented until advanced features, the skeleton is implemented here.
 * 
 * This class follows the singleton pattern, and is insipred from the
 * Unity tutorial - Data Persistence.
 */
public class HealthManager : MonoBehaviour {

	//Follwoing the singeltong pattern - static variable allows the instance
	//to be obtained and then increment/decrement/get health.
	public static HealthManager healthManager;

	private static int DEFAULT_HEALTH = 3;

	//private just to enforce that health should only be incremented
	//via use of methods - just to help debugging/controlling the value.
	private int health = DEFAULT_HEALTH;

	//Method called to either instantiate or destroy the object to ensure
	//singleton nature.
	void Awake () {
		Debug.Log ("Im alive xdd");
		if (healthManager == null) {
			DontDestroyOnLoad (gameObject);
			healthManager = this;
		} else if (healthManager != this) {
			Destroy (gameObject);
		}
	}

	//Methods for varying health - may add more in the future.

	public void incrementHealth(){
		health++;
	}

	public void decrementHealth(){
		health--;
		Debug.Log ("Took damage, current health is: " + health);
		if (health == 0) {
			health = DEFAULT_HEALTH;//set health BACK to default value
			SceneManager.LoadScene(3);//Probably a good idea to CHANGE THIS. DONT MAKE IT FULLY INDEX BASED.
		}
	}

	//Getter method
	public float getHealth(){
		return health;
	}
}
