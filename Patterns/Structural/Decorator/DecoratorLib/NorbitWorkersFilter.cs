using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
	/// <summary>
	/// Фильтр сотрудников.
	/// </summary>
	public class NorbitWorkersFilter : WorkersFilter
	{
		#region Поля.
		/// <summary>
		/// Сотрудники.
		/// </summary>
		protected static List<Worker> Workers; 

		/// <summary>
		/// Название организации по умолчанию.
		/// </summary>
		private string _defaultOrganization = "Норбит";
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание фильтра сотрудников с помощью указанных параметров.
		/// </summary>
		/// <param name="workers">Список сотрудников.</param>
		/// <exception cref="ArgumentNullException">Список сотрудников или его элементы равны null!</exception>
		public NorbitWorkersFilter(List<Worker> workers)
		{
			if (workers == null || workers.FindIndex(worker => worker == null) != -1)
			{
				throw new ArgumentNullException(nameof(workers), "Список сотрудников или его элементы равны null!");
			}

			Workers = workers;
		}
		#endregion

		#region Методы.

		#region Переопределенные методы.
		/// <summary>
		/// Получение отфильтрованного списка сотрудников.
		/// </summary>
		/// <returns>Отфильтрованный список сотрудников.</returns>
		public override List<Worker> GetFiltratedList() => Workers
			.Where(worker => worker.Organization == _defaultOrganization)
			.ToList();
		#endregion

		#endregion
	}
}
