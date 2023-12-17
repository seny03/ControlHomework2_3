using DataUtils;

namespace UserUtils
{
    /// <summary>
    /// Предоставляет методы для работы с пользователем через консоль.
    /// </summary>
    public static class IOUtils
    {

        internal static void StructureError() => Console.WriteLine("Структура файла не соответствует описанной в условии.");
        /// <summary>
        /// Запрашивает названия файла, а затем считывает из него строки, обрабатывая исключения с информативным выводом.
        /// </summary>
        internal static MosGas[]? ReadLines()
        {
            string[]? lines = null;
            try
            {
                Console.Write("Введите путь к файлу: ");
                lines = CsvProcessing.ReadLines(Console.ReadLine());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("[ERROR] Некорректное значение названия файла, попробуйте еще раз...");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("[ERROR] Файл с указанным именем не найден, попробуйте еще раз...");
            }
            catch (IOException ex)
            {
                Console.WriteLine("[ERROR] Ошибка в процессе чтения файла: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] Возникла ошибка: " + ex.Message);
            }

            if (lines is null || lines.Length < 2)
            {
                return null;
            }

            MosGas[] mosGas = new MosGas[lines.Length];
            string[] headingSplittedLine = CsvProcessing.CsvLineSplit(lines[0]);
            if (headingSplittedLine is null || headingSplittedLine.Length != CsvProcessing.Heading.Length)
            {
                return null;
            }
            for (int i = 0; i < CsvProcessing.Heading.Length; i++)
            {
                if (headingSplittedLine[i] != CsvProcessing.Heading[i])
                {
                    return null;
                }
            }

            for (int i = 1; i < lines.Length; i++)
            {
                var splittedLine = CsvProcessing.CsvLineSplit(lines[i]);
                Console.WriteLine(string.Join(" ; ", splittedLine));
                if (splittedLine == null || splittedLine.Length != CsvProcessing.Heading.Length)
                {
                    return null;
                }


                if (!int.TryParse(splittedLine[1], out int areaId))
                {
                    return null;
                }

                try
                {
                    mosGas[i] = new MosGas(new AdministrativeUnit(splittedLine[2], splittedLine[3]), splittedLine[0], areaId);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
            return mosGas;
        }
    }
}
