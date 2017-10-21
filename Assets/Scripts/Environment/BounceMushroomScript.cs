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
			Rigidbody2D rb2d = other.gameObject.GetComponent<Rigidbody2D>();

			Vector2 current_velocity = rb2d.velocity;
			current_velocity.y = 0f;

			rb2d.velocity = current_velocity;
			rb2d.AddForce(velocity, ForceMode2D.Impulse);
			// rb2d.velocity = velocity;
		}
	}
}
