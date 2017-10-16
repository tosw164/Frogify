using UnityEngine;
using System.Collections;


/**
 * This script is used for the moving platform - the assigned object moves left and right (set left and right limits) with a set 
 * movement speed.
 */
public class MovingPlatform : MonoBehaviour {

	//Public fields, assigned
	public int left_x;
	public int right_x;
	public int movement_speed;

	private bool move_left;

	// Use this for initialization
	void Start () {
		//Initially moves left
		move_left = true;
	}
	
	// Update is called once per frame
	void Update () {

		//If the asset moves far enough left, turns right.
		//Vice versa, once it passes the right limit, turns left
		if (transform.position.x < left_x){
			move_left = false;
		} else if (transform.position.x > right_x) {
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
