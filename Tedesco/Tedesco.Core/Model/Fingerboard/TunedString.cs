using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tedesco
{
	[DebuggerDisplay("{open}")]
	public class TunedString
	{
		private Pitch open;

		public TunedString()
		{
			this.open = new Pitch(0);
			this.Number = 0;
		}

		public TunedString(Pitch p, int number)
		{
			this.open = new Pitch(p);
			this.Number = number;
		}

		public Pitch Open
		{
			get
			{
				return new Pitch(this.open);
			}
		}

		public int Number { get; private set; }

		public void TuneTo(Pitch p)
		{
			this.open = new Pitch(p);
		}

		public Pitch PitchAt(int fret)
		{
			if (fret < 0)
				throw new ArgumentOutOfRangeException("fret", "Fret must be zero or positive");

			return this.open.SharpenBy(fret);
		}

		public IEnumerable<FingerPosition> FindAllPositionsFor(int fretRange, Predicate<FingerSearchArgs> decider)
		{
			var list = new List<FingerPosition>();

			foreach (var fret in Enumerable.Range(0, fretRange + 1))
			{
				Pitch candidate = this.PitchAt(fret);

				var position = new FingerPosition(fret, this.Number);
				var args = new FingerSearchArgs { Pitch = candidate, Position = position };

				if (decider(args))
				{
					list.Add(position);
				}
			}

			return list;
		}

		public IEnumerable<FingerPosition> FindAllPositionsFor(int fretRange, Pitch p)
		{
			return this.FindAllPositionsFor(fretRange, args => args.Pitch == p);
		}

		public IEnumerable<FingerPosition> FindAllPositionsForNote(int fretRange, Pitch p)
		{
			return this.FindAllPositionsFor(fretRange, args => args.Pitch.Degree == p.Degree);
		}
	}

}
