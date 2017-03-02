using System.Collections.Generic;

namespace Tedesco.Evolution
{
	public class EasiestFingeringOrder : IComparer<Fingering>
	{
		private FingeringScorer scorer = new FingeringScorer();

		public int Compare(Fingering x, Fingering y)
		{
			return scorer.Score(x).CompareTo(scorer.Score(y));
		}
	}
}
