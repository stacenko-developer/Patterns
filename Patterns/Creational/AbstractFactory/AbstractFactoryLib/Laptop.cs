
namespace Patterns
{
	/// <summary>
	/// Ноутбук.
	/// </summary>
	public class Laptop : WorkingDevice
	{
		#region Конструкторы.
		/// <summary>
		/// Создание ноутбука с помощью указанных параметров.   
		/// </summary>
		/// <param name="model">Модель ноутбука.</param>
		/// <param name="price">Цена ноутбука.</param>
		public Laptop(string model, int price)
			: base(model, price)
		{
		}

		/// <summary>
		/// Создание ноутбука.
		/// </summary>
		public Laptop()
			: base()
		{
		}
		#endregion

		#region Методы.

		#region Переопределенные методы.
		/// <summary>
		/// Получить стоимость дополнительных аксессуаров.
		/// </summary>
		/// <returns>Стоимость дополнительных аксессуаров.</returns>
		public override int GetAccessoriesCost() => _defaultMouseCost + _defaultBatteryChargerCost;
		#endregion

		#endregion
	}
}
