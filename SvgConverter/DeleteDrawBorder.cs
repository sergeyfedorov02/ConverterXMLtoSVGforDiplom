using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class DeleteDrawBorder
    {
        public static void DelDrawBorder(this SvgGeometryElement currentElement, string aDrawBorder)
        {

            // Если пришло значение False (атрибут "DrawBorder" не задан или его значение False)
            if (aDrawBorder.Equals("False"))
            {
                // Границу отображать не будем
                currentElement.StrokeWidth = new SvgLength(0);  
            }
        }
    }
}