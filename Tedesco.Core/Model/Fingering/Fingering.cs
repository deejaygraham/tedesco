using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tedesco
{
	public sealed class Fingering : IEquatable<Fingering>
	{
		private readonly List<FingerPosition> positions = new List<FingerPosition>();

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
			var handPositions = new List<HandPosition>();

			var positionsLowToHigh = this.positions.OrderBy(p => p.Fret).Distinct();

			//var lowestPosition = positionsLowToHigh.First();

			int handSpan = 4;
			//HandPosition firstPosition = new HandPosition(lowestPosition.Fret, lowestPosition.Fret + handSpan - 1);

			//handPositions.Add(firstPosition);

			foreach (var fingering in positionsLowToHigh) //.Skip(1))
			{
				bool isCovered = handPositions.Any(hand => hand.Covers(fingering));

				if (!isCovered)
				{
					handPositions.Add(new HandPosition(fingering.Fret, fingering.Fret + handSpan - 1));
				}
			}

			return new ReadOnlyCollection<HandPosition>(handPositions);
		}


		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;

            if (object.ReferenceEquals(this, obj)) return true;

            if (this.GetType() != obj.GetType()) return false;

            return this.Equals(obj as Fingering);
        }

        public bool Equals(Fingering other)
        {
            if (object.ReferenceEquals(other, null)) return false;

            return this.positions.SequenceEqual(other.positions);
        }

        public override string ToString()
		{
			return String.Join(" ", this.positions);
		}

		public Melody ToMelody(FingerboardInstrument instrument)
		{
            if (instrument == null) throw new ArgumentNullException("instrument");

			var notes = new List<Note>();

            this.positions.ForEach(p => notes.Add(instrument[p]));

			return new Melody(notes);
		}
	}
}
