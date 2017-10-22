using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MessageBubble : MonoBehaviour {

	public int delay = 2;
	public Canvas bubbleCanvas;
	public Text text;


	// Use this for initialization
	void Start () {
		bubbleCanvas.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void OnMouseDown(){
		StartCoroutine (ShowMessage());

	}

	IEnumerator ShowMessage(){
		Debug.Log ("hio");

		bubbleCanvas.gameObject.SetActive (true);
		yield return new WaitForSeconds (delay);
		bubbleCanvas.gameObject.SetActive (false);
	}
}
