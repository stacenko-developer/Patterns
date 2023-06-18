using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
	/// <summary>
	/// Файловая система.
	/// </summary>
	public class FileSystem : IFileNumerable
	{
		#region Поля.
		/// <summary>
		/// Файлы, хранящиеся в файловой системе.
		/// </summary>
		private List<File> _files;
		#endregion

		#region Свойства.
		/// <summary>
		/// Количество файлов в файловой системе.
		/// </summary>
		public int Count => _files.Count;
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание файловой системы.
		/// </summary>
		public FileSystem()
		{
			_files = new List<File>();
		}
		#endregion

		#region Методы.

		#region Валидация.
		/// <summary>
		/// Проверяет выход индекса за границы списка файлов файловой системы.
		/// </summary>
		/// <param name="index">Порядковый номер элемента.</param>
		/// <exception cref="ArgumentOutOfRangeException">Индекс вышел за границы!
		/// </exception>
		private void ValidateIndex(int index)
		{
			if (index < 0 || index >= _files.Count)
			{
				throw new ArgumentOutOfRangeException("Индекс вышел за границы массива!");
			}
		}
		#endregion

		/// <summary>
		/// Создание итератора.
		/// </summary>
		/// <returns>Итератор.</returns>
		public IFileIterator CreateNumerator() => new FileSystemNumerator(this);

		/// <summary>
		/// Доступ к элементам файловой системы.
		/// </summary>
		/// <param name="index">Позиция элемента, к которому необходим доступ.</param>
		/// <exception cref="ArgumentOutOfRangeException">Индекс вышел за границы!</exception>
		public File this[int index]
		{
			get
			{
				ValidateIndex(index);
				return _files[index];
			}
		}

		/// <summary>
		/// Добавляет файл в файловую систему.
		/// </summary>
		/// <param name="name">Название.</param>
		/// <param name="type">Тип.</param>
		/// <returns>Идентификатор созданного файла.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Файл с указанными названием и типом уже существует!</exception>
		public Guid AddFile(string name, string type)
		{
			Validator.ValidateStringText(name);
			Validator.ValidateStringText(type);

			if (_files.FirstOrDefault(file => file.Name == name && file.Type == type) != null)
			{
				throw new ArgumentOutOfRangeException("Файл с указанными названием и типом уже существует!");
			}

			var id = Guid.NewGuid();

			_files.Add(new File
			{
				Name = name,
				Type = type,
				Id = id
			});

			return id;
		}

		/// <summary>
		/// Удаляет файл из файловой системы.
		/// </summary>
		/// <param name="id">Идентификатор файла, который необходимо удалить.</param>
		/// <exception cref="ArgumentNullException">Файл с указанным идентификатором не найден!</exception>
		public void DeleteFile(Guid id)
		{
			if (_files.FirstOrDefault(file => file.Id == id) == null)
			{
				throw new ArgumentNullException(nameof(id), "Файл с указанным идентификатором не найден!");
			}

			_files.RemoveAt(_files.FindIndex(file => file.Id == id));
		}
		#endregion
	}
}
