using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using POCC;

public class AcheivementCheck : MonoBehaviour {

	public string acheivementname;
	private Image background;

	// Use this for initialization
	void Start () {
		background = (Image)gameObject.transform.GetChild(0).GetComponent<Image>();
		if (POCC.GameManager.getInstance ().getAchievements ().Contains (acheivementname)) {
			background.enabled = true;
		} else {
			background.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		background = (Image)gameObject.transform.GetChild(0).GetComponent<Image>();
		if (POCC.GameManager.getInstance ().getAchievements ().Contains (acheivementname)) {
			background.enabled = true;
		} else {
			background.enabled = false;
		}
	}
}
