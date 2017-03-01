using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution.Tests
{
	public class PredictableValueSelector : IValueSelector
	{
		public PredictableValueSelector(int intValue, bool boolValue)
		{
			this.nextInt = intValue;
			this.nextBool = boolValue;
		}

		private int nextInt;
		private bool nextBool;

		public int Index(int arrayLength)
		{
			if (arrayLength >= nextInt)
				return arrayLength - 1;

			return nextInt;
		}

		public bool Boolean()
		{
			return this.nextBool;
		}

		public int Integer(int highestValue)
		{
			return this.nextInt;
		}

		public int Integer(int lowestValue, int highestValue)
		{
			return this.nextInt;
		}
	}

}
