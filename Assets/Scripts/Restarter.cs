using System;
using UnityEngine;
using UnityEngine.SceneManagement;

//Obtained from https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html

public class Restarter : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
			SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);

	}
}

