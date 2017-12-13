using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco.Evolution
{
	/// <summary>
	/// Notification of an evolution event
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EvolutionEventArgs<T> : EventArgs
	{
		public EvolutionEventArgs(T best, int round, int score)
		{
			this.Best = best;
			this.Round = round;
			this.Score = score;
		}

		/// <summary>
		/// The best so far
		/// </summary>
		public T Best { get; private set; }

		/// <summary>
		/// Which round does this apply to?
		/// </summary>
		public int Round { get; private set; }

		/// <summary>
		/// How the best value scores against perfect
		/// </summary>
		public int Score { get; private set; }
	}
}
