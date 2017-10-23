using UnityEngine;
using System.Collections;

public class HaloSwitcher : MonoBehaviour {

	public SpriteRenderer halo;
	private bool outside_region;

	// Use this for initialization
	void Start () {
		outside_region = false;
	}

	void OnTriggerEnter2D(Collider2D collision) 
	{
		if(collision.tag == "Player"){
			halo.enabled = true;
			outside_region = false;

		}
	}

	void OnTriggerExit2D (Collider2D collision) 
	{
		if(collision.tag == "Player"){
			halo.enabled = false;
			outside_region = true;
		}
	}

	void Update (){
		if (outside_region) {
			if (CollisionFlag.isAttached) {
				halo.enabled = true;
			} else {
				outside_region = false;
				halo.enabled = false;
			}
		}
	}

}
