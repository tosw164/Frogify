using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AcheivementNotification : MonoBehaviour {

	public Text messageBox;

	void Start() {
		gameObject.SetActive (false);
	}

	public void ShowMessage(string message) {
		gameObject.SetActive (true);
		messageBox.text = message;
		Waiting ();
		gameObject.SetActive (false);
	}

	IEnumerator Waiting() {
		yield return new WaitForSeconds(2);
	}
}
