using System;

namespace Patterns
{
	/// <summary>
	/// Сообщение.
	/// </summary>
	public class Message
	{
		#region Поля.
		/// <summary>
		/// Текст сообщения.
		/// </summary> 
		private string _text;

		/// <summary>
		/// Автор сообщения.
		/// </summary>
		private string _author;
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание сообщения с помощью указанных данных.
		/// </summary>
		/// <param name="text">Текст сообщения.</param>
		/// <param name="author">Автор сообщения.</param>
		public Message(string text, string author)
		{
			Validator.ValidateStringText(text);
			Validator.ValidateStringText(author);

			_text = text;
			_author = author;
		}
		#endregion

		#region Методы.

		#region Переопределенные методы. 
		/// <summary>
		/// Строковое представление объекта сообщения.
		/// </summary>
		/// <returns>Данные сообщения в виде строки.</returns>
		public override string ToString() => $"Текст сообщения: {Environment.NewLine}{_text}" +
			$"{Environment.NewLine}Автор: {_author}";
		#endregion

		#endregion
	}
}
