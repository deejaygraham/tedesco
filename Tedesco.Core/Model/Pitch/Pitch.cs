using System;
using System.Diagnostics;

namespace Tedesco
{
	[DebuggerDisplay("{value}")]
	public class Pitch : IEquatable<Pitch>, IComparable<Pitch>, IComparable
	{
		private readonly int value;

		public Pitch(Pitch copy)
		{
			if (copy == null)
				throw new ArgumentNullException("copy", "pitch cannot be null");

			this.value = copy.value;
		}

		public Pitch(int scaleDegree)
		{
			this.value = Math.Abs(scaleDegree);
		}

		public Pitch(int scaleDegree, int octave, MidiOctaveFormat format = MidiOctaveFormat.Standard)
		{
			if (octave < -2)
				throw new OctaveValueException(octave);

			int octaveModifier = format == MidiOctaveFormat.Standard ? 2 : 1;

			this.value = PitchScaler.Scale(scaleDegree) + (Interval.Octave.Semitones * (octaveModifier + octave));
		}

		public Pitch(MidiNoteValue value)
		{
			this.value = (int)value;
		}

		public string Name
		{
			get
			{
				return NoteNamer.NameOf(this.value);
			}
		}

		public string MidiName
		{
			get
			{
				return string.Format("{0}{1}", this.Name, this.Octave);
			}
		}

		public ScaleDegree Degree
		{
			get
			{
				return (ScaleDegree)(PitchScaler.Scale(this.value));
			}
		}

		public int Octave
		{
			get
			{
				return OctaveCalculator.OctaveOf(this.value);
			}
		}

		public override int GetHashCode()
		{
			return value.GetHashCode();
		}

		public override string ToString()
		{
			return this.value.ToString();
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
			if (object.ReferenceEquals(other, null)) return false;

			return this.value == other.value;
		}

		public int CompareTo(object obj)
		{
			Pitch other = obj as Pitch;

			if (object.ReferenceEquals(other, null)) throw new ArgumentException("Argument is not a valid pitch value", "obj");

			return this.CompareTo(other);
		}

		public int CompareTo(Pitch other)
		{
			if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

			return this.value.CompareTo(other.value);
		}
		
		public static bool operator <(Pitch left, Pitch right)
		{
			if (object.ReferenceEquals(left, null)) throw new ArgumentException("note is not a valid pitch value", "left");
			if (object.ReferenceEquals(right, null)) throw new ArgumentException("note is not a valid pitch value", "right");

			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(Pitch left, Pitch right)
		{
			if (object.ReferenceEquals(left, null)) throw new ArgumentException("note is not a valid pitch value", "left");
			if (object.ReferenceEquals(right, null)) throw new ArgumentException("note is not a valid pitch value", "right");

			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(Pitch left, Pitch right)
		{
			if (object.ReferenceEquals(left, null)) throw new ArgumentException("note is not a valid pitch value", "left");
			if (object.ReferenceEquals(right, null)) throw new ArgumentException("note is not a valid pitch value", "right");

			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(Pitch left, Pitch right)
		{
			if (object.ReferenceEquals(left, null)) throw new ArgumentException("note is not a valid pitch value", "left");
			if (object.ReferenceEquals(right, null)) throw new ArgumentException("note is not a valid pitch value", "right");

			return left.CompareTo(right) >= 0;
		}

		public static bool operator ==(Pitch left, Pitch right)
		{
			if (object.ReferenceEquals(left, null)) return false;
			if (object.ReferenceEquals(right, null)) return false;

			return left.CompareTo(right) == 0;
		}

		public static bool operator !=(Pitch left, Pitch right)
		{
			if (object.ReferenceEquals(left, null)) return true;
			if (object.ReferenceEquals(right, null)) return true;

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
			if (object.ReferenceEquals(note, null)) throw new ArgumentException("note is not a valid pitch value", "note");
			if (object.ReferenceEquals(interval, null)) throw new ArgumentException("interval is not a valid interval value", "interval");

			return new Pitch(note.value + interval.Semitones);
		}

		public static Pitch Add(Pitch note, int offset)
		{
			if (object.ReferenceEquals(note, null)) throw new ArgumentException("note is not a valid pitch value", "note");

			return new Pitch(note.value + offset);
		}

		public static Pitch Subtract(Pitch note, Interval interval)
		{
			if (object.ReferenceEquals(note, null)) throw new ArgumentException("note is not a valid pitch value", "note");
			if (object.ReferenceEquals(interval, null)) throw new ArgumentException("interval is not a valid interval value", "interval");

			return new Pitch(note.value - interval.Semitones);
		}

		public static Pitch Subtract(Pitch note, int offset)
		{
			if (object.ReferenceEquals(note, null)) throw new ArgumentException("note is not a valid pitch value", "note");

			return new Pitch(note.value - offset);
		}

		public static Pitch Flatten(Pitch note)
		{
			if (object.ReferenceEquals(note, null)) throw new ArgumentException("note is not a valid pitch value", "note");

			return new Pitch(note.value - 1);
		}

		public static Interval Difference(Pitch left, Pitch right)
		{
			if (object.ReferenceEquals(left, null)) throw new ArgumentException("note is not a valid pitch value", "left");
			if (object.ReferenceEquals(right, null)) throw new ArgumentException("note is not a valid pitch value", "right");

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
