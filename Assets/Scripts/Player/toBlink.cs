using UnityEngine;
using System.Collections;


/**
 * Use this script to control the blinking animation of Pep
 * */
public class toBlink : MonoBehaviour {

	Animator blink;

	/**
	 * Use this for initialization
	 * */
	void Start () {
		//Initialise the animator
		blink = GetComponent<Animator> ();
		//Call the cycle
		StartCoroutine(Waiting());
	}

	// Update is called once per frame
	void Update () {
	}

	/**
	 * Call this method to restart the cycle
	 * */
	void RepeatMyCoroutine() {
		StartCoroutine(Waiting());
	}

	/**
	 * Call this method to control the blinking.
	 * */
	IEnumerator Waiting() {
		while (true) {
			//Wait for 3 seconds, this is in between blinks
			yield return new WaitForSeconds (3f);
			//Set blinked to false so it starts blinking
			blink.SetBool ("isBlinked", false);
			//Wait for the blinking animation to finish
			yield return new WaitForSeconds (1f);
			//Set the bilinked to true
			blink.SetBool ("isBlinked", true);
			//Repeat the cycle
			RepeatMyCoroutine ();
		}
	}
}
