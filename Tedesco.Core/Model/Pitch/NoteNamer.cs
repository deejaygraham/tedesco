﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tedesco
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Namer")]
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
			if (value < 0) throw new NoteFormatException(value);
			
			return NoteNames[PitchScaler.Scale(value)];
		}

        public static Note FromName(string note)
        {
            return NoteNamer.FromName(note, MidiOctaveFormat.Standard);
        }

        public static Note FromName(string note, MidiOctaveFormat format)
		{
			const int MinimumTextLength = 2;

			if (String.IsNullOrEmpty(note) || note.Length < MinimumTextLength) throw new NoteFormatException("Note text is too short");

			if (!Char.IsLetter(note.First()))
				throw new NoteFormatException("Note must start with a letter");

            Accidental accidental = Accidental.FromString(note.Substring(1, 1));

			int NamePartLength = 1;

			if (accidental != null)
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
			int octaveValue = Convert.ToInt32(octaveText, CultureInfo.CurrentCulture);

			return new Note(scaleDegree, octaveValue, format);
		}
	}
}
