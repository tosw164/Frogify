using UnityEngine;
using System.Collections;

public class Snek : MonoBehaviour {

	public bool isLeft = true;
	public float deltaX = 20f;

	public float speed = 1f;

	private float origX;

	// Use this for initialization
	void Start () {
		origX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (isLeft) {
			transform.Translate (Vector2.left * step);
			if (transform.position.x < (origX - deltaX)) {
				Destroy (this.gameObject);
			}
		} else {
			transform.Translate (Vector2.right * step);
			if (transform.position.x > (deltaX + origX)) {
				Destroy (this.gameObject);
			}
		}
	}
}
