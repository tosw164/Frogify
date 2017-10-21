using System;

namespace POCC
{
	public class EndLevelScene : Scene {
		public EndLevelScene() : base() {
			_sceneType = SceneType.END_LEVEL_SCENE;
			_sceneLocation = "ExitScreen";
		}

		protected void startupHookBase() {
		}

		protected void teardownHookBase() {
			GameManager.getInstance().resetScore();
		}
	}
}
