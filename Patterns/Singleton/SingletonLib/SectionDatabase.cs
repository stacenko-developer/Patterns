using System.Collections.Generic;

namespace Patterns
{
    /// <summary>
    /// База данных разделов. Реализация паттерна Singleton.
    /// </summary>
    public class SectionDatabase
    {
        #region Поля.
        /// <summary>
        /// База данных разделов.
        /// </summary>
        private static SectionDatabase Database = null;

        /// <summary>
        /// Заблокированный объект.
        /// Служит для синхронизации потоков.
        /// </summary>
        private static object LockObject = new object(); 

        /// <summary>
        /// Список разделов.
        /// </summary>
        private List<Section> _sectionsList;

        /// <summary>
        /// Количество разделов в списке по умолчанию.
        /// </summary>
        private int _defaultSectionsCount = 10;
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает хранилище данных разделов.
        /// </summary>
        protected SectionDatabase()
        {
            _sectionsList = new List<Section>();

            for (var i = 0; i < _defaultSectionsCount; i++)
            {
                _sectionsList.Add(new Section
                {
                    Name = $"Name {i}",
                    Code = $"NrbCode {i}"
                });
            }
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Инициализация хранилища данных разделов.
        /// </summary>
        /// <returns>Хранилище данных разделов.</returns>
        public static SectionDatabase Initialize()
        {
            if (Database == null)
            {
                lock (LockObject)
                {
                    if (Database == null)
                    {
                        Database = new SectionDatabase();
                    }
                }
            }

            return Database;
        }

        /// <summary>
        /// Получение всех разделов.
        /// </summary>
        /// <returns>Список разделов.</returns>
        public List<Section> GetAllSections() => _sectionsList;

        /// <summary>
        /// Добавление раздела в базу данных.
        /// </summary>
        /// <param name="name">Название раздела.</param>
        /// <param name="code">Код раздела.</param>
        public void AddSection(string name, string code)
        {
            Validator.ValidateStringText(name);
            Validator.ValidateStringText(code);

            _sectionsList.Add(new Section
            {
                Name = name,
                Code = code
            });
        }
        #endregion
    }
}
