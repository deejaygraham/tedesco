using System.Linq;
using Xunit;

namespace Tedesco.Tests
{
	public class PitchReaderTests
	{
		[Fact]
		public void Recognizes_Empty_String_As_Empty()
		{
			var reader = new NoteReader(new ABCNoteRecognizer());
			Assert.Empty(reader.ReadToEnd("                                                  "));
		}

		// c-1 is 0, c#-1 is 1, db-1 db0 db1 / g8 is 127

		[Fact]
		public void Recognizes_Comma_Delimited_ABC_Values()
		{
			var reader = new NoteReader(new ABCNoteRecognizer());

			var list = reader.ReadToEnd(" C3, G8,C-2		,		C3").ToList();

			Assert.Equal(4, list.Count());
			Assert.Equal(new Note(60), list[0]);
			Assert.Equal(new Note(127), list[1]);
			Assert.Equal(new Note(0), list[2]);
			Assert.Equal(new Note(60), list[3]);
		}

		[Fact]
		public void Matches_Lowest_Frequency_To_Midi_0()
		{
			// c 0
			var reader = new NoteReader(new NoteFrequencyRecognizer());
			Assert.Equal(new Note(0), reader.ReadToEnd("8.1758").ToList()[0]);
		}

		[Fact]
		public void Matches_Middle_C_To_Midi_60()
		{
			// middle c
			// 3c = 60
			var reader = new NoteReader(new NoteFrequencyRecognizer());
			Assert.Equal(new Note(60), reader.ReadToEnd("261.6256").ToList()[0]);
		}

		[Fact]
		public void Matches_Middle_CSharp_To_Midi_61()
		{
			// c#
			// 3d = 61
			var reader = new NoteReader(new NoteFrequencyRecognizer());
			Assert.Equal(new Note(61), reader.ReadToEnd("277.1827").ToList()[0]);
		}

		[Fact]
		public void Matches_A_Above_Middle_C_As_69()
		{
			// a 440 45 - 69
			var reader = new NoteReader(new NoteFrequencyRecognizer());
			Assert.Equal(new Note(69), reader.ReadToEnd("440.0").ToList()[0]);
		}

		[Fact]
		public void Matches_Highest_Midi_Note_As_127()
		{
			// g 7f - 127
			var reader = new NoteReader(new NoteFrequencyRecognizer());
			Assert.Equal(new Note(127), reader.ReadToEnd("12543.88").ToList()[0]);
		}

	}
}
