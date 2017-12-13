using System;

namespace Tedesco.Evolution
{
	/// <summary>
	/// Always returns fixed values to allow testing of "random" selection.
	/// </summary>
	public class FixedValueSelector : ISelectValue
	{
		public int Upto(int length)
		{
			return 0;
		}

		public bool Boolean()
		{
			return true;
		}

		public int Between(int lowestValue, int highestValue)
		{
			return lowestValue;
		}

		public int BetweenZeroAnd(int highestValue)
		{
			return 0;
		}
	}

}


