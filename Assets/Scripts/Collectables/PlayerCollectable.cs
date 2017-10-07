using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollectable : MonoBehaviour {

	// Update the singleton ScoreManager's score when the player picks up a coin.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Collectable")) {
			other.gameObject.SetActive (false);
			ScoreManager.manager.collectableScore++;
		}
	}
}
