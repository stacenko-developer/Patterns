

namespace Patterns
{
	/// <summary>
	/// Офис Норбит. Реализация паттерна Адаптер.
	/// </summary>
	public class NrbOffice : Office, IMovable
	{
		#region Конструкторы.
		/// <summary>
		/// Создает офис Норбит с помощью указанных параметров. 
		/// </summary>
		/// <param name="name">Название офиса.</param>
		/// <param name="address">Адрес офиса.</param>
		public NrbOffice(string name, string address)
			: base(name, address)
		{
		}
		#endregion

		#region Методы.
		/// <summary>
		/// Изменение адреса офиса.
		/// </summary>
		/// <param name="newAddress">Новый адрес.</param>
		public void Move(string newAddress)
		{
			Validator.ValidateStringText(newAddress);

			_address = newAddress;
		}
		#endregion
	}
}
