using System;

namespace Tedesco
{
    public static class PitchInterpreter
    {
		static readonly int SemitonesInAnOctave = 12;
		
		public static Pitch FromString(string text)
		{
			const int MinTextLength = 2;
			const int MaxTextLength = 3;

			if (string.IsNullOrEmpty(text))
				throw new ArgumentNullException("text");

			if (text.Length < MinTextLength || text.Length > MaxTextLength)
				throw new ArgumentOutOfRangeException("text", "text length is out of range");

			char noteName = Char.ToLower(text[0]);
			int noteValue = NoteNameToValue(noteName);

			char nextCharacter = text[1];

			string octaveValue = string.Empty;

			const char sharp = '#';
			const char flat = 'b';

			if (nextCharacter == sharp)
			{
				noteValue++;
				octaveValue = text.Substring(2);
			}
			else if (nextCharacter == flat)
			{
				noteValue--;
				octaveValue = text.Substring(2);
			}
			else
			{
				octaveValue = text.Substring(1);
			}

			int octave = Convert.ToInt32(octaveValue);
			return new Pitch(noteValue + (SemitonesInAnOctave * octave));
		}

		private static int NoteNameToValue(char noteName)
		{
			int value = 0;

			switch (Char.ToUpper(noteName))
			{
				case 'C':
					value = 0;
					break;

				case 'D':
					value = 2;
					break;

				case 'E':
					value = 4;
					break;

				case 'F':
					value = 5;
					break;

				case 'G':
					value = 7;
					break;

				case 'A':
					value = 9;
					break;

				case 'B':
					value = 11;
					break;

				default:

					throw new ArgumentOutOfRangeException();
			}

			return value;
		}
    }
}
