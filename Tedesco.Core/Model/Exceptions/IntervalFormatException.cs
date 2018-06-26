using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Tedesco
{
	[Serializable]
	public class IntervalFormatException : Exception
	{
		public IntervalFormatException()
			: base()
		{
		}

		public IntervalFormatException(int value)
			: base(string.Format(CultureInfo.CurrentCulture, "Interval \'{0}\' is not a valid value", value))
		{
		}

		public IntervalFormatException(string message)
			: base(string.Format(CultureInfo.CurrentCulture, "Interval \'{0}\' is not recognized as a valid format", message))
		{
		}

		public IntervalFormatException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected IntervalFormatException(SerializationInfo info, StreamingContext context)
			:base(info, context)
		{
		}
	}
}
