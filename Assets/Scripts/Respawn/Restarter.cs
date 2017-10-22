using System;
using UnityEngine;
using POCC;
using POCC.Scenes;

//Obtained from https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html

public class Restarter : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Player") {
			GameManager.getInstance().switchScene(Lookup.sceneLookup(SceneType.GAME_OVER));
		}
	}
}
