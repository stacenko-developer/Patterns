namespace Patterns
{
    /// <summary>
	/// �������� ������������ ���������� �������� Builder.
	/// </summary>
    [TestClass]
    public class BuilderTests
    {
        #region ����.
        /// <summary>
        /// ���������� �������� ������ ��� ���������� HP.
        /// </summary>
        private string _correctDELLModel = "DELL";

        /// <summary>
        /// ���������� �������� ���������� ��� ���������� HP.
        /// </summary>
        private string _correctDELLProcessor = "Intel Core i3-10100";

        /// <summary>
        /// ���������� �������� ����������� ������ ��� ���������� HP.
        /// </summary>
        private int _correctDELLRandomAccessMemoryCount = 4;

        /// <summary>
        /// ���������� �������� ������������ ������� ��� ���������� HP.
        /// </summary>
        private string _correctDELLOperationSystem = "Windows 10";

        /// <summary>
        /// ������.
        /// </summary>
        private string _correctHPModel = "HP"; 

        /// <summary>
        /// ���������.
        /// </summary>
        private string _correctHPProcessor = "Intel Core i5-7400"; 

        /// <summary>
        /// ���������� ����������� ������.
        /// </summary>
        private int _correctHPRandomAccessMemoryCount = 8;

        /// <summary>
        /// ������������ �������.
        /// </summary>
        private string _correctHPOoperationSystem = "Windows 10 Pro"; 
        #endregion 

        #region ������.
        /// <summary>
        /// �������� ������������ �������� ������������ ����������� DELL.
        /// </summary>
        [TestMethod]
        public void CreateDELLComputerDeveloper_ByConstructor_ShouldCreateDELLComputerDeveloper()
        {
            new DELLComputerDeveloper();
        }

        /// <summary>
        /// �������� ������������ �������� ������������ ����������� HP.
        /// </summary>
        [TestMethod]
        public void CreateHPComputerDeveloper_ByConstructor_ShouldCreateHPComputerDeveloper()
        {
            new HPComputerDeveloper();
        }

        /// <summary>
        /// �������� ��������� � null-���������� � ������������.
        /// </summary>
        /// <exception cref="ArgumentNullException">����������� ����������� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateDirector_WithNullArgumentInConstructor_ShouldThrowArgumentNullException()
        {
            new Director(null);
        }

        /// <summary>
        /// �������� ��������� � null-���������� � ������������.
        /// </summary>
        [TestMethod]
        public void CreateDirector_WithCorrectArgumentInConstructor_ShouldCreateDirector()
        {
            new Director(new DELLComputerDeveloper());
        }

        /// <summary>
        /// �������� ������������ �������� ��������� DELL. 
        /// </summary>
        [TestMethod]
        public void CreateDELLFullComputer_WithCorrectArguments_ShouldReturnCorrectComputer()
        {
            var computer = new Director(new DELLComputerDeveloper()).CreateFullComputer();

            Assert.IsTrue(computer.Model == _correctDELLModel && computer.Processor == _correctDELLProcessor 
                && computer.RandomAccessMemory == _correctDELLRandomAccessMemoryCount && computer.OperationSystem == _correctDELLOperationSystem);
        }

        /// <summary>
        /// �������� ������������ �������� ��������� DELL ��� ������������ �������. 
        /// </summary>
        [TestMethod]
        public void CreateDELLComputerWithoutOperationSystem_WithCorrectArguments_ShouldReturnCorrectComputer()
        {
            var computer = new Director(new DELLComputerDeveloper()).CreateComputerWithoutOperationSystem();

            Assert.IsTrue(computer.Model == _correctDELLModel && computer.Processor == _correctDELLProcessor
                && computer.RandomAccessMemory == _correctDELLRandomAccessMemoryCount && computer.OperationSystem == null);
        }

        /// <summary>
        /// �������� ������������ �������� ���������� HP. 
        /// </summary>
        [TestMethod]
        public void CreateHPFullComputer_WithCorrectArguments_ShouldReturnCorrectComputer()
        {
            var computer = new Director(new HPComputerDeveloper()).CreateFullComputer();

            Assert.IsTrue(computer.Model == _correctHPModel && computer.Processor == _correctHPProcessor
                && computer.RandomAccessMemory == _correctHPRandomAccessMemoryCount && computer.OperationSystem == _correctHPOoperationSystem);
        }

        /// <summary>
        /// �������� ������������ �������� ��������� HP ��� ������������ �������. 
        /// </summary>
        [TestMethod]
        public void CreateHPComputerWithoutOperationSystem_WithCorrectArguments_ShouldReturnCorrectComputer()
        {
            var computer = new Director(new HPComputerDeveloper()).CreateComputerWithoutOperationSystem();

            Assert.IsTrue(computer.Model == _correctHPModel && computer.Processor == _correctHPProcessor
                && computer.RandomAccessMemory == _correctHPRandomAccessMemoryCount && computer.OperationSystem == null);
        }

        #endregion
    }
}