using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution
{
	public class MelodyScorer : IRelativeScorer<Melody>
	{
		private ComparisonMode comparisonMode = ComparisonMode.Loose;

		public MelodyScorer()
		{
			this.comparisonMode = ComparisonMode.Loose;
		}

		public MelodyScorer(ComparisonMode mode)
		{
			this.comparisonMode = mode;
		}

		public int Score(Melody first, Melody second)
		{
			if (this.comparisonMode == ComparisonMode.Exact)
				return first.Notes.Zip(second.Notes, (a, b) => a == b ? 1 : 0).Sum();

			return first.Notes.Zip(second.Notes, (a, b) => a == b
				? 10
				: Math.Abs((a - b).Semitones) < 10
					? 10 - Math.Abs((a - b).Semitones)
					: 0).Sum();
		}
	}

}
