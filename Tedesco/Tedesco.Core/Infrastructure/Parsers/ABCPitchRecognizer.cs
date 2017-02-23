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
			const int MaxTextLength = 4;

			return (token.Length >= MinTextLength && token.Length <= MaxTextLength);
        }

		public Pitch Recognize(string token)
		{
			try
			{
				return NoteNamer.PitchOf(token);
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
