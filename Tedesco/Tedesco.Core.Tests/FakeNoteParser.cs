using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Tests
{
	public class FakeNoteParser : IReadPitches
	{
		private List<Pitch> pitches = new List<Pitch>();

		public static FakeNoteParser Parser()
		{
			return new FakeNoteParser();
		}

		public FakeNoteParser WithPitch(Pitch p)
		{
			this.pitches.Add(p);

			return this;
		}

		public IEnumerable<Pitch> ReadToEnd()
		{
			return this.pitches;
		}
	}

}
