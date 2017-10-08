using UnityEngine;
using System.Collections;

public class SecretEntranceActivator : MonoBehaviour {

	public GameObject entrance;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			Destroy(entrance);
			Destroy(gameObject);
		}
	}
}
