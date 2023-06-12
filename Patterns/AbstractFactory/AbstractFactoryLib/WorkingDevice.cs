
namespace Patterns
{
	/// <summary>
	/// Рабочее устройство.
	/// </summary>
	public abstract class WorkingDevice
	{
		#region Поля.
		/// <summary>
		/// Значение минимальной цены по умолчанию. 
		/// </summary>
		private int _defaultMinPrice = 10000; 

		/// <summary>
		/// Значение максимальной цены по умолчанию.
		/// </summary>
		private int _defaultMaxPrice = 300000;

		/// <summary>
		/// Модель.
		/// </summary>
		protected string _model;

		/// <summary>
		/// Цена.
		/// </summary>
		protected int _price;

		/// <summary>
		/// Модель устройства по умолчанию.
		/// </summary>
		protected static string DefaultModel = "Модель не указана";

		/// <summary>
		/// Цена по умолчанию.
		/// </summary>
		protected static int DefaultPrice = 50000;

		/// <summary>
		/// Цена мышки по умолчанию.
		/// </summary>
		protected int _defaultMouseCost = 2000;

		/// <summary>
		/// Цена клавиатуры по умолчанию.
		/// </summary>
		protected int _defaultKeyboardCost = 4000;

		/// <summary>
		/// Стоимость зарядки по умолчанию.
		/// </summary>
		protected int _defaultBatteryChargerCost = 3000;
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание рабочего устройства с помощью указанных параметров. 
		/// </summary>
		/// <param name="model">Модель устройства.</param>
		/// <param name="price">Цена устройства.</param>
		protected WorkingDevice(string model, int price)
		{
			Validator.ValidateStringText(model);
			Validator.ValidateRangeNumber(_defaultMinPrice, _defaultMaxPrice, price);

			_model = model;
			_price = price;
		}

		/// <summary>
		/// Создание рабочего устройства.
		/// </summary>
		protected WorkingDevice()
			: this(DefaultModel, DefaultPrice)
		{
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Получить стоимость дополнительных аксессуаров.
		/// </summary>
		/// <returns>Стоимость дополнительных аксессуаров.</returns>
		public abstract int GetAccessoriesCost();
		#endregion
	}
}
