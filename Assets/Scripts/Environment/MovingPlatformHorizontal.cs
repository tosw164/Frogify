using UnityEngine;
using System.Collections;


/**
 * This script is used for the moving platform - the assigned object moves left and right (set left and right limits) with an assignable 
 * movement speed. If Pep collides/is on the platform, he becomes a child of the platform and moves with it.
 */
public class MovingPlatformHorizontal : MonoBehaviour {

	//Public fields, assigned, relative to current position
	public int dLeft_x;
	public int dRight_x;
	public int movement_speed;

	private float origPosition;
	private bool move_left;

	// Use this for initialization
	void Start () {
		// Save the initial position of the platform
		origPosition = transform.position.x;

		//Initially moves left
		move_left = true;
	}
		
	
	// Update is called once per frame
	void Update () {
		//If the asset moves far enough left, turns right.
		//Vice versa, once it passes the right limit, turns left
		if (transform.position.x < (origPosition - dLeft_x)){
			move_left = false;
		} else if (transform.position.x > (origPosition + dRight_x)) {
			move_left = true;
		}


		//Transforms left or right
		if (move_left) {
			transform.Translate (Vector2.left * movement_speed * Time.deltaTime);
		} else if (!move_left) {
			transform.Translate (Vector2.right * movement_speed * Time.deltaTime);
		}
	}


	//Triggered when Pep jumps on the platform
	//Sets Pep to become a child of the platform, and inherits the movement script
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			other.gameObject.transform.parent = transform;
		}
	}

	//Triggered when Pep jumps off the platform
	//Sets Pep's parent back to null
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.transform.parent = null;
		}
	}
}
