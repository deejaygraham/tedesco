using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	[DebuggerDisplay("[S:{@string}, F:{fret}]")]
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

		public bool Covers(FingerPosition pos)
		{
			return pos.Fret >= this.Lowest && pos.Fret <= this.Highest;
		}

		public override int GetHashCode()
		{
			return this.minFret.GetHashCode() ^ this.maxFret.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("[{0} -> {1}]", this.minFret, this.maxFret);
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
	}

}
