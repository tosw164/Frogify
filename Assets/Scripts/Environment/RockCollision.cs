using UnityEngine;
using System.Collections;

public class RockCollision : MonoBehaviour {
	public int expiryTime;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, expiryTime);

	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		

		if (collision.gameObject.tag == "Player") {
			Debug.Log ("HI");
			Physics2D.IgnoreCollision (collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}
}
