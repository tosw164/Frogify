using UnityEngine;
using System.Collections;

public class toBlink : MonoBehaviour {

	Animator blink;

	// Use this for initialization
	void Start () {
		blink = GetComponent<Animator> ();
		StartCoroutine(Waiting());
	}

	// Update is called once per frame
	void Update () {
	}

	void RepeatMyCoroutine() {
		StartCoroutine(Waiting());
	}

	IEnumerator Waiting() {
		while (true) {
			yield return new WaitForSeconds (3f);
			blink.SetBool ("isBlinked", false);
			yield return new WaitForSeconds (1f);
			blink.SetBool ("isBlinked", true);
			RepeatMyCoroutine ();
		}
	}
}
