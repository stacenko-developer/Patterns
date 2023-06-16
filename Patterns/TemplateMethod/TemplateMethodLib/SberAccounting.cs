using System;
using System.Collections.Generic;

namespace Patterns
{
    /// <summary>
    /// Бухгалтерия Сбера.
    /// </summary>
    public class SberAccounting : Accounting
    {
        #region Поля.
        /// <summary>
        /// Премия.
        /// </summary>
        private decimal _prize = 5000;
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создание бухгалтерии Сбера.
        /// </summary>
        public SberAccounting() 
        {
            _workers = new List<Worker>();

            _workersSalary = new Dictionary<string, decimal>
            {
                {"Менеджер", 30000 },
                {"Программист", 100000 }
            };
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Получение расчитанной зарплаты сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Расчитанная зарплата.</returns>
        protected override decimal GetCalculationSalary(Guid id) => base.GetCalculationSalary(id) + _prize;

        #endregion
    }
}
