using System.Collections.Generic;
using System.Linq;

namespace Tedesco
{
	public class MelodyMaker
	{
		public Melody Compose(FingerboardInstrument instrument, Fingering fingering)
		{
			var notes = new List<Note>();

			fingering.Positions.ToList().ForEach(
				position =>
					notes.Add(instrument.PitchAt(position))
					);

			return new Melody(notes);
		}

		public Melody Compose(IReadNotes parser)
		{
			return new Melody(parser.ReadToEnd());
		}
	}
}
