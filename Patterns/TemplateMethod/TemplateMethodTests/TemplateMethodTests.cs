namespace Patterns
{
    /// <summary>
    /// Проверка корректности реализации паттерна TemplateMethod.
    /// </summary>
    [TestClass]
    public class TemplateMethodTests
    {
        #region Поля.
        /// <summary>
        /// Сотрудник по умолчанию.
        /// </summary>
        private Worker _defaultWorker = new Worker
        {
            FirstName = "Артем",
            LastName = "Стаценко",
            Patronymic = "Николаевич",
            Post = "Программист",
            IsSalaryPaid = false
        };
        #endregion

        #region Методы.
        /// <summary>
        /// Проверка корректности создания бухгалтерии Сбера.
        /// </summary>
        [TestMethod]
        public void CreateSberAccounting_WithoutParametersInConstructor_ShouldCreateSberAccounting()
        {
            new SberAccounting();
        }

        /// <summary>
        /// Добавление сотрудника в базу бухгалтерии Сбера с null-аргументами.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronymic">Отчество.</param>
        /// <param name="post">Должность.</param>
        /// <exception cref="ArgumentNullException">Поля сотрудника равны null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null, "Стаценко", "Николаевич", "Программист")]
        [DataRow("Артем", null, "Николаевич", "Программист")]
        [DataRow("Артем", "Стаценко", null, "Программист")]
        [DataRow("Артем", "Стаценко", "Николаевич", null)]
        [TestMethod]
        public void AddWorkerInSberAccounting_WithNullArguments_ShouldThrowArgumentNullException(string firstName, string lastName, string patronymic,
            string post)
        {
            new SberAccounting().AddWorker(firstName, lastName, patronymic, post);
        }

        /// <summary>
        /// Добавление сотрудника в бухгалтерию Сбера с несуществующей должностью.
        /// </summary>
        /// <exception cref="ArgumentNullException">Указанная должность в бухгалтерии не найдена!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddWorkerInSberAccounting_WithIncorrectPost_ShouldAddWorker() 
        {
            new SberAccounting().AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                "Должность");
        }

        /// <summary>
        /// Добавление сотрудника в бухгалтерию Сбера с корректными параметрами.
        /// </summary>
        [TestMethod]
        public void AddWorkerInSberAccounting_WithCorrectArguments_ShouldAddWorker() 
        {
            new SberAccounting().AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic, 
                _defaultWorker.Post);
        }

        /// <summary>
        /// Получение сотрудника из бухгалтерии Сбера по несуществующему идентификатору.
        /// </summary>
        /// <exception cref="ArgumentNullException">Сотрудник с указанным идентификатором не найден!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetWorkerFromSberAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new SberAccounting().GetWorker(Guid.NewGuid());
        }

        /// <summary>
        /// Получение сотрудника из бухгалтерии Сбера по существующему идентификатору.
        /// </summary>
        [TestMethod]
        public void GetWorkerFromSberAccounting_WithExistenceId_ShouldReturnWorker()
        {
            var sberAccounting = new SberAccounting();
            var worker = sberAccounting.GetWorker(sberAccounting.AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post));

            Assert.IsTrue(worker.FirstName == _defaultWorker.FirstName && worker.LastName == _defaultWorker.LastName 
                && worker.Patronymic == _defaultWorker.Patronymic && worker.Post == _defaultWorker.Post 
                && worker.IsSalaryPaid == _defaultWorker.IsSalaryPaid);
        }

        /// <summary>
        /// Удаление сотрудника из бухгалтерии Сбера по несуществующему идентификатору.
        /// </summary>
        /// <exception cref="ArgumentNullException">Сотрудник с указанным идентификатором не найден!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void DeleteWorkerFromSberAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new SberAccounting().DeleteWorker(Guid.NewGuid());
        }

        /// <summary>
        /// Удаление сотрудника из бухгалтерии Сбера по существующему идентификатору.
        /// </summary>
        [TestMethod]
        public void DeleteWorkerFromSberAccounting_WithExistenceId_ShouldDeleteWorker()
        {
            var sberAccounting = new SberAccounting();
            sberAccounting.DeleteWorker(sberAccounting.AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post));
        }

        /// <summary>
        /// Выдача зарплаты сотруднику в бухгалтерии Сбера с несуществующим идентификатором.
        /// </summary>
        /// <exception cref="ArgumentNullException">Сотрудник с указанным идентификатором не существует.</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetSalaryFromSberAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new SberAccounting().GetSalary(Guid.NewGuid());
        }

        /// <summary>
        /// Выдача зарплаты сотруднику в бухгалтерии Сбера с существующим идентификатором.
        /// </summary>
        [TestMethod]
        public void GetSalaryFromSberAccounting_WithExistenceId_ShouldGetSalary()
        {
            var sberAccounting = new SberAccounting();
            var id = sberAccounting.AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post);

            sberAccounting.GetSalary(id);
            
            Assert.IsTrue(sberAccounting.GetWorker(id).IsSalaryPaid);
        }

        /// <summary>
        /// Проверка корректности создания бухгалтерии Озона.
        /// </summary>
        [TestMethod]
        public void CreateOzonAccounting_WithoutParametersInConstructor_ShouldCreateOzonAccounting()
        {
            new OzonAccounting();
        }

        /// <summary>
        /// Добавление сотрудника в базу бухгалтерии Озона с null-аргументами.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronymic">Отчество.</param>
        /// <param name="post">Должность.</param>
        /// <exception cref="ArgumentNullException">Поля сотрудника равны null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null, "Стаценко", "Николаевич", "Программист")]
        [DataRow("Артем", null, "Николаевич", "Программист")]
        [DataRow("Артем", "Стаценко", null, "Программист")]
        [DataRow("Артем", "Стаценко", "Николаевич", null)]
        [TestMethod]
        public void AddWorkerInOzonAccounting_WithNullArguments_ShouldThrowArgumentNullException(string firstName, string lastName, string patronymic,
            string post)
        {
            new OzonAccounting().AddWorker(firstName, lastName, patronymic, post);
        }

        /// <summary>
        /// Добавление сотрудника в бухгалтерию Озона с корректными параметрами.
        /// </summary>
        [TestMethod]
        public void AddWorkerInOzonAccounting_WithCorrectArguments_ShouldAddWorker() 
        {
            new OzonAccounting().AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post);
        }

        /// <summary>
        /// Добавление сотрудника в бухгалтерию Озона с несуществующей должностью.
        /// </summary>
        /// <exception cref="ArgumentNullException">Указанная должность в бухгалтерии не найдена!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddWorkerInOzonAccounting_WithIncorrectPost_ShouldAddWorker()
        {
            new OzonAccounting().AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                "Должность");
        }

        /// <summary>
        /// Получение сотрудника из бухгалтерии Озона по несуществующему идентификатору.
        /// </summary>
        /// <exception cref="ArgumentNullException">Сотрудник с указанным идентификатором не найден!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetWorkerFromOzonAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new OzonAccounting().GetWorker(Guid.NewGuid());
        }

        /// <summary>
        /// Получение сотрудника из бухгалтерии Озона по существующему идентификатору.
        /// </summary>
        [TestMethod]
        public void GetWorkerFromOzonAccounting_WithExistenceId_ShouldReturnWorker() 
        {
            var ozonAccounting = new OzonAccounting();
            var worker = ozonAccounting.GetWorker(ozonAccounting.AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post));

            Assert.IsTrue(worker.FirstName == _defaultWorker.FirstName && worker.LastName == _defaultWorker.LastName
                && worker.Patronymic == _defaultWorker.Patronymic && worker.Post == _defaultWorker.Post
                && worker.IsSalaryPaid == _defaultWorker.IsSalaryPaid);
        }

        /// <summary>
        /// Удаление сотрудника из бухгалтерии Озона по несуществующему идентификатору.
        /// </summary>
        /// <exception cref="ArgumentNullException">Сотрудник с указанным идентификатором не найден!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void DeleteWorkerFromOzonAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new OzonAccounting().DeleteWorker(Guid.NewGuid());
        }

        /// <summary>
        /// Удаление сотрудника из бухгалтерии Озона по существующему идентификатору.
        /// </summary>
        [TestMethod]
        public void DeleteWorkerFromOzonAccounting_WithExistenceId_ShouldDeleteWorker()
        {
            var ozonAccounting = new OzonAccounting();
            ozonAccounting.DeleteWorker(ozonAccounting.AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post));
        }

        /// <summary>
        /// Выдача зарплаты сотруднику в бухгалтерии Озона с несуществующим идентификатором. 
        /// </summary>
        /// <exception cref="ArgumentNullException">Сотрудник с указанным идентификатором не существует.</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetSalaryFromOzonAccounting_WithNotExistenceId_ShouldThrowArgumentNullException() 
        {
            new OzonAccounting().GetSalary(Guid.NewGuid());
        }

        /// <summary>
        /// Выдача зарплаты сотруднику в бухгалтерии Озона с существующим идентификатором.
        /// </summary>
        [TestMethod]
        public void GetSalaryOzonSberAccounting_WithExistenceId_ShouldGetSalary()
        {
            var ozonAccounting = new OzonAccounting();
            var id = ozonAccounting.AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post);

            ozonAccounting.GetSalary(id);

            Assert.IsTrue(ozonAccounting.GetWorker(id).IsSalaryPaid);
        }
        #endregion 
    }
}