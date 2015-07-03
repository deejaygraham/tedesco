using System;

namespace Tedesco
{
	public static class PitchFrequencyConverter
	{
		static readonly int SemitonesInAnOctave = 12;
		static readonly int A440Midi = 69;
		static readonly double A440Hz = 440.0;

		public static Pitch ToPitch(double frequency)
		{
			int midiValue = Convert.ToInt32(Math.Floor(A440Midi + (Convert.ToDouble(SemitonesInAnOctave) * Math.Log(frequency / A440Hz, 2.0))));

			return new Pitch(midiValue);
		}

		public static double ToFrequency(Pitch pitch)
		{
			return A440Hz * Math.Pow(Convert.ToDouble(pitch.Value - A440Midi) / Convert.ToDouble(SemitonesInAnOctave), 2.0);
		}
	}
}
