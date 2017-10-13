using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {


	public Transform transform;
	public float limit_x;
	public float movement_speed;
	public bool directionLeft;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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
