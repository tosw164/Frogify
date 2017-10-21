using System;

namespace POCC
{
	public class MainMenuScene : Scene
	{
		public MainMenuScene() : base() {
			_sceneType = SceneType.MAIN_MENU;
			_sceneLocation = "MainMenu";
		}

		protected void startupHookBase() {
		}

		protected void teardownHookBase() {
		}
	}
}

