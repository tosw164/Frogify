using UnityEngine;
using System.Collections;
using Fungus;

public class CollideMessage : MonoBehaviour {

	public int debug;
	public bool isRepeatable = true;

	void OnCollisionEnter(Collision collision){
		print ("collided");
	
	}

	void OnTriggerEnter2D(Collider2D other){
		print ("collided");

		if (other.name == "Player" && isRepeatable) {
			print ("triggered");
			Flowchart.BroadcastFungusMessage("PINK_COLLIDED");
			debug=2;
			isRepeatable = false;

		
		}

	}
		
}
