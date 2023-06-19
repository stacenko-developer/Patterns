namespace Patterns
{
    /// <summary>
	/// �������� ������������ ���������� �������� Factory Method.
	/// </summary>
    [TestClass]
    public class FactoryMethodTests
    {
        #region ������.
        /// <summary>
        /// �������� ������������ �������� �������� ����� ������� � ������� ������������.
        /// </summary>
        [TestMethod]
        public void CreateSamsung_BySamsungDeveloper_ShouldReturnSamsung()
        {
            Assert.IsTrue(new SamsungDeveloper().CreatePhone() is Samsung);
        }

        /// <summary>
        /// �������� ������������ �������� �������� ����� ����� � ������� ������������.
        /// </summary>
        [TestMethod]
        public void CreateNokia_ByNokiaDeveloper_ShouldReturnNokia() 
        {
            Assert.IsTrue(new NokiaDeveloper().CreatePhone() is Nokia);
        }
        #endregion
    }
}