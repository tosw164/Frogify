using UnityEngine;
using System.Collections;

public class BounceMushroomScript : MonoBehaviour {

	bool onTop;
	GameObject Player;
	Rigidbody2D rigi2d;
	public Vector2 velocity;
	public Animator anim;
	public bool collided;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (collided && Input.GetKeyDown ("space")) {
			anim.SetBool ("IsReleased",true);
			Player.GetComponent<Rigidbody2D>().velocity = velocity;
			anim.SetBool ("IsOnTop",false);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Pep" ) {
			anim.SetBool ("IsReleased",false);
			anim.SetBool ("IsOnTop",true);
			collided = true;
			Player = other.gameObject;
		}
	}
		

}
