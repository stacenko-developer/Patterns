using System;
using System.Collections.Generic;

namespace Patterns
{
	/// <summary>
	/// Работает с отписками от уведомлений.
	/// </summary>
	/// <typeparam name="T">Тип подписчика.</typeparam>
	public class Unsubscriber<T> : IDisposable
	{
		#region Поля.
		/// <summary>
		/// Список подписчиков.
		/// </summary>
		private readonly List<IObserver<T>> _observers; 

		/// <summary>
		/// Подписчик.
		/// </summary>
		private readonly IObserver<T> _observer;
		#endregion

		#region Конструкторы.
		/// <summary>
		/// Создание экземпляра для отписок от уведомлений с помощью указанных данных.
		/// </summary>
		/// <param name="observers">Подписчики.</param>
		/// <param name="observer">Подписчик.</param>
		/// <exception cref="ArgumentNullException">Подписчики равны null!</exception>
		public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
		{
			if (observers == null || observers.FindIndex(subscriber => subscriber == null) != -1)
			{
				throw new ArgumentNullException(nameof(observers),
					"Список подписчиков или его элементы равны null!");
			}

			if (observer == null)
			{
				throw new ArgumentNullException(nameof(observer), "Подписчик равен null!");
			}

			if (!observers.Contains(observer))
			{
				throw new ArgumentNullException(nameof(observer),
					"Подписчик не найден в списке подписчиков!");
			}

			_observer = observer;
			_observers = observers;
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Отписка подписчика от уведомлений.
		/// </summary>
		public void Dispose()
		{
			if (_observers.Contains(_observer))
			{
				_observers.Remove(_observer);
			}
		}
		#endregion
	}
}
