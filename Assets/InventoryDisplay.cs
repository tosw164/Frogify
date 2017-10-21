using UnityEngine;
using System.Collections;

public class InventoryDisplay : MonoBehaviour {

	public string itemName;
	public Renderer renderers;

	// Use this for initialization
	void Start () {
		renderers = GetComponent<Renderer> ();
		renderers.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(ItemManager.itemManager.itemList.Contains (itemName));
		if (ItemManager.itemManager.itemList.Contains (itemName)) {
			Debug.Log("pickedup");
			renderers.enabled = true;
		}
	}
}
