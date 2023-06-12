
using System;

namespace Patterns
{
	class Program
	{
		#region Методы.
		static void Main(string[] args)
		{
			RunDemo();
		}

		/// <summary>
		/// Выполнение основного функционала.
		/// </summary>
		private static void RunDemo()
		{
			var arrayForSorting = new int[] { 6, 5, 4, 7, 8, 9, 0, 2, 1 };
			var arrayWorker = new ArrayWorker(new ArraySorter());

			Console.WriteLine($"Массив для сортировки: " +
				$"{string.Join(" ", arrayForSorting)}{Environment.NewLine}");
			Console.WriteLine($"Отсортированный массив в порядке возрастания: " +
				$"{string.Join(" ", arrayWorker.GetSortedArrayInAscendingOrder(arrayForSorting))}" +
				$"{Environment.NewLine}");
			Console.WriteLine($"Отсортированный массив в порядке убывания: " +
				$"{string.Join(" ", arrayWorker.GetSortedArrayInDescendingOrder(arrayForSorting))}");
		}
		#endregion
	}
}
