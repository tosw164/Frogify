using System;

namespace POCC.Scenes {
	public class MainMenuScene : Scene {
		public MainMenuScene() : base() {
			_sceneType = SceneType.MAIN_MENU;
			_sceneLocation = "MainMenu";
			_startupHooks = this.startupHookBase;
			_teardownHooks = this.teardownHookBase;
		}

		protected override void startupHookBase() {
		}

		protected override void teardownHookBase() {
		}
	}
}
