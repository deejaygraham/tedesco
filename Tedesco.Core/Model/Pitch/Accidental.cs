using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
    public class Accidental
    {
        private static readonly Dictionary<string, int> accidentalDictionary = new Dictionary<string, int>
        {
            // sharps
            { "#", 1 },
            { "s", 1 },
            { "^", 1 },
            // flats
            { "b", -1 },
            { "_", -1 },
        };

        public static Accidental FromString(string candidate)
        {
            if (string.IsNullOrEmpty(candidate)) return null;

            string accidentalChar = candidate.Substring(0, 1);

            if (accidentalDictionary.ContainsKey(accidentalChar))
            {
                return new Accidental(accidentalDictionary[accidentalChar]);
            }

            return null;
        }

        private Accidental(int sharpOrFlat)
        {
            this.Value = sharpOrFlat;
        }

        public int Value { get; private set; }
    }
}
