
namespace Tedesco.Evolution
{
	/// <summary>
	/// Scores two objects relative to each other
	/// in how closely they are matched. 0 is exact 
	/// match, positive value is distance apart.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IScoreRelative<T>
	{
		int Score(T first, T second);
	}
}
