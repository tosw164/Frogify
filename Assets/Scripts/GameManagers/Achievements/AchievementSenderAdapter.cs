using UnityEngine;
using System.Collections;
using POCC;
using POCC.Achievements;
using UnityStandardAssets._2D;

/**
 * Adapter class for sending achievement events from end of levels/fungus 
 */ 
public class AchievementSenderAdapter : MonoBehaviour {

	/**
	 * This method takes an int input, and then translates it to the corresponding
	 * achievement type. Refer to POCC.Achievements.AchievementType for the 
	 * mappings of int to types.
	 */
	public void sendAchievement(int achievementCode) {
		AchievementType achType = (AchievementType)achievementCode;
		GameManager.getInstance().sendAchievementEvent(achType);
	}
}
