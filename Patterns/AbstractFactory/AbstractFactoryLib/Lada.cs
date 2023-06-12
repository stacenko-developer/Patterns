
namespace Patterns
{
	/// <summary>
	/// Автомобиль марки Лада.
	/// </summary>
	public class Lada : WorkingCar
	{
		#region Конструкторы.
		/// <summary>
		/// Создание лады с помощью указанных параметров.   
		/// </summary>
		/// <param name="model">Модель автомобиля.</param>
		/// <param name="price">Цена автомобиля.</param>
		/// <param name="releaseYear">Год выпуска автомобиля.</param>
		public Lada(string model, int price, int releaseYear)
			: base(model, price, releaseYear)
		{
		}

		/// <summary>
		/// Создание лады.
		/// </summary>
		public Lada()
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
		public override int GetTax() => _minTax * _baseRatio;
		#endregion

		#endregion
	}
}
