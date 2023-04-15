using System.Reflection;

namespace ГрупповаяЛабаИнфа.Logic
{
    internal static class Helper
    {
        private static string _fileName = DateTime.Now.ToString("yyyy_MM_dd HH-mm-ss");

        /// <summary>
        /// Вывод в консоль (и логирование)
        /// </summary>
        private static void WriteAndLoging(string text, string environmentNewLine, ConsoleColor color = ConsoleColor.White)
        {
            // вывод в консоль
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor=color;
            if (string.IsNullOrEmpty(environmentNewLine))
            {
                Console.Write(text);
            }
            else
            {
                Console.WriteLine(text);
            }
            
            Console.ForegroundColor = currentColor;

            // логирование в файл
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyFolder= Path.GetDirectoryName(assemblyLocation);
            string logFileName = Path.Combine(assemblyFolder, $"{_fileName}.txt");
            System.IO.File.AppendAllText(logFileName, $"{text}{environmentNewLine}");
        }

        /// <summary>
        /// Вывод в консоль (без переноса строки)
        /// </summary>
        public static void Write(string text = "", ConsoleColor color = ConsoleColor.White)
        {
            WriteAndLoging(text, string.Empty, color);
        }

        /// <summary>
        /// Выводв консоль (с переносом строки)
        /// </summary>
        public static void WriteLine(string text = "", ConsoleColor color = ConsoleColor.White)
        {
            WriteAndLoging(text, Environment.NewLine, color);
        }
    }
}
