using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldenBugCollect : MonoBehaviour {

	// Update the singleton POCC.GameManager's collectable score when the player picks up a coin.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			POCC.GameManager.getInstance().incrementCollectableScore(POCC.Collectable.GOLDFLY);
			Destroy (gameObject);
            FindObjectOfType<AudioManager>().Play("goldenFlyCollectable");
            
        }
	}
}
