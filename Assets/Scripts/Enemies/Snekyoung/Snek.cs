using UnityEngine;
using System.Collections;

/**
 * The Snek Script is assigned to Snekyoung, and determines its movement.
 * Can set the direction, speed, and the amount if moves before dissapearing/destroying itself.
 */ 
public class Snek : MonoBehaviour {

	// Determines direction
	public bool isLeft = true;

	// The distance Snekyoung moves from its original position before destroying
	public float deltaX = 20f;

	// The speed of Snekyoung
	public float speed = 1f;

	// Saves the original X position of the snake, to determine the relative movement
	private float origX;

	// Grabs the original positiion
	void Start () {
		origX = transform.position.x;
	}
	
	// Update is called once per frame
	// Determines the step size depending on the speed and the amount that has passed
	// Then translates the Snekyoung's position depending on the step size
	void Update () {
		float step = speed * Time.deltaTime;
		if (isLeft) {
			transform.Translate (Vector2.left * step);
			if (transform.position.x < (origX - deltaX)) {
				Destroy (this.gameObject);
			}
		} else {
			transform.Translate (Vector2.right * step);
			if (transform.position.x > (deltaX + origX)) {
				Destroy (this.gameObject);
			}
		}
	}
}
