using UnityEngine;
using System.Collections;

/**
 * This script is responsible for changing the health on the Pep
 * character when collidng with any general enemy. To utilize this
 * script the enemy MUST have a trigger associated with it.
 * Pep must also have a rigidbody
 */
public class EnemyDamangeOnContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	/**
	 * This will trigger when Pep come within the range of the enemy,
	 * it will decrement the health as it is a discrete value on Pep.
	 */ 
	void OnTriggerEnter(Collider pep){
		pep.gameObject.GetComponent<HealthManager> ().decrementHealth();
	}
}
