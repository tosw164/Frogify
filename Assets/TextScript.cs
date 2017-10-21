using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
		score.text = "" + (int)POCC.GameManager.getInstance().getCollectableScore();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "" + (int)POCC.GameManager.getInstance().getCollectableScore();
	}
}
