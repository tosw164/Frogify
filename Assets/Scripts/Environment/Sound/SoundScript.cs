using UnityEngine;
using System.Collections;

/// <summary>
/// main menu sound
/// </summary>
public class SoundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        FindObjectOfType<AudioManager>().StopAll();

        FindObjectOfType<AudioManager>().Play("waterSound");
        FindObjectOfType<AudioManager>().Play("mainTheme");
    }
	
	
}
