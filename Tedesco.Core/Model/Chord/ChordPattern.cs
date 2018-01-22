using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
    public class ChordPattern
    {
        private readonly List<ScaleDegree> pattern = new List<ScaleDegree>();

        public static ChordPattern FromString(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentNullException("pattern");

            string[] words = pattern.Split(new char[] { ',' });

            var cp = new ChordPattern();

            foreach (string word in words.Where(w => !String.IsNullOrWhiteSpace(w)))
            {
                int accidental = 0;

                string candidate = word.Trim();

                if (candidate.StartsWith("#"))
                {
                    accidental = 1;
                    candidate = candidate.Substring(1);
                }
                else if (candidate.StartsWith("b"))
                {
                    accidental = -1;
                    candidate = candidate.Substring(1);
                }

                int value = Convert.ToInt32(candidate);

                if (value > 0)
                {
                    value += accidental;

                    var degrees = new ScaleDegree[] 
                    {
                        ScaleDegree.First,
                        ScaleDegree.Second,
                        ScaleDegree.Third,
                        ScaleDegree.Fourth,
                        ScaleDegree.Fifth,
                        ScaleDegree.Sixth,
                        ScaleDegree.Seventh,
                        ScaleDegree.Octave,
                        ScaleDegree.FlatNinth,
                        ScaleDegree.Ninth,
                        ScaleDegree.SharpNinth,
                        ScaleDegree.Eleventh,
                        ScaleDegree.SharpEleventh,
                        ScaleDegree.Thirteen

                    };

                    if (value < 1 || value > degrees.Length)
                        throw new ArgumentOutOfRangeException("pattern", string.Format("Don't understand chord degree {0} -> {1}", words, value));

                    cp.Add(degrees[value - 1]);
                }
            }

            return cp;
        }

        public void Add(ScaleDegree s)
        {
            this.pattern.Add(s);
        }

        public IReadOnlyCollection<ScaleDegree> Values
        {
            get
            {
                return new ReadOnlyCollection<ScaleDegree>(this.pattern);
            }
        }
    }

}
