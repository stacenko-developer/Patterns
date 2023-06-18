

namespace Patterns
{
	/// <summary>
	/// Программист.
	/// </summary>
	public class Programmer : Worker
	{
		#region Поля.
		/// <summary>
		/// Текст задачи,над которой работает программист.
		/// </summary>
		private string _taskText = string.Empty;
		#endregion

		#region Свойства.
		/// <summary>
		/// Получение текста задания.
		/// </summary>
		public string TaskText => _taskText;
		#endregion

		#region Методы.
		/// <summary>
		/// Начинает работу над задачей.
		/// </summary>
		/// <param name="taskText">Текст задачи.</param>
		public void StartWork(string taskText)
		{
			Validator.ValidateStringText(taskText);

			if (_taskText.Length != 0)
			{
				if (_mediator != null)
				{
					_mediator.Notify(this, "Программист уже работает над задачей!");
				}

				return;
			}

			_taskText = taskText;

			if (_mediator != null)
			{
				_mediator.Notify(this, $"Программист начал работу над задачей: {taskText}");
			}
		}

		/// <summary>
		/// Завершает работу над задачей.
		/// </summary>
		public void FinishWork()
		{
			if (_mediator != null)
			{
				_mediator.Notify(this, $"Программист завершил работу над задачей: {_taskText}");
			}
			_taskText = string.Empty;
		}
		#endregion
	}
}
