using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using POCC.HighScore;
using POCC;

public class SubmitHighScore : MonoBehaviour {
	
	public void handleHighScoreClick(){
		GameObject go = GameObject.Find("HighscoreInput");
		string playerName = go.GetComponent<InputField> ().text;
		GameManager gm = GameManager.getInstance ();

		HighScoreEntry hScoreEntry = new HighScoreEntry (playerName, (int)gm.getCollectableScore (), (int)gm.getArgumentationScore ());
		HighScoreManager.getInstance ().addHighScore (0, hScoreEntry);

//		GameObject.Find(gameObject.name).GetComponent<Button> ().interactable = false;

		GameObject go2 = GameObject.Find("HighscoreText");

		string currentHighScoreText = go2.GetComponent<Text> ().text;
		string formattedEntry = hScoreEntry._name+"\t Argue Score: "+hScoreEntry._argueScore+"\t Collectable Score: "+hScoreEntry._collectScore+"\n";

		currentHighScoreText = currentHighScoreText + formattedEntry;

		go2.GetComponent<Text> ().text = currentHighScoreText;
	}

}
