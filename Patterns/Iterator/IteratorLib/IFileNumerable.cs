
namespace Patterns
{
	/// <summary>
	/// Содержит методы получения итератора из коллекции.
	/// </summary>
	public interface IFileNumerable
	{
		/// <summary>
		/// Создание итератора.
		/// </summary>
		/// <returns>Созданный итератор.</returns>
		IFileIterator CreateNumerator(); 

		/// <summary>
		/// Количество элементов в коллекции.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Получение элемента из коллекции по индексу.
		/// </summary>
		/// <param name="index">Индекс элемента, который необходимо получить.</param>
		/// <returns>Элемент по индексу.</returns>
		File this[int index] { get; }
	}
}
