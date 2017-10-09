using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Initialize the death scene.
//(Just uses the singleton to populate the score)
public class BuildDeathScene : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Transform scoreChild =  transform.Find("Panel/Panel/Score");
		Text score = scoreChild.GetComponent<Text>();
		score.text = "" + ScoreManager.manager.collectableScore;


	}





}
