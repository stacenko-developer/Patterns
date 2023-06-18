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
			var workers = new List<Worker>();
			var organizations = new List<string>
			{
				"Сбер",
				"Норбит",
				"Альфабанк"
			};
			var posts = new List<string>
			{
				"Консультант",
				"Директор"
			};
			var workersCount = 30;
			var minAgeValue = 20;
			var maxAgeValue = 40;
			var defaultSalary = 40000;
			var numberGenerator = new Random();

			for (var i = 0; i < workersCount; i++)
			{
				workers.Add(new Worker
				{
					FirstName = $"Имя {i}",
					LastName = $"Фамилия {i}",
					Patronymic = $"Отчество {i}",
					Age = numberGenerator.Next(minAgeValue, maxAgeValue + 1),
					Post = posts[numberGenerator.Next(posts.Count)],
					Salary = defaultSalary,
					Organization = organizations[numberGenerator.Next(posts.Count)]
				});
			}
			var norbitWorkersFilter = new NorbitWorkersFilter(workers);
			var ageWorkersFilter = new AgeWorkersFilter(norbitWorkersFilter);

			Console.WriteLine($"Список всех сотрудников: {Environment.NewLine}{string.Join(Environment.NewLine, workers)}" +
				$"{Environment.NewLine}Список сотрудников Норбит: {Environment.NewLine}" +
				$"{string.Join(Environment.NewLine, norbitWorkersFilter.GetFiltratedList())}" +
				$"{Environment.NewLine}Список сотрудников Норбит старше 25 лет: {Environment.NewLine}" +
				$"{string.Join(Environment.NewLine, ageWorkersFilter.GetFiltratedList())}" +
				$"{Environment.NewLine}Список сотрудников Норбит старше 25 лет с должностью 'Консультант': {Environment.NewLine}" +
				$"{string.Join(Environment.NewLine, new PostWorkersFilter(ageWorkersFilter).GetFiltratedList())}");
		}
		#endregion
	}
}
