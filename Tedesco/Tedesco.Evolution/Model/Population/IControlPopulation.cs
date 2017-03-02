using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution
{
	public interface IControlPopulation<T>
	{
		ICollection<T> CreateInstances(int populationSize);
	}
}
