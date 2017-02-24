using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tedesco
{
	public class Chord
	{
		private List<Pitch> chord = new List<Pitch>();

		public Chord(Pitch tonic, IntervalPattern pattern)
		{
			this.chord.Add(tonic);

			Pitch current = tonic;

			foreach(Interval i in pattern.Values)
			{
				current = current + i;
				this.chord.Add(current);
			}
		}

		public IReadOnlyCollection<Pitch> Values
		{
			get
			{
				return new ReadOnlyCollection<Pitch>(this.chord);
			}
		}

	}
}
