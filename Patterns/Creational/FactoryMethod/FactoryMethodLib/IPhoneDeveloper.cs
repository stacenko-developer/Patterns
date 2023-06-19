
namespace Patterns
{
    /// <summary>
    /// Содержит методы для рабработчика телефонов.
    /// </summary>
    public interface IPhoneDeveloper
    {   
        /// <summary>
        /// Создание телефона.
        /// </summary>
        /// <returns>Телефон.</returns>
        Phone CreatePhone();
    }
}
