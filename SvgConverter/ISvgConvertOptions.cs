namespace SvgConverter
{
    public interface ISvgConvertOptions
    {
        /// <summary>
        /// Добавлять или нет комментарии для объекта
        /// </summary>
        bool AddTitles { get; }

        /// <summary>
        /// Получить комментарий для объекта, он добавляется в заголовок элемента и в браузере показывается в виде подсказки
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        string GetTitleForObject(long objectId);
    }
}