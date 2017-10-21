using UnityEngine;
using System.Collections;

public class Snek : MonoBehaviour {

	public float endX;
	public float endY;

	public float speed = 1f;

	Vector2 startPosition;
	Vector2 endPosition;


	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		endPosition = new Vector2 (endX, endY);
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.Translate (Vector2.left * step);
	}
}
