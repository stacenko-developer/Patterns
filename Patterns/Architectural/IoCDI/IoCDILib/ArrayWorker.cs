
using System;

namespace Patterns
{
	/// <summary>
	/// Работа с массивами.
	/// </summary>
	public class ArrayWorker
	{
		#region Поля.
		/// <summary>
		/// Сортировщик массивов.
		/// </summary>
		private IArraySortable _arraySortable;
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создает экземпляр класса для работы с массивами с помощью указанных параметров.
		/// </summary>
		/// <param name="arraySortable">Сортировщик массивов.</param>
		/// <exception cref="ArgumentNullException">Сортировщик массивов равен null!</exception>
		public ArrayWorker(IArraySortable arraySortable)
		{
			if (arraySortable == null)
			{
				throw new ArgumentNullException(nameof(arraySortable), "Сортировщик массивов равен null!");
			}

			_arraySortable = arraySortable;
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Получение отсортированного массива в порядке возрастания.
		/// </summary>
		/// <param name="array">Массив, который необходимо отсортировать.</param>
		/// <returns>Отсортированный массив.</returns>
		public int[] GetSortedArrayInAscendingOrder(int[] array)
			=> _arraySortable.GetSortedArrayInAscendingOrder(array);

		/// <summary>
		/// Получение отсортированного массива в порядке убывания.
		/// </summary>
		/// <param name="array">Массив, который необходимо отсортировать.</param>
		/// <returns>Отсортированный массив.</returns>
		public int[] GetSortedArrayInDescendingOrder(int[] array)
			=> _arraySortable.GetSortedArrayInDescendingOrder(array);
		#endregion
	}
}
