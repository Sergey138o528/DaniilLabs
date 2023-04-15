namespace ГрупповаяЛабаИнфа.Logic;

/// <summary>
/// Класс описывает операцию
/// </summary>
internal class Operation
{
    /// <summary>
    /// Наименование задачи
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Оставшееся время жизни (в каждом цикли вычитаем единицу)
    /// </summary>
    public int LifeTime { get; set; }

    /// <summary>
    /// Размер задачи
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Позиция (адрес начала) операции в контейнере
    /// </summary>
    public int StartPositionInContainer { get; set; }

    public int EndPositionInContainer
    {
        get { return StartPositionInContainer + Size - 1; }
    }

    public Operation(string name, int lifeTime, int size)
    {
        Name = name;
        LifeTime = lifeTime;
        Size = size;
    }
}