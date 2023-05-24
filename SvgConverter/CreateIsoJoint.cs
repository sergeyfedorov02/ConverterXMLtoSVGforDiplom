using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateIsoJoint
    {
        // Функция для формирования SVG картинки для "StandardLibrary.IsoJoint"
        public static SvgGroupElement CreateSvgImageIsoJoint(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetIsoJointBounds(out var bounds))
            {
                return null;
            }

            // Проверка типа элемента изостык
            if (!xmlNode.TryGetValue("Type", out var typeIsoJoint)) return null;

            // Если тип "Габаритный изостык" -> ничего не рисуем
            if (xmlNode["Type"] == "Overall") return null;

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curRight = bounds.Right;
            var curTop = bounds.Top;
            var curBottom = bounds.Bottom;

            // Создадим группу для отрисовки текущей "StandardLibrary.IsoJoint" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Получим элемент "Изостык"
            var isoJoint = CreateIsoJointSvg(xmlNode, curLeft, curRight, curTop, curBottom, typeIsoJoint);

            // Если был указан неверный тип
            if (isoJoint == null) return null;

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(isoJoint, result, xmlNode, curLeft, curRight, curTop,
                curBottom, true);

            return result;
        }

        private static SvgGeometryElement CreateIsoJointSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curRight, float curTop, float curBottom, string typeIsoJoint)
        {
            // Получим элемент "Изостык"
            return typeIsoJoint switch
            {
                // Не габаритный изостык
                "NoOverall" => CreateNoOverallIsoJointSvg(xmlNode, curLeft, curRight, curTop, curBottom),

                // Ячейка изостык
                "Cell" => CreateCellIsoJointSvg(xmlNode, curLeft, curRight, curTop, curBottom),

                _ => null
            };
        }

        // Функция для получения элемента "Не габаритный изостык" в формате Svg
        private static SvgCircleElement CreateNoOverallIsoJointSvg(IReadOnlyDictionary<string, string> xmlNode,
            float curLeft, float curRight, float curTop, float curBottom)
        {
            // Вычислим координаты центра и радиуса
            var curCentreX = curLeft + (curRight - curLeft) / 2;
            var curCentreY = curTop + (curBottom - curTop) / 2;
            const float radius = 8f;

            // Создадим элемент
            return new SvgCircleElement
            {
                CenterX = new SvgLength(curCentreX),
                CenterY = new SvgLength(curCentreY),
                Radius = new SvgLength(radius),

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),

                // Задаем цвет внутри круга полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Убираем отображение
                FillOpacity = 0,

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(Color.DarkGray)
            };
        }

        // Функция для получения элемента "Ячейка изостык" в формате Svg
        private static SvgRectElement CreateCellIsoJointSvg(IReadOnlyDictionary<string, string> xmlNode,
            float curLeft, float curRight, float curTop, float curBottom)
        {
            // Вычислим координаты центра
            var curCentreX = curLeft + (curRight - curLeft) / 2;
            var curCentreY = curTop + (curBottom - curTop) / 2;

            // Получим значение ширины линий
            var strokeWidthValue = (int)(xmlNode.GetLineWidth() / 2);

            // Создадим элемент
            return new SvgRectElement()
            {
                Width = new SvgLength(2),
                Height = new SvgLength(2),

                // Задаем координаты левого верхнего угла
                X = new SvgLength(curCentreX - 1),
                Y = new SvgLength(curCentreY - 1),

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(strokeWidthValue),

                // Задаем цвет внутри круга полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Убираем отображение
                FillOpacity = 0,

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(Color.DarkGray)
            };
        }
    }
}