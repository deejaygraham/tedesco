using Xunit;

namespace Tedesco.Tests
{
	public class MidiMathTests
	{
		[Fact]
		public void Recognizes_Concert_A_As_440()
		{
			Assert.Equal(new Note(69), MidiMath.NoteFromFrequency(440.0));
		}

		//[Fact]
		//public void Recognizes_Lowest_Midi_Frequency()
		//{
		//	var cminus2 = MidiMath.ToPitch(8.175);

		//	Assert.Equal("C-2", cminus2.MidiName);
		//	Assert.Equal(ScaleDegree.First, cminus2.Degree);
		//	Assert.Equal(0, cminus2.Octave);
		//}

		[Fact]
		public void Recognizes_Lowest_Piano_Frequency()
		{
			var pitch = MidiMath.NoteFromFrequency(27.5);

			Assert.Equal(new Note(21), pitch);
			Assert.Equal("A", pitch.Name);
		}

		//[Fact]
		//public void Recognizes_Middle_C_Frequency()
		//{
		//	var pitch = MidiMath.ToPitch(261.6);

		//	Assert.Equal(new Pitch(MidiNoteValue.MiddleC), pitch);
		//	Assert.Equal("A", pitch.Name);
		//}
	}
}
