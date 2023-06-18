using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Patterns
{
	/// <summary>
	/// Проверка корректности реализации паттерна Adapter.
	/// </summary>
	[TestClass]
	public class AdapterTests 
	{
		#region Поля.
		/// <summary>
		/// Название по умолчанию.
		/// </summary>
		private string _defaultName = "name";

		/// <summary>
		/// Адрес по умолчанию.
		/// </summary>
		private string _defaultAddress = "address";
		#endregion 

		#region Методы.
		/// <summary>
		/// Добавление в класс 
		/// </summary>
		[TestMethod]
		public void AddFunctionalityInClass_WithoutChangeThisClass_ShouldAddFunctionality()
		{
			Assert.IsTrue(typeof(NrbOffice).GetInterfaces().Contains(typeof(IMovable)) 
				&& typeof(NrbOffice).BaseType == typeof(Office));
		}

		/// <summary>
		/// Создание офиса с некорректными параметрами в конструкторе.
		/// </summary>
		/// <param name="name">Название офиса.</param>
		/// <param name="address">Адрес офиса.</param>
		/// <exception cref="ArgumentNullException">Текст не содержит символов или равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[DataRow(null, "Адрес")]
		[DataRow("Адрес", null)]
		[TestMethod]
		public void CreateOffice_WithInvalidArguments_ShouldThrowArgumentNullException(string name, 
			string address)
		{
			new Office(name, address);
		}

		/// <summary>
		/// Создание офиса Норбит с некорректными параметрами в конструкторе.
		/// </summary>
		/// <param name="name">Название офиса.</param>
		/// <param name="address">Адрес офиса.</param>
		/// <exception cref="ArgumentNullException">Текст не содержит символов или равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[DataRow(null, "Адрес")]
		[DataRow("Адрес", null)]
		[TestMethod]
		public void CreateNrbOffice_WithInvalidArguments_ShouldThrowArgumentNullException(string name, 
			string address)
		{
			new NrbOffice(name, address);
		}

		/// <summary>
		/// Создание офиса с корректными параметрами в конструкторе.
		/// </summary>
		[TestMethod] 
		public void CreateOffice_WithCorrectArguments_ShouldCreateOffice()
		{
			var office = new NrbOffice(_defaultName, _defaultAddress);

			Assert.IsTrue(office.Name == _defaultName && office.Address == _defaultAddress);
		}

		/// <summary>
		/// Создание офиса Норбит с корректными параметрами в конструкторе.
		/// </summary>
		[TestMethod]
		public void CreateNrbOffice_WithCorrectArguments_ShouldCreateNrbOffice() 
		{
			var office = new Office(_defaultName, _defaultAddress);

			Assert.IsTrue(office.Name == _defaultName && office.Address == _defaultAddress);
		}
		#endregion
	}
}
