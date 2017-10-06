using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollectable : MonoBehaviour {


	private int score = 0;
	public Text scoreText;

	void Start() {
		UpdateScore ();
	}

	void Update() {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Collectable")) {
			other.gameObject.SetActive (false);
			score++;
			UpdateScore ();
		}
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score.ToString ();
	}
}
