
namespace Patterns
{
	/// <summary>
	/// Фабрика программиста.
	/// </summary>
	public class ProgrammerFactory : IWorkerFactory
	{
		#region Методы.
		/// <summary>
		/// Создание рабочего автомобиля.
		/// </summary>
		/// <returns>Рабочий автомобиль.</returns>
		public WorkingCar CreateWorkingCar() => new Lada(); 

		/// <summary>
		/// Создание рабочего устройства.
		/// </summary>
		/// <returns>Рабочее устройство.</returns>
		public WorkingDevice CreateWorkingDevice() => new Laptop();
		#endregion
	}
}
