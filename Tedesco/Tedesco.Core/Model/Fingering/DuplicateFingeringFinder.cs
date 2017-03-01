using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
