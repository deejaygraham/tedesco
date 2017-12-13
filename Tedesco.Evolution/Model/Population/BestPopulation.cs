using System;
using System.Collections.Generic;
using System.Linq;

namespace Tedesco.Evolution
{
	public class BestPopulation<T> : ISelectPopulation<T>
	{
		public BestPopulation(int howMany)
		{
			if (howMany <= 0) throw new ArgumentOutOfRangeException("number must be positive");

			this.HowMany = howMany;
		}

		private int HowMany { get; set; }

		public ICollection<T> Select(ICollection<T> population)
		{
			// sort the collection first ...

			return population.Take(this.HowMany).ToList();
		}
	}
}
