using UnityEngine;
using System.Collections;

/*
 * Script for oily water.
 * Whenever player is inside the water, the player gets damaged every second,
 */
public class OilWater : MonoBehaviour {
	private bool _playerInWater = false;
	private float _timeInWater = 0f;


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.1f, 0.1f);
			
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);

		}
	}

	void OnTriggerStay2D(Collider2D other) {
		_timeInWater += Time.deltaTime;

		if (other.tag == "Player") {
			_playerInWater = true;
			//user manager to damage player
			if(_timeInWater >= 5) {
				_timeInWater = 0;
				POCC.GameManager.getInstance().decrementHealth();
			}
		}



	}


}
