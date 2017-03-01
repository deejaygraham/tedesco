using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tedesco
{
	public class Scale
	{
		private List<Pitch> scale = new List<Pitch>();

		public Scale(Pitch tonic, IntervalPattern pattern)
			: this(tonic, pattern, 1)
		{
		}

		public Scale(Pitch tonic, IntervalPattern pattern, int octaves)
		{
			if (tonic == null) throw new ArgumentNullException("tonic");

			if (pattern == null) throw new ArgumentNullException("pattern");

			this.scale.Add(tonic);

			Pitch current = tonic;

			for (int i = 0; i < octaves; ++i)
			{
				foreach (Interval v in pattern.Values)
				{
					current = current + v;
					this.scale.Add(current);
				}
			}
		}

		public IReadOnlyCollection<Pitch> Values
		{
			get
			{
				return new ReadOnlyCollection<Pitch>(this.scale);
			}
		}
	}
}
