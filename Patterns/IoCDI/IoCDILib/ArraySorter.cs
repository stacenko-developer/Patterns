

namespace Patterns
{
	/// <summary>
	/// Сортировщик массива.
	/// </summary>
	public class ArraySorter : IArraySortable
	{
		#region Методы.
		/// <summary>
		/// Сортировка массива.
		/// </summary>
		/// <param name="array">Массив, который необходимо отсортировать.</param>
		/// <param name="isAscendingOrder">Как упорядочивать массив.</param>
		/// <returns>Отсортированный массив.</returns>
		private int[] GetSortedArray(int[] array, bool isAscendingOrder = true)
		{
			for (var i = 0; i < array.Length - 1; i++)
			{
				var index = i;

				for (var j = i + 1; j < array.Length; j++)
				{
					if ((array[j] < array[index] && isAscendingOrder) || (array[j] > array[index] && !isAscendingOrder))
					{
						index = j;
					}
				}

				var tmp = array[index];
				array[index] = array[i];
				array[i] = tmp;
			}

			return array;
		}

		/// <summary>
		/// Получение отсортированного массива.
		/// </summary>
		/// <param name="array">Массив, который необходимо отсортировать.</param>
		/// <returns>Отсортированный массив.</returns>
		public int[] GetSortedArrayInAscendingOrder(int[] array)
		{
			Validator.ArrayValidate(array);

			return GetSortedArray(array, true);
		}

		/// <summary>
		/// Получение отсортированного массива в порядке убывания.
		/// </summary>
		/// <param name="array">Массив, который необходимо отсортировать.</param>
		/// <returns>Отсортированный массив.</returns>
		public int[] GetSortedArrayInDescendingOrder(int[] array)
		{
			Validator.ArrayValidate(array);

			return GetSortedArray(array, false);
		}
		#endregion
	}
}
