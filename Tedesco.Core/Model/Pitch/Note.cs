using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
            if (note == null) throw new ArgumentNullException("note", "Note value cannot be null");

            this.value = note.value;
            this.Duration = note.Duration;
        }

        public Note(int midiValue)
        {
            if (midiValue < 0) throw new ArgumentOutOfRangeException("midiValue", "Value cannot be negative");

            this.value = midiValue;
            this.Duration = 1;
        }

        public Note(int scaleDegree, int octave)
            : this(scaleDegree, octave, MidiOctaveFormat.Standard)
        {
        }

        public Note(int scaleDegree, int octave, MidiOctaveFormat format)
        {
            if (octave < -2) throw new OctaveValueException(octave);

            int octaveModifier = format == MidiOctaveFormat.Standard ? 2 : 1;

            this.value = PitchScaler.Scale(scaleDegree) + (Interval.Octave.Semitones * (octaveModifier + octave));
            this.Duration = 1;
        }

        public static implicit operator MidiValue(Note note)
        {
            if (note == null) return MidiValue.C0;

            return (MidiValue)note.value;
        }
        
        public static implicit operator Note(MidiValue value)
        {
            return new Note(value);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override string ToString()
        {
            return this.value.ToString(CultureInfo.CurrentCulture);
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
                return string.Format(CultureInfo.CurrentCulture, "{0}{1}", this.Name, this.Octave);
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

        // fraction of a whole note 4 = 1/4
        public int Duration { get; set; }

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
            if (obj == null) throw new ArgumentNullException("obj", "Note argument cannot be null");

            return obj.Sharpen();
        }

        public Note Increment()
        {
            return this.Sharpen();
        }

        public Note Flatten()
        {
            return new Note(this.value - 1);
        }

        public bool Equals(MidiValue other)
        {
            return this.value == (int)other;
        }

        public static Note operator --(Note note)
        {
            if (note == null) throw new ArgumentNullException("note", "Note argument cannot be null");

            return note.Flatten();
        }

        public Note Decrement()
        {
            return this.Flatten();
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
            if (left == null) throw new ArgumentNullException("left", "Note argument cannot be null");
            if (right == null) throw new ArgumentNullException("right", "Note argument cannot be null");

            return new Interval(left.value - right.value);
        }

        public static Interval Subtract(Note left, Note right)
        {
            if (left == null) throw new ArgumentNullException("left", "Note argument cannot be null");
            if (right == null) throw new ArgumentNullException("right", "Note argument cannot be null");

            return new Interval(left.value - right.value);
        }

        public static Note operator +(Note note, Interval interval)
        {
            if (note == null) throw new ArgumentNullException("note", "Note argument cannot be null");
            if (interval == null) throw new ArgumentNullException("interval", "Interval argument cannot be null");

            return new Note(note.value + interval.Semitones);
        }

        public static Interval Add(Note left, Note right)
        {
            if (left == null) throw new ArgumentNullException("left", "Note argument cannot be null");
            if (right == null) throw new ArgumentNullException("right", "Note argument cannot be null");

            return new Interval(left.value + right.value);
        }
    }
}
