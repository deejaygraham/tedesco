
namespace Tedesco
{
	public interface IUnderstandNoteFormat
	{
		Note Recognize(string token);

		bool IsTokenCorrectFormat(string token);
	}
}
