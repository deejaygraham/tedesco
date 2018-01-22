using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tedesco
{
    public class Chord : IEquatable<Chord>
    {
        private readonly List<Note> chord = new List<Note>();

        // root and scale degree list

        public Chord(Scale scale, ChordPattern pattern)
        {
            if (scale == null) throw new ArgumentNullException("scale");

            if (pattern == null) throw new ArgumentNullException("pattern");

            foreach (var degree in pattern.Values)
            {
                this.chord.Add(scale[degree]);
            }
        }

        public Chord(IEnumerable<Note> notes)
        {
            // de-duplicate
            this.chord = new List<Note>(notes);
        }


        public IReadOnlyCollection<Note> Values
        {
            get
            {
                return new ReadOnlyCollection<Note>(this.chord);
            }
        }

        public IntervalPattern Pattern()
        {
            var pattern = new IntervalPattern();

            var previous = this.Root();

            foreach (var note in this.chord.Skip(1))
            {
                var interval = note - previous;

                pattern.Add(interval);
                previous = note;
            }

            return pattern;
        }

        public IReadOnlyCollection<Solfege> AsSolfege()
        {
            var list = new List<Solfege>();

            foreach (var note in this.chord)
            {
                var interval = note - this.Root();

                list.Add(interval.AsSolfege());
            }

            return new ReadOnlyCollection<Solfege>(list);
        }

        public Note Root()
        {
            return new Note(this.chord.First());
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;

            if (object.ReferenceEquals(this, obj)) return true;

            if (this.GetType() != obj.GetType()) return false;

            return this.Equals(obj as Scale);
        }

        public bool Equals(Chord other)
        {
            if (object.ReferenceEquals(other, null)) return false;

            return this.Values.SequenceEqual(other.Values);
        }

    }
}

