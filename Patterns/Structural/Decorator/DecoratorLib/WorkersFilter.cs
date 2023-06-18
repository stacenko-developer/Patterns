using System.Collections.Generic;

namespace Patterns
{
    /// <summary>
    /// Фильтр.
    /// </summary>
    public abstract class WorkersFilter
    {
        #region Методы.
        /// <summary>
        /// Получение отфильтрованного списка.
        /// </summary>
        /// <returns>Отфильтрованный список.</returns>  
        public abstract List<Worker> GetFiltratedList(); 
        #endregion
    }
}
