using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ChangeInfo : MonoBehaviour {

	private string currentInfo;

	// Use this for initialization
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
