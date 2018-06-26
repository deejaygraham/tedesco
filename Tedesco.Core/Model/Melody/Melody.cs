using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tedesco
{
	public class Melody
	{
		private List<Note> notes = new List<Note>();
				
		public Melody()
		{
		}

		public Melody(IEnumerable<Note> list)
		{
			this.notes = new List<Note>(list);
		}

		public static Melody CreateFrom(IReadNotes parser)
		{
            if (parser == null) throw new ArgumentNullException("parser", "IReadNotes argument cannot be null");

			return new Melody(parser.ReadToEnd());
		}

		public Melody ModulateBy(Interval semitones)
		{
            if (semitones == null) throw new ArgumentNullException("semitones", "Interval argument cannot be null");

            var newComposition = new Melody();

			foreach (var note in this.notes)
			{
				newComposition.notes.Add(note + semitones);
			}

			return newComposition;
		}

		public Note LowestNote()
		{
			return new Note(this.notes.Min());
		}

		public Note HighestNote()
		{
			return new Note(this.notes.Max());
		}

		public IReadOnlyCollection<Note> Notes
		{
			get
			{
				return new ReadOnlyCollection<Note>(this.notes);
			}
		}
	}

}
