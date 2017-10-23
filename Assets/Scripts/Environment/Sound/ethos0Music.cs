using UnityEngine;
using System.Collections;

public class ethos0Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("ethosCave");
    }
}
