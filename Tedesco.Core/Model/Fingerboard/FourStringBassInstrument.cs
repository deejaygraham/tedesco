using System.Collections.Generic;

namespace Tedesco
{
	public class FourStringBassInstrument : FingerboardInstrument
	{
		public static readonly MidiValue EString = MidiValue.E0;
		public static readonly MidiValue AString = MidiValue.A0;
		public static readonly MidiValue DString = MidiValue.D1;
		public static readonly MidiValue GString = MidiValue.G1;

		public FourStringBassInstrument()
			: base(new List<Note> 
			{ 
				new Note(EString), 
				new Note(AString), 
				new Note(DString), 
				new Note(GString) }, 
				22)
		{
		}
	}
}
