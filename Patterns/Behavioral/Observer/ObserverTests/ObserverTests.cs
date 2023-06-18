using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
	/// <summary>
	/// Проверка корректности реализации паттерна Observer.
	/// </summary>
	[TestClass]
	public class ObserverTests
	{
		#region Поля.
		/// <summary>
		/// Логин по умолчания.
		/// </summary>
		private string _defaultLogin = "login"; 

		/// <summary>
		/// Текст по умолчанию.
		/// </summary>
		private string _defaultText = "Текст";

		/// <summary>
		/// Автор по умолчанию.
		/// </summary>
		private string _defaultAuthor = "Автор";
		#endregion 

		#region Методы.
		/// <summary>
		/// Создание пользователя с помощью null-аргументов в конструкторе.
		/// </summary>
		/// <exception cref="ArgumentNullException">Аргумента равны null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateUser_WithNullArguments_ShouldThrowArgumentNullException() 
		{
			new User(null);
		}
		
		/// <summary>
		/// Создание пользователя с корректными параметрами.
		/// </summary>
		[TestMethod]
		public void CreateUser_WithCorrectArguments_ShouldCreateUser()
		{
			new User(_defaultLogin);
		}

		/// <summary>
		/// Вызов обработчика события поступления уведомлений от поставщика данных с null-аргументами.
		/// </summary>
		/// <exception cref="ArgumentNullException">Аргументы равны null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CallUserOnNext_WithNullArguments_ShouldThrowArgumentNullException()
		{
			new User(_defaultLogin).OnNext(null);
		}

		/// <summary>
		/// Вызов обработчика события уведомления об ошибке на стороне поставщика данных с null-аргументами.
		/// </summary>
		/// <exception cref="ArgumentNullException">Аргументы равны null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CallUserOnError_WithNullArguments_ShouldThrowArgumentNullException()
		{
			new User(_defaultLogin).OnError(null);
		}

		/// <summary>
		/// Вызов обработчика события поступления уведомлений от поставщика данных с 
		/// корректными аргументами.
		/// </summary>
		[TestMethod]
		public void CallUserOnNext_WithCorrectArguments_ShouldThrowArgumentNullException()
		{
			new User(_defaultLogin).OnNext(new Message(_defaultText, _defaultAuthor));
		}

		/// <summary>
		/// Вызов обработчика события уведомления об ошибке на стороне поставщика данных с 
		/// корректными аргументами.
		/// </summary>
		[TestMethod]
		public void CallUserOnError_WithCorrectArguments_ShouldThrowArgumentNullException()
		{
			new User(_defaultLogin).OnError(new Exception());
		}

		/// <summary>
		/// Создание сообщения с null-аргументами.
		/// </summary>
		/// <param name="text">Текст сообщения.</param>
		/// <param name="author">Автор сообщения.</param>
		/// <exception cref="ArgumentNullException">Аргументы равны null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[DataRow(null, "Автор")]
		[DataRow("Текст", null)]
		[TestMethod]
		public void CreateMessage_WithNullArguments_ShouldThrowArgumentNullException(string text, 
			string author)
		{
			new Message(text, author);
		}

		/// <summary>
		/// Создание сообщения с корректными аргументами.
		/// </summary>
		[TestMethod]
		public void CreateMessage_WithCorrectArguments_ShouldCreateMessage()
		{
			new Message(_defaultText, _defaultAuthor);
		}

		/// <summary>
		/// Подписка на уведомления с null аргументами.
		/// </summary>
		/// <exception cref="ArgumentNullException">Аргументы равны null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void SubscribeToNotifications_WithNullArguments_ShouldThrowArgumentNullException()
		{
			new CorporatePortal().Subscribe(null);
		}

		/// <summary>
		/// Подписка на уведомления с корректными аргументами.
		/// </summary>
		[TestMethod]
		public void SubscribeToNotifications_WithCorrectArguments_ShouldSubscribeToNotify()
		{
			new CorporatePortal().Subscribe(new User(_defaultLogin));
		}

		/// <summary>
		/// Отправка уведомлений подписчикам с null аргументами.
		/// </summary>
		/// <exception cref="ArgumentNullException">Аргументы равны null!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void NotifySubscribers_WithNullArguments_ShouldThrowArgumentNullException()
		{
			new CorporatePortal().Notify(null);
		}

		/// <summary>
		/// Отправка уведомлений подписчикам с корректными аргументами.
		/// </summary>
		[TestMethod]
		public void NotifySubscribers_WithCorrectArguments_ShouldSubscribeToNotify()
		{
			new CorporatePortal().Notify(new Message(_defaultText, _defaultAuthor));
		}

		/// <summary>
		/// Создание механизма отписки от уведомлений с null-аргументами.
		/// </summary>
		/// <exception cref="ArgumentNullException">Аргументы равны null!</exception>
		[TestMethod]
		public void CreateUnsubscriber_WithNullArguments_ShouldThrowArgumentNullException()
		{
			Assert.ThrowsException<ArgumentNullException>(()
				=> new Unsubscriber<Message>(null, new User(_defaultLogin)));
			Assert.ThrowsException<ArgumentNullException>(()
				=> new Unsubscriber<Message>(new List<IObserver<Message>>(), null));
		}

		/// <summary>
		/// Создание механизма отписки от уведомлений с подписчиков, отсутствующим в списке подписчиков.
		/// </summary>
		/// <exception cref="ArgumentNullException">Подписчик не найден в списке подписчиков!</exception>
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void CreateUnsubscriber_WithSubscriberNotInList_ShouldThrowArgumentNullException()
		{
			new Unsubscriber<Message>(new List<IObserver<Message>>(), new User(_defaultLogin));
		}

		/// <summary>
		/// Создание механизма отписки от уведомлений с корректными аргументами.
		/// </summary>
		[TestMethod]
		public void CreateUnsubscriber_WithCorrectArguments_ShouldCreateUnsubscriber()
		{
			var user = new User(_defaultLogin);
			var users = new List<IObserver<Message>> { user };

			new Unsubscriber<Message>(users, user);
		}

		/// <summary>
		/// Анализ корректности реализации паттерна Наблюдатель.
		/// </summary>
		[TestMethod]
		public void AnalyzeAbstractFactoryPatternStructure_ShouldGetCorrectStructure()
		{
			Assert.IsTrue(typeof(CorporatePortal).GetInterfaces().Contains(typeof(IObservable<Message>))
				&& typeof(User).GetInterfaces().Contains(typeof(IObserver<Message>))
				&& typeof(Unsubscriber<Message>).GetInterfaces().Contains(typeof(IDisposable)));
		}
		#endregion
	}
}
