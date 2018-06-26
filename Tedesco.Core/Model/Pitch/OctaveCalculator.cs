
namespace Tedesco
{
	public static class OctaveCalculator
	{
        public static int OctaveOf(int value)
        {
            return OctaveOf(value, MidiOctaveFormat.Standard);
        }

        /// <summary>
        /// Calculates which octave a value belongs to.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static int OctaveOf(int value, MidiOctaveFormat format)
		{
			int octaveModifier = format == MidiOctaveFormat.Standard ? 2 : 1;

			return (value / 12) - octaveModifier;
		}
	}
}
