using UnityEngine;
using System.Collections;

public class tutorialScaryMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {

        FindObjectOfType<AudioManager>().StopAll();

        FindObjectOfType<AudioManager>().Play("tutorialScary");

    }
	
	
}
