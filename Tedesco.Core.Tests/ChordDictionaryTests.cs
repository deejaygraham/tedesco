using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
    public class ChordDictionaryTests
    {
        [Fact]
        public void ChordDictionary_Major_Chord_Is_135()
        {
            var fMajor = new ChordBuilder()
                .FromPattern(
                    new ScaleBuilder()
                    .FromPattern(MidiValue.F3, WellKnownIntervalPattern.Major), 
                    WellKnownChord.Major);

            string[] expected = new string[] { "F", "A", "C" };

            var noteNames = fMajor.Values.Select(n => n.Name);

            Assert.True(noteNames.SequenceEqual(expected));

            // roman numerals 1 2 4 5 etc. 

            // kodaly ?
        }
    }
}
