using System.Collections.Generic;

namespace Tedesco
{
	public class UkuleleInstrument : FingerboardInstrument
	{
		public static readonly MidiValue GString = MidiValue.G3;
		public static readonly MidiValue CString = MidiValue.C3;
		public static readonly MidiValue EString = MidiValue.E3;
		public static readonly MidiValue AString = MidiValue.A3;

		public UkuleleInstrument()
			: base(new List<Note> 
			{ 
				new Note(GString), 
				new Note(CString), 
				new Note(EString), 
				new Note(AString) }, 
				10)
		{
		}
	}
}
