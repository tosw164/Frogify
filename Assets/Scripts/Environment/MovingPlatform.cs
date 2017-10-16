using UnityEngine;
using System.Collections;


/**
 * This script is used for the moving platform - the assigned object moves left and right (set left and right limits) with a set 
 * movement speed.
 */
public class MovingPlatform : MonoBehaviour {

	//Public fields, assigned, relative to current position
	public int dLeft_x;
	public int dRight_x;
	public int movement_speed;

	private float origPosition;
	private bool move_left;
	private bool firstTime;

	// Use this for initialization
	void Start () {
		//Initially moves left

		move_left = true;
		firstTime = true;
	}
		
	
	// Update is called once per frame
	void Update () {
		if (firstTime) {
			origPosition = transform.position.x;
			firstTime = false;
		}

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
}
