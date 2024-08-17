
using Lab.Logic;

namespace Lab;

public class Start
{
    public void Main()
    {

        static void Main(string[] args)
        {
            #region Новая реализация

            var container = new Container(40);

            while (true)
            {
                Helper.WriteLine(
                    "Для продолжения нажми клавишу ([D] - шаг с дефрагментацией, [пробел] - шаг БЕЗ дефрагментации)...");
                ConsoleKeyInfo readKey = Console.ReadKey();
                Console.WriteLine();
                switch (readKey.Key)
                {
                    case ConsoleKey.D:
                    {
                        container.ExecuteNextStep(5, 10, true);
                        break;
                    }
                    default:
                    {
                        container.ExecuteNextStep(5, 10);
                        break;
                    }
                }
            }

            #endregion
        }
    }
}