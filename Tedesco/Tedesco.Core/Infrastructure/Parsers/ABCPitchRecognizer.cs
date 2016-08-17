using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	public class ABCPitchRecognizer : IUnderstandPitchFormat
	{
		public bool IsTokenCorrectFormat(string token)
		{
			const int MinTextLength = 2;
			const int MaxTextLength = 3;

			return (token.Length >= MinTextLength && token.Length <= MaxTextLength);
        }

		public Pitch Recognize(string token)
		{
			try
			{
				return NoteNameInterpreter.ToValue(token);
			}
			catch (NoteFormatException)
			{
			}
			catch (ArgumentOutOfRangeException)
			{
			}

			// empty value instead ???
			return null;
		}
	}
}
