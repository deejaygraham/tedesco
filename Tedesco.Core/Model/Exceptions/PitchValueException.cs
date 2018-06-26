using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Tedesco
{
	[Serializable]
	public class PitchValueException : Exception
	{
		public PitchValueException()
			: base()
		{
		}

		public PitchValueException(int value)
			: base(string.Format(CultureInfo.CurrentCulture, "Note \'{0}\' is not a valid value", value))
		{
		}

		public PitchValueException(string message)
			: base(message)
		{
		}

		public PitchValueException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected PitchValueException(SerializationInfo info, StreamingContext context)
			:base(info, context)
		{
		}
	}
}
