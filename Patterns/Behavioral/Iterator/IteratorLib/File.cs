using System;

namespace Patterns
{
	/// <summary>
	/// Файл.
	/// </summary>
	public class File
	{
		#region Свойства.
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Тип.
		/// </summary>
		public string Type { get; set; }
		#endregion

		#region Методы.
		/// <summary>
		/// Строковое преставление объекта файла.
		/// </summary>
		/// <returns>Данные объекта файла в виде строки.</returns>
		public override string ToString() => $"Идентификатор: {Id} Название: {Name} Тип: {Type}";
		#endregion
	}
}
