
namespace Patterns
{
	/// <summary>
	/// Сотрудники.
	/// </summary>
	public class Worker
	{
		#region Поля.
		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; set; } 

		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// Возраст.
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		public string Post { get; set; }

		/// <summary>
		/// Зарплата.
		/// </summary>
		public int Salary { get; set; }

		/// <summary>
		/// Название организации.
		/// </summary>
		public string Organization { get; set; }
		#endregion

		#region Методы.

		#region Переопределенные методы.
		/// <summary>
		/// Строковое представления объекта офиса. 
		/// </summary>
		/// <returns>Данные объекта офиса в виде строки.</returns>
		public override string ToString() => $"Имя: {FirstName}, Фамилия: {LastName}, Отчество: " +
			$"{Patronymic}, Возраст: {Age} Должность: {Post} Зарплата: {Salary} Организация: {Organization}";
		#endregion

		#endregion
	}
}
