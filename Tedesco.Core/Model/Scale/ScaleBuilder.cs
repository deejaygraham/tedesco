using System;
using System.Collections.Generic;

namespace Tedesco
{
	public sealed class ScaleBuilder
	{
        private readonly IntervalPatternDictionary dictionary = new IntervalPatternDictionary();

        public Scale FromPattern(MidiValue root, WellKnownIntervalPattern canned)
        {
            return this.FromPattern(new Note(root), canned, 1);
        }

        public Scale FromPattern(MidiValue root, WellKnownIntervalPattern canned, int octaves)
        {
            return this.FromPattern(new Note(root), canned, octaves);
        }

        public Scale FromPattern(Note root, WellKnownIntervalPattern canned)
        {
            return this.FromPattern(root, canned, 1);
        }

        public Scale FromPattern(Note root, WellKnownIntervalPattern canned, int octaves)
        {
            var pattern = this.dictionary[canned];

            return new Scale(root, pattern, octaves);
        }
	}
}
