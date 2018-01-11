using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tedesco
{
	public class Chord
	{
		private List<Note> chord = new List<Note>();

        // root and scale degree list

		public Chord(Note tonic, DegreePattern pattern)
		{
			if (tonic == null) throw new ArgumentNullException("tonic");

			if (pattern == null) throw new ArgumentNullException("pattern");

			this.chord.Add(tonic);

			//Pitch current = tonic;

			//foreach(ScaleDegree i in pattern.Values)
			//{
   //             //Pitch next = new Pitch(tonic + )
			//	//current = current + i;
			//	this.chord.Add(tonic + i);
			//}
		}

		public IReadOnlyCollection<Note> Values
		{
			get
			{
				return new ReadOnlyCollection<Note>(this.chord);
			}
		}

	}
}
