using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Evolution.Tests
{
	public class FingeringScorerTests
	{
		[Fact]
		public void Fingering_Along_Single_String_Scores_Lower_Than_Across_Three_Strings()
		{
			var oneString = new Fingering();

			// do they all fit under one hand position.
			// one fret per finger
			oneString.Add(new FingerPosition(0, 1));
			oneString.Add(new FingerPosition(1, 1));
			oneString.Add(new FingerPosition(2, 1));
			oneString.Add(new FingerPosition(3, 1));
			oneString.Add(new FingerPosition(4, 1));
			oneString.Add(new FingerPosition(5, 1));

			var spread = new Fingering();
			spread.Add(new FingerPosition(10, 3));
			spread.Add(new FingerPosition(11, 3));
			spread.Add(new FingerPosition(12, 3));
			spread.Add(new FingerPosition(8, 2));
			spread.Add(new FingerPosition(9, 2));
			spread.Add(new FingerPosition(10, 2));

			var scorer = new FingeringScorer();

			Assert.True(scorer.Score(oneString) < scorer.Score(spread));
		}
	}
}
