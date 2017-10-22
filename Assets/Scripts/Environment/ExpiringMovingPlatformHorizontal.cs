using UnityEngine;
using System.Collections;


/**
 * Subclass of the horizontal moving platform, with an additional method that makes the platform destroy itself 
 * after a fixed period of time.
 */
public class ExpiringMovingPlatformHorizontal : MovingPlatformHorizontal {
	public int expiryTime = 2;


	// Use this for initialization
	void Start () {

		Destroy (gameObject, expiryTime);
	}
		

}
