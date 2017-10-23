using UnityEngine;
using System.Collections;

public class tutorialLightMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Stop("waterSound");
        FindObjectOfType<AudioManager>().Stop("mainTheme");

        FindObjectOfType<AudioManager>().Play("tutorialLight");
        
    }
	
	
}
