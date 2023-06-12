using System;
using System.Collections.Generic;

namespace Patterns
{
	class Program
	{
		#region Методы.
		/// <summary>
		/// Точка входа в программу.
		/// </summary>
		/// <param name="args">Набор аргументов.</param>
		private static void Main(string[] args)
		{
			RunDemo();
		}

		/// <summary>
		/// Выполнение основного функционала. 
		/// </summary>
		private static void RunDemo()
		{
			var author = "admin";
			var text = "message";
			var corporatePortal = new CorporatePortal();
			var message = new Message(text, author);
			var usersCount = 5;
			var subscribers = new List<IDisposable>();

			for (var i = 1; i <= usersCount; i++)
			{
				Console.WriteLine($"Добавление {i} пользователя: ");
				subscribers.Add(corporatePortal.Subscribe(new User($"Login{i}")));
				corporatePortal.Notify(message);
				Console.WriteLine($"--------------------------------{Environment.NewLine}");
			}

			for (var i = usersCount - 1; i >= 0; i--)
			{
				Console.WriteLine($"Удаление {i + 1} пользователя: ");
				subscribers[i].Dispose();
				corporatePortal.Notify(message);
				Console.WriteLine($"--------------------------------{Environment.NewLine}");
			}
		}
		#endregion
	}
}
