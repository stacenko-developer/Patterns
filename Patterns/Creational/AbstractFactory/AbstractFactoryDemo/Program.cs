using System;

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
			var programmer = new Worker(new ProgrammerFactory());
			var director = new Worker(new DirectorFactory());

			Console.WriteLine($"Реализация паттерна Абстрактная фабрика: {Environment.NewLine}" +
				$"Программист: {Environment.NewLine}{programmer} {Environment.NewLine}Директор: " +
				$"{Environment.NewLine}{director}");
		}
		#endregion 
	}
}
