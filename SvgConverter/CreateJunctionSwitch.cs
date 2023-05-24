using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateJunctionSwitch
    {
        // Функция для формирования SVG картинки для "StandardLibrary.JunctionSwitch" или "JunctionSwitchWithoutNoControl"
        public static SvgGroupElement CreateSvgImageJunctionSwitch(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetJunctionSwitchBounds(out var bounds))
            {
                return null;
            }

            // Вычислим все координаты
            var curLeft = bounds["curLeft"];
            var curTop = bounds["curTop"];
            var curLampWidth = bounds["curLampWidth"];
            var curLampHeight = bounds["curLampHeight"];
            var curLampSpace = bounds["curLampSpace"];
            var curRowSpace = bounds["curRowSpace"];

            // Создадим группу для отрисовки текущей "StandardLibrary.JunctionSwitch" или "JunctionSwitchWithoutNoControl" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Стрелочный коммутатор"
            var junctionSwitch = CreateJunctionSwitchSvg(xmlNode, curLeft, curTop, curLampWidth, curLampHeight,
                curLampSpace, curRowSpace, objColor);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(junctionSwitch, result, xmlNode, curLeft, curLeft,
                curTop, curTop, false);

            return result;
        }

        // Функция для получения элемента "Стрелочный коммутатор" в формате Svg
        private static SvgGroupElement CreateJunctionSwitchSvg(IReadOnlyDictionary<string, string> xmlNode,
            float curLeft, float curTop, float curLampWidth, float curLampHeight, float curLampSpace, float curRowSpace,
            Color objColor)
        {
            // Получим значение ширины  линии
            var strokeWidth = xmlNode.GetLineWidth();

            var result = new SvgGroupElement
            {
                Fill = new SvgPaint(Color.DarkGray),
                FillOpacity = 1,

                Stroke = new SvgPaint(objColor),
                StrokeWidth = new SvgLength(strokeWidth)
            };

            // Если рассматриваем элемент "StandardLibrary.JunctionSwitch" -> три прямоугольника
            if (curRowSpace >= 0)
            {
                result.Children.Add
                (
                    // Левый 
                    new SvgRectElement
                    {
                        X = new SvgLength(curLeft),
                        Y = new SvgLength(curTop + curLampHeight + curRowSpace),
                        Width = new SvgLength(curLampWidth),
                        Height = new SvgLength(curLampHeight)
                    }
                );

                result.Children.Add
                (
                    // Центральный
                    new SvgRectElement
                    {
                        X = new SvgLength(curLeft + curLampWidth / 2 + curLampSpace / 2),
                        Y = new SvgLength(curTop),
                        Width = new SvgLength(curLampWidth),
                        Height = new SvgLength(curLampHeight)
                    }
                );

                result.Children.Add
                (
                    // Правый
                    new SvgRectElement
                    {
                        X = new SvgLength(curLeft + curLampWidth + curLampSpace),
                        Y = new SvgLength(curTop + curLampHeight + curRowSpace),
                        Width = new SvgLength(curLampWidth),
                        Height = new SvgLength(curLampHeight)
                    }
                );

                // Если отображаем элемент "УКСПС" -> меняем цвет внутри двух прямоугольников
                if (xmlNode["ToolId"].Equals("StandardLibrary.Uksps"))
                {
                    result.Children[1].Fill = new SvgPaint(Color.Red);
                    result.Children[2].Fill = new SvgPaint(Color.Red);
                }
            }
            // Иначе рассматриваем элемент "StandardLibrary.JunctionSwitchWithoutNoControl" -> два прямоугольника
            else
            {
                result.Children.Add
                (
                    // Левый 
                    new SvgRectElement
                    {
                        X = new SvgLength(curLeft),
                        Y = new SvgLength(curTop),
                        Width = new SvgLength(curLampWidth),
                        Height = new SvgLength(curLampHeight)
                    }
                );

                result.Children.Add
                (
                    // Правый
                    new SvgRectElement
                    {
                        X = new SvgLength(curLeft + curLampWidth + curLampSpace),
                        Y = new SvgLength(curTop),
                        Width = new SvgLength(curLampWidth),
                        Height = new SvgLength(curLampHeight)
                    }
                );
            }

            return result;
        }
    }
}