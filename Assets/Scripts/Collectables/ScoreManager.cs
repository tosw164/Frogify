using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public static ScoreManager manager;
	public int score;

	void Awake () {

		// Ensure singleton existence of the ScoreManager
		if (manager == null) {
			DontDestroyOnLoad (gameObject);
			manager = this;
		}
		else if (manager != this) {
			Destroy (gameObject);
		}
	}
}
