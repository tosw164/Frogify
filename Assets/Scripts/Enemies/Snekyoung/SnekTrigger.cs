using UnityEngine;
using System.Collections;

/*
 * The SnekTrigger is assigned to the Collision Trigger Gameobject at certain positions of the Ethos scene.
 * Snekyoung is already positioned in the scene, and the trigger just enables Snekyoung which begins his movement
 * Snekyoung is originally disabled for each trigger.
 */
public class SnekTrigger : MonoBehaviour {

	// Trigger set off when Pep walks through the gameobject's collider
	void OnTriggerEnter2D(Collider2D other) {
		// Double checks that the gameobject colliding is Pep, which is tagged PLayer
		if (other.gameObject.CompareTag ("Player")) {
			// Child(0) refers to the Snekyoung prefab, which is a child of the trigger
			// Enables Snekyoung
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
		}

		// Finds the Camera, and calls the CameraShake script's ShakeCamera method
		GameObject camera = GameObject.Find ("CameraUI");
        
        FindObjectOfType<AudioManager>().Play("snakeRumble");
        CameraShake cameraScript = camera.GetComponentInChildren<CameraShake> ();
		cameraScript.ShakeCamera(1, 1);

		// Removes the trigger, so Pep does not call Snekyoung again
		Destroy (this);
	}
		
}
