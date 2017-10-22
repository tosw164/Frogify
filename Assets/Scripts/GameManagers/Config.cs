using System;
using UnityEngine;

namespace POCC
{
	/**
	 * Class that holds global constants for the game.
	 */
	public class Config
	{
		// String for the file that the save data persists to
		// Using unity built in persistentDataPath in order to be more professional
		public static string PERSISTENCE_FILE = Application.persistentDataPath + "/pepInfo.dat";
	}
}

