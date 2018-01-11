using System;
using System.Text;

namespace Tedesco
{
	public static class FingeringPrinter
	{
		public static string Print(Fingering fingering, FingerboardInstrument instrument)
		{
            if (fingering == null) throw new ArgumentNullException("fingering");

            if (instrument == null) throw new ArgumentNullException("instrument");

			var builder = new StringBuilder();

			foreach(var s in instrument.Strings)
			{
				builder.Append("-");

				foreach (var f in fingering.Positions)
				{
					if (f.String == s.Number)
					{
						builder.Append("-");
						builder.Append(f.Fret);

						if (f.Fret < 10)
							builder.Append("-");
					}
					else
					{
						builder.Append("---");
					}
				}

				builder.AppendLine("-");
			}

			return builder.ToString();
		}

	}
}
