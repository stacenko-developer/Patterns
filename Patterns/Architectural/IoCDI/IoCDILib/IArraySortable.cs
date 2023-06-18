
namespace Patterns
{
	/// <summary>
	/// Содержит методы для сортировщика массивов.
	/// </summary>
	public interface IArraySortable
	{
		/// <summary>
		/// Получение отсортированного массива в порядке возрастания.
		/// </summary>
		/// <param name="array">Массив, который необходимо отсортировать.</param>
		/// <returns>Отсортированный массив.</returns>
		int[] GetSortedArrayInAscendingOrder(int[] array);

		/// <summary>
		/// Получение отсортированного массива в порядке убывания.
		/// </summary>
		/// <param name="array">Массив, который необходимо отсортировать.</param>
		/// <returns>Отсортированный массив.</returns>
		int[] GetSortedArrayInDescendingOrder(int[] array);
	}
}
