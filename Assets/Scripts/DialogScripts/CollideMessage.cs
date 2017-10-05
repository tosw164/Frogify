using UnityEngine;
using System.Collections;
using Fungus;

/**
 * This script should be used for all assets that have a dialogue-on-interact component.
 * Set the repeatable to true if you want the trigger to repeat.
 * Set the broadcast message to the name of the dialogue fungus box.
 * 
**/
public class CollideMessage : MonoBehaviour {

	public bool isRepeatable = false;
	public string broadcastMessage;

	private bool firstTime=true;

	void OnCollisionEnter(Collision collision){
		print ("collided");
	
	}

	void OnTriggerEnter2D(Collider2D other){
		print ("collided");

		if (other.name == "Player" && firstTime) {
			print ("triggered");
			Flowchart.BroadcastFungusMessage(broadcastMessage);
			if (!isRepeatable) {
				firstTime = false;//disable from repeating
			}
			//disable player movement during the timeframe 

		
		}



	}


		
}
