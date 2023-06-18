using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Patterns
{
	/// <summary>
	/// Проверка корректности реализации паттерна Decorator.
	/// </summary>
	[TestClass]
	public class DecoratorTests
	{
		#region Поля.
		/// <summary>
		/// Сотрудник с корректными данными.
		/// </summary>
		private static Worker CorrectWorker = new Worker 
		{
			FirstName = "Артем",
			LastName = "Стаценко",
			Patronymic = "Николаевич",
			Age = 30,
			Post = "Консультант",
			Salary = 50000,
			Organization = "Норбит"
		};

		/// <summary>
		/// Сотрудник с некорректной организацией.
		/// </summary>
		private static Worker WorkerWithInvalidOrganization = new Worker
		{
			FirstName = "Артем",
			LastName = "Стаценко",
			Patronymic = "Николаевич",
			Age = 30,
			Post = "Консультант",
			Salary = 50000,
			Organization = "Сбер"
		};

		/// <summary>
		/// Сотрудник с некорректным возрастом.
		/// </summary>
		private static Worker WorkerWithInvalidAge = new Worker
		{
			FirstName = "Артем",
			LastName = "Стаценко",
			Patronymic = "Николаевич",
			Age = 12,
			Post = "Консультант",
			Salary = 50000,
			Organization = "Норбит"
		}; 

		/// <summary>
		/// Сотрудник с некорректной должностью.
		/// </summary>
		private static Worker WorkerWithInvalidPost = new Worker
		{
			FirstName = "Артем",
			LastName = "Стаценко",
			Patronymic = "Николаевич",
			Age = 30,
			Post = "Директор",
			Salary = 50000,
			Organization = "Норбит"
		};

		/// <summary>
		/// Список сотрудников, который необходимо отфильтровать.
		/// </summary>
		private List<Worker> _workers = new List<Worker>()
		{
			CorrectWorker, 
			WorkerWithInvalidAge,
			WorkerWithInvalidOrganization,
			WorkerWithInvalidPost
		};
		#endregion

		#region Методы.
		/// <summary>
		/// Создание фильтра сотрудников Норбит с null-списком.
		/// </summary>
		/// <exception cref="ArgumentNullException">Список сотрудников равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateNorbitWorkersFilter_WithNullWorkersList_ShouldThrowArgumentNullException()
		{
			new NorbitWorkersFilter(null);
		}

		/// <summary>
		/// Создание фильтра сотрудников Норбит с null-элементом в списке.
		/// </summary>
		/// <exception cref="ArgumentNullException">Элементы списка сотрудников равны null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateNorbitWorkersFilter_WithNullElementsWorkersList_ShouldThrowArgumentNullException()
		{
			new NorbitWorkersFilter(new List<Worker>
			{
				null, 
				CorrectWorker
			});
		}

		/// <summary>
		/// Создание фильтра сотрудников Норбит с корректными параметрами.
		/// </summary>
		[TestMethod]
		public void CreateNorbitWorkersFilter_WithCorrectArguments_ShouldCreateNorbitWorkersFilter()
		{
			new NorbitWorkersFilter(new List<Worker>
			{
				CorrectWorker
			});
		}

		/// <summary>
		/// Создание дополнительного условия фильтрации с null-фильтром сотрудников Норбит.
		/// </summary>
		/// <exception cref="ArgumentNullException">Фильтр сотрудников Норбит равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateAdditionalFilteringCondition_WithNullNorbitWorkersFilter_ShouldThrowArgumentNullException() 
		{
			new AdditionalFilteringCondition(null);
		}

		/// <summary>
		/// Создание дополнительного условия фильтрации с корректным фильтром сотрудников Норбит.
		/// </summary>
		[TestMethod]
		public void CreateAdditionalFilteringCondition_WithCorrectArguments_ShouldCreateAdditionalFilteringCondition() 
		{
			new AdditionalFilteringCondition(new NorbitWorkersFilter(_workers));
		}

		/// <summary>
		/// Создание фильтра сотрудников по возрасту с null-фильтром сотрудников Норбит.
		/// </summary>
		/// <exception cref="ArgumentNullException">Фильтр сотрудников Норбит равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateAgeWorkersFilter_WithNullNorbitWorkersFilter_ShouldThrowArgumentNullException()
		{
			new AgeWorkersFilter(null);
		}

		/// <summary>
		/// Создание фильтра сотрудников по возрасту c корректным фильтром сотрудников Норбит.
		/// </summary>
		[TestMethod]
		public void CreateAgeWorkersFilter_WithCorrectArguments_ShouldCreateAgeWorkersFilter()
		{
			new AgeWorkersFilter(new NorbitWorkersFilter(_workers));
		}

		/// <summary>
		/// Создание фильтра сотрудников по должности с null-фильтром сотрудников Норбит.
		/// </summary>
		/// <exception cref="ArgumentNullException">Фильтр сотрудников Норбит равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreatePostWorkersFilter_WithNullNorbitWorkersFilter_ShouldThrowArgumentNullException()
		{
			new PostWorkersFilter(null);
		}

		/// <summary>
		/// Создание фильтра сотрудников по должности с корректным фильтром сотрудников Норбит.
		/// </summary>
		[TestMethod]
		public void CreatePostWorkersFilter_WithCorrectArguments_ShouldCreatePostWorkersFilter()
		{
			new PostWorkersFilter(new NorbitWorkersFilter(_workers));
		}

		/// <summary>
		/// Проверка корректности реализации паттерна Декоратор.
		/// </summary>
		[TestMethod]
		public void CreateDecoratorPatternStructure_WithCorrectArguments_ShouldCreateDecoratorPatternStructure()
		{
			var norbitWorkersFilter = new NorbitWorkersFilter(_workers);

			Assert.IsTrue(norbitWorkersFilter.GetType().BaseType == typeof(WorkersFilter) 
				&& new AdditionalFilteringCondition(norbitWorkersFilter).GetType().BaseType == typeof(NorbitWorkersFilter)
				&& new AgeWorkersFilter(norbitWorkersFilter).GetType().BaseType == typeof(AdditionalFilteringCondition)
				&& new PostWorkersFilter(norbitWorkersFilter).GetType().BaseType == typeof(AdditionalFilteringCondition));
		}

		/// <summary>
		/// Фильтрация сотрудников Норбит по названию организации.
		/// </summary>
		[TestMethod]
		public void FiltrationByNorbitWorkersFilter_WithCorrectArgument_ShouldGetCorrectResult()
		{
			var result = new NorbitWorkersFilter(_workers).GetFiltratedList();
			var correctWorkersCountInResult = 3;

			Assert.IsTrue(result.Count == correctWorkersCountInResult && result.IndexOf(CorrectWorker) != -1 
				&& result.IndexOf(WorkerWithInvalidAge) != -1 && result.IndexOf(WorkerWithInvalidPost) != -1);
		}

		/// <summary>
		/// Фильтрация сотрудников Норбит по возрасту и по организации.
		/// </summary>
		[TestMethod]
		public void FiltrationByAgeWorkersFilter_WithCorrectArgument_ShouldGetCorrectResult()
		{
			var result = new AgeWorkersFilter(new NorbitWorkersFilter(_workers)).GetFiltratedList();
			var correctWorkersCountInResult = 2;

			Assert.IsTrue(result.Count == correctWorkersCountInResult && result.IndexOf(CorrectWorker) != -1
				&&  result.IndexOf(WorkerWithInvalidPost) != -1);
		}

		/// <summary>
		/// Фильтрация сотрудников Норбит по должности и по организации.
		/// </summary>
		[TestMethod]
		public void FiltrationByPostWorkersFilter_WithCorrectArgument_ShouldGetCorrectResult() 
		{
			var result = new PostWorkersFilter(new NorbitWorkersFilter(_workers)).GetFiltratedList();
			var correctWorkersCountInResult = 2;

			Assert.IsTrue(result.Count == correctWorkersCountInResult && result.IndexOf(CorrectWorker) != -1
				&& result.IndexOf(WorkerWithInvalidAge) != -1);
		}

		/// <summary>
		/// Фильтрация сотрудников Норбит по должности, возрасту и организации.
		/// </summary>
		[TestMethod]
		public void FiltrationByAgeWorkersFilterAndPostWorkersFilter_WithCorrectArgument_ShouldGetCorrectResult()
		{
			var result = new AgeWorkersFilter(new PostWorkersFilter(new NorbitWorkersFilter(_workers)))
				.GetFiltratedList();
			var correctWorkersCountInResult = 1;

			Assert.IsTrue(result.Count == correctWorkersCountInResult && result.IndexOf(CorrectWorker) != -1);
		}

		/// <summary>
		/// Фильтрация сотрудников Норбит по должности, возрасту и организации.
		/// </summary>
		[TestMethod]
		public void FiltrationByPostWorkersFilterAndAgeWorkersFilter_WithCorrectArgument_ShouldGetCorrectResult()
		{
			var result = new PostWorkersFilter(new AgeWorkersFilter(new NorbitWorkersFilter(_workers)))
				.GetFiltratedList();
			var correctWorkersCountInResult = 1;

			Assert.IsTrue(result.Count == correctWorkersCountInResult && result.IndexOf(CorrectWorker) != -1);
		}
		#endregion
	}
}
