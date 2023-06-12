
namespace Patterns
{
	/// <summary>
	/// Фабрика сотрудника Норбит.
	/// </summary>
	public interface INorbitWorkerFactory 
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
