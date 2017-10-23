using UnityEngine;
using System.Collections;

public class BearlanaSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /// if the theme's not playing, play it
        if (!FindObjectOfType<AudioManager>().isPlaying("bearlanaTheme"))
        {

            FindObjectOfType<AudioManager>().StopAll();
            FindObjectOfType<AudioManager>().Play("bearlanaTheme");
        }
    }
	
	
}
