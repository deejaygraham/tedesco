using System;

namespace Tedesco
{
	public static class MidiMath
	{
		public static Pitch ToPitch(double frequencyInHertz)
		{
			const double ConcertAInHertz = 440.0;
			const int ConcertAInMidi = 69;

			double octavesAboveConcertA = Math.Log(frequencyInHertz / ConcertAInHertz, 2.0);
			int semitonesAboveConcertA = Convert.ToInt32(Math.Floor(Convert.ToDouble(Interval.Octave.Semitones) * octavesAboveConcertA));
			int semitones = ConcertAInMidi + semitonesAboveConcertA;

			//if (semitones < (int)MidiNoteValue.C0 || semitones > (int)MidiNoteValue.G10)
			//	throw new ArgumentOutOfRangeException("frequency", "frequency cannot be expressed as a midi value");

			return new Pitch(semitones);
		}

		//Hertz = 440.0 * pow(2.0, (midi note - 69)/12); 
		// midi note = log(Hertz/440.0)/log(2) * 12 + 69;

		//private static readonly double InverseLog2 = 1.0 / Math.Log10(2.0);

		//public static double FrequencyFromMidi(int midiValue)
		//{
		//	return Math.Pow(10.0, (midiValue - 33.0) / InverseLog2 / 12.0) * 55.0;
		//}

		//public static int MidiFromFrequency(double frequency)
		//{
		//	if (frequency >= 20.0)
		//		return (int)((12.0 * Math.Log10(frequency / 55.0) * InverseLog2) + 33.0);

		//	return 0;
		//}

	}
}
