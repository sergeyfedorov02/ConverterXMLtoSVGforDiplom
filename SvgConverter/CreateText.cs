using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateText
    {
        public static bool IsShouldDrawLabel(string shouldDrawLabel)
        {
            return shouldDrawLabel != null && bool.TryParse(shouldDrawLabel, out var drawLabel) && drawLabel;
        }

        //Функция для добавления элемента SvgTextElement
        public static SvgTextElement AddSvgTextElement(IReadOnlyDictionary<string, string> xmlNode, string name)
        {
            // Проверим, есть ли заданное имя или же будем брать значение Default
            var curText = name ?? xmlNode["LabelDefaultText"];

            // Получим значения позиции
            var curX = float.Parse(xmlNode["LabelPosition"].Split(",")[0], CultureInfo.InvariantCulture);
            var curY = float.Parse(xmlNode["LabelPosition"].Split(",")[1], CultureInfo.InvariantCulture);

            var curFontSize = float.Parse(xmlNode["LabelFontSize"], CultureInfo.InvariantCulture);

            var text = new SvgTextElement
            {
                // Создаем сам текст
                Children =
                {
                    new SvgContentElement
                    {
                        Content = curText,
                    },
                },

                // Задаем расположение надписи по формуле согласно заданным координатам
                X = new List<SvgLength> { new SvgLength(curX) },
                Y = new List<SvgLength> { new SvgLength(curY + curFontSize * 1854f / 2048f) },

                // Задаем размер текста
                FontSize = new SvgLength(curFontSize),

                // Задаем стандартный цвет надписи (чёрный НЕ прозрачный цвет)
                Fill = new SvgPaint(Color.FromArgb(255, 0, 0, 0)),
                
                // Ширина обводки
                StrokeWidth = new SvgLength(0),
                
                // Расположение текста и куда будет расти при увеличении ("start")
                TextAnchor = new SvgTextAnchor(),
                
                // Делаем его видимым
                FillOpacity = 1
            };

            // Задаем цвет надписи согласно LabelBrush, если такой узел присутствует
            if (xmlNode.ContainsKey("LabelBrush"))
            {
                var labelBrushColor = GetColor.ConvertArgb(xmlNode["LabelBrush"]);
                text.Fill = new SvgPaint(labelBrushColor);
            }

            // Есть задан стиль текста, то добавим его
            if (xmlNode.ContainsKey("LabelFontStyle"))
            {
                if (xmlNode["LabelFontStyle"] == "Normal")
                {
                    text.FontStyle = SvgFontStyle.Normal;
                }

                if (xmlNode["LabelFontStyle"] == "Italic")
                {
                    text.FontStyle = SvgFontStyle.Italic;
                }
            }

            return text;
        }
    }
}