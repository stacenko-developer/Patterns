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
			var firstName = "Сбер";
			var firstAddress = "Улица Щорса, 11";
			var secondName = "Норбит";
			var secondAddress = "Улица Щорса, 12";
			var office = new Office(firstName, firstAddress);
			var nrbOffice = new NrbOffice(secondName, secondAddress);

			Console.WriteLine($"Реализация паттерна адаптер: {Environment.NewLine} Вывод данных" +
				$" офиса Сбера: {Environment.NewLine} {office} {Environment.NewLine} Вывод данных " +
				$"офиса Норбит: {nrbOffice} {Environment.NewLine} Изменение адреса офиса Норбит: ");

			nrbOffice.Move(firstAddress);
			Console.WriteLine(nrbOffice);
		}
		#endregion
	}
}
