
namespace Patterns
{
    /// <summary>
    /// Содержит методы для разработчика компьютеров.
    /// </summary>
    public interface IComputerDeveloper
    {   
        /// <summary>
        /// Установка процессора.
        /// </summary>
        void SetProcessor();

        /// <summary>
        /// Установка оперативной памяти.
        /// </summary>
        void SetRandomAccessMemory();

        /// <summary>
        /// Установка операционной системы.
        /// </summary>
        void SetOperationSystem();

        /// <summary>
        /// Получение компьютера.
        /// </summary>
        /// <returns>Компьютер.</returns>
        Computer GetComputer();
    }
}
