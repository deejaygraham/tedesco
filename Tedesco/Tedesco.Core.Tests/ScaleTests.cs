using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
	public class ScaleTests
	{
		[Fact]
		public void Chromatic_Scale_Intervals_Are_Single_Semitone_Apart()
		{
			var dictionary = new ScaleDictionary();

			var intervals = dictionary[WellKnownScale.Chromatic];

			foreach(var v in intervals.Values)
			{
				Assert.Equal(1, v.Semitones);
			}
		}
	}
}
