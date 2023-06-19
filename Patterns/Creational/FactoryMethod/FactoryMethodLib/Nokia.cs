
namespace Patterns
{
    /// <summary>
    /// Нокиа.
    /// </summary>
    public class Nokia : Phone
    {
        #region Свойства.
        /// <summary>
        /// Работает ли батарея.
        /// </summary>
        public bool IsBatteryWork { get; set; }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представления объекта Нокиа.
        /// </summary>
        /// <returns>Данные Нокиа в виде строки.</returns>
        public override string ToString() => $"Нокиа: {base.ToString()} Работает ли батарея = {IsBatteryWork}";
        #endregion 
    }
}
