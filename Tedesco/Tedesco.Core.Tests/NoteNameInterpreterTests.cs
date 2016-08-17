using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
	public class NoteNameInterpreterTests
	{
		[Fact]
		public void Recognizes_C0_As_Lowest_Midi_Number()
		{
			Assert.Equal(new Pitch(0), NoteNameInterpreter.ToValue("C0"));
		}

		[Fact]
		public void Recognizes_Sharp_Modifiers()
		{
			Assert.Equal(new Pitch(1), NoteNameInterpreter.ToValue("C#0"));
		}

		[Fact]
		public void Recognizes_Flat_Modifiers()
		{
			Assert.Equal(new Pitch(1), NoteNameInterpreter.ToValue("Db0"));
		}

		[Fact]
		public void Recognizes_C5_As_Middle_C()
		{
			Assert.Equal(new Pitch(60), NoteNameInterpreter.ToValue("C5"));
		}

		[Fact]
		public void Recognizes_G10_As_Highest_Midi_Number()
		{
			Assert.Equal(new Pitch(127), NoteNameInterpreter.ToValue("G10"));
		}
	}
}
