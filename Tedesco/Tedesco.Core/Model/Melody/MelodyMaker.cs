using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	public class MelodyMaker
	{
		public Melody Compose(FingerboardInstrument instrument, Fingering fingering)
		{
			var notes = new List<Pitch>();

			fingering.Positions.ToList().ForEach(
				position =>
					notes.Add(instrument.PitchAt(position))
					);

			return new Melody(notes);
		}

		public Melody Compose(IReadPitches parser)
		{
			return new Melody(parser.ReadToEnd());
		}
	}
}
