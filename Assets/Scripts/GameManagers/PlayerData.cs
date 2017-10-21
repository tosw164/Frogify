using System;

namespace POCC
{
	/**
	 * Class used to hold the values that should be persisted
	 * between executions. Simply a "data container"
	 *
	 * Reference: Unity Live Training 3 March 2014:
	 * 		https://www.youtube.com/watch?v=J6FfcJpbPXE
	 */
	[Serializable] //states that the class is serialziable
	public class PlayerData
	{
		private int _health;
		private long _argumentationScore;
		private long _collectableScore;
		private string _levelString;

		//TODO: Add fields regarding achievements

		public PlayerData(int health, long aScore, long cScore, String levelString){
			_health = health;
			_argumentationScore = aScore;
			_collectableScore = cScore;
			_levelString = levelString;
		}

		public int getHealth(){
			return _health;
		}

		public long getArgueScore(){
			return _argumentationScore;
		}

		public long getCollectScore(){
			return _collectableScore;
		}

		public string getLevelString(){
			return _levelString;
		}
	}
}

