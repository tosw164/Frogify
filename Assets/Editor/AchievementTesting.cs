using UnityEngine;
using UnityEditor;
using NUnit.Framework;

/**
 * Testing framework for checking that the achievements are working correctly.
 */ 
public class AchievementTesting {

	/**
	 * Testing that collectable achievements will be unlocked correctly.
	 * THis is achieved via incrementing colletable scores.
	 */
	[Test]
	public void ScoreTesting()
	{
		POCC.GameManager manager = POCC.GameManager.getInstance ();
		manager.destroyTest ();
		manager = POCC.GameManager.getInstance ();
		Assert.AreEqual(0, manager.getAchievements().Count);

		for (int i = 0; i < 10; i++) {
			manager.incrementCollectableScore (POCC.Collectable.GOLDFLY);
		}
		Debug.Log (manager.getAchievements ());
		Assert.AreEqual(1, manager.getAchievements().Count);

		for (int i = 0; i < 9; i++) {
			manager.incrementCollectableScore (POCC.Collectable.GOLDFLY);
		}
		Debug.Log (manager.getAchievements ());
		Assert.AreEqual(1, manager.getAchievements().Count);

		manager.incrementCollectableScore (POCC.Collectable.GOLDFLY);

		Assert.AreEqual(2, manager.getAchievements().Count);

		for (int i = 0; i < 10; i++) {
			manager.incrementCollectableScore (POCC.Collectable.GOLDFLY);
		}

		Assert.AreEqual(3, manager.getAchievements().Count);
	}
}
