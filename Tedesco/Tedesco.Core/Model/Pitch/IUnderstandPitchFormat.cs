using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	public interface IUnderstandPitchFormat
	{
		Pitch Recognize(string token);

		bool IsTokenCorrectFormat(string token);
	}
}
