using UnityEngine;
using System.Collections;

// Obtained from http://answers.unity3d.com/questions/878913/how-to-get-camera-to-follow-player-2d.html

public class CamFollow : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x, player.position.y, -6);
	}
}
