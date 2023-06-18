namespace Patterns
{
    /// <summary>
	/// Проверка корректности реализации паттерна Builder.
	/// </summary>
    [TestClass]
    public class BuilderTests
    {
        #region Поля.
        /// <summary>
        /// Корректное значение модели для компьютера HP.
        /// </summary>
        private string _correctDELLModel = "DELL";

        /// <summary>
        /// Корректное значение процессора для компьютера HP.
        /// </summary>
        private string _correctDELLProcessor = "Intel Core i3-10100";

        /// <summary>
        /// Корректное значение оперативной памяти для компьютера HP.
        /// </summary>
        private int _correctDELLRandomAccessMemoryCount = 4;

        /// <summary>
        /// Корректное значение операционной системы для компьютера HP.
        /// </summary>
        private string _correctDELLOperationSystem = "Windows 10";

        /// <summary>
        /// Модель.
        /// </summary>
        private string _correctHPModel = "HP"; 

        /// <summary>
        /// Процессор.
        /// </summary>
        private string _correctHPProcessor = "Intel Core i5-7400"; 

        /// <summary>
        /// Количество оперативной памяти.
        /// </summary>
        private int _correctHPRandomAccessMemoryCount = 8;

        /// <summary>
        /// Операционная система.
        /// </summary>
        private string _correctHPOoperationSystem = "Windows 10 Pro"; 
        #endregion 

        #region Методы.
        /// <summary>
        /// Проверка корректности создания разработчика компьютеров DELL.
        /// </summary>
        [TestMethod]
        public void CreateDELLComputerDeveloper_ByConstructor_ShouldCreateDELLComputerDeveloper()
        {
            new DELLComputerDeveloper();
        }

        /// <summary>
        /// Проверка корректности создания разработчика компьютеров HP.
        /// </summary>
        [TestMethod]
        public void CreateHPComputerDeveloper_ByConstructor_ShouldCreateHPComputerDeveloper()
        {
            new HPComputerDeveloper();
        }

        /// <summary>
        /// Создание директора с null-аргументом в конструкторе.
        /// </summary>
        /// <exception cref="ArgumentNullException">Разработчик компьютеров равен null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateDirector_WithNullArgumentInConstructor_ShouldThrowArgumentNullException()
        {
            new Director(null);
        }

        /// <summary>
        /// Создание директора с null-аргументом в конструкторе.
        /// </summary>
        [TestMethod]
        public void CreateDirector_WithCorrectArgumentInConstructor_ShouldCreateDirector()
        {
            new Director(new DELLComputerDeveloper());
        }

        /// <summary>
        /// Проверка корректности создания компьютер DELL. 
        /// </summary>
        [TestMethod]
        public void CreateDELLFullComputer_WithCorrectArguments_ShouldReturnCorrectComputer()
        {
            var computer = new Director(new DELLComputerDeveloper()).CreateFullComputer();

            Assert.IsTrue(computer.Model == _correctDELLModel && computer.Processor == _correctDELLProcessor 
                && computer.RandomAccessMemory == _correctDELLRandomAccessMemoryCount && computer.OperationSystem == _correctDELLOperationSystem);
        }

        /// <summary>
        /// Проверка корректности создания компьютер DELL без операционной системы. 
        /// </summary>
        [TestMethod]
        public void CreateDELLComputerWithoutOperationSystem_WithCorrectArguments_ShouldReturnCorrectComputer()
        {
            var computer = new Director(new DELLComputerDeveloper()).CreateComputerWithoutOperationSystem();

            Assert.IsTrue(computer.Model == _correctDELLModel && computer.Processor == _correctDELLProcessor
                && computer.RandomAccessMemory == _correctDELLRandomAccessMemoryCount && computer.OperationSystem == null);
        }

        /// <summary>
        /// Проверка корректности создания компьютера HP. 
        /// </summary>
        [TestMethod]
        public void CreateHPFullComputer_WithCorrectArguments_ShouldReturnCorrectComputer()
        {
            var computer = new Director(new HPComputerDeveloper()).CreateFullComputer();

            Assert.IsTrue(computer.Model == _correctHPModel && computer.Processor == _correctHPProcessor
                && computer.RandomAccessMemory == _correctHPRandomAccessMemoryCount && computer.OperationSystem == _correctHPOoperationSystem);
        }

        /// <summary>
        /// Проверка корректности создания компьютер HP без операционной системы. 
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