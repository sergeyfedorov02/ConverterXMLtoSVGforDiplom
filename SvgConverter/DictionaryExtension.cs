using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace SvgConverter
{
    internal static class DictionaryExtension
    {
        private const string DefaultWidth = "2";
        private const string DefaultObjectColor = "#FF000000"; // TODO - чёрный цвет

        public static string GetValueOrDefault(this IReadOnlyDictionary<string, string> properties, string key,
            string defaultValue = "")
        {
            return properties.TryGetValue(key, out var result) ? result : defaultValue;
        }

        public static float GetLineWidth(this IReadOnlyDictionary<string, string> properties)
        {
            return float.Parse(properties.GetValueOrDefault("LineWidth", DefaultWidth), CultureInfo.InvariantCulture);
        }

        public static Color GetObjectColor(this IReadOnlyDictionary<string, string> properties)
        {
            return GetColor.ConvertArgb(properties.GetValueOrDefault("ObjectColor", DefaultObjectColor));
        }

        public static bool TryGetBounds(this IReadOnlyDictionary<string, string> properties, out RectangleF rect)
        {
            rect = RectangleF.Empty;

            if (!properties.TryGetValue("Left", out var curLeftText)) return false;
            var curLeft = float.Parse(curLeftText, CultureInfo.InvariantCulture);

            if (!properties.TryGetValue("Right", out var curRightText)) return false;
            var curRight = float.Parse(curRightText, CultureInfo.InvariantCulture);

            if (!properties.TryGetValue("Top", out var curTopText)) return false;
            var curTop = float.Parse(curTopText, CultureInfo.InvariantCulture);

            if (!properties.TryGetValue("Bottom", out var curBottomText)) return false;
            var curBottom = float.Parse(curBottomText, CultureInfo.InvariantCulture);

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