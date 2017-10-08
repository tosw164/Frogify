using UnityEngine;
using System.Collections;

public class LevelCompleteMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setActive(string bleh){
		Debug.Log ("hi");
		this.gameObject.SetActive (false);
	}
}
