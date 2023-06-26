namespace Patterns
{
    /// <summary>
    /// Проверка корректности реализации паттерна Composite.
    /// </summary>
    [TestClass]
    public class CompositeTests
    {
        #region Поля.
        /// <summary>
        /// Название по умолчанию.
        /// </summary>
        private string _defaultName = "Название по умолчанию";
        #endregion 

        #region Методы.
        /// <summary>
        /// Создание файла с помощью null-аргументов в конструкторе.
        /// </summary>
        /// <exception cref="ArgumentNullException">Название файла равно null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateFile_WithNullArgumentsInConstructor_ShouldThrowArgumentNullException()
        {
            new File(null);
        }

        /// <summary>
        /// Создание файла с помощью корректных аргументов в конструкторе.
        /// </summary>
        [TestMethod]
        public void CreateFile_WithCorrectArgumentsInConstructor_ShouldСreateFile() 
        {
            new File(_defaultName);
        }

        /// <summary>
        /// Добавление null-компонента файловой системы в файл.
        /// </summary>
        /// <exception cref="ArgumentNullException">Компонент файловой системы равен null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddFileSystemComponentToFile_WithNullFileSystemComponent_ShouldThrowArgumentNullException()
        {
            new File(_defaultName).Add(null);
        }

        /// <summary>
        /// Добавление корректного компонента файловой системы в файл.
        /// </summary>
        [TestMethod]
        public void AddFileSystemComponentToFile_WithCorrectFileSystemComponent_ShouldAddComponent()
        {
            new File(_defaultName).Add(new File(_defaultName));
            new File(_defaultName).Add(new Directory(_defaultName));
        }

        /// <summary>
        /// Удаление null-компонента файловой системы из файла.
        /// </summary>
        /// <exception cref="ArgumentNullException">Компонент файловой системы равен null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void RemoveFileSystemComponentFromFile_WithNullFileSystemComponent_ShouldThrowArgumentNullException()  
        {
            new File(_defaultName).Remove(null);
        }

        /// <summary>
        /// Удаление корректного компонента файловой системы из файла.
        /// </summary>
        [TestMethod]
        public void RemoveFileSystemComponentFromFile_WithNotExistenceFileSystemComponent_ShouldRemoveFileSystemComponent() 
        {
            new File(_defaultName).Remove(new File(_defaultName));
            new File(_defaultName).Remove(new Directory(_defaultName));
        }

        /// <summary>
        /// Создание директории с помощью null-аргументов в конструкторе.
        /// </summary>
        /// <exception cref="ArgumentNullException">Название файла равно null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateDirectory_WithNullArgumentsInConstructor_ShouldThrowArgumentOutOfRangeException()
        {
            new Directory(null);
        }

        /// <summary>
        /// Создание директории с помощью корректных аргументов в конструкторе.
        /// </summary>
        [TestMethod]
        public void CreateDirectory_WithCorrectArgumentsInConstructor_ShouldСreateDirectory()
        {
            new Directory(_defaultName);
        }

        /// <summary>
        /// Добавление null-компонента файловой системы в директорию.
        /// </summary>
        /// <exception cref="ArgumentNullException">Компонент файловой системы равен null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddFileSystemComponentToDirectory_WithNullFileSystemComponent_ShouldThrowArgumentNullException()
        {
            new Directory(_defaultName).Add(null);
        }

        /// <summary>
        /// Добавление корректного компонента файловой системы в директорию.
        /// </summary>
        [TestMethod]
        public void AddFileSystemComponentToDirectory_WithCorrectFileSystemComponent_ShouldAddComponent()
        {
            new Directory(_defaultName).Add(new File(_defaultName));
            new Directory(_defaultName).Add(new Directory(_defaultName));
        }

        /// <summary>
        /// Удаление null-компонента файловой системы из директории.
        /// </summary>
        /// <exception cref="ArgumentNullException">Компонент файловой системы равен null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void RemoveFileSystemComponentFromDirectory_WithNullFileSystemComponent_ShouldThrowArgumentNullException()
        {
            new Directory(_defaultName).Remove(null); 
        }

        /// <summary>
        /// Удаление несуществующего компонента файловой системы из директории.
        /// </summary>
        /// <exception cref="ArgumentNullException">Компонент файловой системы равен null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void RemoveFileSystemComponentFromDirectory_WithNotExistenceFileSystemComponent_ShouldThrowArgumentNullException()
        {
            new Directory(_defaultName).Remove(new File(_defaultName));
        }
        #endregion
    }
}