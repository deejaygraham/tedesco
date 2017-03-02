using System;
using System.Collections.Generic;
using System.Linq;

namespace Tedesco.Evolution
{
	public static class RecombinationAlgorithms<T>
	{
		public static List<T> Swap(List<T> original, int firstIndex, int secondIndex)
		{
			if (firstIndex < 0)
				throw new ArgumentOutOfRangeException("firstIndex", "Index cannot be negative");

			if (firstIndex >= original.Count)
				throw new ArgumentOutOfRangeException("firstIndex", "Index must be less than list length");

			if (secondIndex < 0)
				throw new ArgumentOutOfRangeException("secondIndex", "Index cannot be negative");

			if (secondIndex >= original.Count)
				throw new ArgumentOutOfRangeException("secondIndex", "Index must be less than list length");

			if (firstIndex == secondIndex)
				throw new ArgumentException("secondIndex", "Indexes must be different");

			List<T> swapped = new List<T>(original);

			T first = swapped[firstIndex];
			T second = swapped[secondIndex];

			swapped[firstIndex] = second;
			swapped[secondIndex] = first;

			return swapped;
		}

		public static List<T> CutAndCrossFill(List<T> parent1, List<T> parent2, int cutIndex)
		{
			if (parent1.Count != parent2.Count)
				throw new ArgumentException("Lists must be the same length");

			if (cutIndex < 0)
				throw new ArgumentOutOfRangeException("cutIndex", "Index cannot be negative");

			if (cutIndex >= parent1.Count)
				throw new ArgumentOutOfRangeException("cutIndex", "Index must be less than list length");

			List<T> child = new List<T>();

			child.AddRange(parent1.Take(cutIndex));

			CrossFill(child, parent2, cutIndex);

			return child;
		}

		public static void CrossFill(List<T> child, List<T> parent, int cutIndex)
		{
			if (cutIndex < 0)
				throw new ArgumentOutOfRangeException("cutIndex", "Index cannot be negative");

			if (cutIndex >= parent.Count)
				throw new ArgumentOutOfRangeException("cutIndex", "Index must be less than list length");

			CopyIfRequired(parent, child, cutIndex, parent.Count);
			CopyIfRequired(parent, child, 0, cutIndex);
		}

		private static void CopyIfRequired(List<T> fromList, List<T> toList, int fromIndex, int toIndex)
		{
			for (int i = fromIndex; i < toIndex; ++i)
			{
				T value = fromList[i];

				if (!toList.Contains(value))
				{
					toList.Add(value);
				}
			}
		}
	}

}
