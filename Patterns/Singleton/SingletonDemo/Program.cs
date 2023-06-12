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
			var defaultName = "Name";
			var defaultCode = "NrbCode";
			var databaseFirst = SectionDatabase.Initialize();

			Console.WriteLine($"Демонстрация реализации паттерна Singleton: {Environment.NewLine} " +
				$"Первая инициализация базы данных. Текущие данные базы данных до добавления элемента: ");
			PrintSections(databaseFirst.GetAllSections());
			
			databaseFirst.AddSection(defaultName, defaultCode);
			
			Console.WriteLine("Текущие данные базы данных после добавления элемента: ");
			PrintSections(databaseFirst.GetAllSections());
			Console.WriteLine("Вторая инициализация базы данных: ");
			PrintSections(SectionDatabase.Initialize().GetAllSections());
		}

		/// <summary>
		/// Вывод на экран разделов.
		/// </summary>
		/// <param name="sections">Список разделов.</param>
		private static void PrintSections(List<Section> sections)
		{
			sections.ForEach(section => Console.WriteLine($"{section.Name} : " +
				$"{section.Code}"));
		}
		#endregion
	}
}
