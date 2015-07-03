using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tedesco.Tests
{
	[TestClass]
    public class PitchFrequencyConverterShould
    {
		[TestMethod]
		public void Match_Lowest_Frequency_To_Midi_0()
		{
			// c 0
			var p = PitchFrequencyConverter.ToPitch(8.1758);
			Assert.AreEqual(0, p.Value);
		}

		[TestMethod]
		public void Match_Middle_C_To_Midi_60()
		{
			// middle c
			// 3c = 60
			var p = PitchFrequencyConverter.ToPitch(261.6256);
			Assert.AreEqual(60, p.Value);
		}

		[TestMethod]
		public void Match_Middle_CSharp_To_Midi_61()
		{
			// c#
			// 3d = 61
			var p = PitchFrequencyConverter.ToPitch(277.1827);
			Assert.AreEqual(61, p.Value);
		}

		[TestMethod]
		public void Match_A_Above_Middle_C_As_69()
		{
			// a 440 45 - 69
			var p = PitchFrequencyConverter.ToPitch(440.0);
			Assert.AreEqual(69, p.Value);
		}

		[TestMethod]
		public void Match_Highest_Midi_Note_As_127()
		{
			// g 7f - 127
			var p = PitchFrequencyConverter.ToPitch(12543.88);
			Assert.AreEqual(127, p.Value);
		}

		//[TestMethod]
		//public void Round_Trip_Frequency()
		//{
		//	const double frequency = 12543.88;

		//	var fromFrequency = PitchFrequencyConverter.ToPitch(frequency);

		//	Assert.AreEqual((int)frequency, (int)PitchFrequencyConverter.ToFrequency(fromFrequency));
		//}
    }
}
