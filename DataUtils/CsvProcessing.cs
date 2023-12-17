using System.Security;
using System.Text.RegularExpressions;

namespace DataUtils
{
    /// <summary>
    /// Предоставляет методы для работы с csv файлом.
    /// </summary>
    public static class CsvProcessing
    {
        public const char quotechar = '"';
        public const char delimiter = ',';

        public static string[] Heading
        {
            get
            {
                return new string[] { "streetname", "areaid", "okrug", "area" };
            }
        }

        /// <summary>
        /// Считывает все строки из файла.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static string[] ReadLines(string? filename)
        {
            List<string> lines = new();
            try
            {
                foreach (string line in File.ReadAllLines(filename))
                {
                    lines.Add(line);
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException || ex is PathTooLongException || ex is NotSupportedException)
            {
                throw new ArgumentException($"Некорректное значение {nameof(filename)}.");
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is SecurityException)
            {
                throw new IOException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lines.ToArray();
        }

        public static string[] CsvLineSplit(string line)
        {
            if (line is null)
            {
                throw new ArgumentException(nameof(line));
            }

            var splittedLine = new List<string>();
            // Изначально разбиваем строку только по запятым, которые стоят рядом с quotechar.
            Regex regex = new Regex($"(?<={quotechar}),|,(?={quotechar})");
            foreach (string substring in regex.Split(line))
            {
                // Теперь: если полученная подстрока содержит в начале и в конце quotchar, добавляем ее к ответу.
                // Иначе разбиваем ее по разделиелю и все полученные строки добавляем к ответу.
                if (substring.Length == 0)
                {
                    splittedLine.Add(substring);
                }
                else if (substring.StartsWith(quotechar) && substring.EndsWith(quotechar))
                {
                    splittedLine.Add(substring[1..^1]);
                }
                else
                {
                    splittedLine.AddRange(substring.Split(delimiter));
                }
            }

            return splittedLine.ToArray();
        }
    }
}
