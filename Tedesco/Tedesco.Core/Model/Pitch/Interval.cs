using System;

namespace Tedesco
{
	public class Interval
	{
		public static readonly Interval Semitone = new Interval(IntervalDistance.MinorSecond);
		public static readonly Interval Tone = new Interval(IntervalDistance.MajorSecond);
		public static readonly Interval Octave = new Interval(IntervalDistance.PerfectOctave);

		private IntervalDistance distance;

		private static readonly string[] IntervalNames = new string[] {
					"unison",
					"minor second",
					"major second",
					"minor third",
					"major third",
					"perfect fourth",
					"diminished fifth",
					"perfect fifth",
					"minor sixth",
					"major sixth",
					"minor seventh",
					"major seventh",
					"octave"
				};

		public Interval(int semitones)
		{
			if (semitones < 0)
				throw new ArgumentException("semitones", "Value is not recognised as a valid interval");

			while (semitones > (int)IntervalDistance.PerfectOctave)
				semitones -= (int)IntervalDistance.PerfectOctave;

			if (Enum.IsDefined(typeof(IntervalDistance), semitones))
			{
				this.distance = (IntervalDistance)semitones;
			}
			else
			{
				throw new ArgumentException("semitones", "Value is not recognised as a valid interval");
			}
		}

		public Interval(IntervalDistance distance)
		{
			this.distance = distance;
		}

		public int Semitones { get { return (int)this.distance; } }

		public IntervalDistance Distance { get { return this.distance; } }

		public override int GetHashCode()
		{
			return this.distance.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			Interval other = obj as Interval;

			if (other == null)
			{
				return false;
			}

			return other.distance == this.distance;
		}

		public int CompareTo(Interval other)
		{
			return this.distance.CompareTo(other.distance);
		}

		public override string ToString()
		{
			return IntervalNames[(int)this.distance];
		}

		public static bool operator ==(Interval left, Interval right)
		{
			return left.distance == right.distance;
		}

		public static bool operator !=(Interval left, Interval right)
		{
			return !(left == right);
		}

		public static bool operator <(Interval left, Interval right)
		{
			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(Interval left, Interval right)
		{
			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(Interval left, Interval right)
		{
			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(Interval left, Interval right)
		{
			return left.CompareTo(right) >= 0;
		}

	}

}
