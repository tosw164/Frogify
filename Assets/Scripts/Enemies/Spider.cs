using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {

	public Transform transform;
	public float top_y;
	public float bottom_y;
	public float shakingLength;


	private float movement_speed = 2f;
	private bool move_down;

	//Tracks the shaking left and right
	private bool shake;
	private bool prevShake;

	//The pausing counter between shakes
	private float shakeCounterPause = 5;
	private float shakeCounter;

	//The timer for how long the spider shakes
	private float shakeTimer;
	private float shakeTimerLimit;

	//Counter for speed of spider dropping down, increments as it goes
	float counter;

	// Use this for initialization
	void Start () {
		
		shake = true;
		prevShake = true;

		shakeTimer = 0f;
		shakeTimerLimit = 30f;

		move_down = true;

		counter = 0;
		shakeCounter = 0;
	}

	// Update is called once per frame
	void Update () {

		if (shake == true) {
			shakeSpider ();
		} else {
			// Debug.Log ("DROP");
			if (transform.position.y < bottom_y) {
				move_down = false;
			} else if (transform.position.y > top_y) {
				shake = true;
				move_down = true;
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


		shakeTimer++;
		shakeCounter++;
//		Debug.Log (shakeTimer);

		if (shakeTimer > shakeTimerLimit) {
			shake = false;
			//Sets the timer for the amount shake to 0 again
			shakeTimer = 0f;
		}
			
		if (shakeCounter == shakeCounterPause) {
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
