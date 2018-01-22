using System.Linq;
using Xunit;

namespace Tedesco.Tests
{
    public class IntervalPatternTests
    {
        [Fact]
        public void IntervalPattern_Creates_Interval_For_Each_Value()
        {
            string ri = "2,1,2,1,3,2,1";

            var pattern = IntervalPattern.FromString(ri);

            Assert.Equal(7, pattern.Values.Count);
        }

        [Fact]
        public void IntervalPattern_Understands_Sharp_Prefix()
        {
            string ri = "#2,1";

            var pattern = IntervalPattern.FromString(ri);

            Assert.Equal(Interval.MinorThird, pattern.Values.First());
        }

        [Fact]
        public void IntervalPattern_Understands_Flat_Prefix()
        {
            string ri = "2, b3";

            var pattern = IntervalPattern.FromString(ri);

            Assert.Equal(Interval.Step, pattern.Values.Skip(1).First());
        }

        [Fact]
        public void Chromatic_Scale_Intervals_Are_Single_Semitone_Apart()
        {
            var dictionary = new IntervalPatternDictionary();

            var pattern = dictionary[WellKnownIntervalPattern.Chromatic];

            foreach (var interval in pattern.Values)
            {
                Assert.Equal(1, interval.Semitones);
            }
        }

        [Fact]
        public void Whole_Scale_Intervals_Are_Two_Semitones_Apart()
        {
            var dictionary = new IntervalPatternDictionary();

            var pattern = dictionary[WellKnownIntervalPattern.WholeTone];

            foreach (var interval in pattern.Values)
            {
                Assert.Equal(2, interval.Semitones);
            }
        }

    }
}
