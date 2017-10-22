using UnityEngine;
using System.Collections;

public class InitializeScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		POCC.GameManager.getInstance().resetScore();
	}

	// Update is called once per frame
	void Update () {

	}
}
