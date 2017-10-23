using UnityEngine;
using System.Collections;

/**
 * This script is for controling health UI
 * */
public class HealthScript : MonoBehaviour {

	public int health;
	public Renderer renderers;

	// Use this for initialization, initialise the renderer of the hearts
	void Start () {
		renderers = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if the current health is less than what the heart should be displaying, hide it, if it is equal show it
		if (POCC.GameManager.getInstance ().getHealth () < health) {
			renderers.enabled = false;
		} else if (POCC.GameManager.getInstance ().getHealth () == health) {
			renderers.enabled = true;
		}
	}
}
