using System;

namespace POCC.Achievements
{
	[Serializable]
	public class Achievement
	{
		public Achievement(int unlockCount, bool unlocked, string achievementMessage){
			_unlockCount = unlockCount;
			_unlocked = unlocked;
			_achievementMessage = achievementMessage;
		}

		public int _unlockCount;
		public bool _unlocked;
		public string _achievementMessage;

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

