
using System;

namespace Patterns
{
	/// <summary>
	/// Работник.
	/// </summary>
	public abstract class Worker
	{
		#region Поля.
		/// <summary>
		/// Посредник.
		/// </summary>
		protected IMediator _mediator;
		#endregion

		#region Методы.
		/// <summary>
		///Устанавливает посредника для работника.
		/// </summary>
		/// <param name="mediator">Посредник.</param>
		/// <exception cref="ArgumentNullException">Посредник равен null!</exception>
		public void SetMediator(IMediator mediator)
		{
			if (mediator == null)
			{
				throw new ArgumentNullException(nameof(mediator), "Посредник равен null!");
			}

			_mediator = mediator;
		}
		#endregion
	}
}
