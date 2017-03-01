using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution
{
	public class FretSpreadScorer : IScorer<Fingering>
	{
		public int Score(Fingering item)
		{
			var positions = item.Positions;

			// punish big jumps between positions.

			int spread = positions.Max(f => f.Fret) - positions.Min(f => f.Fret) + 1;

			// how far horizontally do we have to move...
			// how far vertically do we have to move...
			//			var fretDifferences = this.positions.Zip(this.positions.Skip(1), (first, second) => Math.Abs(second.Fret - first.Fret));

			// return total;

			return spread;
		}
	}
}
