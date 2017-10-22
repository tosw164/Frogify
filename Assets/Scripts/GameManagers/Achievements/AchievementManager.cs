﻿using UnityEngine;
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

			_achivementTypeCount.Add (AchievementType.LEVEL, 0);
			_achivementTypeCount.Add (AchievementType.NPC_PERSUADED, 0);
			_achivementTypeCount.Add (AchievementType.COLLECTABLES, 0);
			_achivementTypeCount.Add (AchievementType.HIDDEN_ITEMS, 0);

			_achievementGroups = new Dictionary<AchievementType, List<Achievement>> ();
			addAchivements ();

		}

		/**
		 * This is for handling whenever an action that can correspond to an 
		 * achievement is triggered. It will be called on this object and then it
		 * will increment the field holding the counts for each of the achievement categories
		 */ 
		public void RegisterAchievementEvent(AchievementType achType){
			//Do a check to make sure the type is actually in the dictionary
			//just as a precaution.
			switch(achType){
			case AchievementType.LEVEL:
				_achivementTypeCount[achType]++;
				break;
			case AchievementType.NPC_PERSUADED:
				_achivementTypeCount[achType]++;
				break;
			case AchievementType.COLLECTABLES:
				_achivementTypeCount[achType]++;
				break;
			case AchievementType.HIDDEN_ITEMS:
				_achivementTypeCount[achType]++;
				break;
			}

			ParseAchievements(achType);
		}

		/**
		 * This method is called after each change to one of the achievement groups, it will
		 * check if any new achievements ahve been achieved after a value has been changed. It
		 * will only check for the achievements if it hasn't been achieved.
		 * 
		 * After the achievement is unlocked then it will call the relevant method to pass in the
		 * achievement that was achieved
		 */
		public void ParseAchievements(AchievementType achType){
			List<Achievement> achievementList = _achievementGroups [achType];
			foreach(var currentAchievement in achievementList){
				if (currentAchievement._unlocked == false) {
					if( achType == AchievementType.COLLECTABLES ) {
						if (_achivementTypeCount[achType] >= currentAchievement._unlockCount) {
							GameManager.getInstance ().handleAchievement (currentAchievement);
						}
					}
					else if(_achivementTypeCount[achType] >= currentAchievement._unlockCount ){
						GameManager.getInstance ().handleAchievement (currentAchievement);
					}
				}
			}
		}


		/**
		 * This method is responsible for populating all the different achievements
		 * that can be obtained in this system.
		 * 
		 * It should really be in a seperate file or Database, but due to time constraints
		 * we just placed it in the code here for now
		 */
		private void addAchivements(){

			//========================================================================
			// Achievements for Levels
			//========================================================================

			List<Achievement> levelBasedAcheivements = new List<Achievement>();
			levelBasedAcheivements.Add (new Achievement(1,false,"First Level Completed"));
			levelBasedAcheivements.Add (new Achievement(2,false,"Second Level Completed"));
			levelBasedAcheivements.Add (new Achievement(3,false,"Last Level Completed"));

			_achievementGroups.Add (AchievementType.LEVEL, levelBasedAcheivements);


			//Testing for when want to switch to JSON

			//Achievement[] testArray = levelBasedAcheivements.ToArray();
			//string achToJSON = JsonHelper.ToJson<Achievement>(testArray, true);
			//Debug.Log(achToJSON);
			//Achievement[] levelBasedList = JsonHelper.FromJson<Achievement>("LevelAchievementData.json");
			//Debug.Log(levelBasedList[0]._achievementMessage);
			//Debug.Log(levelBasedList[1]._achievementMessage);


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
			collectablesBasedAcheivements.Add (new Achievement(10,false,"10 Collectables Obtained"));
			collectablesBasedAcheivements.Add (new Achievement(20,false,"20 Collectables Obtained"));
			collectablesBasedAcheivements.Add (new Achievement(30,false,"30 Collectables Obtained"));

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