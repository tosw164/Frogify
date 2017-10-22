using UnityEngine;
using System.Collections;

public class InventoryDisplay : MonoBehaviour {

	public string itemName;
	public Renderer renderers;

	// Use this for initialization
	void Start () {
		//Initialise the component.
		renderers = GetComponent<Renderer> ();
		//Disable the renderer so it is not visible.
		renderers.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		/**
		 * Checks if the item has been picked up, if so the render the item.
		 * */
		if (POCC.GameManager.getInstance().playerHasItem(itemName)) {
			renderers.enabled = true;
		}
	}
}
