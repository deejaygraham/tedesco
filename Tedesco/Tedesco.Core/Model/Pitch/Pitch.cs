using System;
using System.Diagnostics;

namespace Tedesco
{
	[DebuggerDisplay("{value}")]
	public class Pitch : IEquatable<Pitch>, IComparable<Pitch>, IComparable
	{
		private readonly int value;

		public Pitch(Pitch p)
		{
			this.value = p.value;
		}

		public Pitch(int scaleDegree)
			: this (scaleDegree, 0)
		{
		}

		public Pitch(int scaleDegree, int octave)
		{
			if (scaleDegree < 0)
				throw new ArgumentOutOfRangeException("scaleDegree", "Value cannot be negative");

			if (octave < 0)
				throw new ArgumentOutOfRangeException("octave", "Value cannot be negative");

			this.value = scaleDegree + (Interval.Octave.Semitones * octave);
		}

		public Pitch(MidiNoteValue value)
		{
			this.value = (int)value;
		}

		public bool Equals(Pitch other)
		{
			if (other == null)
				throw new ArgumentNullException("other");

			return this.value == other.value;
		}

		public override int GetHashCode()
		{
			return value.GetHashCode();
		}

		public override string ToString()
		{
			return this.value.ToString();
		}

		public int CompareTo(Pitch other)
		{
			if (other == null)
				throw new ArgumentNullException("other");

			return this.value.CompareTo(other.value);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null)) return false;

			if (object.ReferenceEquals(this, obj)) return true;

			if (this.GetType() != obj.GetType()) return false;

			return this.Equals(obj as Pitch);
		}

		int IComparable.CompareTo(object obj)
		{
			Pitch other = obj as Pitch;

			if (other == null)
				throw new ArgumentException("Argument is not a valid pitch value", "obj");

			return this.CompareTo(other);
		}

		public static bool operator <(Pitch left, Pitch right)
		{
			if (left == null)
				throw new ArgumentNullException("left");

			if (right == null)
				throw new ArgumentNullException("right");

			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(Pitch left, Pitch right)
		{
			if (left == null)
				throw new ArgumentNullException("left");

			if (right == null)
				throw new ArgumentNullException("right");

			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(Pitch left, Pitch right)
		{
			if (left == null)
				throw new ArgumentNullException("left");

			if (right == null)
				throw new ArgumentNullException("right");

			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(Pitch left, Pitch right)
		{
			if (left == null)
				throw new ArgumentNullException("left");

			if (right == null)
				throw new ArgumentNullException("right");

			return left.CompareTo(right) >= 0;
		}

		public static bool operator ==(Pitch left, Pitch right)
		{
			if (left == null)
				throw new ArgumentNullException("left");

			if (right == null)
				throw new ArgumentNullException("right");

			return left.CompareTo(right) == 0;
		}

		public static bool operator !=(Pitch left, Pitch right)
		{
			if (left == null)
				throw new ArgumentNullException("left");

			if (right == null)
				throw new ArgumentNullException("right");

			return left.CompareTo(right) != 0;
		}

		public Pitch Sharpen()
		{
			return this.SharpenBy(IntervalDistance.MinorSecond);
		}

		public Pitch SharpenBy(IntervalDistance semitones)
		{
			return new Pitch(this.value + (int)semitones);
		}

		public Pitch SharpenBy(int semitones)
		{
			return new Pitch(this.value + semitones);
		}

		public Pitch Flatten()
		{
			return this.FlattenBy(IntervalDistance.MinorSecond);
		}

		public Pitch FlattenBy(IntervalDistance semitones)
		{
			return new Pitch(this.value - (int)semitones);
		}

		public Pitch FlattenBy(int semitones)
		{
			return new Pitch(this.value - semitones);
		}

		public static Pitch Add(Pitch note, Interval interval)
		{
			return new Pitch(note.value + interval.Semitones);
		}

		public static Pitch Add(Pitch note, int offset)
		{
			return new Pitch(note.value + offset);
		}

		public static Pitch Subtract(Pitch note, Interval interval)
		{
			return new Pitch(note.value - interval.Semitones);
		}

		public static Pitch Subtract(Pitch note, int offset)
		{
			return new Pitch(note.value - offset);
		}

		public static Pitch Flatten(Pitch note)
		{
			return new Pitch(note.value - 1);
		}

		public static Interval Difference(Pitch left, Pitch right)
		{
			return new Interval(Math.Abs(left.value - right.value));
		}

		public static Pitch operator +(Pitch note, Interval interval)
		{
			return Pitch.Add(note, interval);
		}

		public static Pitch operator +(Pitch note, int offset)
		{
			return Pitch.Add(note, offset);
		}

		public static Pitch operator -(Pitch note, Interval interval)
		{
			return Pitch.Subtract(note, interval);
		}

		public static Pitch operator -(Pitch note, int offset)
		{
			return Pitch.Subtract(note, offset);
		}

		public static Interval operator -(Pitch left, Pitch right)
		{
			return Pitch.Difference(left, right);
		}

	}

}
