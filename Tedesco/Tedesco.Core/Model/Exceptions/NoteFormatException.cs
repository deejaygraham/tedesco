using System;
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

		public NoteFormatException(string message)
			: base(message)
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
