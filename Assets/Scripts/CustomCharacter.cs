using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class CustomCharacter : MonoBehaviour
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
		private bool m_FacingRight = true;  // For determining which way the player is currently facing.

		private void Awake()
		{
			// Setting up references.
			m_GroundCheck = transform.Find("GroundCheck");
			m_CeilingCheck = transform.Find("CeilingCheck");
			m_Anim = GetComponent<Animator>();
			m_Rigidbody2D = GetComponent<Rigidbody2D>();
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

			// Set the vertical animation
			m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
		}


		public void Move(float move, bool crouch, bool jump)
		{

			if (m_Grounded || m_AirControl)
			{
				// Reduce the speed if crouching by the crouchSpeed multiplier
				move = (crouch ? move*m_CrouchSpeed : move);

				m_Anim.SetBool ("isWalking",true);
				// Move the character
				m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

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
			if (Input.GetKeyDown ("space") && m_Anim.GetBool ("Ground")) {
				m_Anim.SetBool ("isWalking",false);
				m_Anim.SetBool("Ground", false);
				m_Anim.SetBool ("isJump",true);
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}

			if (m_Rigidbody2D.velocity.x == 0) {
				m_Anim.SetBool ("isWalking",false);
			}

		}

		void OnCollisionEnter2D(Collision2D col) {
			if (col.gameObject.name == "Ground" || col.gameObject.name == "mushroomB3") {
				m_Anim.SetBool ("isJump",false);
				m_Anim.SetBool ("Ground", true);
				m_Anim.SetBool ("isBlinked",false);
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


