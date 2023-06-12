using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
	/// <summary>
	/// Фильтр сотрудников по занимаемой должности.
	/// </summary>
	public class PostWorkersFilter : AdditionalFilteringCondition
	{
		#region Поля.
		/// <summary>
		/// Значение занимаемой должности по умолчанию. 
		/// </summary>
		private string _defaultPost = "Консультант"; 
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание фильтра сотрудников по занимаемой должности с помощью указанных параметров.
		/// </summary>
		/// <param name="filter">Базовый фильтр сотрудников Норбит.</param>
		public PostWorkersFilter(NorbitWorkersFilter filter)
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
			.Where(worker => worker.Post == _defaultPost)
			.ToList();
		#endregion

		#endregion
	}
}
