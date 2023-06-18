
namespace Patterns
{   
    /// <summary>
    /// Компьютер.
    /// </summary>
    public class Computer
    {
        #region Свойства.
        /// <summary>
        /// Модель.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Процессор.
        /// </summary>
        public string Processor { get; set; }

        /// <summary>
        /// Оперативная память.
        /// </summary>
        public int RandomAccessMemory { get; set; }

        /// <summary>
        /// Операционная система.
        /// </summary>
        public string OperationSystem { get; set; }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представления объекта компьютера.
        /// </summary>
        /// <returns>Данные объекта компьютера в виде строки.</returns>
        public override string ToString() => $"Характеристики компьютера: Модель: {Model} Процессор: {Processor} " +
            $"Оперативная память: {RandomAccessMemory} Операционная система: {OperationSystem}";
        #endregion
    }
}
