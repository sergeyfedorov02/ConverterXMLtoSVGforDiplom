using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateLamp
    {
        // Сет для хранения всех элементов с параметром class = "fill-indicator"
        private static readonly HashSet<string> FillIndicators = new HashSet<string>
        {
            "Rectangle",
            "RoundRectangle",
            "ArrowLeftRight",
            "ArrowLeft",
            "ArrowRight",
            "Circle",
            "Triangle",
            "KeyBarrel"
        };

        // Сет для хранения всех элементов с параметром class = "line-indicator"
        private static readonly HashSet<string> LineIndicators = new HashSet<string>
        {
            "GroundControl",
            "RailEndCoupling",
            "FeedEndCoupling",
            "RailEndBox",
            "FeedEndBox"
        };

        // Функция для формирования SVG картинки для "StandardLibrary.Lamp"
        public static SvgGroupElement CreateSvgImageLamp(IReadOnlyDictionary<string, string> xmlNode)
        {
            // Проверка координат 
            if (!xmlNode.TryGetBounds(out var bounds))
            {
                return null;
            }
            
            // Вычислим все координаты
            var curLeft = bounds.Left;
            var curRight = bounds.Right;
            var curTop = bounds.Top;
            var curBottom = bounds.Bottom;

            // Создадим группу для отрисовки текущей "StandardLibrary.Lamp"
            var result = new SvgGroupElement
            {
                CustomAttributes = new List<SvgCustomAttribute>
                {
                    // Добавление кастомного атрибута data-object-hint = "Shape=..,DrawBorder=..." 
                    new SvgCustomAttribute("data-object-hint",
                        "Shape=" + xmlNode["Shape"] + ",DrawBorder=" + xmlNode["DrawBorder"]),
                    //TODO - drawBorder == null ?

                    // Добавление кастомного атрибута data-object-type = "StandardLibrary.Lamp" (имя этого атрибута - Лампа)
                    new SvgCustomAttribute("data-object-type", xmlNode["ToolId"]),

                    // Добавление кастомного атрибута data-state = "-2" к создаваемой группе, чтобы потом была подсветка, если придет значение
                    new SvgCustomAttribute("data-state", "-2")
                }
            };

            // Если указан ClientId
            if (xmlNode.TryGetValue("ClientId", out var objectId) && objectId != "0")
            {
                // Обновление data-state
                var dataStateAttribute =
                    result.CustomAttributes.Find(attribute => attribute.AttributeName == "data-state");
                dataStateAttribute.Value = "-1";
                // Добавление object-id
                result.CustomAttributes.Add(new SvgCustomAttribute("data-object-id", objectId));
            }

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Добавление Стиля
            // TODO() - добавить параметр указания стиля

            // Если текущая лампа относится к классу "fill-indicator"
            var aShape = xmlNode.GetValueOrDefault("Shape", "Rectangle");

            if (FillIndicators.Contains(aShape))
            {
                // Выберем тот или иной метод для рисования
                switch (aShape)
                {
                    case "Rectangle":
                    case "RoundRectangle":

                        // Получим прямоугольник
                        var rectangle = CreateRectangleSvg(xmlNode, curLeft, curRight, curTop, curBottom, objColor);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesFillIndicator(rectangle, result, xmlNode, curLeft, curRight, curTop,
                            curBottom);
                        break;

                    case "ArrowLeftRight":
                    case "ArrowLeft":
                    case "ArrowRight":
                        // Создадим List для точек и вычислим их
                        var listPoints = GetPointsList(aShape, curLeft, curRight, curTop, curBottom).ToList();

                        // Получим стрелку
                        var arrow = CreateLeftRightArrowSvg(listPoints, xmlNode.GetLineWidth(), objColor);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesFillIndicator(arrow, result, xmlNode, curLeft, curRight, curTop,
                            curBottom);

                        break;

                    case "Circle":
                        // Получим круг
                        var circle = CreateCircleSvg(xmlNode, curLeft, curRight, curTop, curBottom, objColor);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesFillIndicator(circle, result, xmlNode, curLeft, curRight, curTop,
                            curBottom);

                        break;
                    case "Triangle":
                        // Получим треугольник
                        var triangle = CreateTriangleSvg(xmlNode, curLeft, curRight, curTop, curBottom, objColor);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesFillIndicator(triangle, result, xmlNode, curLeft, curRight, curTop,
                            curBottom);

                        break;
                    case "KeyBarrel":
                        break;
                }
            }
            // Иначе к классу "line-indicator"
            else if (LineIndicators.Contains(xmlNode["Shape"]))
            {
                // Выберем тот или иной метод для рисования
                switch (xmlNode["Shape"])
                {
                    case "GroundControl":
                        break;
                    case "RailEndCoupling":
                        break;
                    case "FeedEndCoupling":
                        break;
                    case "RailEndBox":
                        break;
                    case "FeedEndBox":
                        break;
                }
            }

            // Контроль заземления - chart_687
            //TODO
            /*if (xmlNode["Shape"] == "GroundControl")
            {
                // Создадим группу для контроля заземления (поворот без этого не осуществить)
                var groundControlGroup = new SvgGroupElement();

                // Вычислим координаты для треугольника
                var leftAngle = new SvgPoint(new SvgLength(curLeft), new SvgLength(curBottom));
                var topAngle = new SvgPoint(new SvgLength(curLeft + (curRight - curLeft) / 2), new SvgLength(curTop));
                var rightAngle = new SvgPoint(new SvgLength(curRight), new SvgLength(curBottom));

                // Рисуем контроль заземления
                var groundControl = new SvgPolylineElement()
                {
                    
                    // Задаем ширину обводки
                    StrokeWidth = new SvgLength(float.Parse(xmlNode["LineWidth"], CultureInfo.InvariantCulture)),

                    // Задаем цвет внутри стрелки влево полностью прозрачным
                    Fill = new SvgPaint(Color.Transparent),

                    // Задаем цвет обводки, который берется с ObjectColor
                    //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                    Stroke = new SvgPaint(objColor)
                };
                
                // Добавим стандартные атрибуты в Xml файл
                AddStandardAttributes(groundControl, groundControlGroup, result, xmlNode, shouldDrawLabel, name, curLeft, curRight,
                    curTop, curBottom);
                
            }*/

            // Релейный конец РЦ (коробка) - chart_685 (крест в прямоугольнике)
            //TODO()

            // Релейный конец РЦ (муфта) (крест в круге)
            //TODO()

            // Питающий конец РЦ (коробка) - chart_685 (круг в прямоугольнике)
            //TODO()

            // Питающий конец РЦ (муфта) (крест в круге)
            //TODO()

            // Ключ Жезл - chart_64 
            //TODO()

            return result;

            // Рисуем элемент Линии
            /*float length = (float)cur_length;
            var line = new SvgLineElement()
            {
                // Задаем координаты
                X1 = new SvgLength(5.0f),
                Y1 = new SvgLength(5.0f),
                X2 = new SvgLength(5.0f + length),
                Y2 = new SvgLength(5.0f),
                // Настраиваем отображение (без этого ничего не будет видно - бесцветное)
                Stroke = new SvgPaint(Color.Brown),
                // Настраиваем ширину
                StrokeWidth = new SvgLength(5.0f)

            };*/
        }

        // Функция для получения Прямоугольника в формате Svg
        private static SvgRectElement CreateRectangleSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curRight, float curTop, float curBottom, Color objColor)
        {
            // Вычислим координаты для прямоугольника
            var curWidth = curRight - curLeft;
            var curHeight = curBottom - curTop;
            var curX = curLeft;
            var curY = curTop;

            // Создадим стандартный прямоугольник
            var rectangle = new SvgRectElement()
            {
                Width = new SvgLength(curWidth),
                Height = new SvgLength(curHeight),

                // Задаем координаты левого верхнего угла
                X = new SvgLength(curX),
                Y = new SvgLength(curY),

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),

                // Задаем цвет внутри прямоугольника полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(objColor)
            };

            // Если задан RoundRectangle, то установим скругление углов
            if (xmlNode["Shape"] == "RoundRectangle")
            {
                var radius = curWidth / 4;
                rectangle.RadiusX = new SvgLength(radius);
                rectangle.RadiusX = new SvgLength(radius);
            }

            return rectangle;
        }

        // Функция для получения Круга в формате Svg
        private static SvgCircleElement CreateCircleSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curRight, float curTop, float curBottom, Color objColor)
        {
            // Вычислим координаты для круга
            var curCentreX = curLeft + (curRight - curLeft) / 2;
            var curCentreY = curTop + (curBottom - curTop) / 2;
            var radius = Math.Min((curRight - curLeft) / 2, (curBottom - curTop) / 2);

            // Создадим круг
            var circle = new SvgCircleElement
            {
                CenterX = new SvgLength(curCentreX),
                CenterY = new SvgLength(curCentreY),
                Radius = new SvgLength(radius),

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),

                // Задаем цвет внутри круга полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(objColor)
            };

            return circle;
        }

        // Функция для получения Треугольника в формате Svg
        private static SvgPolygonElement CreateTriangleSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curRight, float curTop, float curBottom, Color objColor)
        {
            // Вычислим координаты для треугольника
            var leftAngle = new SvgPoint(new SvgLength(curLeft), new SvgLength(curBottom));
            var topAngle = new SvgPoint(new SvgLength(curLeft + (curRight - curLeft) / 2), new SvgLength(curTop));
            var rightAngle = new SvgPoint(new SvgLength(curRight), new SvgLength(curBottom));

            // Создадим полигон из точек
            var allPoints = new List<SvgPoint>()
            {
                leftAngle,
                topAngle,
                rightAngle
            };

            // Создадим треугольник
            var triangle = new SvgPolygonElement
            {
                // Добавим полигон из точек
                Points = allPoints,

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(xmlNode.GetLineWidth()),

                // Задаем цвет внутри стрелки влево полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(objColor)
            };

            return triangle;
        }

        // Функция для получения Стрелки в формате Svg
        private static SvgPolygonElement CreateLeftRightArrowSvg(IEnumerable<SvgPoint> points, float width,
            Color objColor)
        {
            // Создадим полигон из точек
            var allPoints = points.ToList();

            // Рисуем стрелку
            return new SvgPolygonElement
            {
                // Добавим полигон из точек
                Points = allPoints,

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(width),

                // Задаем цвет внутри стрелки влево полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(objColor)
            };
        }

        // Функция для добавления стандартных атрибутов к элементу (граница, текущая группа, угол поворота, добавление в result, текст)
        private static void AddStandardAttributesFillIndicator(SvgGeometryElement curElement, SvgElement curResult,
            IReadOnlyDictionary<string, string> xmlNode, float curLeft, float curRight, float curTop, float curBottom)
        {
            // Добавим указатель класса "fill-indicator"
            curElement.Class = "fill-indicator";

            // Удалим границу, если задан есть соответствующий параметр со значением False
            curElement.DelDrawBorder(xmlNode);

            // Добавим угол поворота, если он есть
            curElement.AddAngles(xmlNode, curLeft, curRight, curTop, curBottom);

            // Добавим полученный элемент в result
            curResult.Children.Add(curElement);

            // Если надо отображать текст, то добавим его в result
            if (CreateText.IsShouldDrawLabel(xmlNode["ShouldDrawLabel"]))
            {
                // Добавляем созданный текст
                curResult.Children.Add(CreateText.AddSvgTextElement(xmlNode, xmlNode["Label"]));
            }
        }

        /// <summary>
        /// Дополнительная функция для создания списка точек для той или иной стрелки
        /// </summary>
        /// <param name="curShape">Форма стрелки</param>
        /// <param name="curLeft">Координата левого края</param>
        /// <param name="curRight">Координата правого края</param>
        /// <param name="curTop">Координата верхнего края</param>
        /// <param name="curBottom">Координата нижнего края</param>
        /// <returns>Список точек для отрисовки стрелки</returns>
        private static IEnumerable<SvgPoint> GetPointsList(string curShape, float curLeft, float curRight, float curTop,
            float curBottom)
        {
            // TODO - Добавить вычисление по формуле

            // Зададим всевозможные координаты для двухсторонней стрелки
            // Острие стрелки справа
            var rightArrowheadX = curRight;
            var rightArrowheadY = curTop + (curBottom - curTop) / 2;

            // Верхний угол наконечника стрелки справа
            var rightArrowTopX = curRight - (curRight - curLeft) / 3;
            var rightArrowTopY = curTop;

            // Правый верхний угол прямоугольника стрелки
            var rightArrowRectangleTopX = rightArrowTopX;
            var rightArrowRectangleTopY = curTop + (curBottom - curTop) / 3;

            // Левый верхний угол прямоугольника стрелки
            var leftArrowRectangleTopX = curLeft + (curRight - curLeft) / 3;
            var leftArrowRectangleTopY = rightArrowRectangleTopY;

            // Верхний угол наконечника стрелки справа
            var leftArrowTopX = leftArrowRectangleTopX;
            var leftArrowTopY = rightArrowTopY;

            // Острие стрелки слева
            var leftArrowheadX = curLeft;
            var leftArrowheadY = rightArrowheadY;

            // Нижний угол наконечника стрелки слева
            var leftArrowBottomX = leftArrowRectangleTopX;
            var leftArrowBottomY = curBottom;

            // Левый нижний угол прямоугольника стрелки
            var leftArrowRectangleBottomX = leftArrowRectangleTopX;
            var leftArrowRectangleBottomY = curBottom - (curBottom - curTop) / 3;

            // Правый нижний угол прямоугольника стрелки
            var rightArrowRectangleBottomX = rightArrowTopX;
            var rightArrowRectangleBottomY = leftArrowRectangleBottomY;

            // Нижний угол наконечника стрелки справа
            var rightArrowBottomX = rightArrowTopX;
            var rightArrowBottomY = leftArrowBottomY;

            // Правый верхний угол прямоугольника
            var rightRectangleTopX = rightArrowheadX;
            var rightRectangleTopY = rightArrowRectangleTopY;

            // Правый нижний угол прямоугольника
            var rightRectangleBottomX = rightArrowheadX;
            var rightRectangleBottomY = rightArrowRectangleBottomY;

            // Левый верхний угол прямоугольника
            var leftRectangleTopX = leftArrowheadX;
            var leftRectangleTopY = leftArrowRectangleTopY;

            var leftRectangleBottomX = leftArrowheadX;
            var leftRectangleBottomY = leftArrowRectangleBottomY;

            switch (curShape)
            {
                // Если стрелка влево, то добавим нужные координаты 
                case "ArrowLeft":
                    //Добавим нужные координаты
                    yield return new SvgPoint(new SvgLength(leftArrowheadX), new SvgLength(leftArrowheadY));
                    yield return new SvgPoint(new SvgLength(leftArrowTopX), new SvgLength(leftArrowTopY));
                    yield return new SvgPoint(new SvgLength(leftArrowRectangleTopX),
                        new SvgLength(leftArrowRectangleTopY));
                    yield return new SvgPoint(new SvgLength(rightRectangleTopX), new SvgLength(rightRectangleTopY));
                    yield return new SvgPoint(new SvgLength(rightRectangleBottomX),
                        new SvgLength(rightRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(leftArrowRectangleBottomX),
                        new SvgLength(leftArrowRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(leftArrowBottomX), new SvgLength(leftArrowBottomY));
                    break;

                // Если стрелка вправо, то добавим нужные координаты 
                case "ArrowRight":
                    //Добавим нужные координаты
                    yield return new SvgPoint(new SvgLength(rightArrowheadX), new SvgLength(rightArrowheadY));
                    yield return new SvgPoint(new SvgLength(rightArrowTopX), new SvgLength(rightArrowTopY));
                    yield return new SvgPoint(new SvgLength(rightArrowRectangleTopX),
                        new SvgLength(rightArrowRectangleTopY));
                    yield return new SvgPoint(new SvgLength(leftRectangleTopX), new SvgLength(leftRectangleTopY));
                    yield return new SvgPoint(new SvgLength(leftRectangleBottomX), new SvgLength(leftRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(rightArrowRectangleBottomX),
                        new SvgLength(rightArrowRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(rightArrowBottomX), new SvgLength(rightArrowBottomY));
                    break;

                // Если стрелка двухсторонняя, то добавим нужные координаты 
                case "ArrowLeftRight":
                    //Добавим нужные координаты
                    yield return new SvgPoint(new SvgLength(rightArrowheadX), new SvgLength(rightArrowheadY));
                    yield return new SvgPoint(new SvgLength(rightArrowTopX), new SvgLength(rightArrowTopY));
                    yield return new SvgPoint(new SvgLength(rightArrowRectangleTopX),
                        new SvgLength(rightArrowRectangleTopY));
                    yield return new SvgPoint(new SvgLength(leftArrowRectangleTopX),
                        new SvgLength(leftArrowRectangleTopY));
                    yield return new SvgPoint(new SvgLength(leftArrowTopX), new SvgLength(leftArrowTopY));
                    yield return new SvgPoint(new SvgLength(leftArrowheadX), new SvgLength(leftArrowheadY));
                    yield return new SvgPoint(new SvgLength(leftArrowBottomX), new SvgLength(leftArrowBottomY));
                    yield return new SvgPoint(new SvgLength(leftArrowRectangleBottomX),
                        new SvgLength(leftArrowRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(rightArrowRectangleBottomX),
                        new SvgLength(rightArrowRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(rightArrowBottomX), new SvgLength(rightArrowBottomY));
                    break;
            }
        }
    }
}