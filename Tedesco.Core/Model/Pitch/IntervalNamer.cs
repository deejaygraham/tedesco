
namespace Tedesco
{
	internal static class IntervalNamer
	{
		private static readonly string[] IntervalNames = new string[] {
			"unison",
			"minor second",
			"major second",
			"minor third",
			"major third",
			"perfect fourth",
			"diminished fifth",
			"perfect fifth",
			"minor sixth",
			"major sixth",
			"minor seventh",
			"major seventh",
			"octave",
            "minor ninth",
            "ninth"
		};

		public static string NameOf(Interval interval)
		{
            int distance = System.Math.Abs(interval.Semitones);

            if (distance >= IntervalNames.Length)
                return "unknown";

			return IntervalNames[distance];
		}
	}
}
