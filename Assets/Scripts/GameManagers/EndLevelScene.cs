using System;

namespace POCC {
	public class EndLevelScene : Scene {
		public EndLevelScene() : base() {
			_sceneType = SceneType.END_LEVEL_SCENE;
			_sceneLocation = "ExitScreen";
			_startupHooks = this.startupHookBase;
			_teardownHooks = this.teardownHookBase;
		}

		protected void startupHookBase() {
			GameManager.getInstance().clearInventory();
		}

		protected void teardownHookBase() {
			GameManager.getInstance().resetScore();
		}
	}
}
