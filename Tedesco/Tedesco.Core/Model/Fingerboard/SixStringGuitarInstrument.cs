using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	public class SixStringGuitarInstrument : FingerboardInstrument
	{
		public static readonly MidiNoteValue LowEString = MidiNoteValue.E1;
		public static readonly MidiNoteValue AString = MidiNoteValue.A1;
		public static readonly MidiNoteValue DString = MidiNoteValue.D2;
		public static readonly MidiNoteValue GString = MidiNoteValue.G2;
		public static readonly MidiNoteValue BString = MidiNoteValue.B2;
		public static readonly MidiNoteValue HighEString = MidiNoteValue.E3;

		public SixStringGuitarInstrument()
			: base(new List<Pitch> 
			{ 
				new Pitch(LowEString), 
				new Pitch(AString), 
				new Pitch(DString), 
				new Pitch(GString), 
				new Pitch(BString), 
				new Pitch(HighEString) }, 
				22)
		{
		}
	}
}
