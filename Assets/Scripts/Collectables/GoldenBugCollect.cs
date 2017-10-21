using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldenBugCollect : MonoBehaviour {

	// Update the singleton ScoreManager's score when the player picks up a coin.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			ScoreManager.manager.collectableScore++;
			Destroy (gameObject);
		}
	}
}
