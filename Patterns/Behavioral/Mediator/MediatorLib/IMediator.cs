
namespace Patterns
{
	/// <summary>
	/// Содержит методы для посредника.
	/// </summary>
	public interface IMediator
	{
		/// <summary>
		/// Обрабатывает уведомления.
		/// </summary>
		/// <param name="worker">Работник.</param>
		/// <param name="message">Сообщение.</param>
		void Notify(Worker worker, string message);
	}
}
