using Xunit;

namespace Tedesco.Tests
{
	public class IntervalTests
	{
		[Fact]
		public void Intervals_Are_Constructable_From_Semitones()
		{
			var i = new Interval(5);

			Assert.Equal(5, i.Semitones);
			Assert.Equal(IntervalDistance.PerfectFourth, i.Distance);
		}

		[Fact]
		public void Intervals_Are_Constructable_From_Distance()
		{
			var i = new Interval(IntervalDistance.PerfectUnison);

			Assert.Equal(0, i.Semitones);
			Assert.Equal(IntervalDistance.PerfectUnison, i.Distance);
		}

		[Fact]
		public void Intervals_Are_Equatable_By_Value()
		{
			Assert.Equal(new Interval(5), new Interval(IntervalDistance.PerfectFourth));
		}

		[Fact]
		public void Intervals_Are_Relatively_Comparable()
		{
			Assert.True(new Interval(IntervalDistance.PerfectFifth) < new Interval(IntervalDistance.PerfectOctave));
		}

	}
}
