using System;

namespace Tedesco
{
	public sealed class Interval : IEquatable<Interval>, IComparable<Interval>, IComparable
	{
        private readonly int distance;

        public static readonly Interval Semitone = new Interval(1);
        public static readonly Interval HalfStep = new Interval(1);
        public static readonly Interval MinorSecond = new Interval(1);

        public static readonly Interval Tone = new Interval(2);
        public static readonly Interval Step = new Interval(2);

        public static readonly Interval MinorThird = new Interval(3);
        public static readonly Interval MajorThird = new Interval(4);

        public static readonly Interval Fourth = new Interval(5);

        public static readonly Interval Tritone = new Interval(6);

        public static readonly Interval Fifth = new Interval(7);

        public static readonly Interval MinorSixth = new Interval(8);
        public static readonly Interval MajorSixth = new Interval(9);
        public static readonly Interval MinorSeventh = new Interval(10);
        public static readonly Interval MajorSeventh = new Interval(11);

        public static readonly Interval Octave = new Interval(12);

        public static readonly Interval MinorNinth = new Interval(13);
        public static readonly Interval Ninth = new Interval(14);
        

		public Interval(int semitones)
		{
			this.distance = semitones;
		}

		public int Semitones { get { return this.distance; } }

        public bool Ascending
        {
            get
            {
                return this.distance >= 0;
            }
        }

        public bool Descending
        {
            get
            {
                return this.distance < 0;
            }
        }

        public override int GetHashCode()
		{
			return this.distance.GetHashCode();
		}

		public override string ToString()
		{
            return IntervalNamer.NameOf(this);
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
			if (object.ReferenceEquals(other, null)) return false;

			return this.distance == other.distance;
		}

		public int CompareTo(object obj)
		{
			Interval other = obj as Interval;

			if (object.ReferenceEquals(other, null)) throw new ArgumentException("Argument is not a valid pitch value", "obj");

			return this.CompareTo(other);
		}

		public int CompareTo(Interval other)
		{
			if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

			return this.distance.CompareTo(other.distance);
		}

        public bool RelatedTo(Interval other)
        {
            if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

            return (this.distance % 12 == other.distance % 12);
        }

        public static bool operator ==(Interval left, Interval right)
		{
			if (object.ReferenceEquals(left, null)) return false;
			if (object.ReferenceEquals(right, null)) return false;

			return left.distance == right.distance;
		}

		public static bool operator !=(Interval left, Interval right)
		{
			if (object.ReferenceEquals(left, null)) return true;
			if (object.ReferenceEquals(right, null)) return true;

			return !(left == right);
		}

		public static bool operator <(Interval left, Interval right)
		{
			if (object.ReferenceEquals(left, null)) return false;
			if (object.ReferenceEquals(right, null)) return false;

			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(Interval left, Interval right)
		{
			if (object.ReferenceEquals(left, null)) return false;
			if (object.ReferenceEquals(right, null)) return false;

			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(Interval left, Interval right)
		{
			if (object.ReferenceEquals(left, null)) return false;
			if (object.ReferenceEquals(right, null)) return false;

			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(Interval left, Interval right)
		{
			if (object.ReferenceEquals(left, null)) return false;
			if (object.ReferenceEquals(right, null)) return false;

			return left.CompareTo(right) >= 0;
		}

        public Solfege AsSolfege()
        {
            Solfege[] solfa = new Solfege[] {
                Solfege.Do,
                Solfege.Di,
                Solfege.Re,
                Solfege.Ri,
                Solfege.Mi,
                Solfege.Fa,
                Solfege.Fi,
                Solfege.So,
                Solfege.Si,
                Solfege.La,
                Solfege.Li,
                Solfege.Ti
            };

            int degree = this.distance % solfa.Length;

            return solfa[degree];
        }
	}

}
