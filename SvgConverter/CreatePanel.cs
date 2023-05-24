using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreatePanel
    {
        // Функция для формирования SVG картинки для "StandardLibrary.Panel"
        public static SvgGroupElement CreateSvgImagePanel(IReadOnlyDictionary<string, string> xmlNode,
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

            // Создадим группу для отрисовки текущей "StandardLibrary.Panel" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Панель"
            var panel = CreatePanelSvg(xmlNode, curLeft, curRight, curTop, curBottom, objColor);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(panel, result, xmlNode, curLeft, curRight,
                curTop, curTop, true);

            return result;
        }

        // Функция для получения элемента "Панель" в формате Svg
        private static SvgRectElement CreatePanelSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curRight, float curTop, float curBottom, Color objColor)
        {
            // Вычислим координаты для прямоугольника
            var curWidth = curRight - curLeft;
            var curHeight = curBottom - curTop;
            var curX = curLeft;
            var curY = curTop;

            return new SvgRectElement()
            {
                Width = new SvgLength(curWidth),
                Height = new SvgLength(curHeight),

                // Задаем координаты левого верхнего угла
                X = new SvgLength(curX),
                Y = new SvgLength(curY),

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),

                // Задаем цвет внутри прямоугольника полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(objColor),

                // Добавим указатель класса "fill-indicator"
                Class = "fill-indicator",

                // Делаем его невидимым
                FillOpacity = 0
            };
        }
    }
}