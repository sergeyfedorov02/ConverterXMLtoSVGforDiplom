using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace SvgConverter
{
    internal static class DictionaryExtension
    {
        private const string DefaultWidth = "2";
        private const string DefaultObjectColor = "#FF000000";

        // Функция, в которой получаем значение атрибута по заданному key, если нет такого атрибута -> берем значение ""
        public static string GetValueOrDefault(this IReadOnlyDictionary<string, string> properties, string key,
            string defaultValue = "")
        {
            return properties.TryGetValue(key, out var result) ? result : defaultValue;
        }

        // Функция, в которой получаем значение атрибута "LineWidth", если нет такого атрибута -> берем значение DefaultWidth
        public static float GetLineWidth(this IReadOnlyDictionary<string, string> properties)
        {
            return float.Parse(properties.GetValueOrDefault("LineWidth", DefaultWidth), CultureInfo.InvariantCulture);
        }

        // Функция, в которой получаем значение атрибута "ObjectColor", если нет такого атрибута -> берем значение DefaultObjectColor
        public static Color GetObjectColor(this IReadOnlyDictionary<string, string> properties)
        {
            return GetColor.ConvertArgb(properties.GetValueOrDefault("ObjectColor", DefaultObjectColor));
        }

        // Функция для получения координат, если чего-то нет -> false
        public static bool TryGetBounds(this IReadOnlyDictionary<string, string> properties, out RectangleF rect)
        {
            rect = RectangleF.Empty;

            // Проверка атрибута "Left" из переданного Dictionary
            if (!properties.TryGetValue("Left", out var curLeftText)) return false;
            var curLeft = float.Parse(curLeftText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Right" из переданного Dictionary
            if (!properties.TryGetValue("Right", out var curRightText)) return false;
            var curRight = float.Parse(curRightText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Top" из переданного Dictionary
            if (!properties.TryGetValue("Top", out var curTopText)) return false;
            var curTop = float.Parse(curTopText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Bottom" из переданного Dictionary
            if (!properties.TryGetValue("Bottom", out var curBottomText)) return false;
            var curBottom = float.Parse(curBottomText, CultureInfo.InvariantCulture);

            // Если координаты поменяны места (рисовали из правого угла) -> надо изменить выходные значения
            if (curLeft > curRight)
            {
                (curLeft, curRight) = (curRight, curLeft);
            }

            if (curTop > curBottom)
            {
                (curTop, curBottom) = (curBottom, curTop);
            }


            rect = new RectangleF(curLeft, curTop, curRight - curLeft, curBottom - curTop);

            return true;
        }
    }
}