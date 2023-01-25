using System.Collections.Generic;
using System.Globalization;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateAngle
    {
        public static void AddAngle(this SvgElement currentElement, IReadOnlyDictionary<string, string> xmlNode,
            float curLeft, float curRight, float curTop, float curBottom)
        {
            // Добавим угол поворота, если он есть
            if (xmlNode.ContainsKey("Angle") && float.Parse(xmlNode["Angle"], CultureInfo.InvariantCulture) != 0.0f)
            {
                // Вычислим угол поворота
                var angleOfRotation = float.Parse(xmlNode["Angle"], CultureInfo.InvariantCulture);
                var centerX = curLeft + (curRight - curLeft) / 2;
                var centerY = curTop + (curBottom - curTop) / 2;

                // Добавим угол поворота
                currentElement.Transform = new List<SvgTransform>
                {
                    new SvgRotateTransform()
                    {
                        Angle = new SvgAngle(angleOfRotation),
                        CenterX = new SvgLength(centerX),
                        CenterY = new SvgLength(centerY),
                    }
                };
            }
        }
    }
}