using Xunit;

namespace Tedesco.Tests
{
	public class NoteNamerTests
	{
		[Fact]
		public void Recognizes_CMinus2_As_Midi_C_Zero()
		{
			Assert.Equal(new Note(0), NoteNamer.FromName("C-2"));
		}

		[Fact]
		public void Recognizes_CMinus1_As_Midi_C_12()
		{
			Assert.Equal(new Note(12), NoteNamer.FromName("C-1"));
		}

		[Fact]
		public void Recognizes_C3_As_Standard_Middle_C()
		{
			Assert.Equal(new Note(60), NoteNamer.FromName("C3"));
		}

		[Fact]
		public void Recognizes_C4_As_Higher_Middle_C()
		{
			Assert.Equal(new Note(60), NoteNamer.FromName("C4", MidiOctaveFormat.Higher));
		}

		[Fact]
		public void Recognizes_C1_As_Next_Octave_Midi_Number()
		{
			Assert.Equal(new Note(36), NoteNamer.FromName("C1"));
		}
		
		[Fact]
		public void Recognizes_Sharp_Modifiers()
		{
			Assert.Equal(new Note(25), NoteNamer.FromName("C#0"));
			Assert.Equal(new Note(37), NoteNamer.FromName("C#1"));
		}

		[Fact]
		public void Recognizes_Flat_Modifiers()
		{
			Assert.Equal(new Note(25), NoteNamer.FromName("Db0"));
		}

		[Fact]
		public void Recognizes_C3_As_Middle_C()
		{
			Assert.Equal(new Note(60), NoteNamer.FromName("C3"));
		}

		[Fact]
		public void Recognizes_G8_As_Highest_Midi_Number()
		{
			Assert.Equal(new Note(127), NoteNamer.FromName("G8"));
		}
	}
}
