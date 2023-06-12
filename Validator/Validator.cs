using System;

namespace Patterns
{
    /// <summary>
    /// Валидатор.
    /// </summary>
    public static class Validator
    {
        #region Методы.
        /// <summary>
        /// Проверяет строку на пустоту или null.
        /// </summary>
        /// <param name="inputData">Значение типа string.</param>
        /// <exception cref="ArgumentNullException">Текст не содержит символов 
        /// или равен null.</exception>
        public static void ValidateStringText(string inputData)
        {
            if (string.IsNullOrEmpty(inputData))
            {
                throw new ArgumentNullException(nameof(inputData),
                    "Текст не содержит символов или равен null!");
            }
        }

        /// <summary>
        /// Проверка корректности типа.
        /// </summary>
        /// <param name="type">Тип, который необходимо проверить.</param>
        /// <exception cref="ArgumentNullException">Объект равен null!</exception>
        public static void ValidateType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type), "Тип равен null!");
            }
        }

        /// <summary>
        /// Проверяет принадлежность значения диапазону значений.
        /// </summary>
        /// <param name="min">Минимальное значение диапазона.</param>
        /// <param name="max">Максимальное значение диапазона.</param>
        /// <param name="number">Значение для проверки.</param>
        /// <exception cref="ArgumentOutOfRangeException">Числовое значение вышло за границы!
        /// </exception>
        public static void ValidateRangeNumber<T>(T min, T max, T number) where T : IComparable<T>
        {
            if (number.CompareTo(min) < 0 || number.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException("Числовое значение вышло за границы! " +
                    "Допустимый диапазон: [" + min + "; " + max + "]");
            }
        }

        /// <summary>
        /// Проверяет массив на пустоту или null.
        /// </summary>
        /// <typeparam name="T">Тип элементов массива.</typeparam>
        /// <param name="array">Массив.</param>
        /// <exception cref="ArgumentNullException">Массив пустой или равен null!</exception>
        public static void ArrayValidate<T>(T[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array), "Массив пустой или равен null!");
            }
        }
        #endregion
    }
}
