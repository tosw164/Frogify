using UnityEngine;
using System.Collections;
using POCC;
using POCC.Scenes;
using UnityStandardAssets._2D;

public class SceneSwitchAdapter : MonoBehaviour {
	public void switchTo(int sceneCode) {
		SceneType sceneType = (SceneType)sceneCode;
		Scene scene = Lookup.sceneLookup(sceneType);
		GameManager.getInstance().switchScene(scene);


		Platformer2DUserControl pepController = GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer2DUserControl> ();
		pepController.enableMovement ();
	}
}
