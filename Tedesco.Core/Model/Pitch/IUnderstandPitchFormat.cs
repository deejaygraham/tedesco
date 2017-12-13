
namespace Tedesco
{
	public interface IUnderstandPitchFormat
	{
		Pitch Recognize(string token);

		bool IsTokenCorrectFormat(string token);
	}
}
