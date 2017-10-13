using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 

/**
 * Unity's open source GameManager skeleton
 * Source : https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
 * 
 * 
**/
public class ItemManager : MonoBehaviour
{

	public static ItemManager itemManager = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private int level = 3;                                  //Current level number, expressed in game as "Day 1".

	public List<string> itemList;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (itemManager == null)

			//if not, set instance to this
			itemManager = this;

		//If instance already exists and it's not this:
		else if (itemManager != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);


		//Call the InitGame function to initialize the first level 
		InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		

	}



	//Update is called every frame.
	void Update()
	{

	}

}