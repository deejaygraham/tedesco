using System;
using System.Linq;

namespace Tedesco.Evolution
{
	public class MelodyScorer : IScoreRelative<Melody>
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
