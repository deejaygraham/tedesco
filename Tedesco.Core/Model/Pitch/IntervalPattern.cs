using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tedesco
{
    /// <summary>
    /// List of differences between successive intervals used in scales and chords 
    /// e.g. major scale: 2, 2, 1, 2, 2, 2, 1 
    /// </summary>
	public class IntervalPattern
	{
		private List<Interval> pattern = new List<Interval>();

        public static IntervalPattern FromString(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentNullException("pattern");

            string[] words = pattern.Split(new char[] { ',' });

            var ip = new IntervalPattern();

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
                    ip.Add(new Interval(value));
                }
            }

            return ip;
        }

        public void Add(Interval i)
		{
			this.pattern.Add(i);
		}

        public IReadOnlyCollection<Interval> Values
        {
            get
            {
                return new ReadOnlyCollection<Interval>(this.pattern);
            }
        }
    }
}
