
using System;
using System.Collections.Generic;

namespace Patterns
{
	/// <summary>
	/// TFS.
	/// </summary>
	public class TFS : IMediator
	{
		#region Поля.
		/// <summary>
		/// Программист.
		/// </summary>
		private Programmer _programmer;

		/// <summary>
		/// Тимлид.
		/// </summary>
		private TeamLead _teamLead;

		/// <summary>
		/// Задачи.
		/// </summary>
		private List<string> _tasks;
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создает TFS с помощью указанных данных.
		/// </summary>
		/// <param name="programmer">Программист.</param>
		/// <param name="teamLead">Тимлид.</param>
		/// <exception cref="ArgumentNullException">Программист или тимлид равен null!</exception>
		public TFS(Programmer programmer, TeamLead teamLead)
		{
			#region Валидация входных параметров.
			if (programmer == null)
			{
				throw new ArgumentNullException(nameof(programmer), "Программист равен null!");
			}

			if (teamLead == null)
			{
				throw new ArgumentNullException(nameof(teamLead), "Тимлид равен null!");
			}
			#endregion

			_programmer = programmer;
			_teamLead = teamLead;
			programmer.SetMediator(this);
			teamLead.SetMediator(this);
			_tasks = new List<string>();
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Обрабатывает уведомления.
		/// </summary>
		/// <param name="worker">Работник.</param>
		/// <param name="message">Сообщение.</param>
		public void Notify(Worker worker, string message)
		{
			#region Валидация входных параметров.
			if (worker == null)
			{
				throw new ArgumentNullException(nameof(worker), "Работник равен null!");
			}

			Validator.ValidateStringText(message);
			#endregion

			Console.WriteLine(message);

			if (worker is Programmer)
			{
				if (message.StartsWith("Программист завершил работу над задачей"))
				{
					if (_tasks.Count != 0)
					{
						_teamLead.GiveTask(_tasks[0]);
						_tasks.RemoveAt(0);
					}
				}

				return;
			}

			if (worker is TeamLead)
			{
				_programmer.StartWork(message);
			}
		}

		/// <summary>
		/// Добавить задачу.
		/// </summary>
		/// <param name="taskText">Текст задачи.</param>
		public void AddTask(string taskText)
		{
			Validator.ValidateStringText(taskText);

			_tasks.Add(taskText);
		}
		#endregion
	}
}
