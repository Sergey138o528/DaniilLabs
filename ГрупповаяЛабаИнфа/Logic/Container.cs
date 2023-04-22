namespace ГрупповаяЛабаИнфа.Logic;

/// <summary>
/// Класс описывает контейнер
/// </summary>
public class Container
{
    /// <summary>
    /// Признак указывающий требуется ли выполнять автоматическую дефрагменрацию на каждом шаге
    /// </summary>
    public bool EnableAutoDefragmentation;

    /// <summary>
    /// Символ для визуализации вакансии размером = 1
    /// </summary>
    public char VacationChar = '_';

    /// <summary>
    /// Инициализация контейнера заданного размера
    /// </summary>
    /// <param name="size">Размер контейнера</param>
    public Container(int size)
    {
        Size = size;
        Vacations = new List<Vacation>
        {
            new Vacation(1, Size)
        };

        Helper.WriteLine($"Создан контейнер вместительностью {size}", ConsoleColor.Green);
        Helper.WriteLine("Исходное состояние");
        ShowState();
    }

    /// <summary>
    /// Размер контейнера
    /// </summary>
    public int Size;

    /// <summary>
    /// Вакантрые позиции в контейнере
    /// </summary>
    List<Vacation> Vacations;

    /// <summary>
    /// Коллекция операций в контейнере
    /// </summary>
    List<Operation> Operations = new List<Operation>();

    /// <summary>
    /// Коллекция операций не поместившихся в контейнер
    /// </summary>
    List<Operation> OperationsFolt = new List<Operation>();

    /// <summary>
    /// Текущий шаг
    /// </summary>
    public int CurrentStep;


    Random _random = new Random();

    /// <summary>
    /// Выполнить шаг.
    /// </summary>
    /// <remarks>
    /// Состоит из действий:
    /// - Пересчет операций в контейнере;
    /// - Герерация новой операции и помещение ее в контейнер;
    /// - Вывод состояния контейнера в консоль.
    /// </remarks>
    public void ExecuteNextStep(int operationMaxLifeTime, int operationMaxSize, bool enableAutoDefragmentation = false)
    {
        EnableAutoDefragmentation = enableAutoDefragmentation;
        CurrentStep++;

        if (EnableAutoDefragmentation)
        {
            Helper.Write($"---------- Шаг N{CurrentStep}");
            Helper.Write("(с дефрагментацией)",ConsoleColor.Cyan);
            Helper.WriteLine("--------------------------------");
        }
        else
        {
            Helper.WriteLine($"---------- Шаг N{CurrentStep}---------------------------------------------------");
        }
        
        ProcessingOperations();

        GenerateNewOperatin(operationMaxLifeTime, operationMaxSize);

        ShowState();
    }

    /// <summary>
    /// Вывод текущего состояния кантейнера в консоль
    /// </summary>
    private void ShowState()
    {
        Helper.WriteLine("3) Вывод состояния контейнера");
        // Операции
        Helper.WriteLine($"\tОперации (занято всего {Operations.Sum(item => item.Size)}):");
        foreach (Operation operation in Operations)
        {
            Helper.WriteLine($"\t\t{operation.Name}: Size = {operation.Size}, LifeTie = {operation.LifeTime}, Positions  {operation.StartPositionInContainer}-{operation.EndPositionInContainer}");
        }

        // Вакансии
        Helper.WriteLine($"\tВкакнтные позиции (свободно всего {Vacations.Sum(item => item.Size)}):");
        foreach (Vacation vacation in Vacations)
        {
            Helper.WriteLine($"\t\t {vacation.StartPositin}-{vacation.EndPosition()} (размер:{vacation.Size})");
        }

        //Отрисовка задач (в линию)
        for (int i = 1; i <= Size; i++)
        {
            // поиск задачи по адресу
            var item = Operations.FirstOrDefault(item => item.StartPositionInContainer <= i && item.EndPositionInContainer >= i);
            if (item != null)
            {
                Helper.Write($"{item.Name}");
            }
            else
            {
                Helper.Write($"{VacationChar}");
            }
        }

        Helper.WriteLine();
        Helper.WriteLine("1234567890123456789012345678901234567890 - линейка для отладки");
        Helper.WriteLine();
    }

    /// <summary>
    /// Герерация новой операции и помещение ее в контейнер
    /// </summary>
    private void GenerateNewOperatin(int maxLifeTime, int maxSize)
    {
        Helper.WriteLine("2) Герерация новой операции и помещение ее в контейнер");

        var newOperation = CreateOperation(maxLifeTime, maxSize);
        Helper.WriteLine($"\tНовая операция: '{newOperation.Name}' Size = {newOperation.Size}, LifeTime={newOperation.LifeTime}");

        // поиск вакансии для новой операции
        // todo: проверить сотрировку OrderBy
        var vacation = Vacations.Where(i => i.Size >= newOperation.Size).OrderBy(i => i.Size).ThenBy(i => i.StartPositin).FirstOrDefault();
        if (vacation == null)
        {
            Helper.WriteLine($"\tДля операции {newOperation.Name} не удалось найти вакансию размером: {newOperation.Size}", ConsoleColor.Red);
            OperationsFolt.Add(newOperation);
        }
        else
        {
            // Помещение операции в контейнер
            newOperation.StartPositionInContainer = vacation.StartPositin;
            Operations.Add(newOperation);

            // Пересчет свободного пространства
            var vacationBalance = vacation.Size - newOperation.Size;
            if (vacationBalance > 0)
            {
                vacation.StartPositin = vacation.StartPositin + newOperation.Size;
                vacation.Size = vacationBalance;
            }
            else
            {
                Vacations.Remove(vacation);
            }
        }

        // Отсортируем операции по позициям в контейнере
        Operations = Operations.OrderBy(item => item.StartPositionInContainer).ToList();
    }

    /// <summary>
    /// Пересчет операций
    /// </summary>
    /// <remarks>
    /// - сокращаем время жизни операций и уборка "погибших";
    /// - склеивание соседних вакансий;
    /// </remarks>
    private void ProcessingOperations()
    {
        Helper.WriteLine("1) Пересчет операций в контейнере");

        // Пересчет времени жизни для оставшихся операций и уборка "погибших"
        Helper.WriteLine("\tУборка \"погибших\" операций");
        List<Operation> operationListToRemove = new List<Operation>();
        for (int i = 0; i < Operations.Count; i++)
        {
            var operation = Operations[i];

            if (operation.LifeTime <= 1)
            {
                Vacations.Add(new Vacation(operation.StartPositionInContainer, operation.Size));
                operationListToRemove.Add(operation);
            }
            else
            {
                operation.LifeTime -= 1;
            }
        }
        foreach (Operation operationToRemove in operationListToRemove)
        {
            Operations.Remove(operationToRemove);
            Helper.WriteLine($"\t\tУдалена опрация: '{operationToRemove.Name}' Positions: {operationToRemove.StartPositionInContainer}-{operationToRemove.EndPositionInContainer}, Size: {operationToRemove.Size}", ConsoleColor.Red);
        }
        Vacations = Vacations.OrderBy(item => item.StartPositin).ToList();



        if (EnableAutoDefragmentation)
        {
            // Дефрагментация операция
            Helper.WriteLine("\tДефрагментация операций:");
            Operation operationPrevious = null;

            foreach (Operation operationCurrent in Operations)
            {
                if (operationPrevious == null)
                {
                    if (operationCurrent.StartPositionInContainer != 1)
                    {
                        operationCurrent.StartPositionInContainer = 1;
                        Helper.WriteLine(
                            $"\t\t{operationCurrent.Name}, NewPositions {operationCurrent.StartPositionInContainer}-{operationCurrent.EndPositionInContainer}",
                            ConsoleColor.Cyan);
                    }
                }
                else
                {
                    int newStartPosition = operationPrevious.EndPositionInContainer + 1;
                    if (operationCurrent.StartPositionInContainer != newStartPosition)
                    {
                        operationCurrent.StartPositionInContainer = newStartPosition;
                        Helper.WriteLine(
                            $"\t\t{operationCurrent.Name}, NewPositions {operationCurrent.StartPositionInContainer}-{operationCurrent.EndPositionInContainer}",
                            ConsoleColor.Cyan);
                    }
                }

                operationPrevious = operationCurrent;
            }
            Operations = Operations.OrderBy(item => item.StartPositionInContainer).ToList();

            // Вычисление сободного пространства (вакансий)
            if (operationPrevious != null)
            {
                Vacations = new List<Vacation>
                {
                    new Vacation(operationPrevious.EndPositionInContainer + 1,
                        Size - operationPrevious.EndPositionInContainer)
                };
            }
        }
        else
        {

            // склеивание соседних вакансий (и упорядочевание по начальной позиции)
            Vacation itemPrevious = null;
            Helper.WriteLine("\tОбъединение смежных вакансий");
            List<Vacation> newVacations = new List<Vacation>();
            foreach (Vacation itemCurrent in Vacations)
            {
                if (itemPrevious != null && itemPrevious.EndPosition() == itemCurrent.StartPositin - 1)
                {
                    Vacation itemMerged = new Vacation(itemPrevious.StartPositin, itemPrevious.Size + itemCurrent.Size);
                    newVacations.Remove(itemPrevious);
                    newVacations.Add(itemMerged);
                    Helper.WriteLine($"\t\tОбъединена вакансия :{itemMerged.StartPositin}-{itemMerged.EndPosition()}", ConsoleColor.Yellow);

                    itemPrevious = itemMerged;
                }
                else
                {
                    newVacations.Add(itemCurrent);

                    itemPrevious = itemCurrent;
                }
            }
            Vacations = newVacations.OrderBy(item => item.StartPositin).ToList();
        }




    }

    private Operation CreateOperation(int maxLifeTime, int maxSize)
    {
        var operationName = ((char)(CurrentStep + 64)).ToString();
        var operationLifeTime = _random.Next(1, maxLifeTime);
        var operationSize = _random.Next(1, maxSize);
        return new Operation(operationName, operationLifeTime, operationSize);
    }
}