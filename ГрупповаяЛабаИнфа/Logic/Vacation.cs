namespace ГрупповаяЛабаИнфа.Logic;

/// <summary>
/// Класс описывает вакантрые позиции в контейнере
/// </summary>
internal class Vacation
{
    public Vacation(int startPositin, int size)
    {
        StartPositin = startPositin;
        Size = size;
    }

    /// <summary>
    /// Начальная позиция
    /// </summary>
    public int StartPositin { get; set; }

    /// <summary>
    /// Размер
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Конец позиции
    /// </summary>
    /// <returns></returns>
    public int EndPosition()
    {
        return StartPositin + Size - 1;
    }
}