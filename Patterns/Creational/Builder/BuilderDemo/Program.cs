namespace Patterns
{
    class Program
    {
        #region Методы.
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Набор аргументов.</param> 
        private static void Main(string[] args)
        {
            RunDemo();
        }

        /// <summary>
        /// Выполнение основного функционала.
        /// </summary>
        private static void RunDemo()
        {
            Console.WriteLine($"Создание полноценного компьютера HP:{Environment.NewLine}" +
                $"{new Director(new HPComputerDeveloper()).CreateFullComputer()}{Environment.NewLine}" +
                $"Создание компьютера HP без операционной системы:{Environment.NewLine}" +
                $"{new Director(new HPComputerDeveloper()).CreateComputerWithoutOperationSystem()}{Environment.NewLine}{Environment.NewLine}" +
                $"Создание полноценного компьютера DELL:{Environment.NewLine}" +
                $"{new Director(new DELLComputerDeveloper()).CreateFullComputer()}{Environment.NewLine}" +
                $"Создание полноценного компьютера DELL:{Environment.NewLine}" +
                $"{new Director(new DELLComputerDeveloper()).CreateComputerWithoutOperationSystem()}{Environment.NewLine}");
        }
        #endregion
    }
}
