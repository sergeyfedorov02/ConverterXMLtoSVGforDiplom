using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class DeleteDrawBorder
    {
        public static void DelDrawBorder(this SvgGeometryElement currentElement, IReadOnlyDictionary<string, string> xmlNode)
        {
            // Если задан параметр, что границу отображать не надо
            if (xmlNode.ContainsKey("DrawBorder") && xmlNode["DrawBorder"] == "False")
            {
                // Границу отображать не будем
                currentElement.Stroke = new SvgPaint(Color.Transparent);
            }
        }
    }
}