using UnityEngine;
using System.Collections;

/**
 * Item class for item-collidable objects.
 * Note this is distinct from the score items.
 *
 * Consists of a basic OnTrigger collide event, where, when collided,
 * will add the item's name onto the inventory manager singleton class.
 *
**/
public class Item : MonoBehaviour {
	public string itemName;



	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
            
            this.gameObject.SetActive(false);
			POCC.GameManager.getInstance().addPlayerItem(itemName);//add to player's inventory
            FindObjectOfType<AudioManager>().Play("collectItem");
        }

	}
}
