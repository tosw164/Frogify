using UnityEngine;
using System.Collections;

/***
 * This class is used to imitiate the behaviour of a secret entrance. What it does
 * is that it will be attatched onto a object and when the player enters the 
 * trigger colider of that object, the other object will be destroyed. The destroyed
 * object is the imitation of the secret entrance.
 *
 */
public class SecretEntranceActivator : MonoBehaviour {

	//This is a pointer to the gameobject that will be destroyed
	public GameObject entrance;

	//When the player enters the range, destroy the object with this script and the 
	//"entrance" object
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			Destroy(entrance);
			Destroy(gameObject);
		}
	}
}
