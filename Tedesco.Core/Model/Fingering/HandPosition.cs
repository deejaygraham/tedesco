using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	[DebuggerDisplay("[From:{minFret}, To:{maxFret}]")]
	public class HandPosition : IEquatable<HandPosition>, IComparable<HandPosition>, IComparable
	{
		private readonly int minFret, maxFret;

		public HandPosition(int lowest, int highest)
		{
			if (lowest < 0)
				throw new ArgumentException("lowest must be positive or zero");

			if (highest < 0)
				throw new ArgumentException("highest must be positive or zero");

			this.minFret = Math.Min(lowest, highest);
			this.maxFret = Math.Max(lowest, highest);
		}

		public int Lowest { get { return this.minFret; } }

		public int Highest { get { return this.maxFret; } }

		public bool Covers(FingerPosition position)
		{
            if (position == null) throw new ArgumentNullException("position", "FingerPosition is not a valid object");

			return position.Fret >= this.Lowest && position.Fret <= this.Highest;
		}

		public override int GetHashCode()
		{
			return this.minFret.GetHashCode() ^ this.maxFret.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "[{0} -> {1}]", this.minFret, this.maxFret);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null)) return false;

			if (object.ReferenceEquals(this, obj)) return true;

			if (this.GetType() != obj.GetType()) return false;

			return this.Equals(obj as HandPosition);
		}

		public bool Equals(HandPosition other)
		{
			if (object.ReferenceEquals(other, null)) return false;

			return this.minFret == other.minFret
				&& this.maxFret == other.maxFret;
		}

		int IComparable.CompareTo(object obj)
		{
			HandPosition other = obj as HandPosition;

			if (object.ReferenceEquals(other, null)) throw new ArgumentException("Argument is not an HandPosition object", "obj");

			return this.CompareTo(other);
		}

		public int CompareTo(HandPosition other)
		{
			if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

			int comparison = this.minFret.CompareTo(other.minFret);

			if (comparison == 0)
			{
				comparison = this.maxFret.CompareTo(other.maxFret);
			}

			return comparison;
		}

        public static bool operator ==(HandPosition left, HandPosition right)
        {
            if (object.ReferenceEquals(left, null)) return false;
            if (object.ReferenceEquals(right, null)) return false;

            return left.CompareTo(right) == 0;
        }

        public static bool operator !=(HandPosition left, HandPosition right)
        {
            if (object.ReferenceEquals(left, null)) return true;
            if (object.ReferenceEquals(right, null)) return true;

            return !(left == right);
        }

        public static bool operator <(HandPosition left, HandPosition right)
        {
            if (object.ReferenceEquals(left, null)) return false;
            if (object.ReferenceEquals(right, null)) return false;

            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(HandPosition left, HandPosition right)
        {
            if (object.ReferenceEquals(left, null)) return false;
            if (object.ReferenceEquals(right, null)) return false;

            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(HandPosition left, HandPosition right)
        {
            if (object.ReferenceEquals(left, null)) return false;
            if (object.ReferenceEquals(right, null)) return false;

            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(HandPosition left, HandPosition right)
        {
            if (object.ReferenceEquals(left, null)) return false;
            if (object.ReferenceEquals(right, null)) return false;

            return left.CompareTo(right) >= 0;
        }

    }

}
