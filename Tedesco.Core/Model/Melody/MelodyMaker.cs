using System;
using System.Collections.Generic;
using System.Linq;

namespace Tedesco
{
	public static class MelodyMaker
	{
		public static Melody Compose(FingerboardInstrument instrument, Fingering fingering)
		{
            if (instrument == null) throw new ArgumentNullException("instrument", "FingerboardInstrument argument cannot be null");
            if (fingering == null) throw new ArgumentNullException("fingering", "Fingering argument cannot be null");

            var notes = new List<Note>();

			fingering.Positions.ToList().ForEach(
				position =>
					notes.Add(instrument[position])
					);

			return new Melody(notes);
		}

		public static Melody Compose(IReadNotes parser)
		{
            if (parser == null) throw new ArgumentNullException("parser", "IReadNotes argument cannot be null");

            return new Melody(parser.ReadToEnd());
		}
	}
}
