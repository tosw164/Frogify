using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public int left_x;
	public int right_x;
	public int movement_speed;
	private bool move_left;

	// Use this for initialization
	void Start () {
		move_left = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < left_x){
			move_left = false;
		} else if (transform.position.x > right_x) {
			move_left = true;
		}


		if (move_left) {
			transform.Translate (Vector2.left * movement_speed * Time.deltaTime);
		} else if (!move_left) {
			transform.Translate (Vector2.right * movement_speed * Time.deltaTime);
		}
	}
}
