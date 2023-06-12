using System;

namespace Patterns
{
	/// <summary>
	/// Сотрудник Норбит.
	/// </summary>
	public class NorbitWorker
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
		/// Создание сотрудника Норбит с помощью указанных параметров.
		/// </summary>
		/// <param name="norbitWorkerFactory">Фабрика сотрудника Норбит.</param>
		/// <exception cref="ArgumentNullException">Фабрика сотрудника Норбит равна null!</exception>
		public NorbitWorker(INorbitWorkerFactory norbitWorkerFactory)
		{
			if (norbitWorkerFactory == null)
			{
				throw new ArgumentNullException(nameof(norbitWorkerFactory),
					"Фабрика для создания сотрудника Норбит равна null!");
			}

			_workingCar = norbitWorkerFactory.CreateWorkingCar();
			_workingDevice = norbitWorkerFactory.CreateWorkingDevice();
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
		/// Строковое представления объекта сотрудника Норбит. 
		/// </summary>
		/// <returns>Данные сотрудника Норбит в виде строки.</returns>
		public override string ToString() => $"Стоимость налога на рабочий автомобиль {GetTax()}" +
			$"{Environment.NewLine} Стоимость дополнительных аксессуаров для рабочего устройства: " +
			$"{GetAccessoriesCost()}";
		#endregion

		#endregion
	}
}
