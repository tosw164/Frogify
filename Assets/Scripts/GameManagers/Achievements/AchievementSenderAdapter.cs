using UnityEngine;
using System.Collections;
using POCC;
using POCC.Achievements;
using UnityStandardAssets._2D;

public class AchievementSenderAdapter : MonoBehaviour {
	
	public void sendAchievement(int achievementCode) {
		AchievementType achType = (AchievementType)achievementCode;
		GameManager.getInstance().getAchievements(achType);
	}
}
