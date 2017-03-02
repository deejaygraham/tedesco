using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
	public class FingerPositionTests
	{
		[Fact]
		public void FingerPosition_Fret_Must_Be_Zero_Or_Positive()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				new FingerPosition(-1, 1);
			});
		}

		[Fact]
		public void FingerPosition_String_Number_Must_Be_Positive()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				new FingerPosition(0, 0);
			});
		}

		[Fact]
		public void FingerPosition_Same_String_Same_Fret_Are_Equal()
		{
			const int SameString = 3;
			const int SameFret = 10;
			Assert.True(new FingerPosition(SameFret, SameString).CompareTo(new FingerPosition(SameFret, SameString)) == 0);
		}

		[Fact]
		public void FingerPosition_Same_String_Different_Fret_Are_Not_Equal()
		{
			const int SameString = 5;
			const int Fret1 = 9;
			const int Fret2 = 7;
			Assert.False(new FingerPosition(Fret1, SameString).CompareTo(new FingerPosition(Fret2, SameString)) == 0);
		}

		[Fact]
		public void FingerPosition_Same_Fret_Different_String_Are_Not_Equal()
		{
			const int SameFret = 5;
			const int String1 = 1;
			const int String2 = 6;
			Assert.False(new FingerPosition(SameFret, String1).CompareTo(new FingerPosition(SameFret, String2)) == 0);
		}

	}
}
