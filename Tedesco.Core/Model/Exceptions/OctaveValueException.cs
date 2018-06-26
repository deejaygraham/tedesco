using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Tedesco
{
	[Serializable]
	public class OctaveValueException : Exception
	{
		public OctaveValueException()
			: base()
		{
		}

		public OctaveValueException(int value)
			: base(string.Format(CultureInfo.CurrentCulture, "Octave \'{0}\' is not a valid value", value))
		{
		}

		public OctaveValueException(string message)
			: base(message)
		{
		}

		public OctaveValueException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected OctaveValueException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
