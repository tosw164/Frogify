using UnityEngine;
using System.Collections;

/**
 * This script represents the dropping spider.
 * The spider shakes before dropping down at an accelerated rate, and then moves back up and resets.
 * The amount of time the spider shakes, the top and bottom limit of its movement, and its speed can be set.
 * 
 */
public class Spider : MonoBehaviour {

	private Transform transform;

	//The upper limit of movement
	public float dTop_y = 5f;

	//The bottom limit of movement
	public float dBottom_y = 0f;

	//The timer for how long the spider shakes
	public float shakeTimerLimit = 2f;
	private float shakeTimer;

	public float movement_speed = 2f;

	//The pausing counter between shakes - how vigourously the spider shakes
	private float shakeCounterPause = 0.05f;

	private bool move_down;

	//Whether or not it's in shaking 
	private bool shake;

	//Tracks the shaking left and right, to know which way to shake next
	private bool prevShake;


	//The amount of shaking
	private float amount = 0.1f;
	private float shakeCounter;



	//Counter for speed of spider dropping down, increments as it goes
	float counter;

	private float origPositionX;
	private float origPositionY;

	// Use this for initialization
	void Start () {
		shake = true;
		prevShake = true;
		move_down = true;

		transform = gameObject.transform;

		//Iniital values to 0
		shakeTimer = 0f;
		//For accleration of the drop
		counter = 0;
		shakeCounter = 0;

		//Saves original position
		origPositionX = transform.position.x;
		origPositionY = transform.position.y;


	}

	// Update is called once per frame
	void Update () {

		//If spider is in the shake state, should be shaking
		if (shake == true) {
			shakeSpider ();
		} else {
			//Moves up once its gone below the bottom limit, and vice versa
			if (transform.position.y < (dBottom_y+origPositionY)) {
				move_down = false;
			} else if (transform.position.y > (dTop_y+origPositionY)) {
				shake = true;
				move_down = true;
				counter = 0.0f;

			}

			//Acceleration for the drop
			counter = counter + (5 * Time.deltaTime);

			if (move_down) {
				transform.Translate (-Vector2.up * (movement_speed + counter * 5) * Time.deltaTime);
			} else if (!move_down) {
				transform.Translate (Vector2.up * movement_speed * Time.deltaTime);
			}
		}

	}

	//Called when spider is shaking
	void shakeSpider(){

		//How long the shaking state has been going on for
		shakeTimer += Time.deltaTime;

		//Once it has reached the shaketimerlimit, stops shaking and resets
		if (shakeTimer > shakeTimerLimit) {
			shake = false;
			//Sets the timer for the amount shake to 0 again
			shakeTimer = 0f;
			//Also set the counter (for the time between shakes, to 0)
			shakeCounter = 0f;
			//Resets the spider's position to it's original position
			transform.position = new Vector2(origPositionX, transform.position.y);

		}


		//Counter for period of time between each shake movement (as shaking each frame update would be too fast)
		//Depending on the prevShake, shakes left or right alternating
		shakeCounter += Time.deltaTime;	
		if (shakeCounter > shakeCounterPause) {
			if (prevShake) {
				transform.position = new Vector2(origPositionX - amount, transform.position.y);
				prevShake = false;
			} else {
				transform.position = new Vector2(origPositionX + amount, transform.position.y);
				prevShake = true;
			}
			//Sets counter between shake movement back to zero
			shakeCounter = 0f;
		}

	}
}
