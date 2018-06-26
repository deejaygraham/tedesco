using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Tedesco
{
	[Serializable]
	public class NoteFormatException : Exception
	{
		public NoteFormatException()
			: base()
		{
		}

		public NoteFormatException(int value)
			: base(string.Format(CultureInfo.CurrentCulture, "Value \'{0}\' is not a valid value", value))
		{
		}

		public NoteFormatException(string message)
			: base(string.Format(CultureInfo.CurrentCulture, "Note \'{0}\' is not recognized as a valid format", message))
		{
		}

		public NoteFormatException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected NoteFormatException(SerializationInfo info, StreamingContext context)
			:base(info, context)
		{
		}
	}
}
