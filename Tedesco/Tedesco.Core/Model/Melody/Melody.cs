using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tedesco
{
	public class Melody
	{
		private List<Pitch> notes = new List<Pitch>();
				
		public Melody()
		{
		}

		public Melody(IEnumerable<Pitch> list)
		{
			this.notes = new List<Pitch>(list);
		}

		public static Melody CreateFrom(IReadPitches parser)
		{
			return new Melody(parser.ReadToEnd());
		}

		public Melody ModulateBy(int semitones)
		{
			var newComposition = new Melody();

			foreach (var note in this.notes)
			{
				newComposition.notes.Add(note.SharpenBy(semitones));
			}

			return newComposition;
		}

		public Pitch LowestNote()
		{
			return new Pitch(this.notes.Min());
		}

		public Pitch HighestNote()
		{
			return new Pitch(this.notes.Max());
		}

		public IReadOnlyCollection<Pitch> Notes
		{
			get
			{
				return new ReadOnlyCollection<Pitch>(this.notes);
			}
		}
	}

}
