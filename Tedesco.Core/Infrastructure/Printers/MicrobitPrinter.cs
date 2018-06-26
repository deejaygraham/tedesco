using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Infrastructure.Printers
{
    public class MicrobitPrinter
    {
        public string Print(Melody melody)
        {
            if (melody == null) throw new ArgumentNullException("melody");

            var builder = new StringBuilder();

            builder.AppendLine("from microbit import *");
            builder.AppendLine("import music");
            builder.AppendLine();

            builder.AppendLine("melody = [ ");

            int columnCount = 0;
            int melodyLength = melody.Notes.Count;

            foreach (var note in melody.Notes)
            {
                builder.Append("\"");
                builder.Append(note.MidiName.ToLower());
                builder.Append(":");
                builder.Append(note.Duration.ToString());
                builder.Append("\"");

                columnCount++;

                if (columnCount < melodyLength)
                    builder.Append(", " );

                if (columnCount > 10)
                {
                    builder.AppendLine();
                    columnCount = 0;
                }
            }

            builder.AppendLine(); 
            builder.AppendLine("]"); // end

            builder.AppendLine();
            builder.AppendLine("music.play(melody)");
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
