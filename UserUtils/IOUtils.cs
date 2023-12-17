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

            if (lines is null)
            {
                return null;
            }

            if (lines.Length < 2)
            {
                StructureError();
                return null;
            }

            string[] headingSplittedLine = CsvProcessing.CsvLineSplit(lines[0]);
            if (headingSplittedLine is null || headingSplittedLine.Length != CsvProcessing.Heading.Length)
            {
                StructureError();
                return null;
            }
            for (int i = 0; i < CsvProcessing.Heading.Length; i++)
            {
                if (headingSplittedLine[i] != CsvProcessing.Heading[i])
                {
                    StructureError();
                    return null;
                }
            }

            lines = lines[1..];
            MosGas[] mosGas = new MosGas[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                var splittedLine = CsvProcessing.CsvLineSplit(lines[i]);
                if (splittedLine == null || splittedLine.Length != CsvProcessing.Heading.Length)
                {
                    StructureError();
                    return null;
                }


                if (!int.TryParse(splittedLine[1], out int areaId))
                {
                    StructureError();
                    return null;
                }

                try
                {
                    mosGas[i] = new MosGas(new AdministrativeUnit(splittedLine[2], splittedLine[3]), splittedLine[0], areaId);
                }
                catch (ArgumentException)
                {
                    StructureError();
                    return null;
                }
            }
            return mosGas;
        }
    }
}
