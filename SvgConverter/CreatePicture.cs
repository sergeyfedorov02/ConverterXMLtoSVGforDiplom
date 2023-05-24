using System;
using System.Collections.Generic;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreatePicture
    {
        private const string JpegGuid = "19e4a5aa56624fc5a0c01758028e1057";
        private const string PngGuid = "1b7cfaf4713f473cbbcd6137425faeaf";

        // Функция для формирования SVG картинки для "StandardLibrary.Picture"
        public static SvgGroupElement CreateSvgImagePicture(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetBounds(out var bounds))
            {
                return null;
            }

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curRight = bounds.Right;
            var curTop = bounds.Top;
            var curBottom = bounds.Bottom;

            // Получим значение загруженной картинки
            var curPicture = xmlNode["Image"];

            // проверим было ли загружено изображение
            if (string.IsNullOrWhiteSpace(curPicture))
                return null;

            // Удалим лишние пробелы вначале и конце
            curPicture = curPicture.Trim();

            // Строка с картинкой не может начинаться с символа "<"
            if (curPicture.StartsWith("<"))
            {
                return null;
            }

            // Определим формат картинки - jpeg или png
            var contentIndex = curPicture.IndexOf(":", StringComparison.InvariantCulture) + 1;
            var originalFormat = curPicture.Substring(0, contentIndex - 1);
            var pictureFormat = originalFormat switch
            {
                JpegGuid => "jpeg",
                PngGuid => "png",
                _ => null
            };

            // Если формат картинки какой-то другой -> не можем преобразовать
            if (string.IsNullOrEmpty(pictureFormat))
            {
                return null;
            }

            // Уберем из описания картинки ее формат и оставим только данные о самом изображении
            var imageData = curPicture.Substring(contentIndex);

            // Создадим группу для отрисовки текущей "StandardLibrary.Picture" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Получим элемент "Изображение"
            var picture = CreatePictureSvg(curLeft, curRight, curTop, curBottom, imageData, pictureFormat);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(picture, result, xmlNode, curLeft, curRight,
                curTop, curBottom, true);

            return result;
        }

        // Функция для получения элемента "Изображение" в формате Svg
        private static SvgImageElement CreatePictureSvg(float curLeft,
            float curRight, float curTop, float curBottom, string imageData, string pictureFormat)
        {
            // Вычислим координаты для прямоугольника
            var curWidth = curRight - curLeft;
            var curHeight = curBottom - curTop;
            var curX = curLeft;
            var curY = curTop;

            var picture = new SvgImageElement()
            {
                Width = new SvgLength(curWidth),
                Height = new SvgLength(curHeight),

                // Задаем координаты левого верхнего угла
                X = new SvgLength(curX),
                Y = new SvgLength(curY),

                // Добавим список кастомных атрибутов
                CustomAttributes = new List<SvgCustomAttribute>
                {
                    new SvgCustomAttribute("href",
                        $"data:image/{pictureFormat};base64,{imageData}")
                }
            };

            return picture;
        }
    }
}