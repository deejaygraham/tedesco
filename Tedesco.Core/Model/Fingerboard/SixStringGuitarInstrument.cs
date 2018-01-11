using System.Collections.Generic;

namespace Tedesco
{
	public class SixStringGuitarInstrument : FingerboardInstrument
	{
		public static readonly MidiValue LowEString = MidiValue.E1;
		public static readonly MidiValue AString = MidiValue.A1;
		public static readonly MidiValue DString = MidiValue.D2;
		public static readonly MidiValue GString = MidiValue.G2;
		public static readonly MidiValue BString = MidiValue.B2;
		public static readonly MidiValue HighEString = MidiValue.E3;

		public SixStringGuitarInstrument()
			: base(new List<Note> 
			{ 
				new Note(LowEString), 
				new Note(AString), 
				new Note(DString), 
				new Note(GString), 
				new Note(BString), 
				new Note(HighEString) }, 
				22)
		{
		}
	}
}
