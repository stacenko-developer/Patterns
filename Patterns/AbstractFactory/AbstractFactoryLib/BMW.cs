
namespace Patterns
{
	/// <summary>
	/// Автомобиль марки BMW.
	/// </summary>
	public class BMW : WorkingCar
	{
		#region Конструкторы.
		/// <summary>
		/// Создание BMW с помощью указанных параметров.   
		/// </summary>
		/// <param name="model">Модель автомобиля.</param>
		/// <param name="price">Цена автомобиля.</param>
		/// <param name="releaseYear">Год выпуска автомобиля.</param>
		public BMW(string model, int price, int releaseYear)
			: base(model, price, releaseYear)
		{
		}

		/// <summary>
		/// Создание BMW.
		/// </summary>
		public BMW()
			: base()
		{
		}
		#endregion

		#region Методы.

		#region Переопределенные методы.
		/// <summary>
		/// Получить стоимость налога.
		/// </summary>
		/// <returns>Налог.</returns>
		public override int GetTax() => _minTax * _baseRatio * _baseRatioForLuxury;
		#endregion

		#endregion
	}
}
