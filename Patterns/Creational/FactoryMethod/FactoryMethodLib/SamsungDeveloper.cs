namespace Patterns
{
    /// <summary>
    /// Разработчик телефонов фирмы Самсунг.
    /// </summary>
    public class SamsungDeveloper
    {
        #region Методы.
        /// <summary>
        /// Создание телефона.
        /// </summary>
        /// <returns>Телефон.</returns>
        public Phone CreatePhone() => new Samsung();
        #endregion
    }
}
