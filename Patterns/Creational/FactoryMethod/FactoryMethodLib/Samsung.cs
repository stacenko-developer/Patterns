
namespace Patterns
{
    /// <summary>
    /// Самсунг.
    /// </summary>
    public class Samsung : Phone
    {
        #region Свойства.
        /// <summary>
        /// Влючена ли сейчас фронтальная камера.
        /// </summary>
        public bool IsFrontCamera { get; set; }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представления объекта Самсунга.
        /// </summary>
        /// <returns>Данные Самсунга в виде строки.</returns>
        public override string ToString() => $"Самсунг: {base.ToString()} Включена ли фронтальная камера = {IsFrontCamera}";
        #endregion 
    }
}
