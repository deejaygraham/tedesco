using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
    public class Key
    {
        // diatonic key signature

        public static readonly Key CMajor = new Key(new Pitch[] 
        {
            new Pitch(MidiValue.C0),
            new Pitch(MidiValue.D0),
            new Pitch(MidiValue.E0),
            new Pitch(MidiValue.F0),
            new Pitch(MidiValue.G0),
            new Pitch(MidiValue.A0),
            new Pitch(MidiValue.B0),
            new Pitch(MidiValue.C1),
        });

        public static readonly Key DMajor = new Key(new Pitch[] 
        {
            new Pitch(MidiValue.D0),
            new Pitch(MidiValue.E0),
            new Pitch(MidiValue.FSharp0),
            new Pitch(MidiValue.G0),
            new Pitch(MidiValue.A0),
            new Pitch(MidiValue.B0),
            new Pitch(MidiValue.C1),
            new Pitch(MidiValue.D1),
        });

        public static readonly Key GMajor = new Key(new Pitch[]
        {
        });

        public static readonly Key FMajor = new Key(new Pitch[]
        {
        });

        private List<Pitch> notes = new List<Pitch>(new Pitch[] { });

        public Key()
        {
            this.notes = new List<Pitch>();
        }

        public Key(IEnumerable<Pitch> pitches)
        {
            this.notes = new List<Pitch>(pitches);
        }

        public Pitch this[ScaleDegree degree]
        {
            get
            {
                int index = (int)degree;

                if (index >= this.notes.Count) throw new ArgumentOutOfRangeException("degree");

                return this.notes[index];
            }
        }

        public Key RotateClockwise()
        {
            var key = new Key();

            foreach(var n in this.notes)
            {
                key.notes.Add(n.SharpenBy(IntervalDistance.PerfectFifth));
            }

            return key;
        }
    }
}
