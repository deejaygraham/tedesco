using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution
{
	public static class FingeringCreator
	{
		public static Fingering CreateFingeringFor(this FingerboardInstrument instrument, Melody piece, ISelectValue randomness)
		{
			var notes = piece.Notes;

			var fingering = new Fingering();

			foreach (Pitch p in notes)
			{
				var possibleAlternatives = instrument.PositionsFor(p);

				int randomIndex = randomness.BetweenZeroAnd(possibleAlternatives.Count - 1);
				FingerPosition selected = possibleAlternatives[randomIndex];

				fingering.Add(new FingerPosition(selected.Fret, selected.String));
			}

			return fingering;
		}

	}


			//	public Fingering Mutate(GuitarFingerboard fingerboard)
		//	{
		//		// find a random position and pull in a new value...
		//		Random random = new Random((int)DateTime.Now.Ticks);

		//		// pick random position...
		//		// for first few - copy as normal
		//		// copy mutated one
		//		// copy remainder
		//		int randomPosition = random.Next(this.Positions.Count);

		//		FingerPosition position = this.Positions[randomPosition];

		//		var possiblePositions = fingerboard.PositionsSimilarTo(position);

		//		foreach (var possiblePos in possiblePositions)
		//		{
		//			if (possiblePos != position)
		//			{
		//				this.Positions[randomPosition] = possiblePos;
		//				break;
		//			}
		//		}

		//		return new Fingering();
		//	}


		//	// progress in first half, much more than process in second half.

		//public List<Fingering> RecombineWith(Fingering otherFingering, IValueSelector randomness)
		//{
		//	var child1 = new List<FingerPosition>();
		//	var child2 = new List<FingerPosition>();

		//	// assert both are same length !!!

		//	// cut.. 
		//	int cutIndex = randomness.Integer(this.positions.Count);

		//	child1.AddRange(this.positions.Take(cutIndex));
		//	child2.AddRange(otherFingering.positions.Take(cutIndex));

		//	// now cross fill

		//	Fingering candidate1 = new Fingering();
		//	candidate1.positions.AddRange(child1);

		//	Fingering candidate2 = new Fingering();
		//	candidate2.positions.AddRange(child2);

		//	return new List<Fingering> { candidate1, candidate2 };
		//}

		//public void CrossFill(List<FingerPosition> child, List<FingerPosition> parent, int cutIndex)
		//{
		//	for (int i = cutIndex; i < parent.Count; ++i)
		//	{
		//		FingerPosition nextPosition = parent[i];

		//		if (!child.Contains(nextPosition))
		//		{
		//			child.Add(nextPosition);
		//		}
		//	}

		//	for (int i = 0; i < cutIndex; ++i)
		//	{
		//		FingerPosition nextPosition = parent[i];

		//		if (!child.Contains(nextPosition))
		//		{
		//			child.Add(nextPosition);
		//		}
		//	}
		//}

		//	public int Score()
		//	{
		//		// how far horizontally do we have to move...
		//		// how far vertically do we have to move...
		//		var fretDifferences = this.Positions.Zip(this.Positions.Skip(1), (first, second) => Math.Abs(second.Fret - first.Fret));
		//		var stringDifferences = this.Positions.Zip(this.Positions.Skip(1), (first, second) => Math.Abs(second.String - first.String));

		//		return fretDifferences.Sum() + stringDifferences.Sum();
		//	}

		//	public List<FingerPosition> Positions { get; private set; }

		//	public Composition ToComposition()
		//	{
		//		var fb = new GuitarFingerboard();

		//		var comp = new Composition();

		//		foreach (var p in this.Positions)
		//		{
		//			comp.Notes.Add(fb.At(p));
		//		}

		//		return comp;
		//	}

		//	public override string ToString()
		//	{
		//		return String.Join(" ", this.Positions);
		//	}

}
