using UnityEngine;
using System.Collections;

public class hubMusicScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /// if the theme's not playing, play it
        if (!FindObjectOfType<AudioManager>().isPlaying("hubMainTheme")) {

            FindObjectOfType<AudioManager>().StopAll();
            FindObjectOfType<AudioManager>().Play("hubMainTheme");
        }
	}
}
