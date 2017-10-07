using UnityEngine;
using System.Collections;

public class HaloSwitcher : MonoBehaviour {

	private Behaviour componentHalo;
	private bool outsideRegion;
	// Use this for initialization
	void Start () {
		outsideRegion = true;
		componentHalo = (Behaviour)GetComponent("Halo");

	}

	void OnTriggerEnter2D(Collider2D collision) 
	{
		componentHalo.enabled = true;
		outsideRegion = false;
	}

	void OnTriggerExit2D (Collider2D col) 
	{
		outsideRegion = true;
		componentHalo.enabled = false;
	}

	void Update (){
		if (outsideRegion) {
			if (CollisionFlag.isAttached) {
				componentHalo.enabled = true;
			} else {
				outsideRegion = false;
				componentHalo.enabled = false;
			}
		}
	}

}
