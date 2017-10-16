using UnityEngine;
using System.Collections;

/**
 * This script is responsible for changing the health on the Pep
 * character when collidng with any general enemy. To utilize this
 * script the enemy MUST have a trigger associated with it.
 * Pep must also have a rigidbody
 */
public class EnemyDamageOnContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	/**
	 * This will trigger when Pep come within the range of the enemy,
	 * it will decrement the health as it is a discrete value on Pep.
	 * DOUBLE CHECK THAT COLLISION2D IS OK.
	 * 
	 * Also should probably have some kind of invulnerability period.
	 * And should make him bounce somewehere.
	 */ 
	void OnTriggerEnter2D(Collider2D pep){ 
		Debug.Log ("Trigger hit");
		if (pep.gameObject.tag == "Player") {
			HealthManager.healthManager.decrementHealth();
			Debug.Log("Took damage");
		}
	}
}
