using Xunit;

namespace Tedesco.Tests
{
	public class ScaleTests
	{
		[Fact]
		public void Chromatic_Scale_Intervals_Are_Single_Semitone_Apart()
		{
			var dictionary = new ScaleDictionary();

			var intervals = dictionary[WellKnownScale.Chromatic];

			foreach(var v in intervals.Values)
			{
				Assert.Equal(1, v.Semitones);
			}
		}

		[Fact]
		public void Whole_Scale_Intervals_Are_Two_Semitones_Apart()
		{
			var dictionary = new ScaleDictionary();

			var intervals = dictionary[WellKnownScale.WholeTone];

			foreach (var v in intervals.Values)
			{
				Assert.Equal(2, v.Semitones);
			}
		}

		[Fact]
		public void C_Major_Scale_Single_Octave_Does_Not_Contain_Accidentals_Notes()
		{
			var dictionary = new ScaleDictionary();

			var scale = dictionary.Build(new Pitch(MidiNoteValue.MiddleC), WellKnownScale.Major);

			foreach(var pitch in scale.Values)
			{
				Assert.DoesNotContain("b", pitch.MidiName);
				Assert.DoesNotContain("#", pitch.MidiName);
			}
		}

		[Fact]
		public void C_Major_Scale_Two_Octave_Does_Not_Contain_Accidentals_Notes()
		{
			var dictionary = new ScaleDictionary();

			var scale = dictionary.Build(new Pitch(MidiNoteValue.MiddleC), WellKnownScale.Major, 2);

			foreach (var pitch in scale.Values)
			{
				Assert.DoesNotContain("b", pitch.MidiName);
				Assert.DoesNotContain("#", pitch.MidiName);
			}
		}

	}
}
