using System;
using System.Collections.Generic;

namespace Patterns
{
    /// <summary>
    /// Папка.
    /// </summary>
    public class Directory : FileSystemComponent
    {
        #region Поля.
        /// <summary>
        /// Список компонентов файловой системы, которые находятся в папке.
        /// </summary>
        private List<FileSystemComponent> _components = new List<FileSystemComponent>(); 
        #endregion 

        #region Конструкторы.
        /// <summary>
        /// Создает папку с помощью указанных параметров.
        /// </summary>
        /// <param name="name">Название папки.</param>
        public Directory(string name) 
            : base(name)
        {
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Добавление компонента.
        /// </summary>
        /// <param name="component">Компонент, который необходимо добавить.</param>
        public override void Add(FileSystemComponent component)
        {
            ValidateComponent(component);

            _components.Add(component);
        }

        /// <summary>
        /// Добавление компонента.
        /// </summary>
        /// <param name="component">Компонент, который необходимо добавить.</param>
        /// <exception cref="ArgumentNullException">Указанный компонент файловой системы отсутствует в директории!</exception>
        public override void Remove(FileSystemComponent component)
        {
            ValidateComponent(component);

            if (!_components.Contains(component))
            {
                throw new ArgumentNullException("Указанный компонент файловой системы отсутствует в директории!");
            }

            _components.Remove(component);
        }

        /// <summary>
        /// Строковое преставление объекта компонента файловой системы.
        /// </summary>
        /// <returns>Данные объекта компонента файловой системы в виде строки.</returns>
        public override string ToString() => $"{_name}: {string.Join("=>", _components)}{Environment.NewLine}";
        #endregion
    }
}
