using System;

namespace POCC {
	public class PrototypeLevelScene : Scene {
		public PrototypeLevelScene() : base() {
			_sceneType = SceneType.BEARLANA;
			_sceneLocation = "PrototypeLevel";
		}

		protected override void startupHookBase() {
		}

		protected override void teardownHookBase() {
		}
	}
}
