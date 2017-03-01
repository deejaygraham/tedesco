using System;

namespace Tedesco.Evolution
{
	/// <summary>
	/// Always returns fixed values to allow testing of "random" selection.
	/// </summary>
	public class FixedValueSelector : IValueSelector
	{
		public int Index(int arrayLength)
		{
			return 0;
		}

		public bool Boolean()
		{
			return true;
		}

		public int Integer(int lowestValue, int highestValue)
		{
			return lowestValue;
		}

		public int Integer(int highestValue)
		{
			return 0;
		}
	}

}


