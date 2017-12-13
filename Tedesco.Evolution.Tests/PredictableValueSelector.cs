
namespace Tedesco.Evolution.Tests
{
	public class PredictableValueSelector : ISelectValue
	{
		public PredictableValueSelector(int intValue, bool boolValue)
		{
			this.nextInt = intValue;
			this.nextBool = boolValue;
		}

		private int nextInt;
		private bool nextBool;

		public int Upto(int length)
		{
			if (length >= nextInt)
				return length - 1;

			return nextInt;
		}

		public bool Boolean()
		{
			return this.nextBool;
		}

		public int BetweenZeroAnd(int highestValue)
		{
			return this.nextInt;
		}

		public int Between(int lowestValue, int highestValue)
		{
			return this.nextInt;
		}
	}

}
