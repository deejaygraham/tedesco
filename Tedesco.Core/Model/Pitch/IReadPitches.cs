using System.Collections.Generic;

namespace Tedesco
{
	public interface IReadPitches
	{
		IEnumerable<Pitch> ReadToEnd();
	}
}
