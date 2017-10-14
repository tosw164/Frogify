﻿using UnityEngine;
using System.Collections;

/**
 * Created using tutorial found at: https://www.youtube.com/watch?v=sHhzWlrTgJo
 * 
 */
public class TongueSwing : MonoBehaviour {

	Vector3 anchor_position;
	SpringJoint2D joint;
	RaycastHit2D raycast_hit;
	public LayerMask layer_mask;
	public float distance = 3f;
	public Transform anchor;
	public LineRenderer rope;

	// Use this for initialization
	void Start () {
		joint = GetComponent<SpringJoint2D>();
		joint.enabled = false;
		anchor_position = anchor.position;

		rope.enabled = false;

		Debug.Log (anchor_position);

	}

	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown(KeyCode.Space)){
			anchor_position = anchor.position;

			raycast_hit = Physics2D.Raycast (transform.position, 
				anchor_position - transform.position,
				distance,
				layer_mask);
			Debug.Log (raycast_hit.collider != null);
			Debug.Log (transform.position + " " + anchor_position + " " + (raycast_hit.collider != null));

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

		if (Input.GetKey(KeyCode.Space) && rope.enabled == true){
			rope.SetPosition (0, transform.position);
		}

		if (Input.GetKeyUp(KeyCode.Space)){
			joint.enabled = false;
			rope.enabled = false;
		}
	
	}
}