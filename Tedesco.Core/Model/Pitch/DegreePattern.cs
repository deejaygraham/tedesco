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
    public class DegreePattern
    {
        private List<ScaleDegree> pattern;

        public DegreePattern()
        {
            this.pattern = new List<ScaleDegree>();
        }

        public DegreePattern(IEnumerable<ScaleDegree> degrees)
            : this()
        {
            foreach(var d in degrees)
            {
                this.pattern.Add(d);
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
