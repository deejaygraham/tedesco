using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
	public class TunedStringTests
	{
		[Fact]
		public void Tuning_Can_Be_Changed()
		{
			var s = new TunedString(new Pitch(40), 6);

			s.TuneTo(new Pitch(45));

			Assert.Equal(new Pitch(45), s.PitchAt(0));
		}

		[Fact]
		public void Tuning_On_Single_String_Is_Self_Consistent()
		{
			var s = new TunedString(new Pitch(40), 6);

			Assert.Equal(new Pitch(45), s.PitchAt(5));
			Assert.Equal(new Pitch(52), s.PitchAt(12));
		}

		[Fact]
		public void Each_Fret_Increases_Pitch_By_Semitone()
		{
			var s = new TunedString(new Pitch(40), 6);

			for (int i = 0; i < 12; ++i)
			{
				Assert.Equal(s.PitchAt(i + 1), s.PitchAt(i) + new Interval(1));
			}
		}
	}
}
