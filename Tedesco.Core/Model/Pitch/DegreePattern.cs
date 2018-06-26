using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
    /// <summary>
    /// List of intervals with reference to a tonic note. 
    /// E.g. Major Triad : 1, 3, 5
    /// </summary>
    [Obsolete("Using IntervalPattern instead")]
    public class DegreePattern
    {
        private readonly List<ScaleDegree> pattern;

        public DegreePattern()
        {
            this.pattern = new List<ScaleDegree>();
        }

        public DegreePattern(IEnumerable<ScaleDegree> degrees)
            : this()
        {
            if (degrees == null) throw new ArgumentNullException("degrees", "ScaleDegree collection cannot be null");

            foreach(var degree in degrees)
            {
                this.pattern.Add(degree);
            }
        }

        public void Add(ScaleDegree i)
        {
            this.pattern.Add(i);
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
