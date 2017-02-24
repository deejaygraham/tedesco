using System;

namespace Tedesco
{
	public class FrequencyPitchRecognizer : IUnderstandPitchFormat
	{
		public bool IsTokenCorrectFormat(string token)
		{
			return !string.IsNullOrWhiteSpace(token);
		}

		public Pitch Recognize(string token)
		{
			double frequency = 0.0;

			if (Double.TryParse(token, out frequency))
				return MidiMath.ToNote(frequency);

			throw new NoteFormatException(token);
        }
	}
}
