using UnityEngine;
using System.Collections;

public class ethos1Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("tutorialScary");
    }
}
