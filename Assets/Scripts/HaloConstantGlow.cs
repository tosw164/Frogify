using UnityEngine;
using System.Collections;

public class HaloConstantGlow : MonoBehaviour {
	private Behaviour componentHalo;

	// Use this for initialization
	void Start () {
		componentHalo = (Behaviour)GetComponent("Halo");
	}

	void Update () {
		if (CollisionFlag.isAttached == true) {
			componentHalo.enabled = true;
		} else {
			componentHalo.enabled = false;
		}
	}
		
}
