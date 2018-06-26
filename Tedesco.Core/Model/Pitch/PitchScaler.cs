using System;

namespace Tedesco
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Scaler")]
    public static class PitchScaler
	{
		public static int Scale(int value)
		{
			return Math.Abs(value) % 12;
		}
	}
}
