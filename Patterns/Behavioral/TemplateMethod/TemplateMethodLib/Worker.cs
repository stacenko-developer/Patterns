using System;

namespace Patterns
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class Worker
    {
        #region Свойства.
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }    

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// Выплачена ли зарплата.
        /// </summary>
        public bool IsSalaryPaid { get; set; }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое преставление объекта сотрудника.
        /// </summary>
        /// <returns>Данные объекта сотрудника в виде строки.</returns>
        public override string ToString() => $"Имя: {FirstName} Фамилия: {LastName} Отчество: {Patronymic} Должность: {Post} " +
            $"Выплачена ли зарплата: {IsSalaryPaid}";
        #endregion
    }
}
