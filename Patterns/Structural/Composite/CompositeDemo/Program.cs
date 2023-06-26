namespace Patterns
{
    class Program
    {
        #region Методы.
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Набор аргументов.</param> 
        private static void Main(string[] args)
        {
            RunDemo();
        }

        /// <summary>
        /// Выполнение основного функционала.
        /// </summary>
        private static void RunDemo()
        {
            var courseCount = 5;
            var directory = new Directory("Институт");

            var coursesSubjects = new Dictionary<int, List<FileSystemComponent>>
            {
                {
                    1, new List<FileSystemComponent> 
                    {
                        new File("Дискретная математика"),
                        new File("Языки программирования"),
                        new File("Физическая культура")
                    } 
                },
                {
                    2, new List<FileSystemComponent>
                    {
                        new File("Иностранный язык"),
                        new File("Информатика"),
                        new File("Алгебра и геометрия")
                    }
                },
                {
                    3, new List<FileSystemComponent>
                    {
                        new File("Математический анализ"),
                        new File("Физика"),
                        new File("История")
                    }
                },
                {
                    4, new List<FileSystemComponent>
                    {
                        new File("Алгоритмы и структуры данных"),
                        new File("Прикладное программирование"),
                        new File("Теория графов и ее приложения")
                    }
                },
                {
                    5, new List<FileSystemComponent>
                    {
                        new File("Вычислительная математика"),
                        new File("Низкоуровневое программирование"),
                        new File("Алгебраические структуры и теория чисел")
                    }
                },
            };

            for (var i = 1; i <= courseCount; i++)
            {
                var course = new Directory($"{i} курс");

                foreach (var subject in coursesSubjects[i])
                {
                    course.Add(subject);
                }

                directory.Add(course);
            }

            Console.WriteLine(directory);
        }
        #endregion
    }
}
