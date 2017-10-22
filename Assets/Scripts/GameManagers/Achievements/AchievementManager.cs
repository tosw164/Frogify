using UnityEngine;
using System.Collections.Generic;
using POCC.Achievements;

/**
 * This class will be responsible for maintaining a list of Achievements and handling
 * any events that further progress towards obtaining an achievement. If an achievement
 * tier has been reached, it will then trigger an event to the GameManager, who will
 * record and display the achievement.
 * 
 * Credits on idea from: http://www.mikeadev.net/2014/05/simple-achievement-system-in-csharp/
 */
namespace POCC.Achievements{
	
	public class AchievementManager {
		private Dictionary<AchievementType, List<Achievement>> _achievementGroups;
		private Dictionary<AchievementType, int> _achivementTypeCount;

		public AchievementManager(){
			_achivementTypeCount = new Dictionary<AchievementType, int> ();

		}

		/**
		 * This method is responsible for populating all the different achievements
		 * that can be obtained in this system.
		 * 
		 * It should really be in a seperate file or Database, but due to time constraints
		 * we just placed it in the code here for now
		 */
		private void addAchivements(){
			/*
			Achievement testAch = new Achievement ();
			testAch._unlockCount = 1;
			testAch._unlocked = false;
			testAch._achievementMessage = "First Level Completed"; 
			Debug.Log("about to convert..");
			string achToJSON = JsonUtility.ToJson(testAch, true);
			Debug.Log(achToJSON);

			Achievement[] levelBasedList = JsonHelper.FromJson<Achievement>("LevelAchievementData.json");
			foreach (Achievement ach in levelBasedList) {
				Debug.Log ("Value for string:" + ach._achievementMessage);
			}
			*/

			//========================================================================
			// Achievements for Levels
			//========================================================================

			List<Achievement> levelBasedAcheivements = new List<Achievement>();
			levelBasedAcheivements.Add (new Achievement(1,false,"First Level Completed"));
			levelBasedAcheivements.Add (new Achievement(2,false,"Second Level Completed"));
			levelBasedAcheivements.Add (new Achievement(3,false,"Last Level Completed"));

			_achievementGroups.Add (AchievementType.LEVEL, levelBasedAcheivements);

			//========================================================================
			// Achievements for NPC Persuasion
			//========================================================================
			List<Achievement> npcPersuasionBasedAcheivements = new List<Achievement>();
			npcPersuasionBasedAcheivements.Add (new Achievement(1,false,"1 NPC Persuaded"));
			npcPersuasionBasedAcheivements.Add (new Achievement(2,false,"2 NPCs Persuaded"));
			npcPersuasionBasedAcheivements.Add (new Achievement(3,false,"3 NPCs Persuaded"));

			_achievementGroups.Add (AchievementType.NPC_PERSUADED, npcPersuasionBasedAcheivements);

			//========================================================================
			// Achievements for Collectables
			//========================================================================
			List<Achievement> collectablesBasedAcheivements = new List<Achievement>();
			collectablesBasedAcheivements.Add (new Achievement(25,false,"25 Collectables Obtained"));
			collectablesBasedAcheivements.Add (new Achievement(50,false,"50 Collectables Obtained"));
			collectablesBasedAcheivements.Add (new Achievement(75,false,"75 Collectables Obtained"));

			_achievementGroups.Add (AchievementType.COLLECTABLES, collectablesBasedAcheivements);

			//========================================================================
			// Achievements for Hidden Items
			//========================================================================
			List<Achievement> hiddenItemsBasedAcheivements = new List<Achievement>();
			hiddenItemsBasedAcheivements.Add (new Achievement(1,false,"1 Hidden Item Found"));
			hiddenItemsBasedAcheivements.Add (new Achievement(2,false,"2 Hidden Items Found"));
			hiddenItemsBasedAcheivements.Add (new Achievement(3,false,"3 Hidden Items Found"));

			_achievementGroups.Add (AchievementType.HIDDEN_ITEMS, hiddenItemsBasedAcheivements);

		}

	}

}