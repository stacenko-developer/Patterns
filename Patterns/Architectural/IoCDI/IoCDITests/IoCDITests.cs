using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Patterns
{
	/// <summary>
	/// Проверка корректности реализации паттерна IoCDI.
	/// </summary>
	[TestClass]
	public class IoCDITests
	{
		#region Методы.
		/// <summary>
		/// Проверка корректности создания сортировщика массивов.
		/// </summary>
		[TestMethod]
		public void CreateArraySorter_WithNoParametersInConstructor_ShouldCreateArraySorter()
		{
			new ArraySorter();
		}

		/// <summary>
		/// Сортировка в порядке возрастания null-массива.
		/// </summary>
		/// <exception cref="ArgumentNullException">Массив равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void GetSortedArrayInAscendingOrder_WithNullArgument_ShouldThrowArgumentNullException()
		{
			new ArraySorter().GetSortedArrayInAscendingOrder(null);
		}

		/// <summary>
		/// Сортировка в порядке возрастания корректного массива.
		/// </summary>
		/// <param name="array">Массив.</param>
		[DataRow(new int[] { 1, 2, 3, 4, 5 })]
		[DataRow(new int[] { 5, 4, 3, 2, 1 })]
		[DataRow(new int[] { 1, 2, 1, 2, 3 })]
		[DataRow(new int[] { 3, 4, 5, 2, 1 })]
		[TestMethod]
		public void GetSortedArrayInAscendingOrder_WithCorrectArgument_ShouldGetSortedArray(int[] array)
		{
			var sortedArray = new ArraySorter().GetSortedArrayInAscendingOrder(array); 

			for(var index = 0; index < sortedArray.Length - 1; index++)
			{
				Assert.IsTrue(sortedArray[index] <= sortedArray[index + 1]);
			}
		}

		/// <summary>
		/// Сортировка в порядке убывания null-массива.
		/// </summary>
		/// <exception cref="ArgumentNullException">Массив равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void GetSortedArrayInDescendingOrder_WithNullArgument_ShouldThrowArgumentNullException()
		{
			new ArraySorter().GetSortedArrayInDescendingOrder(null); 
		}

		/// <summary>
		/// Сортировка в порядке убывания корректного массива.
		/// </summary>
		/// <param name="array">Массив.</param>
		[DataRow(new int[] { 1, 2, 3, 4, 5 })]
		[DataRow(new int[] { 5, 4, 3, 2, 1 })]
		[DataRow(new int[] { 1, 2, 1, 2, 3 })]
		[DataRow(new int[] { 3, 4, 5, 2, 1 })]
		[TestMethod]
		public void GetSortedArrayInDescendingOrder_WithCorrectArgument_ShouldGetSortedArray(int[] array)
		{
			var sortedArray = new ArraySorter().GetSortedArrayInDescendingOrder(array);

			for (var index = 0; index < sortedArray.Length - 1; index++)
			{
				Assert.IsTrue(sortedArray[index] >= sortedArray[index + 1]);
			}
		}

		/// <summary>
		/// Создание экземпляра класса для работы с массивами с null-сортировщиком массивов.
		/// </summary>
		/// <exception cref="ArgumentNullException">Сортировщик массивов равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateArrayWorker_WithNullValueInConstructor_ShouldThrowArgumentNullException() 
		{
			new ArrayWorker(null);
		}

		/// <summary>
		/// Создание экземпляра класса для работы с массивами с корректным сортировщиком массивов.
		/// </summary>
		[TestMethod]
		public void CreateArrayWorker_WithCorrectValueInConstructor_ShouldCreateArrayWorker() 
		{
			new ArrayWorker(new ArraySorter());
		}

		/// <summary>
		/// Сортировка в порядке возрастания null-массива c помощью экземпляра класса для работы с массивами.
		/// </summary>
		/// <exception cref="ArgumentNullException">Массив равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void GetSortedArrayInAscendingOrderFromArrayWorker_WithNullArgument_ShouldThrowArgumentNullException()
		{
			new ArrayWorker(new ArraySorter()).GetSortedArrayInAscendingOrder(null);
		}

		/// <summary>
		/// Сортировка в порядке возрастания корректного массива c помощью экземпляра класса для работы с массивами.
		/// </summary>
		/// <param name="array">Массив.</param>
		[DataRow(new int[] { 1, 2, 3, 4, 5 })]
		[DataRow(new int[] { 5, 4, 3, 2, 1 })]
		[DataRow(new int[] { 1, 2, 1, 2, 3 })]
		[DataRow(new int[] { 3, 4, 5, 2, 1 })]
		[TestMethod]
		public void GetSortedArrayInAscendingOrderFromArrayWorker_WithCorrectArgument_ShouldGetSortedArray(int[] array)
		{
			var sortedArray = new ArrayWorker(new ArraySorter()).GetSortedArrayInAscendingOrder(array);

			for (var index = 0; index < sortedArray.Length - 1; index++)
			{
				Assert.IsTrue(sortedArray[index] <= sortedArray[index + 1]);
			}
		}

		/// <summary>
		/// Сортировка в порядке убывания null-массива c помощью экземпляра класса для работы с массивами.
		/// </summary>
		/// <exception cref="ArgumentNullException">Массив равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void GetSortedArrayInDescendingOrderFromArrayWorker_WithNullArgument_ShouldThrowArgumentNullException()
		{
			new ArrayWorker(new ArraySorter()).GetSortedArrayInDescendingOrder(null);
		}

		/// <summary>
		/// Сортировка в порядке убывания корректного массива c помощью экземпляра класса для работы с массивами.
		/// </summary>
		/// <param name="array">Массив.</param>
		[DataRow(new int[] { 1, 2, 3, 4, 5 })]
		[DataRow(new int[] { 5, 4, 3, 2, 1 })]
		[DataRow(new int[] { 1, 2, 1, 2, 3 })]
		[DataRow(new int[] { 3, 4, 5, 2, 1 })]
		[TestMethod]
		public void GetSortedArrayInDescendingOrderFromArrayWorker_WithCorrectArgument_ShouldGetSortedArray(int[] array)
		{
			var sortedArray = new ArrayWorker(new ArraySorter()).GetSortedArrayInDescendingOrder(array);

			for (var index = 0; index < sortedArray.Length - 1; index++)
			{
				Assert.IsTrue(sortedArray[index] >= sortedArray[index + 1]);
			}
		}
		#endregion
	}
}
