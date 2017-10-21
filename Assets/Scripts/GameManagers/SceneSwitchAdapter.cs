using UnityEngine;
using System.Collections;
using POCC;

public class SceneSwitchAdapter : MonoBehaviour {
	public void switchTo(int sceneCode) {
		SceneType sceneType = (SceneType)sceneCode;
		Scene scene = Lookup.sceneLookup(sceneType);
		GameManager.getInstance().switchScene(scene);
	}
}
