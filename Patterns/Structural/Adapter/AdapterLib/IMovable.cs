
namespace Patterns
{
	/// <summary>
	/// Содержит методы, связанные с переездом офиса.
	/// </summary>
	public interface IMovable
	{
		/// <summary>
		/// Изменение адреса офиса.
		/// </summary>
		/// <param name="newAddress">Новый адрес.</param>  
		void Move(string newAddress);
	}
}
