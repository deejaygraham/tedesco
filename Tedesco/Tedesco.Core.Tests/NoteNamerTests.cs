using Xunit;

namespace Tedesco.Tests
{
	public class NoteNamerTests
	{
		[Fact]
		public void Recognizes_C0_As_Lowest_Midi_Number()
		{
			Assert.Equal(new Pitch(0), NoteNamer.PitchOf("C0"));
		}

		[Fact]
		public void Recognizes_Sharp_Modifiers()
		{
			Assert.Equal(new Pitch(1), NoteNamer.PitchOf("C#0"));
		}

		[Fact]
		public void Recognizes_Flat_Modifiers()
		{
			Assert.Equal(new Pitch(1), NoteNamer.PitchOf("Db0"));
		}

		[Fact]
		public void Recognizes_C5_As_Middle_C()
		{
			Assert.Equal(new Pitch(60), NoteNamer.PitchOf("C5"));
		}

		[Fact]
		public void Recognizes_G10_As_Highest_Midi_Number()
		{
			Assert.Equal(new Pitch(127), NoteNamer.PitchOf("G10"));
		}
	}
}
