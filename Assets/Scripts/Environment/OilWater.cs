using UnityEngine;
using System.Collections;

/*
 * Script for oily water.
 * Whenever player is inside the water, the player gets damaged every second,
 */
public class OilWater : MonoBehaviour {
	private bool _playerInWater = false;



	void OnTriggerStay(Collider2D other) {
		if (other.tag == "Player") {
			_playerInWater = true;
			//user manager to damage player
		}

	}


}
