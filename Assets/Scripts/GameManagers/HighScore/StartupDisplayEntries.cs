using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using POCC.HighScore;
using POCC;

/*
 * This class is responsible for populating the text field that displays the
 * high score entriesl It also intitalizes some dummy data for showacasing
 * purposes
 */ 
public class StartupDisplayEntries : MonoBehaviour {
	public int _sceneNum;
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find("HighscoreText");
		HighScoreEntry highScoreEntry;
		//dummy data
		if (_sceneNum == 0) {
			highScoreEntry = new HighScoreEntry ("Kenney Chann", 20, 20);
			HighScoreManager.getInstance ().addHighScore (0, highScoreEntry);
		} else if (_sceneNum == 1) {
			highScoreEntry = new HighScoreEntry ("Kalanarama", 30, 40);
			HighScoreManager.getInstance ().addHighScore (0, highScoreEntry);
		}

		List<HighScoreEntry> listForLevel = HighScoreManager.getInstance ().getHighScoresForLevel (_sceneNum);

		//error checking
		if (listForLevel.Count == 0) {
			go.GetComponent<Text> ().text = "No Objects :C!\n";
		} else {//normal case
			string textInput = "";
			foreach (HighScoreEntry entry in listForLevel) {
				int totalScore = (int)entry._argueScore + (int)entry._collectScore;
				textInput = textInput+entry._name+"\t Argue Score: "+entry._argueScore+"\t Collectable Score: "+entry._collectScore+"\n";
			}
			go.GetComponent<Text> ().text = textInput;
		}
	}
}
