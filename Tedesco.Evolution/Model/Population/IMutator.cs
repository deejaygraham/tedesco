using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution
{
	/// <summary>
	/// Creates a new instance of an object based on a template, 
	/// depending on the mutation rate.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IMutator<T>
	{
		/// <summary>
		/// How often the example object 
		/// is likely to be changed.
		/// </summary>
		double Rate { get; set; }

		T Mutate(T example);
	}
}
