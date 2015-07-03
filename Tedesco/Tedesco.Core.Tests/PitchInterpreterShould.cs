using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tedesco.Tests
{
	[TestClass]
	public class PitchInterpreterShould
	{
		[TestMethod]
		public void Recognize_C0_As_Lowest_Midi_Number()
		{
			var p = PitchInterpreter.FromString("C0");
			Assert.AreEqual(0, p.Value);
		}

		[TestMethod]
		public void Recognize_C5_As_Middle_C()
		{
			var p = PitchInterpreter.FromString("C5");
			Assert.AreEqual(60, p.Value);
		}

		[TestMethod]
		public void Recognize_G10_As_Highest_Midi_Number()
		{
			var p = PitchInterpreter.FromString("G10");
			Assert.AreEqual(127, p.Value);
		}
	}
}
