using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateRailCrossing
    {
        // Функция для формирования SVG картинки для "StandardLibrary.RailCrossing"
        public static SvgGroupElement CreateSvgImageRailCrossing(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetBounds(out var bounds))
            {
                return null;
            }

            // Проверка типа элемента переезд
            if (!xmlNode.TryGetValue("RailCrossingType", out var typeRailCrossing)) return null;
            
            // Если был получен неизвестный тип Переезда
            if (typeRailCrossing != "0" && typeRailCrossing != "1" && typeRailCrossing != "2") return null;

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curRight = bounds.Right;
            var curTop = bounds.Top;
            var curBottom = bounds.Bottom;

            // Создадим группу для отрисовки текущей "StandardLibrary.RailCrossing" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, typeRailCrossing, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим элемент "Переезд"
            var railCrossingGroup =
                CreateRailCrossingSvg(xmlNode, curLeft, curRight, curTop, curBottom, typeRailCrossing, objColor);

            // Добавим стандартные атрибуты
            DictionaryExtension.AddStandardEndResultAttributes(railCrossingGroup, result, xmlNode, curLeft, curRight,
                curTop,
                curBottom, true);

            // Задаем цвет линий
            result.Children[0].Stroke = new SvgPaint(objColor);

            return result;
        }

        // Функция для получения элемента "Переезд" в формате Svg
        private static SvgGroupElement CreateRailCrossingSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curRight, float curTop, float curBottom, string typeRailCrossing, Color objColor)
        {
            // Создадим общую группу для элемента "Переезд"
            var result = new SvgGroupElement();

            // Получим значение ширины линии переезда
            var railCrossingStrokeWidth = xmlNode.GetLineWidth();

            // Вычислим значение ширины линии шлагбаума
            var railBarrierWidth = (int)(railCrossingStrokeWidth - 2 * (int)(railCrossingStrokeWidth / 3));

            // Вычислим значение ширины и длины коробки крепления шлагбаума -> 1/6 ширины переезда
            var rectStandardValue = (curRight - curLeft) / 6;

            // Вычислим стандартное значение длины шлагбаума по Горизонтали -> 5/6 ширины переезда
            var railCrossingBarLineHorizontalLength = rectStandardValue * 5;

            // Создадим флаг, который будет сигнализировать о том, рисовать ли всю конструкцию шлагбаума или нет
            var railCrossingFlag = true;

            // Вычислим стандартное значение длины шлагбаума по Вертикали, учитывая длину переезда
            var railCrossingBarLineVerticalLength = railCrossingBarLineHorizontalLength;
            // Длины по вертикали не хватает для минимального отображения линии шлагбаума -> не рисуем вертикальные линии шлагбаума
            if (curBottom - curTop - railCrossingBarLineHorizontalLength < 0)
            {
                railCrossingBarLineVerticalLength = 0f;
                railCrossingFlag = false;
            }
            // Длины по вертикали не хватает, чтобы нарисовать линию шлагбаума стандартной длины -> вычисляем максимально возможное значение
            else if (railCrossingBarLineHorizontalLength > curBottom - curTop - railCrossingBarLineHorizontalLength)
            {
                railCrossingBarLineVerticalLength = curBottom - curTop - railCrossingBarLineHorizontalLength;
            }

            // Вычислим начальные точки для линий шлагбаума
            var topLine = new SvgPoint(new SvgLength(curLeft + (curRight - curLeft) / 6),
                new SvgLength(curTop + (curRight - curLeft) / 3 + rectStandardValue / 2));
            var bottomLine = new SvgPoint(new SvgLength(curRight - (curRight - curLeft) / 6),
                new SvgLength(curBottom - (curRight - curLeft) / 3 - rectStandardValue / 2));

            // Создадим стандартный переезд
            var mainRailCrossingGroup = new SvgGroupElement
            {
                // Зададим параметры для основной группы - переезд
                StrokeWidth = new SvgLength(railCrossingStrokeWidth),
                FillOpacity = 0,
                Class = "rail-crossing",

                // Нарисуем переезд - две ломанные линии
                Children =
                {
                    new SvgPolylineElement
                    {
                        Points = GetPointsForRailCrossing(curLeft, curRight, curTop, curBottom, true)
                    },

                    new SvgPolylineElement
                    {
                        Points = GetPointsForRailCrossing(curLeft, curRight, curTop, curBottom, false)
                    }
                }
            };

            // Добавим стандартный переезд в результат
            result.Children.Add(mainRailCrossingGroup);

            // Если переезд с шлагбаумом или еще с УЗП
            if (typeRailCrossing == "1" || typeRailCrossing == "2")
            {
                // Если присутствует шлагбаумом и хватает места для того, чтобы его нарисовать
                if (railCrossingFlag)
                {
                    // Создадим группу для двух линии - позиция открытого шлагбаума
                    var railCrossingBarLineOpenGroup = new SvgGroupElement
                    {
                        // Сделаем видимым -> переезд открыт
                        StrokeOpacity = 1,

                        // Добавим сами линии
                        Children =
                        {
                            // Левая верхняя
                            new SvgLineElement
                            {
                                Class = "rail-crossing-bar-open",
                                StrokeWidth = new SvgLength(railBarrierWidth),

                                // Верхняя точка
                                X1 = topLine.X,
                                Y1 = topLine.Y,

                                // Нижняя точка
                                X2 = topLine.X,
                                Y2 = new SvgLength(topLine.Y.Value + railCrossingBarLineVerticalLength)
                            },

                            // Правая нижняя
                            new SvgLineElement
                            {
                                Class = "rail-crossing-bar-open",
                                StrokeWidth = new SvgLength(railBarrierWidth),

                                // Нижняя точка
                                X1 = bottomLine.X,
                                Y1 = bottomLine.Y,

                                // Верхняя точка
                                X2 = bottomLine.X,
                                Y2 = new SvgLength(bottomLine.Y.Value - railCrossingBarLineVerticalLength)
                            }
                        }
                    };

                    // Добавим группу линий для открытого шлагбаума в результат
                    result.Children.Add(railCrossingBarLineOpenGroup);

                    // Создадим группу для двух линии - позиция закрытого шлагбаума
                    var railCrossingBarLineClosedGroup = new SvgGroupElement
                    {
                        // Сделаем НЕ видимым, так как изначально переезд открыт -> отображать закрытые линии не надо
                        StrokeOpacity = 0,

                        // Добавим сами линии
                        Children =
                        {
                            // Левая верхняя
                            new SvgLineElement
                            {
                                Class = "rail-crossing-bar-closed",
                                StrokeWidth = new SvgLength(railBarrierWidth),

                                // Верхняя точка
                                X1 = topLine.X,
                                Y1 = topLine.Y,

                                // Нижняя точка
                                X2 = new SvgLength(topLine.X.Value + railCrossingBarLineHorizontalLength),
                                Y2 = topLine.Y
                            },

                            // Правая нижняя
                            new SvgLineElement
                            {
                                Class = "rail-crossing-bar-closed",
                                StrokeWidth = new SvgLength(railBarrierWidth),

                                // Нижняя точка
                                X1 = bottomLine.X,
                                Y1 = bottomLine.Y,

                                // Верхняя точка
                                X2 = new SvgLength(bottomLine.X.Value - railCrossingBarLineHorizontalLength),
                                Y2 = bottomLine.Y
                            }
                        }
                    };

                    // Добавим группу линий для закрытого шлагбаума в результат
                    result.Children.Add(railCrossingBarLineClosedGroup);

                    // Создадим группу для двух прямоугольника - крепление линий шлагбаума
                    var railCrossingBarRectBaseGroup = new SvgGroupElement
                    {
                        // Сделаем цвет заполнения и отобразим его
                        Fill = new SvgPaint(objColor),
                        FillOpacity = 1,

                        // Добавим сами прямоугольники
                        Children =
                        {
                            // Левый верхний
                            new SvgRectElement
                            {
                                Class = "rail-crossing-bar-base",
                                StrokeWidth = new SvgLength(railBarrierWidth),

                                X = new SvgLength(curLeft + rectStandardValue / 2),
                                Y = new SvgLength(curTop + rectStandardValue * 2),
                                Width = new SvgLength(rectStandardValue),
                                Height = new SvgLength(rectStandardValue)
                            },

                            // Правый нижний
                            new SvgRectElement
                            {
                                Class = "rail-crossing-bar-base",
                                StrokeWidth = new SvgLength(railBarrierWidth),

                                X = new SvgLength(curRight - 3 * rectStandardValue / 2),
                                Y = new SvgLength(curBottom - rectStandardValue * 3),
                                Width = new SvgLength(rectStandardValue),
                                Height = new SvgLength(rectStandardValue)
                            }
                        }
                    };

                    // Добавим группу прямоугольников крепления линий шлагбаума в результат
                    result.Children.Add(railCrossingBarRectBaseGroup);
                }

                // Если помимо шлагбаума есть УЗП
                if (typeRailCrossing == "2")
                {
                    // Создадим группу для УЗП - две линии
                    var railCrossingUzpGroup = new SvgGroupElement
                    {
                        // Сделаем видимым
                        StrokeOpacity = 1,

                        // Добавим сами линии
                        Children =
                        {
                            // Верхняя
                            new SvgLineElement
                            {
                                Class = "rail-crossing-uzp",
                                StrokeWidth = new SvgLength(railBarrierWidth),

                                // Левая точка
                                X1 = new SvgLength(curLeft + rectStandardValue * 2),
                                Y1 = new SvgLength(curTop + rectStandardValue * 2),

                                // Правая точка
                                X2 = new SvgLength(curRight - rectStandardValue * 2),
                                Y2 = new SvgLength(curTop + rectStandardValue * 2)
                            },

                            // Нижняя
                            new SvgLineElement
                            {
                                Class = "rail-crossing-uzp",
                                StrokeWidth = new SvgLength(railBarrierWidth),

                                // Левая точка
                                X1 = new SvgLength(curLeft + rectStandardValue * 2),
                                Y1 = new SvgLength(curBottom - rectStandardValue * 2),

                                // Правая точка
                                X2 = new SvgLength(curRight - rectStandardValue * 2),
                                Y2 = new SvgLength(curBottom - rectStandardValue * 2)
                            }
                        }
                    };

                    // Добавим группу линий для закрытого шлагбаума в результат
                    result.Children.Add(railCrossingUzpGroup);
                }
            }

            return result;
        }

        // Дополнительная функция для вычисления координат основной части переезда
        private static List<SvgPoint> GetPointsForRailCrossing(float curLeft, float curRight, float curTop,
            float curBottom, bool position)
        {
            // Вычислим стандартное значение для вычисления координат точек
            var pointsPositionValue = (curRight - curLeft) / 3;

            // Если запрашиваем координаты для левой части
            if (position)
            {
                return new List<SvgPoint>
                {
                    new SvgPoint(new SvgLength(curLeft), new SvgLength(curTop)),
                    new SvgPoint(new SvgLength(curLeft + pointsPositionValue),
                        new SvgLength(curTop + pointsPositionValue)),
                    new SvgPoint(new SvgLength(curLeft + pointsPositionValue),
                        new SvgLength(curBottom - pointsPositionValue)),
                    new SvgPoint(new SvgLength(curLeft), new SvgLength(curBottom))
                };
            }

            // Для правой части
            return new List<SvgPoint>
            {
                new SvgPoint(new SvgLength(curRight), new SvgLength(curTop)),
                new SvgPoint(new SvgLength(curRight - pointsPositionValue),
                    new SvgLength(curTop + pointsPositionValue)),
                new SvgPoint(new SvgLength(curRight - pointsPositionValue),
                    new SvgLength(curBottom - pointsPositionValue)),
                new SvgPoint(new SvgLength(curRight), new SvgLength(curBottom)),
            };
        }
    }
}