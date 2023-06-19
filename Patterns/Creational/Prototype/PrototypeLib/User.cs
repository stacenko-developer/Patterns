

namespace Patterns
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public abstract class User
    {
        #region Свойства.
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }
        #endregion

        #region Методы.
        /// <summary>
        /// Клонирование пользователя.
        /// </summary>
        /// <returns>Нового пользователя.</returns>
        public abstract User Clone();

        /// <summary>
        /// Строковое представления объекта пользователя.
        /// </summary>
        /// <returns>Данные пользователя в виде строки.</returns>
        public override string ToString() => $"Идентификатор - {Id} Имя - {FirstName} Фамилия - {LastName} Отчество - {Patronymic}";
        #endregion 
    }
}
