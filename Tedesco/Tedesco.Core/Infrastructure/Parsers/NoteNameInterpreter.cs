using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tedesco
{
	public static class NoteNameInterpreter
	{
		public static readonly char Sharp = '#';
		public static readonly char Flat = 'b';

		private static Dictionary<char, int> noteNameLookup = new Dictionary<char, int>
		{
			{ 'C',  0 },
			{ 'D',  2 },
			{ 'E',  4 },
			{ 'F',  5 },
			{ 'G',  7 },
			{ 'A',  9 },
			{ 'B', 11 }
		};

		private static Dictionary<char, int> incidentalLookup = new Dictionary<char, int>
		{
			{ Sharp,  1 },
			{ Flat, -1 }
		};

		public static Pitch ToValue(string noteText)
		{
			const int MinimumTextLength = 2;

			if (String.IsNullOrEmpty(noteText) || noteText.Length < MinimumTextLength)
				throw new NoteFormatException("Note text is too short");

			char noteName = Char.ToUpper(noteText.First());
			int noteValue = 0;
			
			try
			{
				noteValue = noteNameLookup[noteName];
			}
			catch(KeyNotFoundException e)
			{
				throw new NoteFormatException(noteText, e);
			}

			int octaveStartPosition = 1;

			char incidental = noteText.Skip(1).First();

			if (incidentalLookup.ContainsKey(incidental))
			{
				noteValue += incidentalLookup[incidental];
				++octaveStartPosition;
			}

			string octaveText = noteText.Substring(octaveStartPosition);
			int octaveValue = Convert.ToInt32(octaveText);

			return new Pitch(noteValue, octaveValue);
		}
	}
}
