using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateRailUnit
    {
        // Функция для формирования SVG картинки для "StandardLibrary.RailUnitEx"
        public static SvgGroupElement CreateSvgImageRailUnit(IReadOnlyDictionary<string, string> xmlNode)
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

            // Создадим группу для отрисовки текущей "StandardLibrary.RailUnitEx" со стандартными атрибутами
            var result = xmlNode.AddStandardResultAttributes(null, null, null);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Добавление Стиля
            // TODO() - добавить параметр указания стиля (Stroke и Fill тогда мб следует убрать)

            // Получим элемент "Путь"
            var railUnitEx = CreateRailUnitExSvg(xmlNode, curLeft, curTop, curWidth, objColor);

            // Добавим стандартные атрибуты
            // Добавим угол поворота, если он есть
            railUnitEx.AddAngle(xmlNode, curLeft, curLeft + curWidth, curTop, curTop);

            // Добавим полученный элемент в result
            result.Children.Add(railUnitEx);

            // Если надо отображать текст, то добавим его в result
            if (CreateText.IsShouldDrawLabel(xmlNode["ShouldDrawLabel"]))
            {
                // Добавляем созданный текст
                result.Children.Add(CreateText.AddSvgTextElement(xmlNode, xmlNode["Label"]));
            }

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
                        Stroke = new SvgPaint(Color.Red), // TODO - потом заменить на "objColor", сейчас для наглядности
                        Class = "rc-line-inner"
                    }
                },

                StrokeWidth = new SvgLength(0),
                Stroke = new SvgPaint(objColor)
            };
        }
    }
}