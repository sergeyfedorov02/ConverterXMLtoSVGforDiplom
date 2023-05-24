using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateRelay
    {
        // Функция для формирования SVG картинки для "StandardLibrary.Relay"
        public static SvgGroupElement CreateSvgImageRelay(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetBounds(out var bounds))
            {
                return null;
            }

            // Проверим, указан ли тип элемента "Контакт/Реле"
            if (!xmlNode.TryGetValue("Shape", out var aShape))
            {
                return null;
            }

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curTop = bounds.Top;
            var curRight = bounds.Right;
            var curBottom = bounds.Bottom;

            // Создадим группу для отрисовки текущей "StandardLibrary.Relay" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Добавим указатель типа
            result.CustomAttributes.Add
            (
                new SvgCustomAttribute("data-object-hint",
                    "RelayShape=" + aShape)
            );

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Контакт/Реле"
            var relay = CreateRelaySvg(xmlNode, curLeft, curRight, curTop, curBottom, aShape, objColor);

            if (relay == null) return null;

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(relay, result, xmlNode, curLeft, curRight, curTop,
                curBottom, true);

            return result;
        }

        // Функция для получения элемента "Контакт/Реле" в формате Svg
        private static SvgElement CreateRelaySvg(IReadOnlyDictionary<string, string> xmlNode,
            float curLeft, float curRight, float curTop, float curBottom, string aShape, Color objColor)
        {
            // Получим элемент "Контакт/Реле"
            return aShape switch
            {
                // Тип - нейтральный
                "TypeN" => new SvgLineElement
                {
                    // Зададим значение ширины линии и ее цвет
                    StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),
                    Stroke = new SvgPaint(objColor),

                    // Рисуем саму линию
                    X1 = new SvgLength(curLeft),
                    Y1 = new SvgLength(curTop),
                    X2 = new SvgLength(curRight),
                    Y2 = new SvgLength(curBottom)
                },
                // Тип - поляризованный
                "TypeP" => new SvgLineElement
                {
                    // Зададим значение ширины линии и ее цвет
                    StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),
                    Stroke = new SvgPaint(objColor),

                    // Рисуем саму линию
                    X1 = new SvgLength(curLeft),
                    Y1 = new SvgLength(curBottom),
                    X2 = new SvgLength(curLeft + (curRight - curLeft) / 2),
                    Y2 = new SvgLength(curTop)
                },
                // Тип - нейтральный зеркальный
                "TypeNMirror" => new SvgLineElement
                {
                    // Зададим значение ширины линии и ее цвет
                    StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),
                    Stroke = new SvgPaint(objColor),

                    // Рисуем саму линию
                    X1 = new SvgLength(curLeft),
                    Y1 = new SvgLength(curBottom),
                    X2 = new SvgLength(curRight),
                    Y2 = new SvgLength(curTop)
                },
                _ => null
            };
        }
    }
}