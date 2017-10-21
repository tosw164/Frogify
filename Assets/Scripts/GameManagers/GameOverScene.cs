using System;

namespace POCC
{
	public class GameOverScene : Scene {
		public GameOverScene() : base() {
			_sceneType = SceneType.GAME_OVER;
			_sceneLocation = "DeathScene";
		}

		protected void startupHookBase() {
			GameManager.getInstance().resetHealth();
		}

		protected void teardownHookBase() {
			GameManager.getInstance().resetScore();
		}
	}
}
