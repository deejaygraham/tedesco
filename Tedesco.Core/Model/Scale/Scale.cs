using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tedesco
{
    /// <summary>
    /// List of ascending notes from a root note.
    /// Do, Re, Mi, Fa, So, La, Ti, Do
    /// </summary>
	public class Scale : IEquatable<Scale>
    {
		private readonly List<Note> scale = new List<Note>();

        public Scale(IntervalPattern pattern)
            : this(new Note(40), pattern, 1) // TODO : default to middle c ???
        {
        }

        public Scale(Note tonic, IntervalPattern pattern)
			: this(tonic, pattern, 1)
		{
		}

        public Scale(IEnumerable<Note> notes)
        {
            // need to be non-duplicated and ascending order ???

            this.scale = new List<Note>(notes);
        }

		public Scale(Note tonic, IntervalPattern pattern, int octaves)
		{
			if (tonic == null) throw new ArgumentNullException("tonic");

			if (pattern == null) throw new ArgumentNullException("pattern");

            if (octaves <= 0) throw new ArgumentOutOfRangeException("octaves");

			this.scale.Add(tonic);

			Note current = tonic;

			for (int octave = 0; octave < octaves; ++octave)
			{
				foreach (Interval v in pattern.Values)
				{
					current = current + v;
					this.scale.Add(current);
				}
			}
		}

        public Scale Transpose(Interval interval)
        {
            var transposedNotes = new List<Note>();

            foreach (var note in this.scale)
            {
                transposedNotes.Add(note + interval);
            }

            return new Scale(transposedNotes);
        }

        public Scale Mode(int number)
        {
            if ((number > 7) || (number <= 0)) throw new ArgumentOutOfRangeException("number");

            number -= 1;

            var modalNotes = new List<Note>();

            modalNotes.AddRange(this.scale.Skip(number));
            modalNotes.AddRange(this.scale.Skip(1).Take(this.scale.Count - modalNotes.Count));

            return new Scale(modalNotes);
        }

        public Note Root()
        {
            return new Note(this.scale.First());
        }

        public IReadOnlyCollection<Note> Values
		{
			get
			{
				return new ReadOnlyCollection<Note>(this.scale);
			}
		}

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;

            if (object.ReferenceEquals(this, obj)) return true;

            if (this.GetType() != obj.GetType()) return false;

            return this.Equals(obj as Scale);
        }

        public bool Equals(Scale other)
        {
            if (object.ReferenceEquals(other, null)) return false;

            return this.Values.SequenceEqual(other.Values);
        }
    }
}
