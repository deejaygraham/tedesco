using System;

namespace Tedesco
{
	public class ABCNoteRecognizer : IUnderstandNoteFormat
	{
		public MidiOctaveFormat Format { get; set; }

		public bool IsTokenCorrectFormat(string token)
		{
			if (string.IsNullOrEmpty(token))
				return false;

			const int MinTextLength = 2;
			const int MaxTextLength = 4;

			return (token.Length >= MinTextLength && token.Length <= MaxTextLength);
        }

		public Note Recognize(string token)
		{
			try
			{
                return NoteNamer.PitchOf(token, this.Format);
			}
			catch (NoteFormatException)
			{
			}
			catch (ArgumentOutOfRangeException)
			{
			}

			// empty value instead ???
			return null;
		}
	}
}
