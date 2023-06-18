
namespace Patterns
{
	class Program
	{
		#region Методы.
		static void Main(string[] args)
		{
			RunDemo();
		}

		/// <summary>
		/// Выполнение основного функционала.
		/// </summary>
		private static void RunDemo()
		{
			var programmer = new Programmer();
			var teamLead = new TeamLead();
			var tfs = new TFS(programmer, teamLead);
			var tasksCount = 10;
			var firstTaskText = "Вступительное задание";

			for (int index = 1; index <= tasksCount; index++)
			{
				tfs.AddTask($"Текст задачи {index}");
			}

			teamLead.GiveTask(firstTaskText);

			for (int index = 1; index <= tasksCount; index++)
			{
				programmer.FinishWork();
			}
		}
		#endregion
	}
}
