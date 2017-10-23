using UnityEngine;
using System.Collections;

public class WaterTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			GameObject water = GameObject.Find ("Water/RisingWater");
			MovingPlatformVertical moveScript = water.GetComponentInChildren<MovingPlatformVertical> ();
			moveScript.enabled = true;
			Destroy (this);
		}
	}


}
