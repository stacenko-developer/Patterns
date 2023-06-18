
namespace Patterns
{
    /// <summary>
    /// Разработчик компьютеров HP.
    /// </summary>
    public class HPComputerDeveloper : IComputerDeveloper
    {
        #region Поля.
        /// <summary>
        /// Компьютер.
        /// </summary>
        private Computer _computer;

        /// <summary>
        /// Модель.
        /// </summary>
        private string _model = "HP";

        /// <summary>
        /// Процессор.
        /// </summary>
        private string _processor = "Intel Core i5-7400";

        /// <summary>
        /// Количество оперативной памяти.
        /// </summary>
        private int _randomAccessMemoryCount = 8;

        /// <summary>
        /// Операционная система.
        /// </summary>
        private string _operationSystem = "Windows 10 Pro";
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создание разработчика компьютеров HP.
        /// </summary>
        public HPComputerDeveloper() 
        {
            _computer = new Computer();
            _computer.Model = _model;
        }
        #endregion 

        #region Методы.
        /// <summary>
        /// Установка процессора.
        /// </summary>
        public void SetProcessor()
        {
            _computer.Processor = _processor;
        }

        /// <summary>
        /// Установка оперативной памяти.
        /// </summary>
        public void SetRandomAccessMemory()
        {
            _computer.RandomAccessMemory = _randomAccessMemoryCount;
        }

        /// <summary>
        /// Установка операционной системы.
        /// </summary>
        public void SetOperationSystem()
        {
            _computer.OperationSystem = _operationSystem;
        }

        /// <summary>
        /// Получение компьютера.
        /// </summary>
        /// <returns>Компьютер.</returns>
        public Computer GetComputer() => _computer;
        #endregion 
    }
}
