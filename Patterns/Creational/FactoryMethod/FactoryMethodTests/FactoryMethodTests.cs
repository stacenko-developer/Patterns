namespace Patterns
{
    /// <summary>
	/// Проверка корректности реализации паттерна Factory Method.
	/// </summary>
    [TestClass]
    public class FactoryMethodTests
    {
        #region Методы.
        /// <summary>
        /// Проверка корректности создания телефона фирмы Самсунг с помощью разработчика.
        /// </summary>
        [TestMethod]
        public void CreateSamsung_BySamsungDeveloper_ShouldReturnSamsung()
        {
            Assert.IsTrue(new SamsungDeveloper().CreatePhone() is Samsung);
        }

        /// <summary>
        /// Проверка корректности создания телефона фирмы Нокиа с помощью разработчика.
        /// </summary>
        [TestMethod]
        public void CreateNokia_ByNokiaDeveloper_ShouldReturnNokia() 
        {
            Assert.IsTrue(new NokiaDeveloper().CreatePhone() is Nokia);
        }
        #endregion
    }
}