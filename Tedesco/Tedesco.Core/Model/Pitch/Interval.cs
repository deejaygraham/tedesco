using System;

namespace Tedesco
{
	public class Interval : IEquatable<Interval>, IComparable<Interval>, IComparable
	{
		public static readonly Interval Semitone = new Interval(IntervalDistance.MinorSecond);
		public static readonly Interval Tone = new Interval(IntervalDistance.MajorSecond);
		public static readonly Interval Octave = new Interval(IntervalDistance.PerfectOctave);

		private IntervalDistance distance;

		public Interval(int semitones)
		{
			if (semitones < 0) throw new ArgumentException("semitones", "Value is not recognised as a valid interval");

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

		public override string ToString()
		{
			return IntervalNamer.NameOf(this.distance);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null)) return false;

			if (object.ReferenceEquals(this, obj)) return true;

			if (this.GetType() != obj.GetType()) return false;

			return this.Equals(obj as Interval);
		}

		public bool Equals(Interval other)
		{
			if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

			return this.distance == other.distance;
		}

		public int CompareTo(object obj)
		{
			if (!(obj is Interval)) throw new ArgumentException("Argument is not an Interval object", "obj");

			Interval other = obj as Interval;

			return this.CompareTo(other);
		}

		public int CompareTo(Interval other)
		{
			if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

			return this.distance.CompareTo(other.distance);
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
