using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
                string candidate = word.Trim();

                Accidental accidental = Accidental.FromString(candidate);
                
                if (accidental != null)
                {
                    candidate = candidate.Substring(1);
                }

                int value = Convert.ToInt32(candidate, CultureInfo.CurrentCulture);

                if (value > 0)
                {
                    if (accidental != null)
                        value += accidental.Value;

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
                        throw new ArgumentOutOfRangeException("pattern", string.Format(CultureInfo.CurrentCulture, "Don't understand chord degree {0} -> {1}", words, value));

                    cp.Add(degrees[value - 1]);
                }
            }

            return cp;
        }

        public void Add(ScaleDegree degree)
        {
            this.pattern.Add(degree);
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
