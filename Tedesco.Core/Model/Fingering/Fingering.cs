using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tedesco
{
	public class Fingering
	{
		private List<FingerPosition> positions = new List<FingerPosition>();

		public void Add(FingerPosition position)
		{
			this.positions.Add(position);
		}

		public IReadOnlyCollection<FingerPosition> Positions
		{
			get
			{
				return new ReadOnlyCollection<FingerPosition>(this.positions);
			}
		}


		public ReadOnlyCollection<HandPosition> HandPositions()
		{
			var list = new List<HandPosition>();

			var lowToHigh = this.positions.OrderBy(p => p.Fret).Distinct();

			int firstPosition = lowToHigh.First().Fret;

			int handSpan = 4;
			HandPosition first = new HandPosition(firstPosition, firstPosition + handSpan);

			list.Add(first);

			foreach (var p in lowToHigh.Skip(1))
			{
				var covered = list.FirstOrDefault(x => x.Covers(p));

				if (covered == null)
				{
					list.Add(new HandPosition(p.Fret, p.Fret + handSpan));
				}
			}

			return new ReadOnlyCollection<HandPosition>(list);
		}


		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		public override string ToString()
		{
			return String.Join(" ", this.positions);
		}

		public Melody ToMelody(FingerboardInstrument instrument)
		{
            if (instrument == null) throw new ArgumentNullException("instrument");

			var notes = new List<Note>();

			foreach (var position in this.positions)
			{
				notes.Add(instrument.PitchAt(position));
			}

			return new Melody(notes);
		}
	}
}
