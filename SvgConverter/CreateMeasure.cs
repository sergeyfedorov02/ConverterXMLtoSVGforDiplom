using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateMeasure
    {
        private static readonly Regex TuplesRegEx = new Regex("^\\[\\s*(\\d+),\\s*(\\d+)\\]", RegexOptions.Compiled);

        // Функция для формирования SVG картинки для "StandardLibrary.Measure"
        public static SvgGroupElement CreateSvgImageMeasure(IReadOnlyDictionary<string, string> xmlNode, ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetMeasureBounds(out var bounds))
            {
                return null;
            }

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curTop = bounds.Top;

            // Создадим группу для отрисовки текущей "StandardLibrary.Measure" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Получим элемент "Измерение"
            var measure = CreateMeasureSvg(xmlNode, curLeft, curTop);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(measure, result, xmlNode, curLeft, 0f,
                curTop, 0f, false);

            return result;
        }

        // Функция для получения элемента "Измерение" в формате Svg
        private static SvgTextElement CreateMeasureSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curTop)
        {
            var curFontSize = float.Parse(xmlNode["FontSize"], CultureInfo.InvariantCulture);

            var text = new SvgTextElement
            {
                // Создаем сам текст
                Children =
                {
                    new SvgContentElement
                    {
                        Content = "",
                    },
                },

                // Задаем расположение надписи по формуле согласно заданным координатам
                X = new List<SvgLength> { new SvgLength(curLeft) },
                Y = new List<SvgLength> { new SvgLength(curTop + curFontSize * 1854f / 2048f) },

                // Задаем размер текста
                FontSize = new SvgLength(curFontSize),

                // Задаем стандартный цвет надписи (чёрный НЕ прозрачный цвет)
                Fill = new SvgPaint(Color.FromArgb(255, 0, 0, 0)),

                // Расположение текста и куда будет расти при увеличении ("start")
                TextAnchor = new SvgTextAnchor(),

                // Делаем его видимым
                FillOpacity = 1,

                // Добавим список кастомных атрибутов
                CustomAttributes = new List<SvgCustomAttribute>()
            };

            // Задаем цвет надписи согласно TextColor, если такой узел присутствует
            if (xmlNode.ContainsKey("TextColor"))
            {
                var textColor = GetColor.ConvertArgb(xmlNode["TextColor"]);
                text.Fill = new SvgPaint(textColor);
            }

            // Есть задан стиль текста, то добавим его
            if (xmlNode.ContainsKey("FontStyle"))
            {
                if (xmlNode["FontStyle"] == "Italic")
                {
                    text.FontStyle = SvgFontStyle.Italic;
                }
            }

            // Добавим кастомный атрибут отображения нулей после точки или нет
            // data-measure-showzerosafterpoint="true/false"
            text.CustomAttributes.Add
            (
                new SvgCustomAttribute("data-measure-showzerosafterpoint",
                    xmlNode["ShowZerosAfterDecimalPoint"].ToLower())
            );

            // Добавим угол поворота, если он есть
            if (xmlNode.ContainsKey("Angle") && float.Parse(xmlNode["Angle"], CultureInfo.InvariantCulture) != 0.0f)
            {
                // Вычислим угол поворота
                var angleOfRotation = float.Parse(xmlNode["Angle"], CultureInfo.InvariantCulture);
                var centerX = curLeft;
                var centerY = curTop;

                // Добавим угол поворота
                text.Transform = new List<SvgTransform>
                {
                    new SvgRotateTransform()
                    {
                        Angle = new SvgAngle(angleOfRotation),
                        CenterX = new SvgLength(centerX),
                        CenterY = new SvgLength(centerY),
                    }
                };
            }

            // Добавим "data-measure-objectid" и "data-measure-id", если они заданы (не равны 0)
            var attachment = xmlNode["MeasureId"];
            if (!string.IsNullOrEmpty(attachment))
            {
                var m = TuplesRegEx.Match(attachment);

                if (m.Success && m.Groups.Count == 3)
                {
                    if (long.TryParse(m.Groups[1].Value, out var objectId) && objectId > 0 &&
                        int.TryParse(m.Groups[2].Value, out var mId))
                    {
                        text.CustomAttributes.Add
                        (
                            new SvgCustomAttribute("data-measure-objectid",
                                objectId.ToString(CultureInfo.InvariantCulture))
                        );

                        text.CustomAttributes.Add
                        (
                            new SvgCustomAttribute("data-measure-id",
                                mId.ToString(CultureInfo.InvariantCulture))
                        );
                    }
                }
            }

            return text;
        }
    }
}