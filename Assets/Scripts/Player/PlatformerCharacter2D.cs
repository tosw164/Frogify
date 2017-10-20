using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class PlatformerCharacter2D : MonoBehaviour
	{
		[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
		[SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
		[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
		[SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
		[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

		private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
		const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		private bool m_Grounded;            // Whether or not the player is grounded.
		private Transform m_CeilingCheck;   // A position marking where to check for ceilings
		const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
		private Animator m_Anim;            // Reference to the player's animator component.
		private Rigidbody2D m_Rigidbody2D;
		private bool m_FacingRight = true;  // For determining which way the player is currently 

		private bool jump_speedup; //Represents user already sprinting when jumping. Jump movement will be sped up until key up.

		public float movement_multiplier = 2.5f; //Represent speedup when LEFTSHIFT is pressed

		private void Awake()
		{
			// Setting up references.
			m_GroundCheck = transform.Find("GroundCheck");
			m_CeilingCheck = transform.Find("CeilingCheck");
			m_Anim = GetComponent<Animator>();
			m_Rigidbody2D = GetComponent<Rigidbody2D>();

			jump_speedup = false;
		}


		private void FixedUpdate()
		{
			m_Grounded = false;

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			

			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
					m_Grounded = true;
			}
			m_Anim.SetBool("Ground", m_Grounded);
			m_Anim.SetBool ("isJump", !m_Grounded);

		}


		public void Move(float move, bool crouch, bool jump, bool run)
		{
			//If shift was held when jump pressed, should keep momentum
			if (m_Grounded && jump && run){
				jump_speedup = true;
			} else if (m_Grounded && jump_speedup){
				jump_speedup = false;
			}

			//TODO REMOVE BECAUSE DEBUGGING
			if (!m_Grounded && !jump_speedup){
				Debug.Log("jump: " + jump + " run: " + run);
			}

			//only control the player if grounded or airControl is turned on
			if (m_Grounded || m_AirControl)
			{
				
				// Reduce the speed if crouching by the crouchSpeed multiplier
				move = (crouch ? move*m_CrouchSpeed : move);

				m_Anim.SetBool ("isWalking", true);

				// Add run multiplier of LEFTSHIFT held down and change speed accordingly
				float x_velocity = 1.0f;
				if (run == true && m_Grounded == true || jump_speedup){
					x_velocity = movement_multiplier;
				}

				// Move the character
				m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed*x_velocity, m_Rigidbody2D.velocity.y);

				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
			}

			// If the player should jump...
			if (m_Grounded && jump && m_Anim.GetBool("Ground"))
			{
				Debug.Log ("Jump");
				// Add a vertical force to the player.
				m_Grounded = false;
				m_Anim.SetBool ("isWalking", false);
				m_Anim.SetBool("Ground", false);
				m_Anim.SetBool ("isJump", true);
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}

			if (m_Rigidbody2D.velocity.x == 0) {
				m_Anim.SetBool ("isWalking",false);
			}
		}


		private void Flip()
		{
			// Switch the way the player is labelled as facing.
			m_FacingRight = !m_FacingRight;

			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
