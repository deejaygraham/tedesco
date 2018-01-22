using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
    public sealed class ChordBuilder
    {
        private readonly ChordDictionary dictionary = new ChordDictionary();

        public Chord FromPattern(Scale scale, WellKnownChord canned)
        {
            var pattern = this.dictionary[canned];

            return new Chord(scale, pattern);
        }
    }

}
