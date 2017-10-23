using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This script is for changing the information on exit panels
 * */
public class ChangeInfo : MonoBehaviour {

	private string currentInfo;


	// Use this for initialization, initialise where the score is showed first
	void Start () {
		Debug.Log ("called");
		currentInfo = "score";
		transform.parent.GetChild(2).gameObject.SetActive(true);
		transform.parent.GetChild(1).gameObject.SetActive(false);
		transform.parent.GetChild(0).gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * Call this information when you pressed the previous button
	 * */
	public void ChangeInformationLeft(int trash) {
		Debug.Log ("called");
		if (currentInfo == "score") {
			transform.parent.GetChild(2).gameObject.SetActive(false);
			currentInfo = "highscore";
			transform.parent.GetChild(1).gameObject.SetActive(true);
		} else if (currentInfo == "information") {
			transform.parent.GetChild(0).gameObject.SetActive(false);
			currentInfo = "score";
			transform.parent.GetChild(2).gameObject.SetActive(true);
		}
	}

	/**
	 * Call this information when you pressed the next button
	 * */
	public void ChangeInformationRight(int trash) {
		if (currentInfo == "highscore") {
			transform.parent.GetChild(1).gameObject.SetActive(false);
			currentInfo = "score";
			transform.parent.GetChild(2).gameObject.SetActive(true);
		} else if (currentInfo == "score") {
			transform.parent.GetChild(2).gameObject.SetActive(false);
			currentInfo = "information";
			transform.parent.GetChild(0).gameObject.SetActive(true);
		}
	}
}
