using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    /// <summary>
    /// Бухгалтегия.
    /// </summary>
    public abstract class Accounting
    {
        #region Поля.
        /// <summary>
        /// Список сотрудников для выплаты зарплаты.
        /// </summary>
        protected List<Worker> _workers = new List<Worker>();

        /// <summary>
        /// Зарплаты сотрудников.
        /// </summary>
        protected Dictionary<string, decimal> _workersSalary = new Dictionary<string, decimal>();
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создание бухгалтерии.
        /// </summary>
        public Accounting()
        {   
            _workers = new List<Worker>();
            _workersSalary = new Dictionary<string, decimal>();
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Проверка корректности идентификатора сотрудника.
        /// </summary>
        /// <exception cref="ArgumentNullException">Идентификатор сотрудника равен null!</exception>
        protected void ValidateWorkerId(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Идентификатор сотрудника равен null!");
            }
        }

        /// <summary>
        /// Проверка наличия сотрудника в базе.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника, которого необходимо проверить.</param>
        protected void ValidateWorkerExistence(Guid id)
        {
            if (_workers.FirstOrDefault(worker => worker.Id == id) == null) 
            {
                throw new ArgumentNullException(nameof(id), "Сотрудник с указанным идентификатором не найден!");
            }
        }

        /// <summary>
        /// Проверка того, была ли выплачена зарплата работнику ранее.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <exception cref="ArgumentOutOfRangeException">Данному сотруднику уже выплачена зарплата!</exception>
        protected void ValidatePaidSalary(Guid id)
        {
            if (_workers.FirstOrDefault(worker => worker.Id == id).IsSalaryPaid)
            {
                throw new ArgumentOutOfRangeException("Данному сотруднику уже выплачена зарплата!");
            }
        }

        /// <summary>
        /// Получение расчитанной зарплаты сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Расчитанная зарплата.</returns>
        protected virtual decimal GetCalculationSalary(Guid id)
            => _workersSalary[_workers.FirstOrDefault(worker => worker.Id == id).Post];

        /// <summary>
        /// Выплата зарплаты сотруднику.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника, которого необходимо проверить.</param>
        public decimal GetSalary(Guid id)
        {
            ValidateWorkerId(id);
            ValidateWorkerExistence(id);
            ValidatePaidSalary(id);

            _workers.FirstOrDefault(worker => worker.Id == id).IsSalaryPaid = true;

            return GetCalculationSalary(id);
        }

        /// <summary>
        /// Добавление сотрудника в базу бухгалтерии.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronymic">Отчество.</param>
        /// <param name="post">Должность.</param>
        /// <exception cref="ArgumentOutOfRangeException">Сотрудник с указанными данными уже есть в базе!</exception>
        /// <exception cref="ArgumentNullException">Указанная должность в бухгалтерии не найдена!</exception>
        public Guid AddWorker(string firstName, string lastName, string patronymic, string post)
        {
            Validator.ValidateStringText(firstName);
            Validator.ValidateStringText(lastName);
            Validator.ValidateStringText(patronymic);
            Validator.ValidateStringText(post);

            if (!_workersSalary.ContainsKey(post))
            {
                throw new ArgumentNullException("Указанная должность в бухгалтерии не найдена!");
            }

            var id = Guid.NewGuid();

            _workers.Add(new Worker
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Patronymic = patronymic,
                Post = post,
                IsSalaryPaid = false
            });

            return id;
        }

        /// <summary>
        /// Получение сотрудника по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Сотрудника.</returns>
        public Worker GetWorker(Guid id)
        {
            ValidateWorkerId(id);
            ValidateWorkerExistence(id);

            return _workers.First(worker => worker.Id == id);
        }

        /// <summary>
        /// Удаляет сотрудника из базы.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника, которого необходимо удалить.</param>
        /// <exception cref="ArgumentNullException">Сотрудник с указанным идентификатором не найден в базе!</exception>
        public void DeleteWorker(Guid id)
        {
            ValidateWorkerExistence(id);

            _workers.Remove(_workers.FirstOrDefault(worker => worker.Id == id));
        }
        #endregion

    }
}
