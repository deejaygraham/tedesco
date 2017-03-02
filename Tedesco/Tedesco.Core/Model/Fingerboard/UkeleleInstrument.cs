using System.Collections.Generic;

namespace Tedesco
{
	public class UkeleleInstrument : FingerboardInstrument
	{
		public static readonly MidiNoteValue GString = MidiNoteValue.G3;
		public static readonly MidiNoteValue CString = MidiNoteValue.C3;
		public static readonly MidiNoteValue EString = MidiNoteValue.E3;
		public static readonly MidiNoteValue AString = MidiNoteValue.A3;

		public UkeleleInstrument()
			: base(new List<Pitch> 
			{ 
				new Pitch(GString), 
				new Pitch(CString), 
				new Pitch(EString), 
				new Pitch(AString) }, 
				10)
		{
		}
	}
}
