using System.Collections.Generic;

namespace Tedesco
{
	public interface IReadNotes
	{
		IEnumerable<Note> ReadToEnd();
	}
}
