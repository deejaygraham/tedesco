using System.Collections.Generic;

namespace Tedesco.Evolution
{
	public interface IControlPopulation<T>
	{
		ICollection<T> CreateInstances(int populationSize);
	}
}
