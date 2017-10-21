using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
		score.text = "" + ScoreManager.manager.collectableScore;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "" + ScoreManager.manager.collectableScore;
	}
}
