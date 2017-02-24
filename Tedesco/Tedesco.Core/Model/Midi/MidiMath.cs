using System;

namespace Tedesco
{
	public static class MidiMath
	{
		public static Pitch ToNote(double frequency)
		{
			const int A440Midi = 69;
			const double A440Hz = 440.0;

			int midiValue = Convert.ToInt32(
				Math.Floor(A440Midi + 
					(Convert.ToDouble(Interval.Octave.Semitones) * Math.Log(frequency / A440Hz, 2.0))
					)
				);

			if (midiValue < (int)MidiNoteValue.C0 || midiValue > (int)MidiNoteValue.G10)
				throw new ArgumentOutOfRangeException("frequency", "frequency cannot be expressed as a midi value");

			return new Pitch((MidiNoteValue)midiValue);
		}
	}
}
