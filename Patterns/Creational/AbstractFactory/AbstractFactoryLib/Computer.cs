
namespace Patterns
{
	/// <summary>
	/// Компьютер.
	/// </summary>
	public class Computer : WorkingDevice
	{
		#region Конструкторы.
		/// <summary> 
		/// Создание компьютера с помощью указанных параметров.  
		/// </summary>
		/// <param name="model">Модель компьютера.</param>
		/// <param name="price">Цена компьютера.</param>
		public Computer(string model, int price)
			: base(model, price)
		{
		}

		/// <summary>
		/// Создание компьютера.
		/// </summary>
		public Computer()
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
		public override int GetAccessoriesCost() => _defaultMouseCost + _defaultKeyboardCost;
		#endregion

		#endregion
	}
}
