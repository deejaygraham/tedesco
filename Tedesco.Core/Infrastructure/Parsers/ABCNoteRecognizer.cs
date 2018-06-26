using System;

namespace Tedesco
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ABC")]
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
                return NoteNamer.FromName(token, this.Format);
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
