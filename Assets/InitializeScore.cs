using UnityEngine;
using System.Collections;

public class InitializeScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ScoreManager.manager.setZero ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
