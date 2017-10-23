using UnityEngine;
using System.Collections;

/**
 * Created using tutorial found at: https://www.youtube.com/watch?v=sHhzWlrTgJo
 * 
 */
public class TongueSwing : MonoBehaviour {

	Vector3 anchor_position; 		//Position of the anchor of the swing
	SpringJoint2D joint;			//Joint constraining player and swing
	RaycastHit2D raycast_hit;		//Variable representing the collision of raycast between anchor and player
	public LayerMask layer_mask;	//Layer pertaining to swing ranges
	public float distance = 3f;		//Distance of the joint
	public Transform anchor;		//XY position of the anchor
	public LineRenderer rope;		//Rope to render line

	// Initialisation of the class, components and first values.
	void Start () {
		joint = GetComponent<SpringJoint2D>();
		joint.enabled = false;
		anchor_position = anchor.position;

		rope.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		//If in range then SPACE will make hte rope
		if (Input.GetKeyDown(KeyCode.Space)){
			anchor_position = anchor.position;

			//Do raycast and get collision values
			raycast_hit = Physics2D.Raycast (transform.position, 
				anchor_position - transform.position,
				distance,
				layer_mask);

			//If valid collison then create the joint and rope
			if (raycast_hit.collider != null 
				&& raycast_hit.collider.gameObject.GetComponent<Rigidbody2D>() != null){
				joint.enabled = true;
				joint.connectedBody = raycast_hit.collider.gameObject.GetComponent<Rigidbody2D> ();
				joint.distance = distance;

				rope.enabled = true;
				rope.SetPosition (0, transform.position);
				rope.SetPosition (1, raycast_hit.point);
			}
			
		}

		//Update rope position of extended per frame
		if (Input.GetKey(KeyCode.Space) && rope.enabled == true){
			rope.SetPosition (0, transform.position);
		}

		//Disable rope when key up
		if (Input.GetKeyUp(KeyCode.Space)){
			joint.enabled = false;
			rope.enabled = false;
		}
	
	}
}
