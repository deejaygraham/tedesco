using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	public class FingerboardInstrument
	{
		private List<TunedString> strings;
		private int frets;

		public FingerboardInstrument(IEnumerable<Pitch> tuningLowToHigh, int fretCount)
		{
			if (fretCount <= 0)
				throw new ArgumentOutOfRangeException("fretCount", "Frets must be positive");

			this.frets = fretCount;
			this.strings = new List<TunedString>();

			int stringNumber = tuningLowToHigh.Count();

			foreach (Pitch p in tuningLowToHigh)
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

		public Pitch PitchAt(FingerPosition position)
		{
			if (position == null) throw new ArgumentNullException("position");

			int stringIndex = this.strings.Count() - position.String;

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

		public IList<FingerPosition> PositionsFor(Pitch p)
		{
			if (p == null) throw new ArgumentNullException("p");

			return this.PositionsFor(args => args.Pitch == p);
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
