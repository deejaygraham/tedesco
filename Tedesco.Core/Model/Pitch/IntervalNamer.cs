
namespace Tedesco
{
	public static class IntervalNamer
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
			"octave"
		};

		public static string NameOf(IntervalDistance distance)
		{
			return IntervalNames[(int)distance];
		}
	}
}
