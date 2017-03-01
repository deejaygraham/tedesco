
namespace Tedesco.Evolution
{
	/// <summary>
	/// Scores an object's fitness, score can be low or high better.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IScorer<T>
	{
		int Score(T item);
	}
}
