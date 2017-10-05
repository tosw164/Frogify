using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/**
 * Script for controlling keyboard interactions with the menu
 *
**/

public class SelectOnInput : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedObject;

	private bool buttonSelected;//whether we have made seleciton

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//see movement detected on vertical axis (i.e. up down keys)
		if(Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false){
			eventSystem.SetSelectedGameObject (selectedObject);//vcauses evengt system to select one of our buttons

			buttonSelected = true;
		}
	}

	//basically fired when the game object is deactivated i.e. opposite of setActive
	//when gameo bject is deactivated
	private void OnDisable(){
		buttonSelected = false;
	
	}
}
