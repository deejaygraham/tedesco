using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedesco;

namespace Tedesco.Midi
{
	public class MidiParser : IReadPitches
    {
		private readonly string file;

		public MidiParser(string filename)
		{
			this.file = filename;
		}

		public IEnumerable<Pitch> ReadToEnd()
		{
			var pitches = new List<Pitch>();

			var midiFile = new NAudio.Midi.MidiFile(this.file);

			const int FirstTrack = 0;

			foreach (var noteOnEvent in midiFile.Events.GetTrackEvents(FirstTrack).Where(e => e.CommandCode == MidiCommandCode.NoteOn))
			{
				NoteEvent noteEvent = noteOnEvent as NoteEvent;

				if (noteEvent != null)
					pitches.Add(new Pitch(noteEvent.NoteNumber));
			}

			return pitches;
		}
	}
}
