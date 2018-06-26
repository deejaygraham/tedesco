using System;
using System.Collections.Generic;

namespace Tedesco
{
	public class FingeringDuplicateFinder : IEqualityComparer<Fingering>
	{
		public bool Equals(Fingering x, Fingering y)
		{
            if (x == null || y == null) return false;

            return String.Compare(x.ToString(), y.ToString(), StringComparison.OrdinalIgnoreCase) == 0;
		}

		public int GetHashCode(Fingering obj)
		{
            if (obj == null) throw new ArgumentNullException("obj");

            return obj.GetHashCode();
		}
	}
}
