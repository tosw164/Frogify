using System;

/**
 * Simple structure class that maintains an entry for a highscore.
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

