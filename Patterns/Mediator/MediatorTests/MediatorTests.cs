using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Patterns
{
	/// <summary>
	/// Проверка корректности реализации паттерна Mediator.
	/// </summary>
	[TestClass]
	public class MediatorTests
	{
		#region Поля.
		/// <summary>
		/// Текст задачи по умолчанию.
		/// </summary>
		private string _defaultTaskText = "Текст задачи";
		#endregion

		#region Методы.
		/// <summary>
		/// Создание программиста с помощью конструктора.
		/// </summary>
		[TestMethod]
		public void CreateProgrammer_WithNoArgumentsInConstructor_ShouldCreateProgrammer()
		{
			new Programmer();
		}

		/// <summary>
		/// Установка посредника программисту с null-значением.
		/// </summary>
		/// <exception cref="ArgumentNullException">Посредник равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void SetMediatorInProgrammer_WithNullValue_ShouldThrowArgumentNullException()
		{
			new Programmer().SetMediator(null);
		}

		/// <summary>
		/// Установка корректного посредника программисту.
		/// </summary>
		[TestMethod]
		public void SetMediatorInProgrammer_WithCorrectsValues_ShouldSetMediator()
		{
			new Programmer().SetMediator(new TFS(new Programmer(), new TeamLead()));
		}

		/// <summary>
		/// Начало работы программиста с null-текстом задачи.
		/// </summary>
		/// <exception cref="ArgumentNullException">Текст задачи равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StartWorkForProgrammer_WithNullTaskText_ShouldThrowArgumentNullException()
		{
			new Programmer().StartWork(null);
		}

		/// <summary>
		/// Начало работы программиста с корректным текстом задачи.
		/// </summary>
		[TestMethod]
		public void StartWorkForProgrammer_WithCorrectTaskText_ShouldStartWork()
		{
			var programmer = new Programmer();
			var newTaskText = "Текст новой задачи";

			programmer.StartWork(_defaultTaskText);

			Assert.IsTrue(_defaultTaskText == programmer.TaskText);

			programmer.StartWork(newTaskText);

			Assert.IsTrue(_defaultTaskText == programmer.TaskText);
		}

		/// <summary>
		/// Завершение работы программистом.
		/// </summary>
		[TestMethod]
		public void FinishWork_WithCorrectArguments_ShouldFinishWork()
		{
			var programmer = new Programmer();

			programmer.StartWork(_defaultTaskText);
			programmer.FinishWork();

			Assert.IsTrue(programmer.TaskText == string.Empty);
		}

		/// <summary>
		/// Создание тимлида с помощью конструктора.
		/// </summary>
		[TestMethod]
		public void CreateTeamLead_WithNoArgumentsInConstructor_ShouldCreateProgrammer()
		{
			new TeamLead();
		}

		/// <summary>
		/// Установка посредника тимлиду с null-значением.
		/// </summary>
		/// <exception cref="ArgumentNullException">Посредник равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void SetMediatorInTeamLead_WithNullValue_ShouldThrowArgumentNullException()
		{
			new TeamLead().SetMediator(null);
		}

		/// <summary>
		/// Установка корректного посредника тимлиду.
		/// </summary>
		[TestMethod]
		public void SetMediatorInTeamLead_WithCorrectsValues_ShouldSetMediator()
		{
			new TeamLead().SetMediator(new TFS(new Programmer(), new TeamLead()));
		}

		/// <summary>
		/// Выдача задачи программисту от тимлида с некорректным значением.
		/// </summary>
		/// <exception cref="ArgumentNullException">Задача равна null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void GiveTaskFromTeamLeadToProgrammer_WithNullValue_ShouldThrowArgumentNullException()
		{
			new TeamLead().GiveTask(null);
		}

		/// <summary>
		/// Создание TFS с помощью null параметров в конструкторе.
		/// </summary>
		/// <param name="isProgrammerNull">Равен ли программист null.</param>
		/// <param name="isTeamLeadNull">Равен ли тимлид null.</param>
		/// <exception cref="ArgumentNullException">Программист или тимлид равен null.</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[DataRow(true, false)]
		[DataRow(false, true)]
		[TestMethod]
		public void CreateTFS_WithNullValuesInConstructor_ShouldThrowArgumentNullException(bool isProgrammerNull, 
			bool isTeamLeadNull)
		{
			new TFS(isProgrammerNull ? null : new Programmer(), isTeamLeadNull ? null : new TeamLead());
		}

		/// <summary>
		/// Создание TFS с помощью корректных параметров в конструкторе.
		/// </summary>
		[TestMethod]
		public void CreateTFS_WithCorrectValuesInConstructor_ShouldCreateTFS()
		{
			new TFS(new Programmer(), new TeamLead());
		}

		/// <summary>
		/// Добавление задачи в TFS с null-текстом задачи.
		/// </summary>
		/// <exception cref="ArgumentNullException">Текст задачи равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void AddTaskToTFS_WithNullTaskValue_ShouldThrowArgumentNullException()
		{
			new TFS(new Programmer(), new TeamLead())
				.AddTask(null);
		}

		/// <summary>
		/// Добавление задачи в TFS с null-текстом задачи.
		/// </summary>
		[TestMethod]
		public void AddTaskToTFS_WithCorrectTaskValue_ShouldAddTask() 
		{
			new TFS(new Programmer(), new TeamLead())
				.AddTask(_defaultTaskText);
		}

		/// <summary>
		/// Вызов уведомления с null-аргументами.
		/// </summary>
		/// <exception cref="ArgumentNullException">Работник или сообщение равно null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[DataRow(true, false)]
		[DataRow(false, true)]
		[TestMethod]
		public void CallNotify_WithNullArguments_ShouldThrowArgumentNullException(bool isNullWorker, 
			bool isNullMessageText)
		{
			new TFS(new Programmer(), new TeamLead())
				.Notify(isNullWorker ? null : new Programmer(), isNullMessageText ? null : _defaultTaskText);
		}

		/// <summary>
		/// Вызов уведомления с корректными аргументами.
		/// </summary>
		[TestMethod]
		public void CallNotify_WithCorrectArguments_ShouldNotifyWithCorrectResult()
		{
			new TFS(new Programmer(), new TeamLead())
				.Notify(new Programmer(), _defaultTaskText);
		}

		/// <summary>
		/// Анализ корректности реализации паттерна Медиатор.
		/// </summary>
		[TestMethod]
		public void AnalyzeMediatorPatternStructure_ShouldGetCorrectStructure()
		{
			Assert.IsTrue(typeof(TFS).GetInterfaces().Contains(typeof(IMediator))
				&& typeof(Programmer).BaseType == typeof(Worker) 
				&& typeof(TeamLead).BaseType == typeof(Worker));
		}
		#endregion
	}
}
