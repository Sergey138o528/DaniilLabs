namespace ГрупповаяЛабаИнфа.Logic;

/// <summary>
/// Класс описывает операцию
/// </summary>
public class Operation
{
    /// <summary>
    /// Наименование задачи
    /// </summary>
    public string Name;

    /// <summary>
    /// Оставшееся время жизни (в каждом цикли вычитаем единицу)
    /// </summary>
    public int LifeTime;

    /// <summary>
    /// Размер задачи
    /// </summary>
    public int Size;

    /// <summary>
    /// Позиция (адрес начала) операции в контейнере
    /// </summary>
    public int StartPositionInContainer;

    public int EndPositionInContainer
    {
        get { return StartPositionInContainer + Size - 1; }
    }

    /// <summary>
    /// Конструктор экземпляра
    /// </summary>
    public Operation(string name, int lifeTime, int size)
    {
        Name = name;
        LifeTime = lifeTime;
        Size = size;
    }
}