using System;

namespace Patterns
{
    /// <summary>
    /// Директор.
    /// </summary>
    public class Director
    {
        #region Поля.
        /// <summary>
        /// Разработчик компьютеров.
        /// </summary>
        private IComputerDeveloper _computerDeveloper;
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создание директора с помощью указанных параметров.
        /// </summary>
        /// <param name="computerDeveloper">Разработчик компьютеров.</param>
        /// <exception cref="ArgumentNullException">Разработчик компьютеров равен null!</exception>
        public Director(IComputerDeveloper computerDeveloper) 
        {
            if (computerDeveloper == null)
            {
                throw new ArgumentNullException(nameof(computerDeveloper), "Разработчик компьютеров равен null!");
            }

            _computerDeveloper = computerDeveloper;
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Создание полноценного компьютера.
        /// </summary>
        /// <returns>Созданный компьютер.</returns>
        public Computer CreateFullComputer()
        {
            _computerDeveloper.SetProcessor();
            _computerDeveloper.SetRandomAccessMemory();
            _computerDeveloper.SetOperationSystem();

            return _computerDeveloper.GetComputer();
        }

        /// <summary>
        /// Создание компьютера без операционной системы.
        /// </summary>
        /// <returns>Созданный компьютер.</returns>
        public Computer CreateComputerWithoutOperationSystem()
        {
            _computerDeveloper.SetProcessor();
            _computerDeveloper.SetRandomAccessMemory();

            return _computerDeveloper.GetComputer();
        }
        #endregion
    }
}
