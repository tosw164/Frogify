using System;
using UnityEngine;

//Class that handles the logic for the movement for the character
namespace UnityStandardAssets._2D
{
	public class PlatformerCharacter2D : MonoBehaviour
	{
		[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
		[SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
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
		
		//Values used to fix issue where on next frame after sprintjump, player still grounded so doesn't sprintjump
		private float jump_cooldown; 				//Float of when allow_ground_slowdown is allowed to be flipped
		private float JUMP_COOLDOWN_VALUE = 1.0f;	//Value of "cooldown" representing time boolean can't be flipped after sprintjump
		private bool allow_ground_slowdown; 		//boolean representing if groundcheck can disable sprintjump.

		private float X_VELOCITY_LIMIT = 30f;		//Speed limit for character (left and right) to ensure that physics aren't broken
		private float Y_VELOCITY_LIMIT = 25f;		//Speed limit for character (up and down) to make sure that jumping cannot
													//be broken when spacebar spammed.

		public float movement_multiplier = 2.0f; //Represent speedup when LEFTSHIFT is pressed

		//Initial setting of values for the character
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
			//Set X and Y velocity speed limit if passed.
			if (m_Rigidbody2D.velocity.y > Y_VELOCITY_LIMIT){
				m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, Y_VELOCITY_LIMIT);
			}
			if (m_Rigidbody2D.velocity.x > Y_VELOCITY_LIMIT){
				m_Rigidbody2D.velocity = new Vector2(X_VELOCITY_LIMIT, m_Rigidbody2D.velocity.y);
			}

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

			//Allow boolean to be flipped after cooldown depleted after sprintjumping
			if (jump_speedup && Time.time > jump_cooldown && !allow_ground_slowdown){
				allow_ground_slowdown = true;
			}
		}


		public void Move(float move, bool jump, bool run)
		{
			//If shift was held when jump pressed, should keep momentum
			if (m_Grounded && jump && run){
				jump_speedup = true;

				//Add cooldown and make else if below not triggerable until cooldown depleted
				jump_cooldown = Time.time + JUMP_COOLDOWN_VALUE;
				allow_ground_slowdown = false;

			} else if (m_Grounded && jump_speedup && allow_ground_slowdown){
				//Only set it to false after cooldown after sprintjump if grounded
				jump_speedup = false;
			}

			//When letting go of LEFTSHIFT when speed jumping, make LEFTSHIFT no longer make you go faster
			if (jump_speedup && !run){
				jump_speedup = false;
			}

			//only control the player if grounded or airControl is turned on
			if (m_Grounded || m_AirControl)
			{
				m_Anim.SetBool ("isWalking", true);

				// Add run multiplier of LEFTSHIFT held down and change speed accordingly
				float x_velocity = 1.0f;
				if (run == true && m_Grounded == true || jump_speedup && run){
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
				m_Grounded = false;

				//Set animation values and jumpforce
				m_Anim.SetBool ("isWalking", false);
				m_Anim.SetBool("Ground", false);
				m_Anim.SetBool ("isJump", true);
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}

			if (m_Rigidbody2D.velocity.x == 0) {
				m_Anim.SetBool ("isWalking",false);
			}
		}

		//Method that flips player sprite depending on which way they ar facing
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
