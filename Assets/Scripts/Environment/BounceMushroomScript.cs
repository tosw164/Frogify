using UnityEngine;
using System.Collections;

/**
 * Use this script to control the functionality of bouncing mushroom
 * */
public class BounceMushroomScript : MonoBehaviour {

	public Vector2 velocity;

	//Add velocity to character if collide with boxcollider of mushroom
	/**
	 * When player enters the box trigger, the velocity of the player is elevated to make them bounce
	 * */
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
            FindObjectOfType<AudioManager>().Play("mushroomBounce");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
		}
	}
}
