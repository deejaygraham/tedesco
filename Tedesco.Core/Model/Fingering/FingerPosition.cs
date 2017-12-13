using System;
using System.Diagnostics;

namespace Tedesco
{
	[DebuggerDisplay("[S:{@string}, F:{fret}]")]
	public class FingerPosition : IEquatable<FingerPosition>, IComparable<FingerPosition>, IComparable
	{
		private readonly int fret;
		private readonly int @string;

		public FingerPosition(int fretNumber, int stringNumber)
		{
			if (fretNumber < 0)
				throw new ArgumentException("fretNumber must be positive");

			if (stringNumber < 1)
				throw new ArgumentException("stringNumber must be 1 or greater");

			this.fret = fretNumber;
			this.@string = stringNumber;
		}

		public int Fret { get { return this.fret; } }

		public int String { get { return this.@string; } }

		public override int GetHashCode()
		{
			return this.fret.GetHashCode() ^ this.@string.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("[{0}, {1}]", this.@string, this.fret);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null)) return false;

			if (object.ReferenceEquals(this, obj)) return true;

			if (this.GetType() != obj.GetType()) return false;

			return this.Equals(obj as FingerPosition);
		}

		public bool Equals(FingerPosition other)
		{
			if (object.ReferenceEquals(other, null)) return false;

			return this.fret == other.fret
				&& this.@string == other.@string;
		}

		int IComparable.CompareTo(object obj)
		{
			FingerPosition other = obj as FingerPosition;

			if (object.ReferenceEquals(other, null)) throw new ArgumentException("Argument is not an FingerPosition object", "obj");

			return this.CompareTo(other);
		}

		public int CompareTo(FingerPosition other)
		{
			if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

			int comparison = this.fret.CompareTo(other.fret);

			if (comparison == 0)
			{
				comparison = this.@string.CompareTo(other.@string);
			}

			return comparison;
		}
	}
}
