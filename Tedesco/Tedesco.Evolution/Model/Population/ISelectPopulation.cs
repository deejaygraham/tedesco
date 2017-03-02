using System.Collections.Generic;

namespace Tedesco.Evolution
{
	public interface ISelectPopulation<T>
	{
		ICollection<T> Select(ICollection<T> population);
	}
}
