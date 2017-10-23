using System;

/**
 * Simple structure class that maintains an entry for a highscore.
 * Structure class as it should be read only - only instantiated once
 * and then thats it.
 */
namespace POCC.HighScore
{
	[Serializable]
	public struct HighScoreEntry
	{
		public String _name;
		public int _collectScore;
		public int _argueScore;

		public HighScoreEntry(String name, int collectScore, int argueScore){
			_name = name;
			_collectScore = collectScore;
			_argueScore = argueScore;
		}
	}
}

