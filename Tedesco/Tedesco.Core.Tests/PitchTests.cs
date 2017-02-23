using Xunit;
using System;

namespace Tedesco.Tests
{
	public class PitchTests
	{
		[Fact]
		public void Pitch_Throws_An_Exception_For_Negative_Values()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				new Pitch(-1);
			});
		}

		[Fact]
		public void Pitches_Are_Constructable_With_Values_Greater_Than_Midi_Max_Value()
		{
			Assert.NotNull(new Pitch(128));
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
