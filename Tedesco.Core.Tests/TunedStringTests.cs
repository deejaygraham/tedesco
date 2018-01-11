using System.Linq;
using Xunit;

namespace Tedesco.Tests
{
	public class TunedStringTests
	{
		[Fact]
		public void Reports_Pitches_Relative_To_Open()
		{
			var ts = new TunedString(new Note(100), 1);

			Assert.True(ts.PitchAt(0).Degree < ts.PitchAt(5).Degree);
		}

		[Fact]
		public void Tuning_Can_Be_Changed()
		{
			var s = new TunedString(new Note(40), 6);

			s.TuneTo(new Note(45));

			Assert.Equal(new Note(45), s.PitchAt(0));
		}

		[Fact]
		public void Tuning_On_Single_String_Is_Self_Consistent()
		{
			var s = new TunedString(new Note(40), 6);

			Assert.Equal(new Note(45), s.PitchAt(5));
			Assert.Equal(new Note(52), s.PitchAt(12));
		}

		[Fact]
		public void Each_Fret_Increases_Pitch_By_Semitone()
		{
			var s = new TunedString(new Note(40), 6);

			for (int i = 0; i < 12; ++i)
			{
				Assert.Equal(s.PitchAt(i + 1), s.PitchAt(i) + new Interval(1));
			}
		}

		[Fact]
		public void Reports_Single_Position_For_Specific_Pitch()
		{
			var pitch = new Note(100);
			var ts = new TunedString(pitch, 1);

			Assert.Single(ts.FindAllPositionsFor(pitch.Sharpen()));
		}

		[Fact]
		public void Reports_Nothing_For_Too_High_Pitch()
		{
			var pitch = new Note(20);
			var ts = new TunedString(pitch, 1);

			Assert.Empty(ts.FindAllPositionsFor(new Note(220)));
		}

		[Fact]
		public void Reports_Nothing_For_Too_Low_Pitch()
		{
			var pitch = new Note(100);
			var ts = new TunedString(pitch, 1);

			Assert.Empty(ts.FindAllPositionsFor(pitch.Flatten()));
		}

	}
}
