using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
	public class HandPositionTests
	{
		[Fact]
		public void HandPosition_Orders_Lowest_And_Highest_Spans()
		{
			var first = new HandPosition(1, 5);

			var reversed = new HandPosition(5, 1);

			Assert.Equal(first, reversed);
		}

		[Fact]
		public void HandPosition_Understands_Position_Within_Its_Span()
		{
			var first = new HandPosition(1, 4);

			Assert.True(first.Covers(new FingerPosition(2, 1)));
		}

		[Fact]
		public void HandPosition_Understands_Position_At_Minimum_Span()
		{
			var first = new HandPosition(1, 4);

			Assert.True(first.Covers(new FingerPosition(1, 1)));
		}

		[Fact]
		public void HandPosition_Understands_Position_At_Maximum_Span()
		{
			var first = new HandPosition(1, 4);

			Assert.True(first.Covers(new FingerPosition(4, 1)));
		}

		[Fact]
		public void HandPosition_Below_Position_Is_Not_Covered()
		{
			var first = new HandPosition(10, 14);

			Assert.False(first.Covers(new FingerPosition(9, 1)));
		}

		[Fact]
		public void HandPosition_Above_Position_Is_Not_Covered()
		{
			var first = new HandPosition(10, 14);

			Assert.False(first.Covers(new FingerPosition(15, 1)));
		}

	}
}
