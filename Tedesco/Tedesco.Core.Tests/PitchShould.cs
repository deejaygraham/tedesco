using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tedesco.Tests
{
	[TestClass]
    public class PitchShould
    {
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throw_An_Exception_For_Negative_Values()
		{
			new Pitch(-1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throw_An_Exception_For_Greater_Midi_Max_Value()
		{
			new Pitch(128);
		}

		[TestMethod]
		public void Construct_For_Intermediate_Value()
		{
			Assert.AreEqual(120, new Pitch(120).Value);
		}

		[TestMethod]
		public void Construct_For_Midi_Value()
		{
			Assert.AreEqual(7, new Pitch(MidiNoteValue.G0).Value);
		}
	}
}
