using UnityEngine;
using System.Collections;

public class RockCollision : MonoBehaviour {
	public int expiryTime;

	private bool collisionFlag = false;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, expiryTime);

	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.tag == "Player" && !collisionFlag) {
			//Physics2D.IgnoreCollision (collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			collisionFlag = true;
			POCC.GameManager manager = POCC.GameManager.getInstance ();
			manager.decrementHealth ();
		}
	}
}
