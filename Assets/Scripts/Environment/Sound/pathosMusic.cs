using UnityEngine;
using System.Collections;

public class pathosMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /// if the theme's not playing, play it
        if (!FindObjectOfType<AudioManager>().isPlaying("pathosSpiderMusic"))
        {

            FindObjectOfType<AudioManager>().StopAll();
            FindObjectOfType<AudioManager>().Play("pathosSpiderMusic");
        }

    }
	
	
}
