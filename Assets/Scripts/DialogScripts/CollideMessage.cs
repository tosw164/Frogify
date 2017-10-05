using UnityEngine;
using System.Collections;
using Fungus;
using System.Collections.Generic;

/**
 * This script should be used for all assets that have a dialogue-on-trigger component.
 * Set the repeatable to true if you want the trigger to repeat.
 * 
 * THe script incorporates conditional messages
 * Currently, the different dialogue options are based on the inventory that Pep has.
 * If Pep has no required items, it sends message 0.
 * THe message index is used to call the particular flowchart block required.
 * 
 * You have to populate the required items yourself. 
 * The required items convention is to have a camelCase and is stored in the 
 * singleton GameManager.
 * 
**/
public class CollideMessage : MonoBehaviour {

	public bool isRepeatable = false;
	public Flowchart targetFlowchart;
	//list of things that are needed
	public List<string> needededItems;

	private bool _firstTime=true;
	private List<bool> _firstTimeList = new List<bool>();

//for collision enter actions. COuld be useful in future.
//	void OnCollisionEnter(Collision collision){
//		print ("collided");
//	
//	}

	//When player enters the trigger box, send the flowchartMessage to the target flowchart.
	void OnTriggerEnter2D(Collider2D other){
		_firstTimeList.Add (true);

		int finalMessageIndex=0;//message to send based on the items
		//if the NPC has multiple dialogue scenes, the dialogue scenes are based on what the 
		//character is carrying.
		if (needededItems != null) {
			foreach(string item in needededItems){
				//if item is in the game manager's player inventory, add it to the message
				if (GameManager.gameManager.itemList.Contains(item)){
					finalMessageIndex+=1;
				}
			}
		}

		//intialize the first-time flag list
		for (int i = 0; i < needededItems.Count; i++){
			_firstTimeList.Add (true);
		}

		if (targetFlowchart != null && other.name == "Player" && _firstTimeList[finalMessageIndex]) {

			targetFlowchart.SendFungusMessage (""+finalMessageIndex);
			_firstTimeList [finalMessageIndex] = false;//set the first time to false after first time interacted
		
		}


	}


		
}
