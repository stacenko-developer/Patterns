using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Patterns
{
	/// <summary>
	/// Проверка корректности реализации паттерна AbstractFactory.
	/// </summary>
	[TestClass]
	public class AbstractFactoryTests 
	{
		#region Методы.
		/// <summary>
		/// Создание сотрудника с null-фабрикой.
		/// </summary>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateWorker_WithNullWorkerFactory_ShouldThrowArgumentNullException()
		{
			new NorbitWorker(null);
		}

		/// <summary>
		/// Создание сотрудника Норбит с корректными параметрами.
		/// </summary>
		[TestMethod]
		public void CreateWorker_WithCorrectArguments_ShouldCreateWorker()
		{
			new NorbitWorker(new ProgrammerFactory());
		}

		/// <summary>
		/// Создание программиста с помощью абстрактной фабрики.
		/// </summary>
		[TestMethod]
		public void CreateProgrammer_WithCorrectArguments_ShouldGetCorrectResults()
		{
			var programmer = new NorbitWorker(new ProgrammerFactory());
			var correctTax = 1000;
			var correctAccessoriesCost = 5000;

			Assert.IsTrue(programmer.GetAccessoriesCost() == correctAccessoriesCost 
				&& programmer.GetTax() == correctTax);
		}

		/// <summary>
		/// Создание директора с помощью абстрактной фабрики.
		/// </summary>
		[TestMethod]
		public void CreateDirector_WithCorrectArguments_ShouldGetCorrectResults()
		{
			var director = new NorbitWorker(new DirectorFactory());
			var correctTax = 5000;
			var correctAccessoriesCost = 6000;

			Assert.IsTrue(director.GetAccessoriesCost() == correctAccessoriesCost
				&& director.GetTax() == correctTax);
		}

		/// <summary>
		/// Анализ корректности реализации паттерна Абстрактная фабрика.
		/// </summary>
		[TestMethod]
		public void AnalyzeAbstractFactoryPatternStructure_ShouldGetCorrectStructure()
		{
			Assert.IsTrue(typeof(ProgrammerFactory).GetInterfaces().Contains(typeof(INorbitWorkerFactory))
				&& typeof(DirectorFactory).GetInterfaces().Contains(typeof(INorbitWorkerFactory))
				&& typeof(Lada).BaseType == typeof(WorkingCar) && typeof(BMW).BaseType == typeof(WorkingCar)
				&& typeof(Computer).BaseType == typeof(WorkingDevice) 
				&& typeof(Laptop).BaseType == typeof(WorkingDevice));
		}
		#endregion
	}
}
