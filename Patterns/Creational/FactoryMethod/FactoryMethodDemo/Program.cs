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
            var nokiaPrice = 10000;
            var nokiaModel = "3310"; 
            var nokiaProcessor = "RAP3G"; 
            var nokiaRandomAccessMemory = 1;

            var samsungPrice = 100000;
            var samsungModel = "S23";
            var samsungProcessor = "Snap Dragon";
            var samsungRandomAccessMemory = 8;

            var nokia = new NokiaDeveloper().CreatePhone();
            nokia.Price = nokiaPrice;
            nokia.Model = nokiaModel;
            nokia.Processor = nokiaProcessor;
            nokia.RandomAccessMemory = nokiaRandomAccessMemory;

            var samsung = new SamsungDeveloper().CreatePhone();
            samsung.Price = samsungPrice;
            samsung.Model = samsungModel;
            samsung.Processor = samsungProcessor;
            samsung.RandomAccessMemory = samsungRandomAccessMemory;

            Console.WriteLine($"Созданные телефоны:{Environment.NewLine}{nokia}{Environment.NewLine}{samsung}");
        }
        #endregion
    }
}
