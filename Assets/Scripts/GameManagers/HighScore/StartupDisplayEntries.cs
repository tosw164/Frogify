using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using POCC.HighScore;
using POCC;

public class StartupDisplayEntries : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find("HighscoreText");

		HighScoreEntry highScoreEntry = new HighScoreEntry ("Kenney Chann", 20, 20);
		HighScoreManager.getInstance ().addHighScore (0, highScoreEntry);

		List<HighScoreEntry> listForLevel = HighScoreManager.getInstance ().getHighScoresForLevel (0);
		if (listForLevel.Count == 0) {
			go.GetComponent<Text> ().text = "No Objects :C!";
		} else {
			string textInput = "";
			foreach (HighScoreEntry entry in listForLevel) {
				int totalScore = (int)entry._argueScore + (int)entry._collectScore;
				textInput = textInput+entry._name+"\t Argue Score: "+entry._argueScore+"\t Collectable Score: "+entry._collectScore+"\n";
			}
			go.GetComponent<Text> ().text = textInput;
		}
	}
}
