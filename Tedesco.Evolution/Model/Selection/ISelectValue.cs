
namespace Tedesco.Evolution
{
	/// <summary>
	/// Selects a value given a constraint - e.g. length range
	/// </summary>
	public interface ISelectValue
	{
		/// <summary>
		/// Value between 0 and one less than length
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		int Upto(int length);

		/// <summary>
		/// Value between zero and value (inclusive)
		/// </summary>
		/// <param name="highestValue"></param>
		/// <returns></returns>
		int BetweenZeroAnd(int highestValue);

		/// <summary>
		/// Value between low and high (inclusive)
		/// </summary>
		/// <param name="lowestValue"></param>
		/// <param name="highestValue"></param>
		/// <returns></returns>
		int Between(int lowestValue, int highestValue);

		bool Boolean();
	}

}
