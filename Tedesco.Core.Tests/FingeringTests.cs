using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
	public class FingeringTests
	{
		[Fact]
		public void Fingering_In_Single_Area_Is_One_Hand_Position()
		{
			var f = new Fingering();
			f.Add(new FingerPosition(1, 1));
			f.Add(new FingerPosition(2, 1));
			f.Add(new FingerPosition(3, 1));

			Assert.Equal(1, f.HandPositions().Count);
		}

		[Fact]
		public void Fingering_In_Low_Then_High_Area_Is_Two_Hand_Positions()
		{
			var f = new Fingering();
			f.Add(new FingerPosition(1, 1));
			f.Add(new FingerPosition(2, 1));
			f.Add(new FingerPosition(3, 1));

			f.Add(new FingerPosition(10, 1));
			f.Add(new FingerPosition(11, 1));
			f.Add(new FingerPosition(12, 1));

			Assert.Equal(2, f.HandPositions().Count);
		}

		[Fact]
		public void Fingering_In_High_Then_Low_Area_Is_Two_Hand_Positions()
		{
			var f = new Fingering();
			f.Add(new FingerPosition(10, 1));
			f.Add(new FingerPosition(11, 1));
			f.Add(new FingerPosition(12, 1));

			f.Add(new FingerPosition(1, 1));
			f.Add(new FingerPosition(2, 1));
			f.Add(new FingerPosition(3, 1));

			Assert.Equal(2, f.HandPositions().Count);
		}

		[Fact]
		public void Fingering_Of_Octave_Is_Three_Hand_Positions()
		{
			var f = new Fingering();

			foreach (int fret in Enumerable.Range(1, 12))
			{
				f.Add(new FingerPosition(fret, 1));
			}

			Assert.Equal(3, f.HandPositions().Count);
		}

		[Fact]
		public void Fingering_Repeated_Notes_Are_Included_In_Hand_Positions()
		{
			var f = new Fingering();

			foreach (int fret in Enumerable.Range(1, 12))
			{
				foreach (int @string in Enumerable.Range(1, 6))
				{
					f.Add(new FingerPosition(fret, @string));
				}
			}

			Assert.Equal(3, f.HandPositions().Count);
		}

	}
}
