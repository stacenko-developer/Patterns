using System;

namespace Patterns
{
	/// <summary>
	/// Дополнительное условие фильтрации.
	/// </summary>
	public class AdditionalFilteringCondition : NorbitWorkersFilter
	{
		#region Поля.
		/// <summary>
		/// Фильтр сотрудников Норбит.
		/// </summary>
		protected NorbitWorkersFilter _filter; 
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создает дополнительное условие фильтрации с помощью указанных параметров.
		/// </summary>
		/// <param name="filter">Фильтр сотрудников Норбит.</param>
		public AdditionalFilteringCondition(NorbitWorkersFilter filter)
			: base(Workers)
		{
			if (filter == null)
			{
				throw new ArgumentNullException(nameof(filter), "Фильтр равен null!");
			}

			_filter = filter;
			Workers = base.GetFiltratedList();
		}
		#endregion
	}
}
