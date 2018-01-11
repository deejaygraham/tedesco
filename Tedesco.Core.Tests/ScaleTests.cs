using Xunit;
using System.Linq;

namespace Tedesco.Tests
{
	public class ScaleTests
	{
        [Fact]
        public void C_Major_Scale_Single_Octave_Does_Not_Contain_Accidentals_Notes()
        {
            var dictionary = new ScaleBuilder();

            var scale = dictionary.FromPattern(new Note((int)MidiValue.MiddleC), WellKnownIntervalPattern.Major);

            foreach (var pitch in scale.Values)
            {
                Assert.DoesNotContain("b", pitch.MidiName);
                Assert.DoesNotContain("#", pitch.MidiName);
            }
        }

        [Fact]
        public void C_Major_Scale_Two_Octave_Does_Not_Contain_Accidentals_Notes()
        {
            var dictionary = new ScaleBuilder();

            var scale = dictionary.FromPattern(new Note((int)MidiValue.MiddleC), WellKnownIntervalPattern.Major, 2);

            foreach (var pitch in scale.Values)
            {
                Assert.DoesNotContain("b", pitch.MidiName);
                Assert.DoesNotContain("#", pitch.MidiName);
            }
        }

        [Fact]
        public void Scale_Transpose_Progresses_Around_Circle_Of_Fifths()
        {
            var cMajor = new ScaleBuilder().FromPattern(MidiValue.MiddleC, WellKnownIntervalPattern.Major);
            Assert.Equal("C", cMajor.Root().Name);

            string[] circleOfFifths = new string[] { "G", "D", "A", "E", "B", "F#", "C#", "G#", "D#", "A#", "F", "C" };

            var start = cMajor;

            foreach(string root in circleOfFifths)
            {
                var next = start.Transpose(Interval.Fifth);
                Assert.Equal(root, next.Root().Name);

                start = next;
            }
        }

        [Fact]
        public void Scale_Transpose_Progresses_Around_Circle_Of_Fourths()
        {
            var cMajor = new ScaleBuilder().FromPattern(MidiValue.MiddleC, WellKnownIntervalPattern.Major);
            Assert.Equal("C", cMajor.Root().Name);

            string[] circleOfFourths = new string[] { "F", "A#", "D#", "G#", "C#", "F#", "B", "E", "A", "D", "G", "C" };

            var start = cMajor;

            foreach (string root in circleOfFourths)
            {
                var next = start.Transpose(Interval.Fourth);
                Assert.Equal(root, next.Root().Name);

                start = next;
            }
        }

        [Fact]
        public void Scale_Mode_C_Major_First_Mode_Is_C()
        {
            var cMajor = new ScaleBuilder().FromPattern(MidiValue.MiddleC, WellKnownIntervalPattern.Major);
            Assert.Equal("C", cMajor.Root().Name);

            string[] dModal = new string[] { "C", "D", "E", "F", "G", "A", "B", "C" };

            var modeNames = cMajor.Mode(1).Values.Select(n => n.Name);

            Assert.True(modeNames.SequenceEqual(dModal));
        }

        [Fact]
        public void Scale_Mode_C_Major_Second_Mode_Starts_At_D()
        {
            var cMajor = new ScaleBuilder().FromPattern(MidiValue.MiddleC, WellKnownIntervalPattern.Major);
            Assert.Equal("C", cMajor.Root().Name);

            string[] dModal = new string[] { "D", "E", "F", "G", "A", "B", "C", "D" };

            var modeNames = cMajor.Mode(2).Values.Select(n => n.Name);

            Assert.True(modeNames.SequenceEqual(dModal));
        }
    }
}
