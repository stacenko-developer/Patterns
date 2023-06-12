using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
	/// <summary>
	/// Фильтр сотрудников по возрасту.
	/// </summary>
	public class AgeWorkersFilter : AdditionalFilteringCondition
	{
		#region Поля.
		/// <summary>
		/// Минимальное допустимое значение возраста.  
		/// </summary>
		private int _defaultMinCorrectAge = 25; 
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание фильтра сотрудников по возрасту с помощью указанных параметров.
		/// </summary>
		/// <param name="filter">Базовый фильтр сотрудников Норбит.</param>
		public AgeWorkersFilter(NorbitWorkersFilter filter)
			: base(filter)
		{
			Workers = filter.GetFiltratedList();
		}
		#endregion

		#region Методы.

		#region Переопределенные методы.
		/// <summary>
		/// Получение отфильтрованного списка сотрудников.
		/// </summary>
		/// <returns>Отфильтрованный список сотрудников.</returns>
		public override List<Worker> GetFiltratedList() => Workers
			.Where(worker => worker.Age >= _defaultMinCorrectAge)
			.ToList();
		#endregion

		#endregion
	}
}
