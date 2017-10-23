using UnityEngine;
using System.Collections;

public class logosCave : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("logosMusicHappy");
    }
	
	
}
