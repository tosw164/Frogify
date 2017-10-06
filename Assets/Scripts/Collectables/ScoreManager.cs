using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager manager;

	public int score;

	void Awake () {
		if (manager == null) {
			DontDestroyOnLoad (gameObject);
			manager = this;
		}
		else if (manager != this) {
			Destroy (gameObject);
		}
	}
}
