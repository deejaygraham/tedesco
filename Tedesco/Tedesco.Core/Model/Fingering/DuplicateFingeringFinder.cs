using System.Collections.Generic;

namespace Tedesco
{
	public class FingeringDuplicateFinder : IEqualityComparer<Fingering>
	{
		public bool Equals(Fingering x, Fingering y)
		{
			return x.ToString().CompareTo(y.ToString()) == 0;
		}

		public int GetHashCode(Fingering obj)
		{
			return obj.GetHashCode();
		}
	}
}
