using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using POCC;

public class ScoreTests {

	[Test]
	public void BasicGoldFlyPickup()
	{
		//Arrange	
		GameManager manager = POCC.GameManager.getInstance();
		manager.resetScore ();

		//Act
		manager.incrementCollectableScore(Collectable.GOLDFLY);
		manager.incrementCollectableScore(Collectable.GOLDFLY);
		manager.incrementCollectableScore(Collectable.GOLDFLY);

		//Assert
		//The game manager registered damage once.
		Assert.AreEqual(3, manager.getTotalScore());
		Assert.AreEqual(3, manager.getCollectableScore());
		Assert.AreEqual(0, manager.getArgumentationScore());
	}

	[Test]
	public void BasicGoldflyAndArgueScore()
	{
		//Arrange	
		GameManager manager = POCC.GameManager.getInstance();
		manager.resetScore ();

		//Act
		manager.incrementCollectableScore(Collectable.GOLDFLY);
		manager.incrementArgumentationScore (ArgumentationValue.FIRST_ATTEMPT);
		manager.incrementCollectableScore(Collectable.GOLDFLY);


		//Assert
		//The game manager registered damage once.
		Assert.AreEqual(12, manager.getTotalScore());
		Assert.AreEqual(2, manager.getCollectableScore());
		Assert.AreEqual(10, manager.getArgumentationScore());
	}
}
