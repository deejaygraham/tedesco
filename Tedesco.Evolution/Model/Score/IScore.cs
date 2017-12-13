
namespace Tedesco.Evolution
{
	/// <summary>
	/// Scores an object's fitness, score can be low or high better.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IScore<T>
	{
		int Score(T item);

		/// <summary>
		/// Can we terminate ?
		/// </summary>
		/// <param name="guess"></param>
		/// <returns></returns>
		bool CloseEnough(T guess);
	}
}
