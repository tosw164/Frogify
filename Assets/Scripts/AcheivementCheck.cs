using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using POCC;

/**
 * Use this script for controlling whether achievements area acheived.
 * */
public class AcheivementCheck : MonoBehaviour {

	public string acheivementname;
	private Image background;

	// Use this for initialization
	void Start () {
		//Initialise the box
		background = (Image)gameObject.transform.GetChild(0).GetComponent<Image>();
		//If the achievement is done, then set it as visible, if it is set it as false
		if (POCC.GameManager.getInstance ().getAchievements ().Contains (acheivementname)) {
			background.enabled = true;
		} else {
			background.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Initialise the box
		background = (Image)gameObject.transform.GetChild(0).GetComponent<Image>();
		//If the achievement is done, then set it as visible, if it is set it as false
		if (POCC.GameManager.getInstance ().getAchievements ().Contains (acheivementname)) {
			background.enabled = true;
		} else {
			background.enabled = false;
		}
	}
}
