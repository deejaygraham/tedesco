
namespace Tedesco
{
	public static class OctaveCalculator
	{
		/// <summary>
		/// Calculates which octave a value belongs to.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		public static int OctaveOf(int value, MidiOctaveFormat format = MidiOctaveFormat.Standard)
		{
			int octaveModifier = format == MidiOctaveFormat.Standard ? 2 : 1;

			return (value / 12) - octaveModifier;
		}
	}
}
