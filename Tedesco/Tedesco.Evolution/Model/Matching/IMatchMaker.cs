using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution
{
	public interface IMatchMaker<T>
	{
		ICollection<T> Match(ICollection<T> parents);
	}
}
