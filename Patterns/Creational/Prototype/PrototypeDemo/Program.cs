
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
            var firstCustomer = new Customer();
            firstCustomer.Id = 1;
            firstCustomer.FirstName = "FirstName";
            firstCustomer.LastName = "LastName";
            firstCustomer.Patronymic = "Patronymic";
            firstCustomer.Passport.Number = 1;
            firstCustomer.Passport.Series = 1;
            firstCustomer.Passport.ReceiptPlace = "УФМС по Самарской области";

            var secondCustomer = (Customer)firstCustomer.Clone();
            secondCustomer.Id = 2;
            secondCustomer.FirstName = "FirstName2";
            secondCustomer.Passport.Series = 2;
            secondCustomer.Passport.Number = 2;

            var firstExecutor = new Executor
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                Patronymic = "Patronymic",
            };

            var secondExecutor = (Executor)firstExecutor.Clone();
            secondExecutor.Id = 2;
            secondExecutor.FirstName = "FirstName2";

            Console.WriteLine($"Первый заказчик: {firstCustomer}{Environment.NewLine}Второй заказчик (склонированный): {secondCustomer}" +
                $"{Environment.NewLine}Первый исполнитель: {firstExecutor}{Environment.NewLine}Второй исполнитель (склонированный) {secondExecutor}");
        }
        #endregion
    }
}
