using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tedesco
{
	public class FingerboardInstrument
	{
		private List<TunedString> strings;
		private int frets;

		public FingerboardInstrument(IEnumerable<Note> tuningLowToHigh, int fretCount)
		{
            if (tuningLowToHigh == null) throw new ArgumentNullException("tuningLowToHigh");

			if (fretCount <= 0) throw new ArgumentOutOfRangeException("fretCount", "Frets must be positive");

			this.frets = fretCount;
			this.strings = new List<TunedString>();

			int stringNumber = tuningLowToHigh.Count();

			foreach (Note p in tuningLowToHigh)
			{
				this.strings.Add(new TunedString(p, stringNumber--));
			}
		}

		public IReadOnlyCollection<TunedString> Strings
		{
			get
			{
				return new ReadOnlyCollection<TunedString>(this.strings);
			}
		}

		public Note PitchAt(FingerPosition position)
		{
			if (position == null) throw new ArgumentNullException("position");

			int stringIndex = this.strings.Count - position.String;

			if (stringIndex < 0)
				throw new ArgumentOutOfRangeException("position", "Position value is not available on this instrument");

			return this.strings[stringIndex].PitchAt(position.Fret);
		}

		public IList<FingerPosition> PositionsFor(Predicate<FingerSearchArgs> decider)
		{
			var list = new List<FingerPosition>();

			foreach (var str in this.strings.OrderBy(x => x.Number))
			{
				list.AddRange(str.FindAllPositionsFor(frets, decider));
			}

			return list;
		}

		public IList<FingerPosition> PositionsFor(Note pitch)
		{
			if (pitch == null) throw new ArgumentNullException("pitch");

			return this.PositionsFor(args => args.Pitch == pitch);
		}

		public IList<FingerPosition> OtherExactPositionsFor(FingerPosition position)
		{
			if (position == null) throw new ArgumentNullException("position");

			var pitch = this.PitchAt(position);

			return this.PositionsFor(args => args.Pitch == pitch && args.Position != position);
		}

		public IList<FingerPosition> OtherFuzzyPositionsFor(FingerPosition position)
		{
			if (position == null) throw new ArgumentNullException("position");

			var pitch = this.PitchAt(position);

			return this.PositionsFor(args => args.Pitch.Degree == pitch.Degree && args.Position != position);
		}

		//public Fingering CreateFingeringFor(Melody piece, IValueSelector randomness)
		//{
		//	var notes = piece.Notes;

		//	var fingering = new Fingering();

		//	foreach (Note p in notes)
		//	{
		//		var possibleAlternatives = this.PositionsFor(p);

		//		int randomIndex = randomness.Integer(0, possibleAlternatives.Count - 1);
		//		FingerPosition selected = possibleAlternatives[randomIndex];

		//		fingering.Add(new FingerPosition(selected.Fret, selected.String));
		//	}

		//	return fingering;
		//}
	}

}
