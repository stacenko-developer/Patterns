using System;

namespace Patterns
{
	/// <summary>
	/// Сотрудник.
	/// </summary>
	public class Worker
	{
		#region Поля.
		/// <summary>
		/// Рабочий автомобиль.
		/// </summary>
		private WorkingCar _workingCar; 

		/// <summary>
		/// Рабочее устройство.
		/// </summary>
		private WorkingDevice _workingDevice;
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание сотрудника с помощью указанных параметров.
		/// </summary>
		/// <param name="workerFactory">Фабрика сотрудника.</param>
		/// <exception cref="ArgumentNullException">Фабрика сотрудника равна null!</exception>
		public Worker(IWorkerFactory workerFactory)
		{
			if (workerFactory == null)
			{
				throw new ArgumentNullException(nameof(workerFactory),
					"Фабрика для создания сотрудника равна null!");
			}

			_workingCar = workerFactory.CreateWorkingCar();
			_workingDevice = workerFactory.CreateWorkingDevice();
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Получить стоимость налога за автомобиль.
		/// </summary>
		/// <returns>Стоимость налога.</returns>
		public int GetTax() => _workingCar.GetTax();

		/// <summary>
		/// Получить стоимость дополнительных аксессуаров для рабочего устройства.
		/// </summary>
		/// <returns>Стоимость дополнительных аксессуаров.</returns>
		public int GetAccessoriesCost() => _workingDevice.GetAccessoriesCost();

		#region Переопределенные методы.
		/// <summary>
		/// Строковое представления объекта сотрудника. 
		/// </summary>
		/// <returns>Данные сотрудника Норбит в виде строки.</returns>
		public override string ToString() => $"Стоимость налога на рабочий автомобиль {GetTax()}" +
			$"{Environment.NewLine} Стоимость дополнительных аксессуаров для рабочего устройства: " +
			$"{GetAccessoriesCost()}";
		#endregion

		#endregion
	}
}
