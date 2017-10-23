using UnityEngine;
using System.Collections;

public class SnekTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
		}

		GameObject camera = GameObject.Find ("CameraUI");
		CameraShake cameraScript = camera.GetComponentInChildren<CameraShake> ();
		cameraScript.ShakeCamera(1, 1);

		Destroy (this);
	}
		
}
