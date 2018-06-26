using System.Linq;
using Xunit;

namespace Tedesco.Tests
{
	public class SixStringGuitarInstrumentTests
	{
		[Fact]
		public void String_Are_Numbered_High_To_Low()
		{
			var gtr = new SixStringGuitarInstrument();

			Assert.Equal(new Note(SixStringGuitarInstrument.HighEString), gtr.Strings.FirstOrDefault(s => s.Number == 1).Open);
			Assert.Equal(new Note(SixStringGuitarInstrument.BString), gtr.Strings.FirstOrDefault(s => s.Number == 2).Open);
			Assert.Equal(new Note(SixStringGuitarInstrument.GString), gtr.Strings.FirstOrDefault(s => s.Number == 3).Open);
			Assert.Equal(new Note(SixStringGuitarInstrument.DString), gtr.Strings.FirstOrDefault(s => s.Number == 4).Open);
			Assert.Equal(new Note(SixStringGuitarInstrument.AString), gtr.Strings.FirstOrDefault(s => s.Number == 5).Open);
			Assert.Equal(new Note(SixStringGuitarInstrument.LowEString), gtr.Strings.FirstOrDefault(s => s.Number == 6).Open);
		}

		[Fact]
		public void Low_String_Is_Tuned_Correctly()
		{
			var gtr = new SixStringGuitarInstrument();

			Assert.Equal(new Note(40), gtr.NoteAt(new FingerPosition(0, 6)));
		}

		[Fact]
		public void Adjacent_Low_Strings_Are_Tuned_Differently()
		{
			var gtr = new SixStringGuitarInstrument();

			var sixOpen = gtr.NoteAt(new FingerPosition(0, 6));
			var fiveOpen = gtr.NoteAt(new FingerPosition(0, 5));

			Assert.True(sixOpen < fiveOpen);
		}

		[Fact]
		public void Adjacent_LowMid_Strings_Are_Tuned_Differently()
		{
			var gtr = new SixStringGuitarInstrument();

			var fiveOpen = gtr.NoteAt(new FingerPosition(0, 5));
			var fourOpen = gtr.NoteAt(new FingerPosition(0, 4));

			Assert.True(fiveOpen < fourOpen);
		}

		[Fact]
		public void Adjacent_Mid_Strings_Are_Tuned_Differently()
		{
			var gtr = new SixStringGuitarInstrument();

			var fourOpen = gtr.NoteAt(new FingerPosition(0, 4));
			var threeOpen = gtr.NoteAt(new FingerPosition(0, 3));

			Assert.True(fourOpen < threeOpen);
		}

		[Fact]
		public void Adjacent_MidHigh_Strings_Are_Tuned_Differently()
		{
			var gtr = new SixStringGuitarInstrument();

			var threeOpen = gtr.NoteAt(new FingerPosition(0, 3));
			var twoOpen = gtr.NoteAt(new FingerPosition(0, 2));

			Assert.True(threeOpen < twoOpen);
		}

		[Fact]
		public void Adjacent_High_Strings_Are_Tuned_Differently()
		{
			var gtr = new SixStringGuitarInstrument();

			var twoOpen = gtr.NoteAt(new FingerPosition(0, 2));
			var oneOpen = gtr.NoteAt(new FingerPosition(0, 1));

			Assert.True(twoOpen < oneOpen);
		}

		[Fact]
		public void Tuning_Increases_Low_To_High_Across_Strings()
		{
			var gtr = new SixStringGuitarInstrument();

			for (int s = 6; s > 5; s--)
			{
				Assert.True(gtr.NoteAt(new FingerPosition(0, s)) < gtr.NoteAt(new FingerPosition(0, s - 1)));
			}
		}

		[Fact]
		public void Tuning_Is_Self_Consistent()
		{
			var gtr = new SixStringGuitarInstrument();

			Assert.Equal(gtr.NoteAt(new FingerPosition(5, 6)), gtr.NoteAt(new FingerPosition(0, 5)));
			Assert.Equal(gtr.NoteAt(new FingerPosition(5, 5)), gtr.NoteAt(new FingerPosition(0, 4)));
			Assert.Equal(gtr.NoteAt(new FingerPosition(5, 4)), gtr.NoteAt(new FingerPosition(0, 3)));
			Assert.Equal(gtr.NoteAt(new FingerPosition(4, 3)), gtr.NoteAt(new FingerPosition(0, 2)));
			Assert.Equal(gtr.NoteAt(new FingerPosition(5, 2)), gtr.NoteAt(new FingerPosition(0, 1)));
		}

		[Fact]
		public void Lowest_Note_Is_Only_Found_In_One_Exact_Match()
		{
			var gtr = new SixStringGuitarInstrument();

			Assert.Equal(1, gtr.PositionsFor(new Note(40)).Count);
		}

		[Fact]
		public void Highest_Note_Is_Only_Found_In_One_Exact_Match()
		{
			var gtr = new SixStringGuitarInstrument();

			Assert.Equal(1, gtr.OtherExactPositionsFor(new FingerPosition(22, 1)).Count);
		}

		[Fact]
		public void Common_Note_Is_Found_In_Many_Other_Exact_Matches()
		{
			var gtr = new SixStringGuitarInstrument();

			Assert.Equal(5, gtr.OtherExactPositionsFor(new FingerPosition(0, 1)).Count);
		}

		[Fact]
		public void Common_Note_Is_Found_In_Many_Other_Fuzzy_Matches()
		{
			var gtr = new SixStringGuitarInstrument();

			Assert.Equal(12, gtr.OtherFuzzyPositionsFor(new FingerPosition(0, 1)).Count);
		}

	}
}
