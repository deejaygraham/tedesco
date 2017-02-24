using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tedesco
{
	public class Scale
	{
		private List<Pitch> scale = new List<Pitch>();

		public Scale(Pitch tonic, IntervalPattern pattern)
		{
			this.scale.Add(tonic);

			Pitch current = tonic;

			foreach(Interval v in pattern.Values)
			{
				current = current + v;
				this.scale.Add(current);
			}
		}

		public IReadOnlyCollection<Pitch> Values
		{
			get
			{
				return new ReadOnlyCollection<Pitch>(this.scale);
			}
		}

		public static Scale Chromatic(Pitch tonic, int octaves = 1)
		{
			var pattern = new IntervalPattern();

			for (int i = 0; i < ((int)IntervalDistance.PerfectOctave * octaves); ++i)
			{
				pattern.Add(Interval.Semitone);
			}

			return new Scale(tonic, pattern);
		}

		// need major, melodic minor etc.
	}
}
