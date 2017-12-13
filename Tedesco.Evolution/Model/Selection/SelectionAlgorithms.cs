using System;
using System.Collections.Generic;
using System.Linq;

namespace Tedesco.Evolution
{
	public static class SelectionAlgorithms<T>
	{
		public static IEnumerable<T> FindBest(IEnumerable<T> selection, IComparer<T> comparer, int howMany)
		{
			var list = selection.ToList();

			list.Sort(comparer);

			return list.Take(howMany);
		}

		public static IEnumerable<T> PickFrom(IEnumerable<T> selection, int howMany, ISelectValue randomness)
		{
			if (howMany > selection.Count())
				throw new ArgumentOutOfRangeException("howMany", "Count cannot be more the number of values");

			var list = selection.ToList();
			var randomCandidates = new List<T>();

			for (int i = 0; i < howMany; ++i)
			{
				int randomIndex = randomness.BetweenZeroAnd(list.Count);

				T candidateSolution = list[randomIndex];
				randomCandidates.Add(candidateSolution);

				list.Remove(candidateSolution);
			}

			return randomCandidates;
		}
	}

}
