using Xunit;

namespace Tedesco.Tests
{
	public class NoteNamerTests
	{
		[Fact]
		public void Recognizes_CMinus2_As_Midi_C_Zero()
		{
			Assert.Equal(new Pitch(0), NoteNamer.PitchOf("C-2"));
		}

		[Fact]
		public void Recognizes_CMinus1_As_Midi_C_12()
		{
			Assert.Equal(new Pitch(12), NoteNamer.PitchOf("C-1"));
		}

		[Fact]
		public void Recognizes_C3_As_Standard_Middle_C()
		{
			Assert.Equal(new Pitch(60), NoteNamer.PitchOf("C3"));
		}

		[Fact]
		public void Recognizes_C4_As_Higher_Middle_C()
		{
			Assert.Equal(new Pitch(72), NoteNamer.PitchOf("C4", MidiOctaveFormat.Higher));
		}

		[Fact]
		public void Recognizes_C1_As_Next_Octave_Midi_Number()
		{
			Assert.Equal(new Pitch(36), NoteNamer.PitchOf("C1"));
		}
		
		[Fact]
		public void Recognizes_Sharp_Modifiers()
		{
			Assert.Equal(new Pitch(25), NoteNamer.PitchOf("C#0"));
			Assert.Equal(new Pitch(37), NoteNamer.PitchOf("C#1"));
		}

		[Fact]
		public void Recognizes_Flat_Modifiers()
		{
			Assert.Equal(new Pitch(25), NoteNamer.PitchOf("Db0"));
		}

		[Fact]
		public void Recognizes_C3_As_Middle_C()
		{
			Assert.Equal(new Pitch(60), NoteNamer.PitchOf("C3"));
		}

		[Fact]
		public void Recognizes_G8_As_Highest_Midi_Number()
		{
			Assert.Equal(new Pitch(127), NoteNamer.PitchOf("G8"));
		}
	}
}
