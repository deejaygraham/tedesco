using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
			var notes = new List<Pitch>();

			foreach (var position in this.positions)
			{
				notes.Add(instrument.PitchAt(position));
			}

			return new Melody(notes);
		}
	}
}
