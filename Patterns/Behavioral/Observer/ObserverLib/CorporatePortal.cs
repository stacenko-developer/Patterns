using System;
using System.Collections.Generic;

namespace Patterns
{
	/// <summary>
	/// Корпоративный портал.
	/// </summary>
	public class CorporatePortal : IObservable<Message>
	{
		#region Поля.
		/// <summary>
		/// Список подписчиков.
		/// </summary>
		private readonly List<IObserver<Message>> _observers; 
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание корпоративного портала.
		/// </summary>
		public CorporatePortal()
		{
			_observers = new List<IObserver<Message>>();
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Подписка на уведомления.
		/// </summary>
		/// <param name="observer">Подписчик.</param>
		/// <returns>Объект с механизмом освобождения неуправляемых ресурсов.</returns>
		/// <exception cref="ArgumentNullException">Подписчик равен null!</exception>
		public IDisposable Subscribe(IObserver<Message> observer)
		{
			if (observer == null)
			{
				throw new ArgumentNullException(nameof(observer), "Подписчик равен null!");
			}

			_observers.Add(observer);

			return new Unsubscriber<Message>(_observers, observer);
		}

		/// <summary>
		/// Отправляет уведомление всем подписчикам.
		/// </summary>
		/// <param name="message">Сообщение, которое будет отправлено всем подписчикам.</param>
		/// <exception cref="ArgumentNullException">Сообщение равно null!</exception>
		public void Notify(Message message)
		{
			if (message == null)
			{
				throw new ArgumentNullException(nameof(message), "Сообщение равно null!");
			}

			foreach (var observer in _observers)
			{
				observer.OnNext(message);
			}
		}
		#endregion
	}
}
