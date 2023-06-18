
using System;
using System.Collections.Generic;

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
			var fileSystem = new FileSystem();
			var filesCount = 5;
			var fileIds = new List<Guid>();

			for (var index = 1; index <= filesCount; index++)
			{
				fileIds.Add(fileSystem.AddFile($"Название {index}", $"Тип {index}"));
				PrintFiles(fileSystem.CreateNumerator());
				Console.WriteLine(Environment.NewLine);
			}

			for (var index = 1; index <= filesCount; index++)
			{
				fileSystem.DeleteFile(fileIds[0]);
				fileIds.RemoveAt(0);
				PrintFiles(fileSystem.CreateNumerator());
				Console.WriteLine(Environment.NewLine);
			}
		}

		/// <summary>
		/// Вывод на экран файлов из файловой системы.
		/// </summary>
		/// <param name="fileIterator">Итератор.</param>
		private static void PrintFiles(IFileIterator fileIterator)
		{
			while (fileIterator.HasNext())
			{
				Console.WriteLine(fileIterator.Next());
			}
		}
		#endregion
	}
}
