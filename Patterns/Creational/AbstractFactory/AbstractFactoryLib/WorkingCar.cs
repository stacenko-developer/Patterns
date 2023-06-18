
namespace Patterns
{
	/// <summary>
	/// Рабочий автомобиль.
	/// </summary>
	public abstract class WorkingCar
	{
		#region Поля.
		/// <summary>
		/// Значение минимальной цены по умолчанию. 
		/// </summary>
		private int _defaultMinPrice = 1000000; 

		/// <summary>
		/// Значение максимальной цены по умолчанию.
		/// </summary>
		private int _defaultMaxPrice = 10000000;

		/// <summary>
		/// Значение минимального года выпуска по умолчанию.
		/// </summary>
		private int _defaultMinReleaseYear = 2000;

		/// <summary>
		/// Значение максимального года выпуска по умолчанию.
		/// </summary>
		private int _defaultMaxReleaseYear = 2022;

		/// <summary>
		/// Модель автомобиля.
		/// </summary>
		protected string _model;

		/// <summary>
		/// Цена.
		/// </summary>
		protected int _price;

		/// <summary>
		/// Год выпуска.
		/// </summary>
		protected int _releaseYear;

		/// <summary>
		/// Минимальная сумма налога.
		/// </summary>
		protected int _minTax = 500;

		/// <summary>
		/// Базовый коэффициент.
		/// </summary>
		protected int _baseRatio = 2;

		/// <summary>
		/// Коэффициент для налога на роскошь.
		/// </summary>
		protected int _baseRatioForLuxury = 5;

		/// <summary>
		/// Год выпуска по умолчанию.
		/// </summary>
		protected static int DefaultYearRelease = 2002;

		/// <summary>
		/// Цена по умолчанию.
		/// </summary>
		protected static int DefaultPrice = 2500000;

		/// <summary>
		/// Модель автомобиля по умолчанию.
		/// </summary>
		protected static string DefaultModel = "Модель не указана";
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание рабочего автомобиля с помощью указанных параметров. 
		/// </summary>
		/// <param name="model">Модель автомобиля.</param>
		/// <param name="price">Цена автомобиля.</param>
		/// <param name="releaseYear">Год выпуска автомобиля.</param>
		protected WorkingCar(string model, int price, int releaseYear)
		{
			Validator.ValidateStringText(model);
			Validator.ValidateRangeNumber(_defaultMinPrice, _defaultMaxPrice, price);
			Validator.ValidateRangeNumber(_defaultMinReleaseYear, _defaultMaxReleaseYear, releaseYear);

			_model = model;
			_price = price;
			_releaseYear = releaseYear;
		}

		/// <summary>
		/// Создание рабочего автомобиля.
		/// </summary>
		protected WorkingCar()
			: this(DefaultModel, DefaultPrice, DefaultYearRelease)
		{
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Получить стоимость налога.
		/// </summary>
		/// <returns>Налог.</returns>
		public abstract int GetTax();
		#endregion
	}
}
