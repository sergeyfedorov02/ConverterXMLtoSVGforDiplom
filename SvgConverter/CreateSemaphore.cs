using System;
using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateSemaphore
    {
        // Функция для формирования SVG картинки для "StandardLibrary.Semaphore"
        public static SvgGroupElement CreateSvgImageSemaphore(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetSemaphoreBounds(out var bounds))
            {
                return null;
            }

            // Проверка наличия переменной "SemaphoreType" - количество индикаторов у светофора (0-5)
            if (!xmlNode.TryGetValue("SemaphoreType", out var semaphoreTypeText)) return null;
            var curSemaphoreType = int.Parse(semaphoreTypeText);
            if (curSemaphoreType < 0 || curSemaphoreType > 5) return null;

            // Проверка наличия переменной "LegType" - карликовый(0) светофор или мачтовый(1)
            if (!xmlNode.TryGetValue("LegType", out var legTypeText)) return null;
            var curLegType = int.Parse(legTypeText);
            if (curLegType != 0 && curLegType != 1) return null;

            // Проверка наличия переменной "LampShape" - тип индикатора (круг(0) или ромб(1))
            if (!xmlNode.TryGetValue("LampShape", out var lampShapeText)) return null;
            var curLampShape = int.Parse(lampShapeText);
            if (curLampShape != 0 && curLampShape != 1) return null;

            // Вычислим оставшиеся координаты
            const float curRadius = 8f;
            var curLeft = bounds.Left;
            var curTop = bounds.Top;
            var curSemaphoreHint = curSemaphoreType + "," + curLegType + "," + curLampShape;

            var curRight = 0f;
            var curBottom = 0f;

            switch (curLegType)
            {
                // Если тип светофора - карликовый
                case 0:
                    // Если меньше 4 индикаторов -> они расположены в линию
                    if (curSemaphoreType < 4)
                    {
                        curRight = curLeft +
                                   2 * xmlNode.GetLineWidth() +
                                   curRadius * 2 * curSemaphoreType;
                        curBottom = curTop + curRadius * 2;
                    }
                    // Если 4 или 5 индикаторов -> они расположены в прямоугольнике длиной 3 или 2 индикатора
                    else
                    {
                        curRight = curSemaphoreType == 4
                            ? curLeft + 2 * xmlNode.GetLineWidth() + curRadius * 2 * 2
                            : curLeft + 2 * xmlNode.GetLineWidth() + curRadius * 2 * 3;
                        curBottom = curTop + curRadius * 2 * 2;
                    }

                    break;

                // Если тип светофора - мачтовый
                case 1:
                    curRight = curLeft +
                               2 * xmlNode.GetLineWidth() +
                               curRadius * 2 * curSemaphoreType +
                               6;
                    curBottom = curTop + curRadius * 2;
                    break;
            }

            // Создадим группу для отрисовки текущей "StandardLibrary.Semaphore" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, curSemaphoreHint, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Светофор"
            var semaphoreGroup =
                CreateSemaphoreSvg(xmlNode, curTop, curRight, curBottom, curSemaphoreType, curLegType, curLampShape,
                    curRadius, objColor);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(semaphoreGroup, result, xmlNode, curLeft, curRight,
                curTop, curBottom, true);

            return result;
        }

        // Функция для получения элемента "Светофор" в формате Svg
        private static SvgGroupElement CreateSemaphoreSvg(IReadOnlyDictionary<string, string> xmlNode, float curTop,
            float curRight, float curBottom, int curSemaphoreType, int curLegType, int curLampShape, float curRadius,
            Color objColor)
        {
            // Вычислим значение ширины линий
            var curLineWidth = xmlNode.GetLineWidth();

            var result = new SvgGroupElement
            {
                // Цвет линий обводки и их ширина
                StrokeWidth = new SvgLength(curLineWidth),
                Stroke = new SvgPaint(objColor),

                // Цвет внутри индикаторов
                Fill = new SvgPaint(Color.Transparent),

                // Делаем его видимым
                FillOpacity = 1,

                // Кастомный атрибут -> количество индикаторов в светофоре
                CustomAttributes = new List<SvgCustomAttribute>
                {
                    new SvgCustomAttribute("data-lamp-count", curSemaphoreType.ToString())
                },

                Children =
                {
                    // Вертикальная линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curRight),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(curRight),
                        Y2 = new SvgLength(curBottom)
                    }
                }
            };

            // Если светофор = "Мачтовый" -> добавим горизонтальную линию
            if (curLegType == 1)
            {
                result.Children.Add
                (
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curRight - curRadius),
                        Y1 = new SvgLength(curTop + curRadius),
                        X2 = new SvgLength(curRight),
                        Y2 = new SvgLength(curTop + curRadius)
                    }
                );
            }

            // Создадим начальное значение класса для индикатора в зависимости от его типа (круг или ромб)
            var curClass = "mast-lamp0";

            // Пройдемся по всем индикаторам и добавим их в зависимости от типа (круг или ромб)
            for (var i = 0; i < curSemaphoreType; i++)
            {
                // Найдем значение класса дял текущего индикатора
                curClass = curClass.Remove(curClass.Length - 1, 1) + i;
                curClass = curLegType == 1 ? curClass.Replace("short", "mast") : curClass.Replace("mast", "short");

                // Если тип светофора = "Мачтовый" -> все индикаторы расположены в линию
                // Также если тип светофора = "Карликовый"
                //      + рассматриваем 0 или 1 индикатор
                //      + рассматриваем 2 индикатор, но общее количество индикаторов != 4
                if (curLegType == 1 || (curLegType == 0 && (i == 0 || i == 1)) ||
                    (curLegType == 0 && i == 2 && curSemaphoreType != 4))
                {
                    AddNewIndicatorElement(result,
                        curRight - curLineWidth - curRadius - 6f * curLegType - curRadius * 2 * i,
                        curBottom - curRadius,
                        curRadius,
                        curLampShape,
                        curClass);
                }
                // Другие случаи - индикаторы в верхней части прямоугольника в линию
                else
                {
                    // Если общее количество индикаторов == 4 -> первым в верхней линии будет i = 2, иначе i = 3
                    var helpValue = curSemaphoreType == 4 ? 2 : 3;
                    AddNewIndicatorElement(result,
                        curRight - curLineWidth - curRadius - curRadius * 2 * (i - helpValue),
                        curTop + curRadius,
                        curRadius,
                        curLampShape,
                        curClass);
                }
            }

            return result;
        }

        // Дополнительная функция для добавления нового элемента "Индикатор" к светофору в зависимости от его типа (круг или ромб)
        private static void AddNewIndicatorElement(SvgElement curResult, float centerX, float centerY,
            float radius, int curLampShape, string curClass)
        {
            switch (curLampShape)
            {
                // Если тип индикатора = "Круг"
                case 0:
                    curResult.Children.Add
                    (
                        new SvgCircleElement
                        {
                            CenterX = new SvgLength(centerX),
                            CenterY = new SvgLength(centerY),
                            Radius = new SvgLength(radius),
                            Class = curClass
                        }
                    );
                    break;
                // Если тип индикатора = "Ромб"
                case 1:
                    // Нарисуем квадрат и перевернем против часовой на 45 -> радиус = половина диагонали квадрата
                    var halfWidth = (float)Math.Sqrt(radius * radius / 2);
                    curResult.Children.Add
                    (
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
                            Class = curClass
                        }
                    );
                    break;
            }
        }
    }
}