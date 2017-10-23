using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int health;
	public Renderer renderers;

	// Use this for initialization
	void Start () {
		renderers = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (POCC.GameManager.getInstance ().getHealth () < health) {
			renderers.enabled = false;
		} else if (POCC.GameManager.getInstance ().getHealth () == health) {
			renderers.enabled = true;
		}
	}
}
