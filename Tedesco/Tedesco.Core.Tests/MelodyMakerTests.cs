using Xunit;

namespace Tedesco.Tests
{
	public class MelodyMakerTests
	{
		[Fact]
		public void MelodyMaker_Reads_Happy_Birthday()
		{
			string text = "D2, D2, E2, D2, G2, F4,  D2, D2, E2, D2, A2, G4,   D2, D2, D3 B2, G2, F2, E2,  C2, C2, B2, G2, A2, G2";
			var reader = new PitchReader(text, new ABCPitchRecognizer());

			var mm = new MelodyMaker();

			var melody = mm.Compose(reader);

			Assert.Equal(NoteNamer.PitchOf("C2"), melody.LowestNote());
			Assert.Equal(NoteNamer.PitchOf("G4"), melody.HighestNote());
		}

		[Fact]
		public void MelodyMaker_Reads_Twinkle_Twinkle()
		{
			string text = "D2, D2, A2, A2, B2, B2, A2";
			var reader = new PitchReader(text, new ABCPitchRecognizer());

			var mm = new MelodyMaker();

			var melody = mm.Compose(reader);

			Assert.Equal(NoteNamer.PitchOf("D2"), melody.LowestNote());
			Assert.Equal(NoteNamer.PitchOf("B2"), melody.HighestNote());
		}

	}
}
