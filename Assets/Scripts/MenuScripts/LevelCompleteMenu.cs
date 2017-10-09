using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelCompleteMenu : MonoBehaviour {

	public GameObject FeedbackPanel;
	public string answer;

	// Use this for initialization
	void Start () {

		this.gameObject.SetActive (true);
		Transform fliesChild =  transform.Find("Panel/Panel/Flies");
		Text flies = fliesChild.GetComponent<Text>();
		flies.text = "" + ScoreManager.manager.collectableScore;

		//check the user's choice with the answer. If correct, add 10 points
		Transform creatureChild =  transform.Find("Panel/Panel/Creature");
		Text creature = creatureChild.GetComponent<Text>();
		if (answer == ScoreManager.manager.choice) {
			ScoreManager.manager.collectableScore += 10;
			creature.text = "10";
		} else {
			creature.text = "0";
		}



		Transform scoreChild =  transform.Find("Panel/Panel/Score");
		Text score = scoreChild.GetComponent<Text>();
		score.text = "" + ScoreManager.manager.collectableScore;




		Transform choiceChild =  transform.Find("Panel/FeedbackPanel/Choice");
		Text choice = choiceChild.GetComponent<Text> ();
		choice.text = "" + ScoreManager.manager.choice;

	}


	public void showFeedback(){
		Transform scorePanelChild =  transform.Find("Panel/Panel");
		scorePanelChild.gameObject.SetActive (false);

		FeedbackPanel.SetActive (true);
	}

	public void showScore(){
		Transform scorePanelChild =  transform.Find("Panel/Panel");
		scorePanelChild.gameObject.SetActive (true);

		FeedbackPanel.SetActive (false);
	}


}
