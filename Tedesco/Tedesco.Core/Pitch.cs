using System;

namespace Tedesco
{
	public class Pitch : IEquatable<Pitch>, IComparable<Pitch>, IComparable
	{
		readonly int MidiMinValue = 0;
		readonly int MidiMaxValue = 127;

		public Pitch(MidiNoteValue value)
			: this((int) value)
		{
		}

		public Pitch(int value)
		{
			if (value > MidiMaxValue || value < MidiMinValue)
				throw new ArgumentOutOfRangeException("value", "value out of range");

			this.value = value;
		}

		private readonly int value;

		public int Value { get { return this.value; } }

		public override string ToString()
		{
			return string.Format("{0}", this.value);
		}

		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null)) return false;

			if (object.ReferenceEquals(this, obj)) return true;

			if (this.GetType() != obj.GetType()) return false;

			return this.Equals(obj as Pitch);
		}

		public bool Equals(Pitch other)
		{
			return this.value == other.value;
		}

		public int CompareTo(Pitch other)
		{
			return this.value.CompareTo(other.value);
		}

		int IComparable.CompareTo(object obj)
		{
			if (!(obj is Pitch))
				throw new ArgumentException("Argument is not a valid midi value", "obj");

			Pitch other = obj as Pitch;

			return this.CompareTo(other);
		}

		public static bool operator <(Pitch left, Pitch right)
		{
			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(Pitch left, Pitch right)
		{
			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(Pitch left, Pitch right)
		{
			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(Pitch left, Pitch right)
		{
			return left.CompareTo(right) >= 0;
		}

		public static bool operator ==(Pitch left, Pitch right)
		{
			return left.CompareTo(right) == 0;
		}

		public static bool operator !=(Pitch left, Pitch right)
		{
			return left.CompareTo(right) != 0;
		}

		public Pitch Sharpen()
		{
			return new Pitch(this.value + 1);
		}

		public Pitch Flatten()
		{
			return new Pitch(this.value - 1);
		}
	}
}
