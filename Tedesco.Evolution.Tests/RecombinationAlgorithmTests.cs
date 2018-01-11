using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tedesco.Evolution.Tests
{

	public class RecombinationAlgorithmTests
	{
		[Fact]
		public void CrossFill_Copies_Values_From_CutIndex_Onwards_To_Start()
		{
			List<int> parent = new List<int> { 1, 2, 3, 4, 5, 6 };
			List<int> child = new List<int>();

			RecombinationAlgorithms<int>.CrossFill(child, parent, 4);

			Assert.Equal(5, child[0]);
			Assert.Equal(6, child[1]);
			Assert.Equal(1, child[2]);
			Assert.Empty(child.Except(parent));
		}

		[Fact]
		public void CrossFill_Child_Content_Matches_Parent()
		{
			List<int> parent = new List<int> { 1, 2, 3, 4, 5, 6 };
			List<int> child = new List<int>();

			RecombinationAlgorithms<int>.CrossFill(child, parent, 4);

            Assert.Empty(child.Except(parent));
        }

        [Fact]
		public void CrossFill_Handles_End_To_Start()
		{
			List<int> parent = new List<int> { 1, 2, 3, 4, 5, 6 };
			List<int> child = new List<int>();

			RecombinationAlgorithms<int>.CrossFill(child, parent, 5);

			Assert.Equal(6, child[0]);
			Assert.Equal(1, child[1]);
			Assert.Equal(2, child[2]);
		}


		[Fact]
		public void CrossFill_Handles_Start_To_End()
		{
			List<int> parent = new List<int> { 1, 2, 3, 4, 5, 6 };
			List<int> child = new List<int>();

			RecombinationAlgorithms<int>.CrossFill(child, parent, 0);

			Assert.Equal(1, child[0]);
			Assert.Equal(2, child[1]);
			Assert.Equal(3, child[2]);
		}


		[Fact]
		public void CutAndCrossFill_Child_Contains_Unique_Values()
		{
			List<int> parent = new List<int> { 1, 2, 3, 4, 5, 6 };
			List<int> child = new List<int>();

			RecombinationAlgorithms<int>.CrossFill(child, parent, 5);

			Assert.Equal(child.Distinct().Count(), child.Count);
		}

		[Fact]
		public void CutAndCrossFill_Copies_From_First_Fills_With_Remainder()
		{
			List<int> parent1 = new List<int> { 1, 2, 3, 4, 5, 6 };
			List<int> parent2 = new List<int> { 2, 3, 5, 6, 4, 1 };

			List<int> child = RecombinationAlgorithms<int>.CutAndCrossFill(parent1, parent2, 2);

			Assert.Equal(parent1.Count, child.Count);

			Assert.Equal(1, child[0]);
			Assert.Equal(2, child[1]);
			Assert.Equal(5, child[2]);
			Assert.Equal(6, child[3]);
			Assert.Equal(4, child[4]);
			Assert.Equal(3, child[5]);
		}


		[Fact]
		public void Swap_Returns_New_List_With_Swapped_Items()
		{
			List<int> original = new List<int> { 1, 2, 3, 4, 5, 6 };
			List<int> swapped = RecombinationAlgorithms<int>.Swap(original, 0, 1);

			Assert.Equal(original.Count, swapped.Count);

			Assert.Equal(original[0], swapped[1]);
			Assert.Equal(original[1], swapped[0]);
			Assert.Equal(original[2], swapped[2]);
		}
	}
}
