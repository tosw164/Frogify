using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthPickupCollect : MonoBehaviour {

	// Update the singleton POCC.GameManager's collectable score when the player picks up a coin.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			POCC.GameManager.getInstance().incrementHealth();
            FindObjectOfType<AudioManager>().Play("healthRegen");
            Destroy(gameObject);
		}
	}
}
