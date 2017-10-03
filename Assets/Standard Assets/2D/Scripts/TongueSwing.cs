using UnityEngine;
using System.Collections;

public class TongueSwing : MonoBehaviour {

	Vector3 anchor_position;
	SpringJoint2D joint;
	RaycastHit2D raycast_hit;
	public LayerMask layer_mask;
	public float distance = 3f;
	public Transform anchor;

	// Use this for initialization
	void Start () {
		joint = GetComponent<SpringJoint2D>();
		joint.enabled = false;
		anchor_position = anchor.position;

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
//				joint.distance = Vector2.Distance (transform.position, raycast_hit.point);
				joint.distance = distance;
			}
			
		}

		if (Input.GetKeyUp(KeyCode.Space)){
			joint.enabled = false;
		}
	
	}
}
