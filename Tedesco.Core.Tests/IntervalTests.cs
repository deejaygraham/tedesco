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
		}

		[Fact]
		public void Intervals_Are_Equal_Based_On_Value()
		{
			Assert.Equal(new Interval(5), Interval.Fourth);
		}

		[Fact]
		public void Intervals_Are_Less_Than_Others()
		{
			Assert.True(Interval.Fifth < Interval.Octave);
		}

        [Fact]
        public void Intervals_Are_Less_Than_Or_Equal_To_Others()
        {
            Assert.True(Interval.Fifth <= new Interval(7));
        }


        [Fact]
        public void Intervals_Are_Greater_Than_Others()
        {
            Assert.True(Interval.Fifth > Interval.Step);
        }

        [Fact]
        public void Intervals_Are_Greater_Than_Or_Equal_To_Others()
        {
            Assert.True(Interval.Octave >= new Interval(12));
        }

        [Fact]
        public void Intervals_Have_Names()
        {
            Assert.Equal("octave", Interval.Octave.ToString());
            Assert.Equal("perfect fifth", Interval.Fifth.ToString());
            Assert.Equal("unison", (new Note(40) - new Note(40)).ToString());
        }

        [Fact]
        public void Interval_Too_Big_Has_Unknown_Name()
        {
            Assert.Equal("unknown", new Interval(24).ToString());
        }

        [Fact]
        public void Intervals_Separated_By_Octave_Are_Related()
        {
            Assert.True(new Interval(2).RelatedTo(new Interval(14)));
        }

    }
}
