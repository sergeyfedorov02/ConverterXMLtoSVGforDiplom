using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateRailUnitWithIntersection
    {
        // Функция для формирования SVG картинки для "StandardLibrary.RailUnitWithIntersection"
        public static SvgGroupElement CreateSvgImageRailUnitWithIntersection(
            IReadOnlyDictionary<string, string> xmlNode, ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetRailUnitWithIntersectionBounds(out var bounds))
            {
                return null;
            }

            // Вычислим все координаты
            var firstLineLeft = bounds[0].Left;
            var firstLineWidth = bounds[0].Width;
            var secondLineLeft = bounds[1].Left;
            var secondLineWidth = bounds[1].Width;
            var curTop = bounds[0].Top;

            // Создадим группу для отрисовки текущей "StandardLibrary.RailUnitWithIntersection" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Путь с разрывом"
            var railUnitWithIntersection = CreateRailUnitWithIntersectionSvg(xmlNode, firstLineLeft, firstLineWidth,
                secondLineLeft, secondLineWidth, curTop, objColor);

            // Добавим стандартные атрибуты
            // Добавим угол поворота для обеих составляющих, если он есть
            railUnitWithIntersection.AddAngle(xmlNode, firstLineLeft, firstLineLeft + firstLineWidth, curTop, curTop);
            railUnitWithIntersection.AddAngle(xmlNode, secondLineLeft, secondLineLeft + secondLineWidth, curTop,
                curTop);

            DictionaryExtension.AddStandardEndResultAttributes(railUnitWithIntersection, result, xmlNode, firstLineLeft,
                firstLineLeft + firstLineWidth,
                curTop, curTop, false);

            return result;
        }

        // Функция для получения элемента "Путь с разрывом" в формате Svg
        private static SvgGroupElement CreateRailUnitWithIntersectionSvg(IReadOnlyDictionary<string, string> xmlNode,
            float firstLineLeft, float firstLineWidth, float secondLineLeft, float secondLineWidth, float curTop,
            Color objColor)
        {
            // Получим значение ширины внешней линии
            var externalStrokeWidth = xmlNode.GetLineWidth();

            // Вычислим значение ширины внутренней линии
            var internalWidth = (int)(externalStrokeWidth - 2 * (int)(externalStrokeWidth / 3));

            return new SvgGroupElement
            {
                Children =
                {
                    // Внешняя левая линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(firstLineLeft),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(firstLineLeft + firstLineWidth),
                        Y2 = new SvgLength(curTop),
                        StrokeWidth = new SvgLength(externalStrokeWidth),
                        Stroke = new SvgPaint(objColor),
                        Class = "rc-line-outer"
                    },

                    // Внутренняя левая линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(firstLineLeft + (float)internalWidth / 2),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(firstLineLeft + firstLineWidth - (float)internalWidth / 2),
                        Y2 = new SvgLength(curTop),
                        StrokeWidth = new SvgLength(internalWidth),
                        Stroke = new SvgPaint(objColor),
                        Class = "rc-line-inner"
                    },

                    // Внешняя правая линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(secondLineLeft),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(secondLineLeft + secondLineWidth),
                        Y2 = new SvgLength(curTop),
                        StrokeWidth = new SvgLength(externalStrokeWidth),
                        Stroke = new SvgPaint(objColor),
                        Class = "rc-line-outer"
                    },

                    // Внутренняя правая линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(secondLineLeft + (float)internalWidth / 2),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(secondLineLeft + secondLineWidth - (float)internalWidth / 2),
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