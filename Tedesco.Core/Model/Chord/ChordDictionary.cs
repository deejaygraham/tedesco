using System;
using System.Collections.Generic;

namespace Tedesco
{
    public class ChordDictionary
    {
        // chord root and quality
        // 7th, minor 7th, 7 sharp 11

        private Dictionary<WellKnownChord, string> chordLookup = new Dictionary<WellKnownChord, string>
            {
                { WellKnownChord.Major,  "1,3,5" },
                { WellKnownChord.Minor,  "1,b3,5" }
            };

        /*
Major Chords
            
Major          1-3-5
maj7           1-3-5-7
maj9           1-3-5-7-9
maj11         1-3-5-7-9-11
maj13         1-3-5-7-9-11-13
maj6           1-3-5-6
maj6/9        1-3-5-6-9
maj7 6/9     1-3-5-6-7-9
maj#5         1-3-#5
majb5         1-3-b5
maj7#5       1-3-#5-7
maj7b5       1-3-b5-7
maj9b5       1-3-b5-7-9
maj9#5       1-3-#5-7-9 
maj11b5     1-3-b5-7-9-11
maj11#5     1-3-#5-7-9-11
maj13b5     1-3-b5 7-9-11-13
maj13#5     1-3-#5-7-9-11-13
maj7b9       1-3-5-7-b9
maj7#9       1-3-5-7-#9
maj9#11     1-3-5-7-9-#11
maj11b13   1-3-5-7-9-11-b13
maj11#13   1-3-5-7-9-11-#13
maj11b9     1-3-5-7-b9-11
maj11#9     1-3-5-7-#9-11
maj13#11   1-3-5-7-9-#11-13
maj13b9     1-3-5-7-b9-11-13
maj13#9     1-3-5-7-#9-11-13
            
            Minor Chords
minor          1-b3-5
m7             1-b3-5-b7
m9             1-b3-5-b7-9
m11           1-b3-5-b7-9-11
m13           1-b3-5-b7-9-11-13
m6             1-b3-5-6
m6/9          1-b3-5-6-9
m7#5         1-b3-#5-b7
m7b5         1-b3-b5-b7
m9#5         1-b3-#5-b7-9
m11#5       1-b3-#5-b7-9-11
m13#5       1-b3-#5-b7-9-11-13
m7b9         1-b3-5-b7-b9
m9#11       1-b3-5-b7-9-#11
m9b11       1-b3-5-b7-9-b11
m11b13     1-b3-5-b7-9-11-b13
m11b9       1-b3-5-b7-b9-11
m13b11     1-b3-5-b7-9-b11-13
m13#11     1-b3-5-b7-9-#11-13
m13b9       1-b3-5-b7-b9-11-13
m13#9       1-b3-5-b7-#9-11-13
m(maj7)     1-b3-5-7
m(maj9)     1-b3-5-7-9
m(maj11)   1-b3-5-7-9-11
m(maj13)   1-b3-5-7-9-11-13

Dominant Chords
7           1-3-5-b7
9           1-3-5-b7-9
11         1-3-5-b7-9-11
13         1-3-5-b7-9-11-13
7b5       1-3-b5-b7
7#5       1-3-#5-b7
9b5       1-3-b5-b7-9
9#5       1-3-#5-b7-9
11b5     1-3-b5-b7-9-11
11#5     1-3-#5-b7-9-11
13b5     1-3-b5-b7-9-11-13
13#5     1-3-#5-b7-9-11-13
7b9       1-3-5-b7-9
7#9       1-3-5-b7-9
9#11     1-3-5-b7-9-#11
11b13    1-3-5-b7-9-11-b13
11b9      1-3-5-b7-b9-11
11#9      1-3-5-b7-#9-11
13#11    1-3-5-b7-9-#11-13
13b9      1-3-5-b7-b9-11-13
13#9      1-3-5-b7-#9-11-13
7 6/9      1-3-5-6-b7-9
            
            Diminished Chords
dim           1-b3-b5
dim7         1-b3-b5-bb7
dim9         1-b3-b5-bb7-9
dim11       1-b3-b5-bb7-9-11

    */

        public DegreePattern this[WellKnownChord chord]
        {
            get
            {
                if (!this.chordLookup.ContainsKey(chord))
                {
                    throw new ArgumentOutOfRangeException();
                }

                string intervalSequence = this.chordLookup[chord];

                return this.Build(intervalSequence);
            }
        }

        public Chord Build(Note root, WellKnownChord chord)
        {
            if (!this.chordLookup.ContainsKey(chord))
            {
                throw new ArgumentOutOfRangeException();
            }

            string intervalSequence = this.chordLookup[chord];

            return new Chord(root, this.Build(intervalSequence));
        }

        private DegreePattern Build(string pattern)
        {
            var ip = new DegreePattern();

            string[] words = pattern.Split(new char[] { ',' });

            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    ScaleDegree degree = ScaleDegree.Tonic;

                    // ignore the first or one that doesn't make sense.
                    if (Enum.TryParse<ScaleDegree>(word.Trim(), out degree) && degree != ScaleDegree.Tonic)
                        ip.Add(degree);
                }
            }

            return ip;
        }

    }
}

