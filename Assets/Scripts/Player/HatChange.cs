using UnityEngine;
using System.Collections;

public class HatChange : MonoBehaviour {

	private SpriteRenderer renderer;
	public Sprite[] hats;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1)){
			renderer.sprite = hats [0];
		} else if (Input.GetKeyDown(KeyCode.Alpha2)){
			renderer.sprite = hats [1];
		}
	
	}
}
