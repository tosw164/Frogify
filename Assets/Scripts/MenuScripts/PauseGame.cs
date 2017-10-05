using UnityEngine;
using System.Collections;

/**
 * Used for pausing the game.
 * Called when the pause menu (esc key) is pressed.
 * 
**/
public class PauseGame : MonoBehaviour {
	public Transform canvas;

	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){

			Pause ();

		}
	}

	public void Pause(){
		//canvas is not open
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);

			//pause the game
			Time.timeScale = 0;//time scale is usually set to 1 (you can increase to make time faster)
		} else {//escape key pressed during pause menu is open
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;

		}
	}
}
