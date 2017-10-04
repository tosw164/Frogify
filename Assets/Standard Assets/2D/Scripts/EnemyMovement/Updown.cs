using UnityEngine;
using System.Collections;

public class Updown : MonoBehaviour {

	public Transform transform;
	public float top_y = 1f;
	public float bottom_y = -1f;

	private float movement_speed = 2f;
	private bool move_up;



	// Use this for initialization
	void Start () {
		move_up = false;
		Debug.Log (transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {


//		Debug.Log (transform.position.y + " " + move_up);


		if (transform.position.y > top_y){
			move_up = false;
		} else if (transform.position.y < bottom_y) {
			move_up = true;
		}

		if (!move_up){
			transform.Translate (-Vector2.up * movement_speed * Time.deltaTime);
		} else if (move_up) {
			transform.Translate (Vector2.up * movement_speed * Time.deltaTime);
		}
	
	}
}
