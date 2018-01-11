using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
    public class ScaleBuilderTests
    {
        [Fact]
        public void ScaleBuilder_Chromatic_Scale_Notes_Ascend_Separated_By_Semitone()
        {
            var scale = new ScaleBuilder().FromPattern(MidiValue.MiddleC, WellKnownIntervalPattern.Chromatic);

            Note last = scale.Values.First();

            foreach(var note in scale.Values.Skip(1))
            {
                Assert.True(note > last);
                Assert.Equal(1, (note - last).Semitones);

                last = note;
            }
        }

        [Fact]
        public void ScaleBuilder_CMajor_Scale_Contains_No_Accidentals()
        {
            var scale = new ScaleBuilder().FromPattern(MidiValue.MiddleC, WellKnownIntervalPattern.Major);

            Assert.Equal(MidiValue.MiddleC, scale.Values.First().Value);
            Assert.Equal(MidiValue.D3, scale.Values.Skip(1).First().Value);
            Assert.Equal(MidiValue.E3, scale.Values.Skip(2).First().Value);
            Assert.Equal(MidiValue.F3, scale.Values.Skip(3).First().Value);
            Assert.Equal(MidiValue.G3, scale.Values.Skip(4).First().Value);
            Assert.Equal(MidiValue.A3, scale.Values.Skip(5).First().Value);
            Assert.Equal(MidiValue.B3, scale.Values.Skip(6).First().Value);
        }

        [Fact]
        public void ScaleBuilder_FMajor_Scale_Contains_One_Accidental()
        {
            var scale = new ScaleBuilder().FromPattern(MidiValue.F3, WellKnownIntervalPattern.Major);

            Assert.Equal(MidiValue.F3, scale.Values.First().Value);
            Assert.Equal(MidiValue.G3, scale.Values.Skip(1).First().Value);
            Assert.Equal(MidiValue.A3, scale.Values.Skip(2).First().Value);
            Assert.Equal(MidiValue.BFlat3, scale.Values.Skip(3).First().Value);
            Assert.Equal(MidiValue.C4, scale.Values.Skip(4).First().Value);
            Assert.Equal(MidiValue.D4, scale.Values.Skip(5).First().Value);
            Assert.Equal(MidiValue.E4, scale.Values.Skip(6).First().Value);
        }

        [Fact]
        public void ScaleBuilder_DMinor_Scale_Contains_One_Accidental()
        {
            var scale = new ScaleBuilder().FromPattern(MidiValue.D3, WellKnownIntervalPattern.Minor);

            Assert.Equal(MidiValue.D3, scale.Values.First().Value);
            Assert.Equal(MidiValue.E3, scale.Values.Skip(1).First().Value);
            Assert.Equal(MidiValue.F3, scale.Values.Skip(2).First().Value);
            Assert.Equal(MidiValue.G3, scale.Values.Skip(3).First().Value);
            Assert.Equal(MidiValue.A3, scale.Values.Skip(4).First().Value);
            Assert.Equal(MidiValue.BFlat3, scale.Values.Skip(5).First().Value);
            Assert.Equal(MidiValue.C4, scale.Values.Skip(6).First().Value);
        }

        [Fact]
        public void ScaleBuilder_GFlatMajor_Equivalent_To_FSharpMajor()
        {
            var gFlatMajor = new ScaleBuilder().FromPattern(MidiValue.GFlat3, WellKnownIntervalPattern.Major);
            var fSharpMajor = new ScaleBuilder().FromPattern(MidiValue.FSharp3, WellKnownIntervalPattern.Major);

            Assert.Equal(gFlatMajor, fSharpMajor);
        }

    }
}
