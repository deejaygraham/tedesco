using System;
using System.Collections.Generic;

namespace Tedesco
{
	public class FingeringDuplicateFinder : IEqualityComparer<Fingering>
	{
		public bool Equals(Fingering x, Fingering y)
		{
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");

            return x.ToString().CompareTo(y.ToString()) == 0;
		}

		public int GetHashCode(Fingering obj)
		{
            if (obj == null) throw new ArgumentNullException("obj");

            return obj.GetHashCode();
		}
	}
}
