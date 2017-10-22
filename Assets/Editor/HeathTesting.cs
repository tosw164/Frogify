using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using POCC;

public class HeathTesting {

	[Test]
	public void DamageOnce()
	{
		//Arrange	
		GameManager manager = POCC.GameManager.getInstance();
		manager.resetHealth ();

		//Act
		manager.decrementHealth();

	
		//Assert
		//The game manager registered damage once.
		Assert.AreEqual(2, manager.getHealth());
	}


	/**
	 * Testing for getting damaged then picking up a health 
	 * collectable
	 */ 
	[Test]
	public void DamageAndHeal()
	{
		//Arrange
		GameManager manager = GameManager.getInstance();
		manager.resetHealth ();

		//Act
		//Damage twice, then heal.
		manager.decrementHealth();
		manager.decrementHealth();

		manager.incrementHealth ();

		//Assert
		//The game manager registered damage once.
		Assert.AreEqual(2, manager.getHealth());
	}

	/**
	 * Testing that health does not exceed the DEFAULT_HEALTH
	 * value.
	 */ 
	[Test]
	public void TestMaxHealth()
	{
		//Arrange
		GameManager manager = GameManager.getInstance();
		manager.resetHealth ();

		//Act
		//Heal repeatedly to ensure it works.
		manager.incrementHealth ();
		manager.incrementHealth ();
		manager.incrementHealth ();
		manager.incrementHealth ();

		//Assert
		//The game manager registered damage once.
		Assert.AreEqual(3, manager.getHealth());
	}
}
