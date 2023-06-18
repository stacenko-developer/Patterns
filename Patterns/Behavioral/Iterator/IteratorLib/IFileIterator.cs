
namespace Patterns
{
	/// <summary>
	/// Содержит методы для итератора файловой системы.
	/// </summary>
	public interface IFileIterator
	{
		/// <summary>
		/// Проверяет, есть ли в коллекции следующий элемент.
		/// </summary>
		/// <returns>Результат проверки.</returns>
		bool HasNext();

		/// <summary>
		/// Получает следующий элемент.
		/// </summary>
		/// <returns>Следующий элемент.</returns>
		File Next();
	}
}
