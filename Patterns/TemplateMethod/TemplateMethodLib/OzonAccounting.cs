using System;
using System.Collections.Generic;

namespace Patterns
{
    /// <summary>
    /// Бухгалтерия Ozon.
    /// </summary>
    public class OzonAccounting : Accounting
    {
        #region Поля.
        /// <summary>
        /// Плата за корпоративное такси в месяц для поезди от дома до работы и обратно.
        /// </summary>
        private decimal _taxiCostByMonth = 15000;
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создание бухгалтерии Озона.
        /// </summary>
        public OzonAccounting()
        {
            _workers = new List<Worker>();

            _workersSalary = new Dictionary<string, decimal>
            {
                { "Менеджер", 40000 },
                { "Программист", 90000 }
            };
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Получение расчитанной зарплаты сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Расчитанная зарплата.</returns>
        protected override decimal GetCalculationSalary(Guid id) => base.GetCalculationSalary(id) - _taxiCostByMonth;
        #endregion
    }
}
