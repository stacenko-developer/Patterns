
namespace Patterns
{
	/// <summary>
	/// Фабрика директора.
	/// </summary>
	public class DirectorFactory : IWorkerFactory 
	{
		#region Методы.
		/// <summary>
		/// Создание рабочего автомобиля.
		/// </summary>
		/// <returns>Рабочий автомобиль.</returns>
		public WorkingCar CreateWorkingCar() => new BMW();

		/// <summary>
		/// Создание рабочего устройства.
		/// </summary>
		/// <returns>Рабочее устройство.</returns>
		public WorkingDevice CreateWorkingDevice() => new Computer();
		#endregion
	}
}
