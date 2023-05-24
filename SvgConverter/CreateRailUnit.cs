using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateRailUnit
    {
        // Функция для формирования SVG картинки для "StandardLibrary.RailUnitEx"
        public static SvgGroupElement CreateSvgImageRailUnit(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetRailUnitBounds(out var bounds))
            {
                return null;
            }

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curTop = bounds.Top;
            var curWidth = bounds.Width;

            // Данный элемент вращается относительно своего начала -> вычислим координату правого края
            // Если элемент рисовали слева направо -> центр будет в левой точке
            var curRight = curLeft;
            // Если элемент рисовали справа налево -> центр будет в правой точке
            if (float.Parse(xmlNode["OffsetEnd"], CultureInfo.InvariantCulture) < 0)
            {
                curRight = curLeft + curWidth * 2;
            }

            // Создадим группу для отрисовки текущей "StandardLibrary.RailUnitEx" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Путь"
            var railUnitEx = CreateRailUnitExSvg(xmlNode, curLeft, curTop, curWidth, objColor);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(railUnitEx, result, xmlNode, curLeft, curRight,
                curTop, curTop, true);

            return result;
        }

        // Функция для получения элемента "Путь" в формате Svg
        private static SvgGroupElement CreateRailUnitExSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curTop, float curWidth, Color objColor)
        {
            // Получим значение ширины внешней линии
            var externalStrokeWidth = xmlNode.GetLineWidth();

            // Вычислим значение ширины внутренней линии
            var internalWidth = (int)(externalStrokeWidth - 2 * (int)(externalStrokeWidth / 3));

            return new SvgGroupElement
            {
                Children =
                {
                    // Внешняя линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curLeft),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(curLeft + curWidth),
                        Y2 = new SvgLength(curTop),
                        StrokeWidth = new SvgLength(externalStrokeWidth),
                        Stroke = new SvgPaint(objColor),
                        Class = "rc-line-outer"
                    },

                    // Внутренняя линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curLeft + (float)internalWidth / 2),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(curLeft + curWidth - (float)internalWidth / 2),
                        Y2 = new SvgLength(curTop),
                        StrokeWidth = new SvgLength(internalWidth),
                        Stroke = new SvgPaint(objColor),
                        Class = "rc-line-inner"
                    }
                },

                StrokeWidth = new SvgLength(0),
                Stroke = new SvgPaint(objColor)
            };
        }
    }
}