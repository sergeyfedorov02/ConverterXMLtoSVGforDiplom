using System;
using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateFenceSemaphore
    {
        // Функция для формирования SVG картинки для "StandardLibrary.FenceSemaphore"
        public static SvgGroupElement CreateSvgImageFenceSemaphore(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetSemaphoreBounds(out var bounds))
            {
                return null;
            }

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curTop = bounds.Top;
            const float curRadius = 8f;
            var curRight = curLeft + 2 * xmlNode.GetLineWidth() + curRadius * 2 + 6;
            var curBottom = curTop + curRadius * 2;

            // Создадим группу для отрисовки текущей "StandardLibrary.FenceSemaphore" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Заградительный светофор"
            var fenceSemaphoreGroup =
                CreateFenceSemaphoreSvg(xmlNode, curLeft, curTop, curRight, curBottom, curRadius, objColor);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(fenceSemaphoreGroup, result, xmlNode, curLeft, curRight,
                curTop, curBottom, true);

            return result;
        }

        // Функция для получения элемента "Заградительный светофор" в формате Svg
        private static SvgGroupElement CreateFenceSemaphoreSvg(IReadOnlyDictionary<string, string> xmlNode,
            float curLeft, float curTop, float curRight, float curBottom, float curRadius, Color objColor)
        {
            // Вычислим значение ширины линий
            var curLineWidth = xmlNode.GetLineWidth();

            // Вычислим половину ширины квадрата, чтобы при повороте получить ромб
            var halfWidth = (float)Math.Sqrt(curRadius * curRadius / 2);

            // Вычислим координаты центра квадрата
            var centerX = curLeft + curLineWidth + curRadius;
            var centerY = curBottom - curRadius;

            return new SvgGroupElement
            {
                // Цвет линий обводки и их ширина
                StrokeWidth = new SvgLength(curLineWidth),
                Stroke = new SvgPaint(objColor),

                // Цвет внутри индикатора
                Fill = new SvgPaint(Color.Transparent),

                Children =
                {
                    // Вертикальная линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curRight),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(curRight),
                        Y2 = new SvgLength(curBottom)
                    },

                    // Горизонтальная линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curRight - curRadius),
                        Y1 = new SvgLength(curTop + curRadius),
                        X2 = new SvgLength(curRight),
                        Y2 = new SvgLength(curTop + curRadius)
                    },

                    // Индикатор - ромб
                    new SvgRectElement
                    {
                        X = new SvgLength(centerX - halfWidth),
                        Y = new SvgLength(centerY - halfWidth),
                        Width = new SvgLength(halfWidth * 2),
                        Height = new SvgLength(halfWidth * 2),

                        // Перевернем квадрат относительно центра против часовой на 45
                        Transform = new List<SvgTransform>
                        {
                            new SvgRotateTransform
                            {
                                Angle = new SvgAngle(-45f),
                                CenterX = new SvgLength(centerX),
                                CenterY = new SvgLength(centerY)
                            }
                        },
                        Class = "fence-semaphore"
                    }
                }
            };
        }
    }
}