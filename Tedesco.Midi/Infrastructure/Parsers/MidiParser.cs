using NAudio.Midi;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tedesco.Midi
{
	public class MidiParser : IReadNotes
    {
		public MidiParser(string filename)
		{
			this.MidiFile = filename;
            this.Track = 1;
		}

		public MidiParser(string filename, int track)
		{
			this.MidiFile = filename;
			this.Track = track;
		}

		public string MidiFile { get; private set; }

		public int? Track { get; private set; }

		public IEnumerable<Note> ReadToEnd()
		{
			if (!File.Exists(this.MidiFile))
				throw new FileNotFoundException("Midi file not found", this.MidiFile);

			var midi = new NAudio.Midi.MidiFile(this.MidiFile);

            var timeSignature = midi.Events[0].OfType<TimeSignatureEvent>().FirstOrDefault();

            int ticksPerQuarterNote = midi.DeltaTicksPerQuarterNote;
            //int ticksPerBar = ticksPerQuarterNote * 4;

            int quarterNote = 96;

            int track = (this.Track.HasValue) ? this.Track.Value : 0;

            if (track >= midi.Tracks)
                track = midi.Tracks - 1;

			foreach (MidiEvent @event in midi.Events[track])
			{
				if (MidiCommandCode.NoteOn == @event.CommandCode)
				{
					NoteOnEvent noteOn = @event as NoteOnEvent;

					if (noteOn != null)
					{
                        int ticks = noteOn.NoteLength;

                        yield return new Note(noteOn.NoteNumber)
                        {
                            Duration = ticks / quarterNote
                        };
					}
				}
			}
		}
	}
}
