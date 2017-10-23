using System;

namespace POCC.Achievements
{
	/**
	 * This class represents a simple Achievement that can be stored.
	 * It holds the unlock count (number of events needed to unlock), a 
	 * boolean representing whether the achievement is unlocked or not, 
	 * and a string that provides a message describing what the achievement is.
	 */ 
	[Serializable]
	public class Achievement
	{
		public Achievement(int unlockCount, bool unlocked, string achievementMessage){
			_unlockCount = unlockCount;
			_unlocked = unlocked;
			_achievementMessage = achievementMessage;
		}

		//Public fields just for conviennce
		public int _unlockCount;
		public bool _unlocked;
		public string _achievementMessage;

		//Getters

		public int getUnlockCount(){
			return _unlockCount;
		}
			
		public bool getUnlockedBoolean(){
			return _unlocked;
		}

		public string getAchievementMessage(){
			return _achievementMessage;
		}
	};
}

