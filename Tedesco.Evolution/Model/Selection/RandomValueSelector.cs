using System;

namespace Tedesco.Evolution
{
	public class RandomValueSelector : ISelectValue
	{
		private Random random = new Random((int)DateTime.Now.Ticks);

		public int Upto(int length)
		{
			return random.Next(0, length);
		}

		public bool Boolean()
		{
			return random.Next(0, 2) == 1;
		}

		public int Between(int lowestValue, int highestValue)
		{
			return random.Next(lowestValue, highestValue + 1);
		}

		public int BetweenZeroAnd(int highestValue)
		{
			return Between(0, highestValue);
		}
	}

}
