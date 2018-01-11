using System.Collections.Generic;

namespace Tedesco.Tests
{
	public class FakeNoteParser : IReadNotes
	{
		private List<Note> pitches = new List<Note>();

		public static FakeNoteParser Parser()
		{
			return new FakeNoteParser();
		}

		public FakeNoteParser WithPitch(Note p)
		{
			this.pitches.Add(p);

			return this;
		}

		public IEnumerable<Note> ReadToEnd()
		{
			return this.pitches;
		}
	}

}
