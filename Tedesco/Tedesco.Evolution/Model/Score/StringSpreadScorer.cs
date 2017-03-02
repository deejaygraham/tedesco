using System.Linq;

namespace Tedesco.Evolution
{
	public class StringSpreadScorer : IScore<Fingering>
	{
		public int Score(Fingering item)
		{
			var positions = item.Positions;

			//			punish larger moves...
			//
			//		punish big gaps,

			//	punish long stretches

			int spread = positions.Max(f => f.String) - positions.Min(f => f.String) + 1;

			//		var stringDifferences = this.positions.Zip(this.positions.Skip(1), (first, second) => Math.Abs(second.String - first.String));

			//	int total = spread + fretDifferences.Sum() + stringDifferences.Sum();

			// return total;
			return spread;
		}

		bool IsSequential(int[] array)
		{
			return array.Zip(array.Skip(1), (a, b) => (a + 1) == b).All(x => x);
		}
	}
}
