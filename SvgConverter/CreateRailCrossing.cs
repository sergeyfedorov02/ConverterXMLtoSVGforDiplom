using System.Collections.Generic;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateRailCrossing
    {
        // Функция для формирования SVG картинки для "StandardLibrary.RailCrossing"
        public static SvgGroupElement CreateSvgImageRailCrossing(IReadOnlyDictionary<string, string> xmlNode)
        {
            // Проверка координат 
            if (!xmlNode.TryGetBounds(out var bounds))
            {
                return null;
            }

            // Проверка типа элемента переезд
            if (!xmlNode.TryGetValue("RailCrossingType", out var typeRailCrossing)) return null;

            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curRight = bounds.Right;
            var curTop = bounds.Top;
            var curBottom = bounds.Bottom;

            // Создадим группу для отрисовки текущей "StandardLibrary.RailCrossing" со стандартными атрибутами
            var result = xmlNode.AddStandardResultAttributes(null, null, typeRailCrossing);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Добавление Стиля
            // TODO() - добавить параметр указания стиля (Stroke и Fill тогда мб следует убрать)

            // Получим элемент "Переезд"
            var railCrossingGroup =
                CreateRailCrossingSvg(xmlNode, curLeft, curRight, curTop, curBottom, typeRailCrossing);

            // Добавим стандартные атрибуты
            // Добавим угол поворота, если он есть
            railCrossingGroup.AddAngle(xmlNode, curLeft, curRight, curTop, curBottom);

            // Задаем цвет линий
            railCrossingGroup.Stroke = new SvgPaint(objColor);

            // Добавим полученный элемент в result
            result.Children.Add(railCrossingGroup);

            // Если надо отображать текст, то добавим его в result
            if (CreateText.IsShouldDrawLabel(xmlNode["ShouldDrawLabel"]))
            {
                // Добавляем созданный текст
                result.Children.Add(CreateText.AddSvgTextElement(xmlNode, xmlNode["Label"]));
            }

            return result;
        }

        // Функция для получения элемента "Переезд" в формате Svg
        private static SvgGroupElement CreateRailCrossingSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curRight, float curTop, float curBottom, string typeRailCrossing)
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

            // Вычислим стандартное значение длины шлагбаума по Вертикали, учитывая длину переезда
            var railCrossingBarLineVerticalLength = railCrossingBarLineHorizontalLength;
            // Длины по вертикали не хватает для минимального отображения линии шлагбаума -> не рисуем вертикальные линии шлагбаума
            if (curBottom - curTop - railCrossingBarLineHorizontalLength < 0)
            {
                railCrossingBarLineVerticalLength = 0f; // TODO - что тут делать?
            }
            // Длины по вертикали не хватает, чтобы нарисовать линию шлагбаума стандартной длины -> вычисляем максимально возможное значение
            else if (railCrossingBarLineHorizontalLength > curBottom - curTop - railCrossingBarLineHorizontalLength)
            {
                railCrossingBarLineVerticalLength = railCrossingBarLineHorizontalLength - curBottom + curTop;
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
                // Если присутствует шлагбаумом
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
                    //TODO
                    //TODO - Если не хватает длины???
                };

                // Добавим группу прямоугольников крепления линий шлагбаума в результат
                result.Children.Add(railCrossingBarRectBaseGroup);

                // Если помимо шлагбаума есть УЗП
                if (typeRailCrossing == "2")
                {
                    //TODO
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