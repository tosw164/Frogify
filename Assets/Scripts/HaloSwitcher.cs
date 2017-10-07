using UnityEngine;
using System.Collections;

public class HaloSwitcher : MonoBehaviour {

	private Behaviour componentHalo;
	private int i;
	// Use this for initialization
	void Start () {
		i = 0;
		Debug.Log("made i: "+i);
		componentHalo = (Behaviour)GetComponent("Halo");
	}

	void OnTriggerEnter2D(Collider2D collision) 
	{
		i++;
		Debug.Log("ouch"+i);
		componentHalo.enabled = true;
	}

	void OnTriggerExit2D (Collider2D col) 
	{
		componentHalo.enabled = false;
	}

}
