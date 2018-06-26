using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Tedesco
{
    /// <summary>
    /// List of differences between successive intervals used in scales and chords 
    /// e.g. major scale: 2, 2, 1, 2, 2, 2, 1 
    /// </summary>
	public class IntervalPattern
	{
		private readonly List<Interval> pattern = new List<Interval>();

        public static IntervalPattern FromString(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentNullException("pattern");

            string[] words = pattern.Split(new char[] { ',' });

            var ip = new IntervalPattern();

            foreach (string word in words.Where(w => !String.IsNullOrWhiteSpace(w)))
            {
                string candidate = word.Trim();

                Accidental accidental = Accidental.FromString(candidate);

                if (accidental != null)
                    candidate = candidate.Substring(1);

                int value = Convert.ToInt32(candidate, CultureInfo.CurrentCulture);

                if (value > 0)
                {
                    if (accidental != null)
                        value += accidental.Value;

                    ip.Add(new Interval(value));
                }
            }

            return ip;
        }

        public void Add(Interval interval)
		{
            if (interval == null) throw new ArgumentNullException("interval", "Interval value cannot be null");

            this.pattern.Add(interval);
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
