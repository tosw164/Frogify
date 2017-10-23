using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AcheivementNotification : MonoBehaviour {

	public Text messageBox;

	void Start() {
		gameObject.GetComponent<Renderer> ().enabled = false;
	}

	public void ShowMessage(string message) {
		Debug.Log (message);
		gameObject.GetComponent<Renderer> ().enabled = true;
		messageBox.enabled = true;
		messageBox.text = message;
		StartCoroutine(Waiting ());
	}

	IEnumerator Waiting() {
		yield return new WaitForSeconds(2f);
		Debug.Log ("hello");
		gameObject.GetComponent<Renderer> ().enabled = false;
		messageBox.enabled = false;
	}
}
