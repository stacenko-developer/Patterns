
namespace Patterns 
{
    /// <summary>
    /// Телефон.
    /// </summary>
    public abstract class Phone
    {
        #region Свойства.
        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Модель.
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Процессор.
        /// </summary>
        public string Processor { get; set; } = string.Empty;

        /// <summary>
        /// Оперативная память.
        /// </summary>
        public int RandomAccessMemory { get; set; }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представления объекта телефона.
        /// </summary>
        /// <returns>Данные телефона в виде строки.</returns>
        public override string ToString() => $"Цена = {Price} Модель = {Model} Процессор = {Processor} Оперативная память = {RandomAccessMemory}";
        #endregion 
    }
}
