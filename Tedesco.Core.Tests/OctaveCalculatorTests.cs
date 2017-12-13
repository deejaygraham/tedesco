using Xunit;

namespace Tedesco.Tests
{
	public class OctaveCalculatorTests
	{
		[Fact]
		public void Standard_C_Zero_Is_Octave_Minus_Two()
		{
			Assert.Equal(-2, OctaveCalculator.OctaveOf(0));
		}

		[Fact]
		public void Standard_C_Twelve_Is_Octave_Minus_One()
		{
			Assert.Equal(-1, OctaveCalculator.OctaveOf(12));
		}

		[Fact]
		public void Standard_Middle_C_Is_Octave_Three()
		{
			Assert.Equal(3, OctaveCalculator.OctaveOf(60));
		}

		[Fact]
		public void High_Middle_C_Is_Octave_Four()
		{
			Assert.Equal(4, OctaveCalculator.OctaveOf(60, MidiOctaveFormat.Higher));
		}

		[Fact]
		public void Standard_High_C_Is_Octave_Eight()
		{
			Assert.Equal(8, OctaveCalculator.OctaveOf(120));
		}

		[Fact]
		public void High_C_Zero_Is_Octave_Minus_One()
		{
			Assert.Equal(-1, OctaveCalculator.OctaveOf(0, MidiOctaveFormat.Higher));
		}

		[Fact]
		public void High_C_Twelve_Is_Octave_Zero()
		{
			Assert.Equal(0, OctaveCalculator.OctaveOf(12, MidiOctaveFormat.Higher));
		}

	}
}
