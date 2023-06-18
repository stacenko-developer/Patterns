
namespace Patterns
{
	/// <summary>
	/// Фабрика сотрудника.
	/// </summary>
	public interface IWorkerFactory 
	{
		#region Методы.
		/// <summary>
		/// Создание рабочего устройства для сотрудника. 
		/// </summary>
		/// <returns>Рабочее устройство.</returns>
		WorkingDevice CreateWorkingDevice();

		/// <summary>
		/// Создание рабочего автомобиля.
		/// </summary>
		/// <returns>Рабочий автомобиль.</returns>
		WorkingCar CreateWorkingCar();
		#endregion
	}
}
