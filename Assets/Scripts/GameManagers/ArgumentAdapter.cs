using UnityEngine;
using System.Collections;

public class ArgumentAdapter : MonoBehaviour {

	/**
	 * An adapter for linking Unity to the GameManager singleton. Unity prefabs
	 * can sent arugmentation choices the user makes that should be saved using
	 * the GameManager through this adapter.
	 */
	public void saveArgumentationChoice(string choice) {
		POCC.GameManager.getInstance().saveChoice(choice);
	}
}
