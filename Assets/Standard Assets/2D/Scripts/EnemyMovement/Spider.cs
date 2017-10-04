using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {

	public Transform transform;
	public float top_y = 5f;
	public float bottom_y = 0f;

	private float movement_speed = 2f;
	private bool move_down;



	// Use this for initialization
	void Start () {
		move_down = true;
		Debug.Log (transform.position.y);
	}

	// Update is called once per frame
	void Update () {

		if (transform.position.y < bottom_y){
			move_down = false;
		} else if (transform.position.y > top_y) {
			move_down = true;
		}

		if (move_down){
			transform.Translate (-Vector2.up * movement_speed * Time.deltaTime);
		} else if (!move_down) {
			transform.Translate (Vector2.up * movement_speed * Time.deltaTime);
		}

	}
}
