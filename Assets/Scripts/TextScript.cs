using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/**
 * This script is for controlling the score UI.
 * */
public class TextScript : MonoBehaviour {

	Text score;

	// Use this for initialization
	void Start () {
		//Initialise the score as the current score.
		score = GetComponent<Text> ();
		score.text = "" + (int)POCC.GameManager.getInstance().getCollectableScore();
	}
	
	// Update is called once per frame
	void Update () {
		//for every frame update the score to what the current score is.
		score.text = "" + (int)POCC.GameManager.getInstance().getCollectableScore();
	}
}
