using System;
using System.Linq;

namespace Tedesco.Evolution
{
	public class FingeringScorer : IScore<Fingering>
	{
		public int Score(Fingering item)
		{
			int horizontalTotal = item.Positions.Max(f => f.String) - item.Positions.Min(f => f.String) + 1;
			int verticalTotal = item.Positions.Max(f => f.Fret) - item.Positions.Min(f => f.Fret) + 1;

			int spread = horizontalTotal * verticalTotal;

			// how far horizontally do we have to move...
			// how far vertically do we have to move...
			var fretDifferences = item.Positions.Zip(item.Positions.Skip(1), (first, second) => Math.Abs(second.Fret - first.Fret));
			var stringDifferences = item.Positions.Zip(item.Positions.Skip(1), (first, second) => Math.Abs(second.String - first.String));

			int total = spread + fretDifferences.Sum() + stringDifferences.Sum();

			return total;
		}

	}
}
