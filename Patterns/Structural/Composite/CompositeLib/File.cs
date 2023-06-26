namespace Patterns
{
    /// <summary>
    /// Файл.
    /// </summary>
    public class File : FileSystemComponent
    {
        #region Конструкторы.
        /// <summary>
        /// Создание файла с помощью указанных параметров.
        /// </summary>
        /// <param name="name">Название файла.</param>
        public File(string name) 
            : base(name)
        {
        }
        #endregion 
    }
}
