using UnityEngine;
using System.Collections;

public class logosMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("pathosMusic");
    }
	
	
}
