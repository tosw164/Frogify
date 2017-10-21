using UnityEngine;
using System.Collections;

public class BounceMushroomScript : MonoBehaviour {

	bool onTop;
	GameObject Player;
	Rigidbody2D rigi2d;
	public Vector2 velocity;
	public bool collided;

	//Add velocity to character if collide with boxcollider of mushroom
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
		}
	}
}
