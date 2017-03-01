using System;

namespace Tedesco.Evolution
{
	public class RandomValueSelector : IValueSelector
	{
		private Random random = new Random((int)DateTime.Now.Ticks);

		public RandomValueSelector()
		{
		}

		public int Index(int arrayLength)
		{
			return random.Next(0, arrayLength);
		}

		public bool Boolean()
		{
			return random.Next(0, 2) == 1;
		}

		public int Integer(int lowestValue, int highestValue)
		{
			return random.Next(lowestValue, highestValue + 1);
		}

		public int Integer(int highestValue)
		{
			return random.Next(highestValue + 1);
		}
	}

}
