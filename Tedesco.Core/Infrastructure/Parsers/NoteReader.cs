using System;
using System.Collections.Generic;

namespace Tedesco
{
    public class NoteReader : IReadNotes
    {
		public NoteReader(string text, IUnderstandNoteFormat formatRecognizer)
			: this(formatRecognizer)
		{
			this.Text = text;
		}

		public NoteReader(IUnderstandNoteFormat formatRecognizer)
		{
			this.Delimiter = ',';
			this.FormatRecognizer = formatRecognizer;
		}

		public string Text { get; set; }

		public char Delimiter { get; set; }

		private IUnderstandNoteFormat FormatRecognizer { get; set; }

		public IEnumerable<Note> ReadToEnd(string text)
		{
			if (string.IsNullOrEmpty(text)) throw new ArgumentNullException("text", "Text cannot be blank");

			string[] tokens = text.Split(new char[] { this.Delimiter });

			foreach (string token in tokens)
			{
				string value = token.Trim();

				if (this.FormatRecognizer.IsTokenCorrectFormat(value))
					yield return this.FormatRecognizer.Recognize(value);
			}
		}

		public IEnumerable<Note> ReadToEnd()
		{
			return this.ReadToEnd(this.Text);
		}
	}
}
