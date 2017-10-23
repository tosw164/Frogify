using UnityEngine;
using System.Collections.Generic;
using System;

/*
 * This class simply stores the HighScore entries that were stored by other players.
 * It is serializable in order to not be quite as susceptible to edits and such.
 */
namespace POCC.HighScore
{
	/**
	 * Manager for holding High score entries - it simply persists the 
	 * highscores based on the levels. It utilizes a singleton type pattern
	 * in order to be accessed and get the entries out.
	 */ 
	[Serializable]
	public class HighScoreManager {

		private Dictionary<int,List<HighScoreEntry>> _highScoreStorage;

		private static HighScoreManager _manager; 

		public static HighScoreManager getInstance() {
			if (_manager == null) {
				_manager = new HighScoreManager();
			}
			return _manager;
		}
			
		/*
		 * Simply instantiate the storage elements.
		 */
		public HighScoreManager(){
			_highScoreStorage = new Dictionary<int, List<HighScoreEntry>> ();
			_highScoreStorage.Add(0,new List<HighScoreEntry>());
			_highScoreStorage.Add(1,new List<HighScoreEntry>());
			_highScoreStorage.Add(2,new List<HighScoreEntry>());
		}

		/**
		 * Method to add high score to the relevant level - can then retrieve 
		 * levels later.
		 */
		public void addHighScore(int level, HighScoreEntry entry){
			List<HighScoreEntry> levelScoreList = _highScoreStorage [level];
			levelScoreList.Add (entry);
		}

		/**
		 * Getter method to return a list of the level requested
		 * Could have some kind of adapter to convert some intermediary value.
		 */ 
		public List<HighScoreEntry> getHighScoresForLevel(int level){
			return _highScoreStorage[level];
		}

	}
}
