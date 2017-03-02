using System.Collections.Generic;

namespace Tedesco.Evolution
{
	public interface IMatchMaker<T>
	{
		ICollection<T> Match(ICollection<T> parents);
	}
}
