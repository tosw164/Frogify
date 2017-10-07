using UnityEngine;
using System.Collections;

public class CollisionFlag : MonoBehaviour {

	//Set up variable to store joint
	SpringJoint2D joint;
	bool swinging = false;

	public LayerMask swingable_layer;
	public float distance = 3f;
	public LineRenderer rope;

	public static bool isAttached;

	void Start(){
		//Disable rope and joint, instantiate joint
		joint = GetComponent<SpringJoint2D> ();
		joint.enabled = false;
		rope.enabled = false;
		isAttached = false;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "SwingRange"){
			Debug.Log ("yay" + other.transform.position);

			if (Input.GetKeyDown(KeyCode.Space)){
				joint.enabled = true;
				joint.connectedBody = other.GetComponent<Rigidbody2D>();
				joint.distance = distance;

				rope.enabled = true;
				rope.SetPosition (0, transform.position);
				rope.SetPosition (1, other.transform.position);
				isAttached = true;
			}
		}
	}


	void Update(){
		if (Input.GetKeyUp(KeyCode.Space) && rope.enabled == true){
			joint.enabled = false;
			rope.enabled = false;
			isAttached = false;
		}

		if (Input.GetKey(KeyCode.Space) && rope.enabled == true){
			rope.SetPosition (0, transform.position);
		}
	}
}
