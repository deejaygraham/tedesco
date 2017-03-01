
namespace Tedesco.Evolution
{
	public interface IValueSelector
	{
		int Index(int arrayLength);

		int Integer(int highestValue);

		int Integer(int lowestValue, int highestValue);

		bool Boolean();
	}
}
