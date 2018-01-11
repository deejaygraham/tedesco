using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
    [DebuggerDisplay("{value}")]
    public sealed class Note : IEquatable<Note>, IComparable<Note>, IComparable, IEquatable<MidiValue>
    {
        private readonly int value;

        public Note(MidiValue midiValue)
            : this((int)midiValue)
        {
        }

        public Note(Note note)
        {
            this.value = note.value;
        }

        public Note(int midiValue)
        {
            if (midiValue < 0) throw new ArgumentOutOfRangeException("midiValue", "Value cannot be negative");

            this.value = midiValue;
        }

        public Note(int scaleDegree, int octave, MidiOctaveFormat format = MidiOctaveFormat.Standard)
        {
            if (octave < -2) throw new OctaveValueException(octave);

            int octaveModifier = format == MidiOctaveFormat.Standard ? 2 : 1;

            this.value = PitchScaler.Scale(scaleDegree) + (Interval.Octave.Semitones * (octaveModifier + octave));
        }

        public static implicit operator MidiValue(Note n)
        {
            return (MidiValue)n.value;
        }
        
        public static implicit operator Note(MidiValue mp)
        {
            return new Note(mp);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override string ToString()
        {
            return this.value.ToString();
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

        public int Octave
        {
            get
            {
                return OctaveCalculator.OctaveOf(this.value);
            }
        }

        public ScaleDegree Degree
        {
            get
            {
                return (ScaleDegree)(PitchScaler.Scale(this.value));
            }
        }

        public MidiValue Value
        {
            get
            {
                return (MidiValue) this.value;
            }
        }
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;

            if (object.ReferenceEquals(this, obj)) return true;

            if (this.GetType() != obj.GetType()) return false;

            return this.Equals(obj as Note);
        }

        public bool Equals(Note other)
        {
            if (object.ReferenceEquals(other, null)) return false;

            return this.value == other.value;
        }

        public int CompareTo(object obj)
        {
            Note other = obj as Note;

            if (object.ReferenceEquals(other, null)) throw new ArgumentException("Argument is not a valid Note value", "obj");

            return this.CompareTo(other);
        }

        public int CompareTo(Note other)
        {
            if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

            return this.value.CompareTo(other.value);
        }

        // notes are related if they are the same degree in a scale, regardless of octave
        public bool RelatedTo(Note other)
        {
            if (object.ReferenceEquals(other, null)) throw new ArgumentNullException("other");

            return PitchScaler.Scale(this.value) == PitchScaler.Scale(other.value); 
        }

        public Note Sharpen()
        {
            return new Note(this.value + 1);
        }

        public static Note operator ++(Note obj)
        {
            return obj.Sharpen();
        }

        public Note Flatten()
        {
            return new Note(this.value - 1);
        }

        public bool Equals(MidiValue other)
        {
            return this.value == (int)other;
        }

        public static Note operator --(Note obj)
        {
            return obj.Flatten();
        }

        // Operator overloads

        public static bool operator ==(Note left, Note right)
        {
            if (object.ReferenceEquals(left, null)) return false;
            if (object.ReferenceEquals(right, null)) return false;

            return left.CompareTo(right) == 0;
        }

        public static bool operator !=(Note left, Note right)
        {
            if (object.ReferenceEquals(left, null)) return true;
            if (object.ReferenceEquals(right, null)) return true;

            return left.CompareTo(right) != 0;
        }

        public static bool operator ==(Note left, MidiValue right)
        {
            if (object.ReferenceEquals(left, null)) return false;

            return left.value == (int)right;
        }

        public static bool operator !=(Note left, MidiValue right)
        {
            if (object.ReferenceEquals(left, null)) return false;

            return left.value != (int)right;
        }

        public static bool operator ==(MidiValue right, Note left)
        {
            if (object.ReferenceEquals(left, null)) return false;

            return left.value == (int)right;
        }

        public static bool operator !=(MidiValue right, Note left)
        {
            if (object.ReferenceEquals(left, null)) return false;

            return left.value != (int)right;
        }

        public static bool operator <(Note left, Note right)
        {
            if (object.ReferenceEquals(left, null)) return false;
            if (object.ReferenceEquals(right, null)) return false;

            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Note left, Note right)
        {
            if (object.ReferenceEquals(left, null)) return false;
            if (object.ReferenceEquals(right, null)) return false;

            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Note left, Note right)
        {
            if (object.ReferenceEquals(left, null)) throw new ArgumentException("left is not a valid note value", "left");
            if (object.ReferenceEquals(right, null)) throw new ArgumentException("right is not a valid note value", "right");

            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Note left, Note right)
        {
            if (object.ReferenceEquals(left, null)) throw new ArgumentException("left is not a valid note value", "left");
            if (object.ReferenceEquals(right, null)) throw new ArgumentException("right is not a valid note value", "right");

            return left.CompareTo(right) >= 0;
        }


        /// <summary>
        /// Difference between one note and another is the distance between the two,
        /// positive or negative and is called the interval.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Interval operator- (Note left, Note right)
        {
            return new Interval(left.value - right.value);
        }

        public static Note operator +(Note note, Interval interval)
        {
            return new Note(note.value + interval.Semitones);
        }


        //public static Note operator +(Note note, Interval interval)
        //{
        //    return Pitch.Add(note, interval);
        //}

        //public static Pitch operator -(Pitch note, int offset)
        //{
        //    return Pitch.Subtract(note, offset);
        //}

        //public static Interval operator -(Pitch left, Pitch right)
        //{
        //    return Pitch.Difference(left, right);
        //}

    }
}
