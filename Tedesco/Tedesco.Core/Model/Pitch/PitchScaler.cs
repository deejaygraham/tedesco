using System;

namespace Tedesco
{
	public static class PitchScaler
	{
		public static int Scale(int value)
		{
			return Math.Abs(value) % 12;
		}
	}
}
