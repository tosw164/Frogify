﻿using UnityEngine;
using System.Collections;


/**
 * This script is used for the moving platform - the assigned object moves up and  and down (set top and bottom limits) with a set 
 * movement speed. If Pep collides/is on the platform, he becomes a child of the platform and moves with it.
 */
public class MovingPlatformVertical : MonoBehaviour {

	//Public fields, assigned, relative to current position
	public int dTop_y;
	public int dBottom_y;
	public float movement_speed;

	private float origPosition;
	private bool move_up;

	// Use this for initialization
	void Start () {
		// Save the initial position of the platform, the current y value
		origPosition = transform.position.y;

		//Initially moves up
		move_up = true;
	}


	// Update is called once per frame
	void Update () {
		//If the asset moves far enough up, move down.
		//Vice versa, once it passes the bottom limit, goes up
		if (transform.position.y > (origPosition + dTop_y)){
			move_up = false;
		} else if (transform.position.y < (origPosition - dBottom_y)) {
			move_up = true;
		}


		//Transforms left or right
		if (move_up) {
			transform.Translate (Vector2.up * movement_speed * Time.deltaTime);
		} else if (!move_up) {
			transform.Translate (Vector2.down * movement_speed * Time.deltaTime);
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
