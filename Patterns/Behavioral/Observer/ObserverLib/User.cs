using System;

namespace Patterns
{
	/// <summary>
	/// Пользователь.
	/// </summary>
	public class User : IObserver<Message>
	{
		#region Поля.
		/// <summary>
		/// Логин пользователя.
		/// </summary>
		private string _login; 
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создает пользователя с помощью указанных параметров.
		/// </summary>
		/// <param name="login">Логин пользователя.</param>
		/// <exception cref="ArgumentNullException">Логин равен null!</exception>
		public User(string login)
		{
			Validator.ValidateStringText(login);

			_login = login;
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Обработчик события, когда от поставщика данных больше не будет поступать никаких уведомлений.
		/// </summary>
		public void OnCompleted()
		{

		}

		/// <summary>
		/// Обработчик события возникновения исключения у поставщика данных при отправке уведомлений.
		/// </summary>
		/// <param name="error">Исключение, которое возникло у поставщика данных.</param>
		/// <exception cref="ArgumentNullException">Исключение равно null!</exception>
		public void OnError(Exception error)
		{
			if (error == null)
			{
				throw new ArgumentNullException(nameof(error), "Исключение равно null!");
			}

			Console.WriteLine($"Отправка уведомлений пользователю завершилась с ошибкой: {error.Message}" +
				$"{Environment.NewLine}Логин получателя: {_login}");
		}

		/// <summary>
		/// Обработчик события поступления уведомлений от поставщика данных.
		/// </summary>
		/// <param name="value">Сообщение, поступившее от поставщика данных.</param>
		/// <exception cref="ArgumentNullException">Сообщение равно null!</exception>
		public void OnNext(Message value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value), "Сообщение равно null!");
			}

			Console.WriteLine($"Полученное уведомление: {Environment.NewLine}{value}{Environment.NewLine}" +
				$"Логин получателя: {_login}");
		}
		#endregion
	}
}
