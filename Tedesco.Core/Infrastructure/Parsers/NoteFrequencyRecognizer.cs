using System;

namespace Tedesco
{
	public class NoteFrequencyRecognizer : IUnderstandNoteFormat
	{
		public bool IsTokenCorrectFormat(string token)
		{
			return !string.IsNullOrWhiteSpace(token);
		}

		public Note Recognize(string token)
		{
			double frequency = 0.0;

			if (Double.TryParse(token, out frequency))
				return MidiMath.NoteFromFrequency(frequency);

			throw new NoteFormatException(token);
        }
	}
}
