using System.Linq;
using Xunit;

namespace Tedesco.Tests
{
	public class PitchReaderTests
	{
		[Fact]
		public void Recognizes_Empty_String_As_Empty()
		{
			var reader = new PitchReader(new ABCPitchRecognizer());
			Assert.Equal(0, reader.ReadToEnd("                                                  ").Count());
		}

		[Fact]
		public void Recognizes_Comma_Delimited_ABC_Values()
		{
			var reader = new PitchReader(new ABCPitchRecognizer());

			var list = reader.ReadToEnd(" C5, G10,C0		,		C5").ToList();

			Assert.Equal(4, list.Count());
			Assert.Equal(new Pitch(60), list[0]);
			Assert.Equal(new Pitch(127), list[1]);
			Assert.Equal(new Pitch(0), list[2]);
			Assert.Equal(new Pitch(60), list[3]);
		}

		[Fact]
		public void Matches_Lowest_Frequency_To_Midi_0()
		{
			// c 0
			var reader = new PitchReader(new FrequencyPitchRecognizer());
			Assert.Equal(new Pitch(0), reader.ReadToEnd("8.1758").ToList()[0]);
		}

		[Fact]
		public void Matches_Middle_C_To_Midi_60()
		{
			// middle c
			// 3c = 60
			var reader = new PitchReader(new FrequencyPitchRecognizer());
			Assert.Equal(new Pitch(60), reader.ReadToEnd("261.6256").ToList()[0]);
		}

		[Fact]
		public void Matches_Middle_CSharp_To_Midi_61()
		{
			// c#
			// 3d = 61
			var reader = new PitchReader(new FrequencyPitchRecognizer());
			Assert.Equal(new Pitch(61), reader.ReadToEnd("277.1827").ToList()[0]);
		}

		[Fact]
		public void Matches_A_Above_Middle_C_As_69()
		{
			// a 440 45 - 69
			var reader = new PitchReader(new FrequencyPitchRecognizer());
			Assert.Equal(new Pitch(69), reader.ReadToEnd("440.0").ToList()[0]);
		}

		[Fact]
		public void Matches_Highest_Midi_Note_As_127()
		{
			// g 7f - 127
			var reader = new PitchReader(new FrequencyPitchRecognizer());
			Assert.Equal(new Pitch(127), reader.ReadToEnd("12543.88").ToList()[0]);
		}

	}
}
