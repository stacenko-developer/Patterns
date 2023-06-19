
namespace Patterns
{
    /// <summary>
    /// Разработчик телефонов фирмы Нокиа.
    /// </summary>
    public class NokiaDeveloper : IPhoneDeveloper
    {
        #region Методы.
        /// <summary>
        /// Создание телефона.
        /// </summary>
        /// <returns>Телефон.</returns>
        public Phone CreatePhone() => new Nokia();
        #endregion
    }
}
