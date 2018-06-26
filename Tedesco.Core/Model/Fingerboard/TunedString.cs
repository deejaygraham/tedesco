using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tedesco
{
	[DebuggerDisplay("{open}")]
	public class TunedString
	{
		private Note open;

		public TunedString()
		{
			this.open = new Note(0);
			this.Number = 0;
		}

		public TunedString(Note rootNote, int number)
		{
			this.open = new Note(rootNote);
			this.Number = number;
		}

		public Note Open
		{
			get
			{
				return new Note(this.open);
			}
		}

		public int Number { get; private set; }

		public void TuneTo(Note openPitch)
		{
			this.open = new Note(openPitch);
		}

		public Note PitchAt(int fret)
		{
			if (fret < 0)
				throw new ArgumentOutOfRangeException("fret", "Fret must be zero or positive");

            var interval = new Interval(fret);

			return this.open + interval;
		}

		public IEnumerable<FingerPosition> FindAllPositionsFor(int fretRange, Predicate<FingerSearchArgs> decider)
		{
			var list = new List<FingerPosition>();

			foreach (var fret in Enumerable.Range(0, fretRange + 1))
			{
				Note candidate = this.PitchAt(fret);

				var position = new FingerPosition(fret, this.Number);
				var args = new FingerSearchArgs { Pitch = candidate, Position = position };

				if (decider != null && decider(args))
				{
					list.Add(position);
				}
			}

			return list;
		}

		public IEnumerable<FingerPosition> FindAllPositionsFor(Note pitch)
		{
			return this.FindAllPositionsFor(22, pitch);
		}

		public IEnumerable<FingerPosition> FindAllPositionsFor(int fretRange, Note pitch)
		{
			return this.FindAllPositionsFor(fretRange, args => args.Pitch == pitch);
		}

		public IEnumerable<FingerPosition> FindAllPositionsForNote(int fretRange, Note pitch)
		{
			return this.FindAllPositionsFor(fretRange, args => args.Pitch.Degree == pitch.Degree);
		}
	}

}
