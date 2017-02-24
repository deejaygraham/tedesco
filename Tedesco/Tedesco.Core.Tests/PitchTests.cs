using System;
using Xunit;

namespace Tedesco.Tests
{
	public class PitchTests
	{
		[Fact]
		public void Pitch_Compensates_For_Negative_Values()
		{
			Assert.Equal(new Pitch(1), new Pitch(-1));
		}

		[Fact]
		public void Pitches_Are_Constructable_With_Values_Greater_Than_Midi_Max_Value()
		{
			Assert.NotNull(new Pitch(128));
		}

		[Fact]
		public void Pitches_Are_Constructable_From_Midi_Values()
		{
			Assert.Equal(new Pitch(60), new Pitch(MidiNoteValue.MiddleC));
		}

		[Fact]
		public void Lowest_C_Is_Correct_Octave()
		{
			Assert.Equal("C-2", new Pitch(0).MidiName);
		}

		[Fact]
		public void Next_Lowest_C_Is_Correct_Octave()
		{
			Assert.Equal("C-1", new Pitch(12).MidiName);
		}

		[Fact]
		public void Middle_C_Is_Correct_Octave()
		{
			Assert.Equal("C3", new Pitch(MidiNoteValue.MiddleC).MidiName);
		}

		[Fact]
		public void Pitches_Can_Have_Negative_Octaves()
		{
			Assert.Equal(new Pitch(0), new Pitch(0, -2));
			Assert.Equal(new Pitch(12), new Pitch(0, -1));
		}

		[Fact]
		public void Pitches_Above_First_Octave_Ignore_Octave_Value()
		{
			Assert.Equal(new Pitch(60), new Pitch(60, 3));
		}

		[Fact]
		public void Pitches_Below_First_Octave_Use_Octave_Value()
		{
			Assert.Equal(new Pitch(60), new Pitch(0, 3));
		}

		[Fact]
		public void Sharpened_Pitch_Is_Higher_Than_Original()
		{
			var original = new Pitch(100);
			Assert.True(original.Sharpen() > original);
		}

		[Fact]
		public void Flattened_Pitch_Is_Lower_Than_Original()
		{
			var original = new Pitch(100);
			Assert.True(original.Flatten() < original);
		}

		[Fact]
		public void Pitch_Plus_Interval_Gives_Higher_Pitch()
		{
			var original = new Pitch(100);
			var second = new Interval(IntervalDistance.MajorSecond);

			var higher = original + second;

			Assert.True(higher > original);
			Assert.Equal(IntervalDistance.MajorSecond, (higher - original).Distance);
		}

	}
}
