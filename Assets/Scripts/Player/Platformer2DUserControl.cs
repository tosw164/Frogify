using System;
using UnityEngine;

//Based off the script from the Unity Standard Assets package
namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class Platformer2DUserControl : MonoBehaviour
	{
		public bool isMovable=true;

		private PlatformerCharacter2D m_Character;  //Character script
		private bool m_Jump;						//Jump boolean

		//Initialise character
		private void Awake()
		{
			m_Character = GetComponent<PlatformerCharacter2D>();
		}


		private void Update()
		{
			if (!m_Jump)
			{
				// Read the jump input in Update so button presses aren't missed.
				m_Jump = Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.W);
			}
		}


		//Method called multiple times a second that handles pasisng of keypresses into Move() function
		private void FixedUpdate()
		{
			//check if movable
			if (isMovable) {
				// Read the inputs.
				bool run = Input.GetKey (KeyCode.LeftShift);
				float h = Input.GetAxis("Horizontal");

				// Pass all parameters to the character control script.
				m_Character.Move(h, m_Jump, run);
				m_Jump = false;
			}

		}

		/**
		 * Used by dialogue system to disable movement during dialogue scenes.
		 * 
		**/
		public void disableMovement(){
			//set the current character movement to be stationery
			m_Character.Move(0, m_Jump, false);
			isMovable = false;
		}

		public void enableMovement(){
			isMovable = true;

		}
	}
}
