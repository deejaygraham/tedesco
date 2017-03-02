using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedesco;

namespace Tedesco.Midi
{
	public class MidiParser : IReadPitches
    {
		public MidiParser(string filename)
		{
			this.MidiFile = filename;
		}

		public MidiParser(string filename, int track)
		{
			this.MidiFile = filename;
			this.Track = track;
		}

		public string MidiFile { get; private set; }

		public int? Track { get; private set; }

		public IEnumerable<Pitch> ReadToEnd()
		{
			if (!File.Exists(this.MidiFile))
				throw new FileNotFoundException("Midi file not found", this.MidiFile);

			var midi = new NAudio.Midi.MidiFile(this.MidiFile);

			for (int track = 0; track < midi.Tracks; ++track)
			{
				if (this.Track.HasValue && this.Track != track)
					continue;

				foreach (MidiEvent @event in midi.Events[track])
				{
					if (MidiCommandCode.NoteOn == @event.CommandCode)
					{
						NoteOnEvent noteOn = @event as NoteOnEvent;

						if (noteOn != null)
						{
							yield return new Pitch(noteOn.NoteNumber);
						}
					}
				}
			}
		}
	}
}
