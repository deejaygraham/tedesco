using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	public static class NoteNamer
	{
		public static readonly char Sharp = '#';
		public static readonly char Flat = 'b';

		private static readonly Dictionary<int, string> NoteNames = new Dictionary<int, string>
		{
			{  0, "C"  },
			{  1, "C#" },
			{  2, "D"  },
			{  3, "D#" },
			{  4, "E"  },
			{  5, "F"  },
			{  6, "F#" },
			{  7, "G"  },
			{  8, "G#" },
			{  9, "A"  },
			{ 10, "A#" },
			{ 11, "B"  }
		};

		private static readonly Dictionary<string, int> NoteValues = new Dictionary<string, int>
		{
			{ "C",   0 },
			{ "C#",  1 },
			{ "DB",  1 },
			{ "D",   2 },
			{ "D#",  3 },
			{ "EB",  3 },
			{ "E",   4 },
			{ "F",   5 },
			{ "F#",  6 },
			{ "GB",  6 },
			{ "G",   7 },
			{ "G#",  8 },
			{ "AB",  8 },
			{ "A",   9 },
			{ "A#", 10 },
			{ "BB", 10 },
			{ "B",  11 }
		};

		public static string NameOf(int value)
		{
			if (value < 0) throw new NoteFormatException();

			int index = value % 12;

			return NoteNames[value % 12];
		}

		public static Pitch PitchOf(string note)
		{
			const int MinimumTextLength = 2;

			if (String.IsNullOrEmpty(note) || note.Length < MinimumTextLength) throw new NoteFormatException("Note text is too short");

			if (!Char.IsLetter(note.First()))
				throw new NoteFormatException("Note must start with a letter");

			char candidateAccidental = note.Skip(1).First();

			int NamePartLength = 1;

			if (candidateAccidental == Sharp || candidateAccidental == Flat)
			{
				NamePartLength = 2;
			}

			string scaleDegreeText = note.Substring(0, NamePartLength).ToUpper();

			int scaleDegree = 0;

			try
			{
				scaleDegree = NoteValues[scaleDegreeText];
			}
			catch (KeyNotFoundException e)
			{
				throw new NoteFormatException(scaleDegreeText, e);
			}

			string octaveText = note.Substring(NamePartLength);
			int octaveValue = Convert.ToInt32(octaveText);

			return new Pitch(scaleDegree, octaveValue);
		}
	}
}
