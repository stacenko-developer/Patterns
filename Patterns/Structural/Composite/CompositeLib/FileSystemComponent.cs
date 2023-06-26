using System;

namespace Patterns
{   
    /// <summary>
    /// Компонент файловой системы.
    /// </summary>
    public abstract class FileSystemComponent
    {
        #region Поля.
        /// <summary>
        /// Название.
        /// </summary>
        protected string _name;
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создание компонента файловой системы с помощью указанных параметров.
        /// </summary>
        /// <param name="name">Название компонента файловой системы.</param>
        public FileSystemComponent(string name)
        {   
            Validator.ValidateStringText(name);
            
            _name = name;
        }
        #endregion

        #region Методы.

        #region Валидация.
        /// <summary>
        /// Проверка корректности компонента.
        /// </summary>
        /// <param name="component">Компонент, который необходимо проверить.</param>
        /// <exception cref="ArgumentNullException">Компонент равен null!</exception>
        protected void ValidateComponent(FileSystemComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component), "Компонент равен null!");
            }
        }
        #endregion 

        /// <summary>
        /// Добавление компонента.
        /// </summary>
        /// <param name="component">Компонент, который необходимо добавить.</param>
        public virtual void Add(FileSystemComponent component) 
        {   
            ValidateComponent(component);
        }

        /// <summary>
        /// Добавление компонента.
        /// </summary>
        /// <param name="component">Компонент, который необходимо добавить.</param>
        public virtual void Remove(FileSystemComponent component) 
        {
            ValidateComponent(component);
        }

        /// <summary>
        /// Строковое преставление объекта компонента файловой системы.
        /// </summary>
        /// <returns>Данные объекта компонента файловой системы в виде строки.</returns>
        public override string ToString() => _name;
        #endregion
    }
}
