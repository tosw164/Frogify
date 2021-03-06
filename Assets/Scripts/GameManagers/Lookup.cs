﻿using System;
using POCC.Scenes;

namespace POCC
{
	/**
	 * This class will simply provide a means of looking
	 * up values in the game.
	 */
	public class Lookup
	{

		public static Scene sceneLookup(SceneType sceneType) {
			SceneBuilder builder = new SceneBuilder(sceneType);

			switch(sceneType) {
				case SceneType.GAME_OVER:
					return new SceneBuilder(new GameOverScene()).build();
				case SceneType.BEARLANA:
					return new SceneBuilder(new PrototypeLevelScene()).build();
				case SceneType.END_LEVEL_SCENE:
					return new SceneBuilder(new EndLevelScene()).build();
				case SceneType.TUTORIAL_1:
					return builder.setLocation ("TutorialLevel").build();
				case SceneType.TUTORIAL_2:
					return builder.setLocation ("TutorialLevelRunAway").build();
				case SceneType.HUB_1:
					return builder.setLocation ("Hub0").build();
				case SceneType.LOGOS_1:
					return builder.setLocation ("LogosLevel1").build();
				case SceneType.LOGOS_2:
					return builder.setLocation ("LogosLevel2").build();
				case SceneType.HUB_2:
					return builder.setLocation ("Hub1").build();
				case SceneType.PATHOS_1:
					return builder.setLocation ("PathosLevelSpider").build();
				case SceneType.PATHOS_2:
					return builder.setLocation ("PathosLevelSpiderFollow").build();
				case SceneType.HUB_3:
					return builder.setLocation ("Hub2").build();
				case SceneType.ETHOS_1:
					return builder.setLocation ("EthosScene").build();
				case SceneType.ETHOS_2:
					return builder.setLocation ("EthosScene1").build();
				case SceneType.HUB_4:
					return builder.setLocation ("Hub3").build();
				case SceneType.EXIT_1:
					return builder.setLocation ("BearlanaExit").resetScoreOnLeave().build();
				case SceneType.EXIT_2:
					return builder.setLocation ("BeeliExit").resetScoreOnLeave().build();
				case SceneType.EXIT_3:
					return builder.setLocation ("SnakeyeongExit").resetScoreOnLeave().build();
				case SceneType.END_OF_YEAR:
				default:
					// Unimplemented scene, map does not exist
				case SceneType.MAIN_MENU:
					return new SceneBuilder(new MainMenuScene()).build();
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
