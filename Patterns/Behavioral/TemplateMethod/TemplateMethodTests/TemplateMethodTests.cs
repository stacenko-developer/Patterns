namespace Patterns
{
    /// <summary>
    /// �������� ������������ ���������� �������� TemplateMethod.
    /// </summary>
    [TestClass]
    public class TemplateMethodTests
    {
        #region ����.
        /// <summary>
        /// ��������� �� ���������.
        /// </summary>
        private Worker _defaultWorker = new Worker
        {
            FirstName = "�����",
            LastName = "��������",
            Patronymic = "����������",
            Post = "�����������",
            IsSalaryPaid = false
        };
        #endregion

        #region ������.
        /// <summary>
        /// �������� ������������ �������� ����������� �����.
        /// </summary>
        [TestMethod]
        public void CreateSberAccounting_WithoutParametersInConstructor_ShouldCreateSberAccounting()
        {
            new SberAccounting();
        }

        /// <summary>
        /// ���������� ���������� � ���� ����������� ����� � null-�����������.
        /// </summary>
        /// <param name="firstName">���.</param>
        /// <param name="lastName">�������.</param>
        /// <param name="patronymic">��������.</param>
        /// <param name="post">���������.</param>
        /// <exception cref="ArgumentNullException">���� ���������� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null, "��������", "����������", "�����������")]
        [DataRow("�����", null, "����������", "�����������")]
        [DataRow("�����", "��������", null, "�����������")]
        [DataRow("�����", "��������", "����������", null)]
        [TestMethod]
        public void AddWorkerInSberAccounting_WithNullArguments_ShouldThrowArgumentNullException(string firstName, string lastName, string patronymic,
            string post)
        {
            new SberAccounting().AddWorker(firstName, lastName, patronymic, post);
        }

        /// <summary>
        /// ���������� ���������� � ����������� ����� � �������������� ����������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� ��������� � ����������� �� �������!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddWorkerInSberAccounting_WithIncorrectPost_ShouldAddWorker() 
        {
            new SberAccounting().AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                "���������");
        }

        /// <summary>
        /// ���������� ���������� � ����������� ����� � ����������� �����������.
        /// </summary>
        [TestMethod]
        public void AddWorkerInSberAccounting_WithCorrectArguments_ShouldAddWorker() 
        {
            new SberAccounting().AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic, 
                _defaultWorker.Post);
        }

        /// <summary>
        /// ��������� ���������� �� ����������� ����� �� ��������������� ��������������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� � ��������� ��������������� �� ������!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetWorkerFromSberAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new SberAccounting().GetWorker(Guid.NewGuid());
        }

        /// <summary>
        /// ��������� ���������� �� ����������� ����� �� ������������� ��������������.
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
        /// �������� ���������� �� ����������� ����� �� ��������������� ��������������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� � ��������� ��������������� �� ������!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void DeleteWorkerFromSberAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new SberAccounting().DeleteWorker(Guid.NewGuid());
        }

        /// <summary>
        /// �������� ���������� �� ����������� ����� �� ������������� ��������������.
        /// </summary>
        [TestMethod]
        public void DeleteWorkerFromSberAccounting_WithExistenceId_ShouldDeleteWorker()
        {
            var sberAccounting = new SberAccounting();
            sberAccounting.DeleteWorker(sberAccounting.AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post));
        }

        /// <summary>
        /// ������ �������� ���������� � ����������� ����� � �������������� ���������������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� � ��������� ��������������� �� ����������.</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetSalaryFromSberAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new SberAccounting().GetSalary(Guid.NewGuid());
        }

        /// <summary>
        /// ������ �������� ���������� � ����������� ����� � ������������ ���������������.
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
        /// �������� ������������ �������� ����������� �����.
        /// </summary>
        [TestMethod]
        public void CreateOzonAccounting_WithoutParametersInConstructor_ShouldCreateOzonAccounting()
        {
            new OzonAccounting();
        }

        /// <summary>
        /// ���������� ���������� � ���� ����������� ����� � null-�����������.
        /// </summary>
        /// <param name="firstName">���.</param>
        /// <param name="lastName">�������.</param>
        /// <param name="patronymic">��������.</param>
        /// <param name="post">���������.</param>
        /// <exception cref="ArgumentNullException">���� ���������� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null, "��������", "����������", "�����������")]
        [DataRow("�����", null, "����������", "�����������")]
        [DataRow("�����", "��������", null, "�����������")]
        [DataRow("�����", "��������", "����������", null)]
        [TestMethod]
        public void AddWorkerInOzonAccounting_WithNullArguments_ShouldThrowArgumentNullException(string firstName, string lastName, string patronymic,
            string post)
        {
            new OzonAccounting().AddWorker(firstName, lastName, patronymic, post);
        }

        /// <summary>
        /// ���������� ���������� � ����������� ����� � ����������� �����������.
        /// </summary>
        [TestMethod]
        public void AddWorkerInOzonAccounting_WithCorrectArguments_ShouldAddWorker() 
        {
            new OzonAccounting().AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post);
        }

        /// <summary>
        /// ���������� ���������� � ����������� ����� � �������������� ����������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� ��������� � ����������� �� �������!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddWorkerInOzonAccounting_WithIncorrectPost_ShouldAddWorker()
        {
            new OzonAccounting().AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                "���������");
        }

        /// <summary>
        /// ��������� ���������� �� ����������� ����� �� ��������������� ��������������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� � ��������� ��������������� �� ������!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetWorkerFromOzonAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new OzonAccounting().GetWorker(Guid.NewGuid());
        }

        /// <summary>
        /// ��������� ���������� �� ����������� ����� �� ������������� ��������������.
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
        /// �������� ���������� �� ����������� ����� �� ��������������� ��������������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� � ��������� ��������������� �� ������!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void DeleteWorkerFromOzonAccounting_WithNotExistenceId_ShouldThrowArgumentNullException()
        {
            new OzonAccounting().DeleteWorker(Guid.NewGuid());
        }

        /// <summary>
        /// �������� ���������� �� ����������� ����� �� ������������� ��������������.
        /// </summary>
        [TestMethod]
        public void DeleteWorkerFromOzonAccounting_WithExistenceId_ShouldDeleteWorker()
        {
            var ozonAccounting = new OzonAccounting();
            ozonAccounting.DeleteWorker(ozonAccounting.AddWorker(_defaultWorker.FirstName, _defaultWorker.LastName, _defaultWorker.Patronymic,
                _defaultWorker.Post));
        }

        /// <summary>
        /// ������ �������� ���������� � ����������� ����� � �������������� ���������������. 
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� � ��������� ��������������� �� ����������.</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetSalaryFromOzonAccounting_WithNotExistenceId_ShouldThrowArgumentNullException() 
        {
            new OzonAccounting().GetSalary(Guid.NewGuid());
        }

        /// <summary>
        /// ������ �������� ���������� � ����������� ����� � ������������ ���������������.
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