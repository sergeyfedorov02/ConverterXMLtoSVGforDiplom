using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateRailTerminator
    {
        // Функция для формирования SVG картинки для "StandardLibrary.RailTerminator"
        public static SvgGroupElement CreateSvgImageRailTerminator(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetRailTerminatorBounds(out var bounds))
            {
                return null;
            }

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curTop = bounds.Top;
            var curWidth = bounds.Width;
            var curHeight = bounds.Height;

            // Создадим группу для отрисовки текущей "StandardLibrary.RailTerminator" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Тупик"
            var railTerminator = CreateRailTerminatorSvg(xmlNode, curLeft, curTop, curWidth, curHeight, objColor);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(railTerminator, result, xmlNode, curLeft,
                curLeft + curWidth, curTop, curTop + curHeight, true);

            return result;
        }

        // Функция для получения элемента "Тупик" в формате Svg
        private static SvgGroupElement CreateRailTerminatorSvg(IReadOnlyDictionary<string, string> xmlNode,
            float curLeft, float curTop, float curWidth, float curHeight, Color objColor)
        {
            return new SvgGroupElement
            {
                // Зададим значение ширины линии и ее цвет
                StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),
                Stroke = new SvgPaint(objColor),

                // Задаем цвет заполнения и Убираем его
                FillOpacity = 0,
                Fill = new SvgPaint(Color.Transparent),

                // Добавим составляющие элементы
                Children =
                {
                    // Боковая линия
                    new SvgPolylineElement
                    {
                        Points = new List<SvgPoint>
                        {
                            new SvgPoint(new SvgLength(curLeft), new SvgLength(curTop + curHeight / 2)),
                            new SvgPoint(new SvgLength(curLeft + curWidth / 2), new SvgLength(curTop + curHeight / 2))
                        },
                        Class = "rc-terminator"
                    },

                    // правые 3 линии, составляющие букву "П"
                    new SvgPolylineElement
                    {
                        Points = new List<SvgPoint>
                        {
                            new SvgPoint(new SvgLength(curLeft + curWidth), new SvgLength(curTop)),
                            new SvgPoint(new SvgLength(curLeft + curWidth / 2), new SvgLength(curTop)),
                            new SvgPoint(new SvgLength(curLeft + curWidth / 2), new SvgLength(curTop + curHeight)),
                            new SvgPoint(new SvgLength(curLeft + curWidth), new SvgLength(curTop + curHeight))
                        },
                        Class = "rc-terminator"
                    }
                }
            };
        }
    }
}