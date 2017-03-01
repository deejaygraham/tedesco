using System;
using System.Diagnostics;

namespace Tedesco
{
	[DebuggerDisplay("[{@string}, {fret}]")]
	public class FingerPosition
	{
		private readonly int fret;
		private readonly int @string;

		public FingerPosition(int fretNumber, int stringNumber)
		{
			if (fretNumber < 0)
				throw new ArgumentException("fretNumber must be positive");

			if (stringNumber < 1)
				throw new AggregateException("stringNumber must be 1 or greater");

			this.fret = fretNumber;
			this.@string = stringNumber;
		}

		public int Fret { get { return this.fret; } }

		public int String { get { return this.@string; } }

		public override string ToString()
		{
			return string.Format("[{0}, {1}]", this.@string, this.fret);
		}
	}
}
