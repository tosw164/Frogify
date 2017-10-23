using UnityEngine;
using System.Collections;

public class logosCave : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!FindObjectOfType<AudioManager>().isPlaying("pathosMusic"))
        {

            FindObjectOfType<AudioManager>().StopAll();
            FindObjectOfType<AudioManager>().Play("pathosMusic");
        }
    }
	
	
}
