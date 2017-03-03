using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution
{
	/// <summary>
	/// Create population of a certain size based
	/// on template object.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ICreatePopulation<T>
	{
		/// <summary>
		/// Population Size.
		/// </summary>
		int Size { get; set; }

		/// <summary>
		/// Create an initial guess.
		/// </summary>
		/// <returns></returns>
		T CreateInitial();

		/// <summary>
		/// Create a population based on an example.
		/// </summary>
		/// <param name="example"></param>
		/// <param name="mutator"></param>
		/// <returns></returns>
		IEnumerable<T> CreatePopulation(T example, IMutator<T> mutator);
	}
}
