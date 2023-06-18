
namespace Patterns
{
	/// <summary>
	/// Тимлид.
	/// </summary>
	public class TeamLead : Worker
	{
		#region Методы.
		/// <summary>
		/// Дать задание.
		/// </summary>
		/// <param name="taskText">Текст задания.</param>
		public void GiveTask(string taskText)
		{
			Validator.ValidateStringText(taskText);

			if (_mediator != null)
			{
				_mediator.Notify(this, "Выдаю задачу программисту: " + taskText);
			}
		}
		#endregion 
	}
}
