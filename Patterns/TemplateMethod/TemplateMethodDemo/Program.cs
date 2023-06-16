namespace Patterns
{
    class Program
    {
        #region Методы.
        private static void Main(string[] args)
        {
            RunDemo();
        }

        /// <summary>
        /// Выполнение основного функционала.
        /// </summary>
        private static void RunDemo()
        {
            var ozonAccounting = new OzonAccounting();
            var sberAccounting = new SberAccounting();
            var ozonWorkersIds = new List<Guid>();
            var sberWorkersIds = new List<Guid>();
            var workersCount = 5;

            for (var i = 0; i < workersCount; i++)
            {
                ozonWorkersIds.Add(ozonAccounting.AddWorker($"Имя {i}", $"Фамилия {i}", $"Отчество {i}", i % 2 == 0 ? "Программист" : "Менеджер"));
                sberWorkersIds.Add(sberAccounting.AddWorker($"Имя {i}", $"Фамилия {i}", $"Отчество {i}", i % 2 == 0 ? "Программист" : "Менеджер"));
            }

            Console.WriteLine($"Сотрудники Сбера:{Environment.NewLine}{Environment.NewLine}");
            PrintStatistics(sberWorkersIds, sberAccounting);

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Сотрудники Озона:{Environment.NewLine}{Environment.NewLine}");
            PrintStatistics(ozonWorkersIds, ozonAccounting);
        }

        /// <summary>
        /// Вывод на экран статистики сотрудников.
        /// </summary>
        /// <param name="workersIds">Идентификаторы сотрудников.</param>
        /// <param name="accounting">Бухгалтерия.</param>
        private static void PrintStatistics(List<Guid> workersIds, Accounting accounting)
        {
            foreach (var workerId in workersIds)
            {
                Console.WriteLine($"Сотдуник: {accounting.GetWorker(workerId)} Зарплата: {accounting.GetSalary(workerId)}");
            }
        }
        #endregion
    }
}
