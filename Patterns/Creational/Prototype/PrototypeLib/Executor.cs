
namespace Patterns
{
    /// <summary>
    /// Исполнитель.
    /// </summary>
    public class Executor : User
    {
        #region Методы.
        /// <summary>
        /// Клонирование пользователя.
        /// </summary>
        /// <returns>Нового пользователя.</returns>
        public override User Clone() => (Executor)MemberwiseClone();

        /// <summary>
        /// Строковое представления объекта исполнителя.
        /// </summary>
        /// <returns>Данные исполнителя в виде строки.</returns>
        public override string ToString() => $"Данные исполнителя: {base.ToString()}";
        #endregion
    }
}
