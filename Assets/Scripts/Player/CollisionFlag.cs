using UnityEngine;
using System.Collections;

public class CollisionFlag : MonoBehaviour {

	//Set up variable to store joint
	SpringJoint2D joint;

	public float distance = 3f;			//Distance that player needs to be from centre of the circle to latch
	public LineRenderer rope;			//Visible line of rope generated

	public static bool isAttached;		//Boolean publicly visible used by other scripts to see if player latched

	void Start(){
		//Disable rope and joint, instantiate joint
		joint = GetComponent<SpringJoint2D> ();
		joint.enabled = false;
		rope.enabled = false;
		isAttached = false;
	}

	//Trigger on every frame when user in range of a swingrange
	void OnTriggerStay2D(Collider2D other)
	{
		//Make sure the other item has tag SwingRange
		if (other.tag == "SwingRange"){

			//Creates the connection if space pressed when in range
			if (Input.GetKeyDown(KeyCode.Space)){

				//Enables the joint to the other component
				joint.enabled = true;
				joint.connectedBody = other.GetComponent<Rigidbody2D>();
				joint.distance = distance;

                //Play the relevant sound
                
                FindObjectOfType<AudioManager>().Play("tongueSwing");

                //Enable the rope (visible part of swing)
                //Attaches it to player and swingrange
                rope.enabled = true;
				rope.SetPosition (0, transform.position);
				rope.SetPosition (1, other.transform.position);
				isAttached = true;
			}
		}
	}

	//Called once per frame to either enable or allow disabling of the rope
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
