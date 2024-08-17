namespace Lab.Logic;

/// <summary>
/// Класс описывает вакантрые позиции в контейнере
/// </summary>
public class Vacation
{
    /// <summary>
    /// Конструктор класса, инициализирует экземпляр
    /// </summary>
    /// <param name="startPositin"></param>
    /// <param name="size"></param>
    public Vacation(int startPositin, int size)
    {
        StartPositin = startPositin;
        Size = size;
    }

    /// <summary>
    /// Начальная позиция
    /// </summary>
    public int StartPositin;

    /// <summary>
    /// Размер
    /// </summary>
    public int Size;

    /// <summary>
    /// Конец позиции
    /// </summary>
    /// <returns></returns>
    public int EndPosition()
    {
        return StartPositin + Size - 1;
    }
}