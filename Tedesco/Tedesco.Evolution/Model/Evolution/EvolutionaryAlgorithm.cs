using System;
using System.Linq;

namespace Tedesco.Evolution
{
	public class EvolutionaryAlgorithm<T>
	{
		public event EventHandler<EvolutionEventArgs<T>> Start;

		public event EventHandler<EvolutionEventArgs<T>> Progress;

		public event EventHandler<EvolutionEventArgs<T>> Complete;

		public EvolutionaryAlgorithm(ICreatePopulation<T> pop, IScore<T> fit, IMutator<T> mute)
		{
			this.Populator = pop;
			this.Scorer = fit;
			this.Mutator = mute;
		}

		private ICreatePopulation<T> Populator { get; set; }

		private IScore<T> Scorer { get; set; }

		private IMutator<T> Mutator { get; set; }

		public T FindBest()
		{
			T bestSoFar = this.Populator.CreateInitial();

			int initialScore = this.Scorer.Score(bestSoFar);
			int i = 0;

			if (this.Start != null)
			{
				this.Start(this, new EvolutionEventArgs<T>(bestSoFar, i, initialScore));
			}

			while (!this.Scorer.CloseEnough(bestSoFar))
			{
				var candidates = this.Populator.CreatePopulation(bestSoFar, this.Mutator);

				var sorted = from candidate in candidates
							 orderby this.Scorer.Score(candidate) descending
							 select candidate;

				bestSoFar = sorted.First();

				++i;

				int nextScore = this.Scorer.Score(bestSoFar);

				if (this.Progress != null)
				{
					this.Progress(this, new EvolutionEventArgs<T>(bestSoFar, i, nextScore));
				}
			}

			if (this.Complete != null)
			{
				this.Complete(this, new EvolutionEventArgs<T>(bestSoFar, i, this.Scorer.Score(bestSoFar)));
			}

			return bestSoFar;
		}
	}
}
