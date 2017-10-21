using System;

namespace POCC
{
	/**
	 * This class will simply provide a means of looking
	 * up values in the game.
	 */
	public class Lookup
	{

		public static string sceneLookup(SceneType sceneType) {
			switch(sceneType) {
				case SceneType.GAME_OVER:
					return "DeathScene";
				case SceneType.END_LEVEL_SCENE:
					return "ExitScreen";
				case SceneType.TUTORIAL_1:
				case SceneType.TUTORIAL_2:
				case SceneType.HUB_1:
				case SceneType.LOGOS:
				case SceneType.HUB_2:
				case SceneType.BEARLANA:
				case SceneType.PATHOS_1:
				case SceneType.HUB_3:
				case SceneType.ETHOS_1:
				case SceneType.ETHOS_2:
				case SceneType.HUB_4:
				case SceneType.END_OF_YEAR:
				default:
					// Unimplemented scene, map does not exist
				case SceneType.MAIN_MENU:
					return "MainMenu";
			}
		}

		public static long collectableScoreLookup(Collectable collectable) {
			switch(collectable) {
				default:
					// Unmapped enum value
				case Collectable.GOLDFLY:
					return 1;
			}
		}

		public static long argumentationScoreLookup(ArgumentationValue argueValue) {
			switch(argueValue) {
				default:
					// Unmapped enum value
				case ArgumentationValue.FIRST_ATTEMPT:
					return 10;
			}
		}
	}
}
