using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	class FourStringBassInstrument : FingerboardInstrument
	{
		public static readonly MidiNoteValue EString = MidiNoteValue.E0;
		public static readonly MidiNoteValue AString = MidiNoteValue.A0;
		public static readonly MidiNoteValue DString = MidiNoteValue.D1;
		public static readonly MidiNoteValue GString = MidiNoteValue.G1;

		public FourStringBassInstrument()
			: base(new List<Pitch> 
			{ 
				new Pitch(EString), 
				new Pitch(AString), 
				new Pitch(DString), 
				new Pitch(GString) }, 
				22)
		{
		}
	}
}
