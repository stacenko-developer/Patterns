using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Patterns
{
	/// <summary>
	/// Проверка корректности реализации паттерна Iterator.
	/// </summary>
	[TestClass]
	public class IteratorTests
	{
		#region Поля.
		/// <summary>
		/// Название файла по умолчанию.
		/// </summary>
		private string _defaultFileName = "Название файла по умолчанию";

		/// <summary>
		/// Тип файла по умолчанию.
		/// </summary>
		private string _defaultFileType = "Тип файла по умолчанию";
		#endregion

		#region Методы.
		/// <summary>
		/// Проверка корректности создания файловой системы с помощью конструктора.
		/// </summary>
		[TestMethod]
		public void CreateFileSystem_WithNoArgumentsInConstructor_ShouldCreateFileSystem() 
		{
			Assert.IsTrue(new FileSystem().Count == 0);
		}

		/// <summary>
		/// Добавление файла в файловую систему с null-значениями.
		/// </summary>
		/// <param name="name">Название.</param>
		/// <param name="type">Тип.</param>
		/// <exception cref="ArgumentNullException">Название или тип равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[DataRow(null, "Тип по умолчанию")]
		[DataRow("Название по умолчанию", null)]
		[TestMethod]
		public void AddFileInFileSystem_WithNullValues_ShouldThrowArgumentNullException(string name, 
			string type)
		{
			new FileSystem().AddFile(name, type);
		}

		/// <summary>
		/// Добавление файла в файловую систему с названием и типом, которые уже заняты.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Файл с указанными названием и типом уже существует!</exception>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void AddFileInFileSystem_WithArgumentsThatAreUsed_ShouldThrowArgumentOutOfRangeException()
		{
			var fileSystem = new FileSystem();
			fileSystem.AddFile(_defaultFileName, _defaultFileType);
			fileSystem.AddFile(_defaultFileName, _defaultFileType);
		}

		/// <summary>
		/// Добавление файла в файловую систему с новыми названием и типом.
		/// </summary>
		[TestMethod]
		public void AddFileInFileSystem_WithArgumentsThatAreNotUsed_ShouldAddFile()
		{
			var fileSystem = new FileSystem();
			var correctCount = 1;

			Assert.IsTrue(fileSystem.AddFile(_defaultFileName, _defaultFileType) != null);
			Assert.IsTrue(fileSystem.Count == correctCount);
		}

		/// <summary>
		/// Удаление файла из файловой системы по несуществующему идентификатору.
		/// </summary>
		/// <exception cref="ArgumentNullException">Файл с указанным идентификатором не найден!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void DeleteFileFromFileSystem_WithNonExistentId_ShouldThrowArgumentNullException()
		{
			var fileSystem = new FileSystem();

			fileSystem.AddFile(_defaultFileName, _defaultFileType);

			fileSystem.DeleteFile(Guid.NewGuid());
		}

		/// <summary>
		/// Удаление файла из файловой системы с существующим идентификатором.
		/// </summary>
		[TestMethod]
		public void DeleteFileFromFileSystem_WithExistentId_ShouldDeleteFile()
		{
			var fileSystem = new FileSystem();
			var correctFilesCountAfterDeletingFile = 0;

			fileSystem.DeleteFile(fileSystem.AddFile(_defaultFileName, _defaultFileType));

			Assert.IsTrue(fileSystem.Count == correctFilesCountAfterDeletingFile);
		}

		/// <summary>
		/// Получение файла из файловой системы по некорректному индексу.
		/// </summary>
		/// <param name="index">Некорректный индекс.</param>
		/// <exception cref="ArgumentOutOfRangeException">Индекс вышел за границы!</exception>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[DataRow(-10)]
		[DataRow(-1)]
		[DataRow(1)]
		[DataRow(10)]
		[TestMethod]
		public void GetFile_WithInvalidIndex_ShouldThrowArgumentOutOfRangeException(int index)
		{
			_ = new FileSystem()[index];
		}

		/// <summary>
		/// Получение файла из файловой системы по корректному индексу.
		/// </summary>
		[TestMethod]
		public void GetFile_WithCorrectIndex_ShouldReturnFile()  
		{
			var fileSystem = new FileSystem();

			fileSystem.AddFile(_defaultFileName, _defaultFileType);

			Assert.IsTrue(fileSystem[0].Name == _defaultFileName && fileSystem[0].Type == _defaultFileType);
		}

		/// <summary>
		/// Создание итератора файловой системы с помощью null-значения в конструкторе.
		/// </summary>
		/// <exception cref="ArgumentNullException">Интерфейс для создания объекта-итератора равен null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateFileSystemNumerator_WithNullValue_ShouldThrowArgumentNullException()
		{
			new FileSystemNumerator(null);
		}

		/// <summary>
		/// Создание итератора файловой системы с помощью корректного значения в конструкторе.
		/// </summary>
		[TestMethod]
		public void CreateFileSystemNumerator_WithCorrectValue_ShouldThrowArgumentNullException()
		{
			new FileSystemNumerator(new FileSystem());
		}

		/// <summary>
		/// Проверка корректности результата метода проверки, существует ли следующий элемент в пустой коллекции.
		/// </summary>
		[TestMethod]
		public void CallHasNext_WithEmptyFileSystem_ShouldReturnFalse()
		{
			Assert.IsTrue(!new FileSystemNumerator(new FileSystem()).HasNext());
		}

		/// <summary>
		/// Проверка корректности результата метода проверки, существует ли следующий элемент в пустой коллекции.
		/// </summary>
		[TestMethod]
		public void CallHasNext_WithNotEmptyFileSystem_ShouldReturnTrue()
		{
			var fileSystem = new FileSystem();
			fileSystem.AddFile(_defaultFileName, _defaultFileType);

			Assert.IsTrue(new FileSystemNumerator(fileSystem).HasNext());
		}

		/// <summary>
		/// Получение следующего элемента из пустой файловой системы.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void CallNext_WithEmptyFileSystem_ShouldThrowArgumentOutOfRangeException()
		{
			new FileSystemNumerator(new FileSystem()).Next();
		}

		/// <summary>
		/// Получение следующего элемента из непустой файловой системы.
		/// </summary>
		[TestMethod]
		public void CallNext_WithNotEmptyFileSystem_ShouldReturnFile()
		{
			var fileSystem = new FileSystem();
			var id = fileSystem.AddFile(_defaultFileName, _defaultFileType);
			var file = new FileSystemNumerator(fileSystem).Next();

			Assert.IsTrue(file.Id == id && file.Name == fileSystem[0].Name
				&& file.Type == fileSystem[0].Type);
		}
		#endregion
	}
}
