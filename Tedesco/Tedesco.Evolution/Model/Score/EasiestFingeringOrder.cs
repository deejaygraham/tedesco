using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
