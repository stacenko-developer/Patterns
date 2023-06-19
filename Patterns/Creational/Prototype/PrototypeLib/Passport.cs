
namespace Patterns
{
    /// <summary>
    /// Паспорт.
    /// </summary>
    public class Passport
    {
        #region Свойства.
        /// <summary>
        /// Серия.
        /// </summary>
        public int Series { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Кем выдан.
        /// </summary>
        public string ReceiptPlace { get; set; }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представления объекта пользователя.
        /// </summary>
        /// <returns>Данные пользователя в виде строки.</returns>
        public override string ToString() => $"Паспортные данные: серия - {Series} номер - {Number} выдан - {ReceiptPlace}";
        #endregion
    }
}
