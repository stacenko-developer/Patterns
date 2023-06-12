using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    /// <summary>
    /// Офис.
    /// </summary>
    public class Office
    {
        #region Поля.
        /// <summary>
        /// Название офиса.
        /// </summary>
        protected string _name; 

        /// <summary>
        /// Адрес.
        /// </summary>
        protected string _address;

        /// <summary>
        /// Сотрудники.
        /// </summary>
        protected List<Worker> _workers;

        /// <summary>
        /// Количество сотрудников по умолчанию.
        /// </summary>
        private int _defaultWorkersCount = 10;

        /// <summary>
        /// Зарплата сотрудника по умолчанию.
        /// </summary>
        private int _defaultSalary = 40000;

        /// <summary>
        /// Значение возраста по умолчанию.
        /// </summary>
        private int _defaultAge = 25;

        /// <summary>
        /// Название организации по умолчанию.
        /// </summary>
        private string _defaultOrganization = "Norbit";
        #endregion

        #region Свойства.
        /// <summary>
        /// Получение названия офиса.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Получение адреса.
        /// </summary>
        public string Address => _address;

        /// <summary>
        /// Сотрудники.
        /// </summary>
        public List<Worker> Workers => _workers;
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает офис с помощью указанных параметров.
        /// </summary>
        /// <param name="name">Название офиса.</param>
        /// <param name="address">Адрес офиса.</param>
        public Office(string name, string address)
        {
            Validator.ValidateStringText(name);
            Validator.ValidateStringText(address);

            _name = name;
            _address = address;
            _workers = new List<Worker>();

            for (var i = 0; i < _defaultWorkersCount; i++)
            {
                _workers.Add(new Worker
                {
                    FirstName = $"Имя {i}",
                    LastName = $"Фамилия {i}",
                    Patronymic = $"Отчество {i}",
                    Age = _defaultAge,
                    Post = $"Должность {i}",
                    Salary = _defaultSalary,
                    Organization = _defaultOrganization
                });
            }
        }
        #endregion

        #region Методы.

        #region Переопределенные методы.
        /// <summary>
        /// Строковое представления объекта офиса.
        /// </summary>
        /// <returns>Данные объекта офиса в виде строки.</returns>
        public override string ToString() => $"Название: {_name} {Environment.NewLine}Адрес: " +
            $"{_address} {Environment.NewLine} {string.Join("\n", _workers)}";
        #endregion

        /// <summary>
        /// Получение суммарного количество выплат всем сотрудникам каждый месяц.
        /// </summary>
        /// <returns>Суммарный размер выплаты.</returns>
        public int GetTotalSalary() => _workers.Sum(worker => worker.Salary);
        #endregion
    }
}
