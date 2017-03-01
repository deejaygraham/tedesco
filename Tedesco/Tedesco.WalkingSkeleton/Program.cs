using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedesco.Evolution;

namespace Tedesco.WalkingSkeleton
{
	class Program
	{
		static void Main(string[] args)
		{
			var instrument = new SixStringGuitarInstrument();

			// create a simple melody.
			var walkingBassFingering = new Fingering();
			walkingBassFingering.Add(new FingerPosition(0, 1));
			walkingBassFingering.Add(new FingerPosition(1, 1));
			walkingBassFingering.Add(new FingerPosition(2, 1));
			walkingBassFingering.Add(new FingerPosition(3, 1));

			FingeringPrinter printer = new FingeringPrinter();

			Console.WriteLine(printer.Print(walkingBassFingering, instrument));

			// build the list of notes
			var melody = walkingBassFingering.ToMelody(instrument);

			// can we build the simples reconstruction ?
			var roundTripFingering = FingeringCreator.CreateFingeringFor(instrument, melody, new FixedValueSelector());

			Console.WriteLine(printer.Print(roundTripFingering, instrument));

			Console.ReadKey();
		}
	}
}
