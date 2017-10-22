using System;

namespace POCC {
	public class GameOverScene : Scene {
		public GameOverScene() : base() {
			_sceneType = SceneType.GAME_OVER;
			_sceneLocation = "DeathScene";
			_startupHooks = this.startupHookBase;
			_teardownHooks = this.teardownHookBase;
		}

		protected override void startupHookBase() {
			GameManager.getInstance().resetHealth();
			GameManager.getInstance().clearInventory();
		}

		protected override void teardownHookBase() {
			GameManager.getInstance().resetScore();
		}
	}
}
