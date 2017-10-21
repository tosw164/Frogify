using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

/**
 * This script is responsible for changing the health on the Pep
 * character when collidng with any general enemy. To utilize this
 * script the enemy MUST have a trigger associated with it.
 * Pep must also have a rigidbody
 */
public class EnemyDamageOnContact : MonoBehaviour {
	//Reference: http://answers.unity3d.com/questions/738991/ontriggerenter-being-called-multiple-times-in-succ.html
	private bool collisionFlag = false;

	/**
	 * This will trigger when Pep come within the range of the enemy,
	 * it will decrement the health as it is a discrete value on Pep.
	 * DOUBLE CHECK THAT COLLISION2D IS OK.
	 * 
	 * Also should probably have some kind of invulnerability period.
	 * And should make him bounce somewehere.
	 */ 
	void OnTriggerEnter2D(Collider2D pep)
	{ 
		Debug.Log ("Trigger hit");
		if (pep.gameObject.tag == "Player") 
		{
			if (!collisionFlag) 
			{
				collisionFlag = true;
				GameManager manager = GameManager.getInstance ();
				manager.decrementHealth ();
				StartCoroutine(Knockback(0.02f, 300, pep.gameObject.transform.position,pep));
			}	
		}
	}

	//Reference: https://www.youtube.com/watch?v=-dMtWZsjX6g
	public IEnumerator Knockback(float knockDur, float kbPower, Vector3 kbDirection, Collider2D pep){
		float timer = 0;
		Rigidbody2D rb2d = pep.GetComponent<Rigidbody2D> ();
		StartCoroutine(disableMovementsForPeriod (0.2f,pep));
		while( knockDur > timer){
			timer += Time.deltaTime;
			rb2d.velocity = new Vector2 (0, 0);
			if (Input.GetAxis("Horizontal") < -0.1f)
			{
				rb2d.AddForce(new Vector3(kbDirection.x * 20, kbDirection.y-kbPower, transform.position.z));
			}
			if (Input.GetAxis("Horizontal") > 0.1f)
			{
				rb2d.AddForce(new Vector3(kbDirection.x * -20, kbDirection.y-kbPower, transform.position.z));
			}
			//rb2d.AddForce(new Vector3(kbDirection.x * -100, kbDirection.y * kbPower, transform.position.z));
		}
		yield return 0;
	}

	public IEnumerator disableMovementsForPeriod(float disableDuration, Collider2D pep){
		Platformer2DUserControl pepController = pep.GetComponent<Platformer2DUserControl> ();
		pepController.disableMovement ();
		yield return new WaitForSeconds (disableDuration);
		pepController.enableMovement ();
		yield return null;
	}

	/**
	 * Method to turn off the collsionFlag AFTER pep leaves the enemy - basically
	 * preventing Pep from being damaged multiple times per collision.
	 * (as the colliders can contain MULTIPLE contact points - box coliders
	 * can contact with 2 faces on each other even if the enemy is static)
	 */
	void OnTriggerExit2D(Collider2D pep){ 
		if (pep.gameObject.tag == "Player") {
			if (collisionFlag) 
			{
				collisionFlag = false;
			}	
		}
	}
}
