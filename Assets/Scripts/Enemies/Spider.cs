using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {

	public Transform transform;
	public float top_y;
	public float bottom_y;

	//The timer for how long the spider shakes
	public float shakeTimerLimit;
	private float shakeTimer;

	public float movement_speed;

	//The pausing counter between shakes - how vigourously the spider shakes
	private float shakeCounterPause = 0.05f;

	private bool move_down;

	//Tracks the shaking left and right
	private bool shake;
	private bool prevShake;


	//The amount of shaking
	private float amount = 0.1f;
	private float shakeCounter;



	//Counter for speed of spider dropping down, increments as it goes
	float counter;

	private float origPositionX;

	// Use this for initialization
	void Start () {
		shake = true;
		prevShake = true;
		move_down = true;


		//Iniital values to 0
		shakeTimer = 0f;
		//For accleration of the drop
		counter = 0;
		shakeCounter = 0;

		//Saves original position
		origPositionX = transform.position.x;


	}

	// Update is called once per frame
	void Update () {

		if (shake == true) {
			shakeSpider ();
		} else {
			Debug.Log ("DROP");
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
		shakeTimer += Time.deltaTime;
//		Debug.Log (shakeTimer);

		if (shakeTimer > shakeTimerLimit) {
			shake = false;
			//Sets the timer for the amount shake to 0 again
			shakeTimer = 0f;
			//Also set the counter (for the time between shakes, to 0)
			shakeCounter = 0f;
			//Resets the spider's position to it's original position
			transform.position = new Vector2(origPositionX, transform.position.y);

		}
		shakeCounter += Time.deltaTime;	
		if (shakeCounter > shakeCounterPause) {
			if (prevShake) {
				transform.position = new Vector2(origPositionX - amount, transform.position.y);
				prevShake = false;
			} else {
				transform.position = new Vector2(origPositionX + amount, transform.position.y);
				prevShake = true;
			}
			shakeCounter = 0f;
		}

	}
}
