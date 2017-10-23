using UnityEngine;
using System.Collections;

/*
 * Original Needle script, for basic implementation of the needle shooter. 
 * Has a set distance it travels, with a set movement speed, before destroying itself.
 */
public class Needle : MonoBehaviour {

	public Transform transform;
	//Set max x distance before destroying itself
	public float limit_x;

	//Movement speed of the needle
	public float movement_speed;

	//Determines which way it shoots
	public bool directionLeft;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	// Checks if it has reached the limit, and destroys if it has
	// If it hasn't, translates the object, taking in the delta time and the movement speed
	void Update () {
		if (directionLeft == false) {
			if (transform.position.x > limit_x) {
				Destroy (this.gameObject);
			} else {
				transform.Translate (Vector2.right * (movement_speed) * Time.deltaTime);
			}
		} else {
			if (transform.position.x < limit_x) {
				Destroy (this.gameObject);
			} else {
				transform.Translate (Vector2.left * (movement_speed) * Time.deltaTime);
			}
		}
			
	}
}
