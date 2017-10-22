using System;

namespace POCC.Achievements
{
	[Serializable]
	public struct Achievement
	{
		public Achievement(int unlockCount, bool unlocked, string achievementMessage){
			_unlockCount = unlockCount;
			_unlocked = unlocked;
			_achievementMessage = achievementMessage;
		}

		public int _unlockCount;
		public bool _unlocked;
		public string _achievementMessage;
	};
}

