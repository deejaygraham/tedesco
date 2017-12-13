using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tedesco
{
	public class IntervalPattern
	{
		private List<Interval> pattern = new List<Interval>();

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
