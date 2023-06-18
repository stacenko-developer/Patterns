using System;

namespace Patterns
{
	/// <summary>
	/// Реализует алгоритм обхода файловой системы.
	/// </summary>
	public class FileSystemNumerator : IFileIterator
	{
		#region Поля.
		/// <summary>
		/// Содержит методы для создания объекта-итератора.
		/// </summary>
		private IFileNumerable _aggregate;

		/// <summary>
		/// Индекс текущего элемента.
		/// </summary>
		private int _index = 0;
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание итератора файловой системы с помощью указанных параметров.
		/// </summary>
		/// <param name="aggregate">Содержит методы для создания объекта-итератора.</param>
		/// <exception cref="ArgumentNullException">Интерфейс для создания объекта-итератора равен null!</exception>
		public FileSystemNumerator(IFileNumerable aggregate)
		{
			if (aggregate == null)
			{
				throw new ArgumentNullException(nameof(aggregate), 
					"Интерфейс для создания объекта-итератора равен null!");
			}

			_aggregate = aggregate;
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Проверяет наличие следующего элемента.
		/// </summary>
		/// <returns>Результат проверки.</returns>
		public bool HasNext() => _index < _aggregate.Count;

		/// <summary>
		/// Получение следующего элемента из файловой системы.
		/// </summary>
		/// <returns>Следующий файл.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Индекс вышел за границы!</exception>
		public File Next()
		{
			if (!HasNext())
			{
				throw new ArgumentOutOfRangeException("Индекс вышел за границы!");
			}

			return _aggregate[_index++];
		}
		#endregion
	}
}
