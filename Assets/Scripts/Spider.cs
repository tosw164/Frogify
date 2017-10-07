using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {

	public Transform transform;
	public float top_y;
	public float bottom_y;
	public float shakingLength;


	private float movement_speed = 2f;
	private bool move_down;
	private bool shake;
	private bool prevShake;
	private float shakeCounterRate = 5;
	private float shakeCounter;

	//Counter for speed of spider dropping down, increments as it goes
	float counter;

	// Use this for initialization
	void Start () {
		shake = true;
		prevShake = true;
		move_down = true;
		counter = 0;
		shakeCounter = 0;
	}

	// Update is called once per frame
	void Update () {

		if (shake == true) {
			shakeSpider ();
		} else {
			if (transform.position.y < bottom_y) {
				move_down = false;
			} else if (transform.position.y > top_y) {
				shake = true;
				shakeSpider ();
				counter = 0.0f;

			}

			counter = counter + (5 * Time.deltaTime);

			if (move_down) {
				transform.Translate (-Vector2.up * (movement_speed + counter * 5) * Time.deltaTime);
			} else if (!move_down) {
				transform.Translate (Vector2.up * movement_speed * Time.deltaTime);
			}
		}

	}


	void shakeSpider(){
		float speed = 1.0f; //how fast it shakes
		float amount = 10.0f; //how much it shakes
		shakeCounter++;
		if (shakeCounter == shakeCounterRate) {
			if (prevShake) {
				transform.Translate (Vector2.left * (amount * (Time.deltaTime * speed)));
				prevShake = false;
			} else {
				transform.Translate (Vector2.right * (amount * (Time.deltaTime * speed)));
				prevShake = true;
			}
			shakeCounter = 0f;
		}
	}
}
