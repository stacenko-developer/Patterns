using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Patterns
{
	/// <summary>
	/// Проверка корректности реализации паттерна Singleton.
	/// </summary>
	[TestClass]
	public class SingletonTests 
	{
		#region Методы.
		/// <summary>
		/// Создание первого экземпляра класса хранилища данных разделов.
		/// </summary>
		[TestMethod]
		public void InitializeSectionDatabase_SeveralTimes_ShouldCreateSectionDatabase()
		{
			Assert.IsTrue(SectionDatabase.Initialize().GetType() == typeof(SectionDatabase));
		}

		/// <summary>
		/// Инициализация хранилища данных разделов.
		/// </summary>
		[TestMethod]
		public void InitializeSectionDatabase_SeveralTimes_ShouldCreateSingleObject()
		{
			Assert.IsTrue(SectionDatabase.Initialize().GetHashCode() == SectionDatabase.Initialize().GetHashCode());
		}

		/// <summary>
		/// Инициализация хранилища несколькими потоками одновременно.
		/// </summary>
		[TestMethod]
		public void InitializeSectionDatabase_SeveralTimesByMultithreaded_ShouldCreateSingleObject()
		{
			var hashCodeFirst = 0;
			var hashCodeSecond = 0; 
			var threadFirst = new Thread(() => hashCodeFirst = SectionDatabase
				.Initialize().GetHashCode());
			var threadSecond = new Thread(() => hashCodeSecond = SectionDatabase
				.Initialize().GetHashCode());

			threadFirst.Start();
			threadSecond.Start();

			threadFirst.Join();
			threadSecond.Join();

			Assert.IsTrue(hashCodeFirst == hashCodeSecond);
		}
		#endregion
	}
}
