namespace Patterns
{
    /// <summary>
	/// Проверка корректности реализации паттерна Prototype.
	/// </summary>
    [TestClass]
    public class PrototypeTests
    {
        #region Методы.
        /// <summary>
        /// Проверка корректности клонирования заказчика.
        /// </summary>
        [TestMethod]
        public void CloneCustomer_WithCorrectArguments_ShouldReturnNewCustomer()
        {
            var firstCustomer = new Customer();
            firstCustomer.Id = 1;
            firstCustomer.FirstName = "FirstName";
            firstCustomer.LastName = "LastName";
            firstCustomer.Patronymic = "Patronymic";
            firstCustomer.Passport.Number = 1;
            firstCustomer.Passport.Series = 1;
            firstCustomer.Passport.ReceiptPlace = "УФМС по Самарской области";

            var secondCustomer = (Customer)firstCustomer.Clone();
            secondCustomer.Id = 2;
            secondCustomer.FirstName = "FirstName2";
            secondCustomer.Passport.Series = 2;
            secondCustomer.Passport.Number = 2;

            Assert.IsTrue(firstCustomer != secondCustomer && firstCustomer.Id != secondCustomer.Id 
                && firstCustomer.FirstName != secondCustomer.FirstName && firstCustomer.LastName == secondCustomer.LastName 
                && firstCustomer.Patronymic == secondCustomer.Patronymic && firstCustomer.Passport != secondCustomer.Passport
                && firstCustomer.Passport.Series != secondCustomer.Passport.Series && firstCustomer.Passport.Number != secondCustomer.Passport.Number
                && firstCustomer.Passport.ReceiptPlace == secondCustomer.Passport.ReceiptPlace);
        }

        /// <summary>
        /// Проверка корректности клонирования исполнителя.
        /// </summary>
        [TestMethod]
        public void CloneExecutor_WithCorrectArguments_ShouldReturnNewExecutor() 
        {
            var firstExecutor = new Executor();
            firstExecutor.Id = 1;
            firstExecutor.FirstName = "FirstName";
            firstExecutor.LastName = "LastName";
            firstExecutor.Patronymic = "Patronymic";

            var secondExecutor = (Executor)firstExecutor.Clone();
            secondExecutor.Id = 2;
            secondExecutor.FirstName = "FirstName2";

            Assert.IsTrue(firstExecutor != secondExecutor && firstExecutor.Id != secondExecutor.Id
                && firstExecutor.FirstName != secondExecutor.FirstName && firstExecutor.LastName == secondExecutor.LastName
                && firstExecutor.Patronymic == secondExecutor.Patronymic);
        }
        #endregion
    }
}