
namespace Patterns
{
    /// <summary>
    /// Заказчик
    /// </summary>
    public class Customer : User
    {
        #region Свойства.
        /// <summary>
        /// Паспорт.
        /// </summary>
        public Passport Passport { get; set; }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создание пользователя.
        /// </summary>
        public Customer()
        {
            Passport = new Passport();
        }
        #endregion 

        #region Методы.
        /// <summary>
        /// Клонирование пользователя.
        /// </summary>
        /// <returns>Нового пользователя.</returns>
        public override User Clone()
        {
            var customer = (Customer)MemberwiseClone();
            customer.Passport = new Passport();
            customer.Passport.Series = Passport.Series;
            customer.Passport.Number = Passport.Number;
            customer.Passport.ReceiptPlace = Passport.ReceiptPlace;

            return customer;
        }

        /// <summary>
        /// Строковое представления объекта заказчика.
        /// </summary>
        /// <returns>Данные заказчика в виде строки.</returns>
        public override string ToString() => $"Данные заказчика: {base.ToString()} {Passport}";
        #endregion
    }
}
