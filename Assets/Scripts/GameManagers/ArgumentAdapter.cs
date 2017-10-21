using UnityEngine;
using System.Collections;

public class ArgumentAdapter : MonoBehaviour {

	public void saveArgumentationChoice(string choice) {
		POCC.GameManager.getInstance ().saveChoice (choice);
	}
}
