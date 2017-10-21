using UnityEngine;
using System.Collections;

public class BounceMushroomScript : MonoBehaviour {

	public Vector2 velocity;

	//Add velocity to character if collide with boxcollider of mushroom
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
		}
	}
}
