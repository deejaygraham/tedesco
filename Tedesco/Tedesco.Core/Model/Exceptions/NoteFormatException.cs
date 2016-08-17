using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
