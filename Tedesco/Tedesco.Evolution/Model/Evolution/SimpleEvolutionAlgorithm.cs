
namespace Tedesco.Evolution
{
	public class SimpleEvolutionAlgorithm<T>
	{
		public IControlPopulation<T> PopulationControl { get; set; }

		public IScore<T> FitnessEvaluator { get; set; }

		public int InitialPopulation { get; set; }

		public int PopulationSize { get; set; }

		public T EvolveBest()
		{
			var population = this.PopulationControl.CreateInstances(this.InitialPopulation);

			// population.Sort(using comparator);

			while (true) // not terminated ...
			{
				ISelectPopulation<T> select = new RandomPopulation<T>(this.PopulationSize);

				// parent selection process - best x, random x, best x out of random y
				var fitParents = select.Select(population);



			}

			return default(T);
		}
	}
}
