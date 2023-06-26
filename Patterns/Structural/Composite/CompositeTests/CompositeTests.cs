namespace Patterns
{
    /// <summary>
    /// �������� ������������ ���������� �������� Composite.
    /// </summary>
    [TestClass]
    public class CompositeTests
    {
        #region ����.
        /// <summary>
        /// �������� �� ���������.
        /// </summary>
        private string _defaultName = "�������� �� ���������";
        #endregion 

        #region ������.
        /// <summary>
        /// �������� ����� � ������� null-���������� � ������������.
        /// </summary>
        /// <exception cref="ArgumentNullException">�������� ����� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateFile_WithNullArgumentsInConstructor_ShouldThrowArgumentNullException()
        {
            new File(null);
        }

        /// <summary>
        /// �������� ����� � ������� ���������� ���������� � ������������.
        /// </summary>
        [TestMethod]
        public void CreateFile_WithCorrectArgumentsInConstructor_Should�reateFile() 
        {
            new File(_defaultName);
        }

        /// <summary>
        /// ���������� null-���������� �������� ������� � ����.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� �������� ������� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddFileSystemComponentToFile_WithNullFileSystemComponent_ShouldThrowArgumentNullException()
        {
            new File(_defaultName).Add(null);
        }

        /// <summary>
        /// ���������� ����������� ���������� �������� ������� � ����.
        /// </summary>
        [TestMethod]
        public void AddFileSystemComponentToFile_WithCorrectFileSystemComponent_ShouldAddComponent()
        {
            new File(_defaultName).Add(new File(_defaultName));
            new File(_defaultName).Add(new Directory(_defaultName));
        }

        /// <summary>
        /// �������� null-���������� �������� ������� �� �����.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� �������� ������� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void RemoveFileSystemComponentFromFile_WithNullFileSystemComponent_ShouldThrowArgumentNullException()  
        {
            new File(_defaultName).Remove(null);
        }

        /// <summary>
        /// �������� ����������� ���������� �������� ������� �� �����.
        /// </summary>
        [TestMethod]
        public void RemoveFileSystemComponentFromFile_WithNotExistenceFileSystemComponent_ShouldRemoveFileSystemComponent() 
        {
            new File(_defaultName).Remove(new File(_defaultName));
            new File(_defaultName).Remove(new Directory(_defaultName));
        }

        /// <summary>
        /// �������� ���������� � ������� null-���������� � ������������.
        /// </summary>
        /// <exception cref="ArgumentNullException">�������� ����� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateDirectory_WithNullArgumentsInConstructor_ShouldThrowArgumentOutOfRangeException()
        {
            new Directory(null);
        }

        /// <summary>
        /// �������� ���������� � ������� ���������� ���������� � ������������.
        /// </summary>
        [TestMethod]
        public void CreateDirectory_WithCorrectArgumentsInConstructor_Should�reateDirectory()
        {
            new Directory(_defaultName);
        }

        /// <summary>
        /// ���������� null-���������� �������� ������� � ����������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� �������� ������� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddFileSystemComponentToDirectory_WithNullFileSystemComponent_ShouldThrowArgumentNullException()
        {
            new Directory(_defaultName).Add(null);
        }

        /// <summary>
        /// ���������� ����������� ���������� �������� ������� � ����������.
        /// </summary>
        [TestMethod]
        public void AddFileSystemComponentToDirectory_WithCorrectFileSystemComponent_ShouldAddComponent()
        {
            new Directory(_defaultName).Add(new File(_defaultName));
            new Directory(_defaultName).Add(new Directory(_defaultName));
        }

        /// <summary>
        /// �������� null-���������� �������� ������� �� ����������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� �������� ������� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void RemoveFileSystemComponentFromDirectory_WithNullFileSystemComponent_ShouldThrowArgumentNullException()
        {
            new Directory(_defaultName).Remove(null); 
        }

        /// <summary>
        /// �������� ��������������� ���������� �������� ������� �� ����������.
        /// </summary>
        /// <exception cref="ArgumentNullException">��������� �������� ������� ����� null!</exception>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void RemoveFileSystemComponentFromDirectory_WithNotExistenceFileSystemComponent_ShouldThrowArgumentNullException()
        {
            new Directory(_defaultName).Remove(new File(_defaultName));
        }
        #endregion
    }
}