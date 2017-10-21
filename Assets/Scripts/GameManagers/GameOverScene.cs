using System;

namespace POCC {
	public class GameOverScene : Scene {
		public GameOverScene() : base() {
			_sceneType = SceneType.GAME_OVER;
			_sceneLocation = "DeathScene";
			_startupHooks = this.startupHookBase;
			_teardownHooks = this.teardownHookBase;
		}

		protected void startupHookBase() {
			GameManager.getInstance().resetHealth();
			GameManager.getInstance().clearInventory();
		}

		protected void teardownHookBase() {
			GameManager.getInstance().resetScore();
		}
	}
}
