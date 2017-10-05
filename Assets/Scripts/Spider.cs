using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {

	public Transform transform;
	public float top_y;
	public float bottom_y;

	private float movement_speed = 2f;
	private bool move_down;

	float counter;



	// Use this for initialization
	void Start () {
		move_down = true;
		Debug.Log (transform.position.y);
		top_y = 5f;
		bottom_y = -2f;
		counter = 0;
	}

	// Update is called once per frame
	void Update () {

		Debug.Log (transform.position.y);

		if (transform.position.y < bottom_y){
			move_down = false;
		} else if (transform.position.y > top_y) {
			move_down = true;
			counter = 0.0f;
		}

		counter = counter + (5*Time.deltaTime);

		if (move_down){
			transform.Translate (-Vector2.up * (movement_speed + counter) * Time.deltaTime);
		} else if (!move_down) {
			transform.Translate (Vector2.up * movement_speed * Time.deltaTime);
		}

	}
}
