using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateLamp
    {
        // Сет для хранения всех типов стрелок (удобная проверка на соответствие в дальнейшем)
        private static readonly HashSet<string> ArrowShapes = new HashSet<string>
        {
            "ArrowLeftRight",
            "ArrowLeft",
            "ArrowRight"
        };

        // Функция для формирования SVG картинки для "StandardLibrary.Lamp"
        public static SvgGroupElement CreateSvgImageLamp(IReadOnlyDictionary<string, string> xmlNode,
            string shouldDrawLabel,
            string name)
        {
            // Приведем координаты к типу float
            var curLeft = float.Parse(xmlNode["Left"], CultureInfo.InvariantCulture);
            var curRight = float.Parse(xmlNode["Right"], CultureInfo.InvariantCulture);
            var curTop = float.Parse(xmlNode["Top"], CultureInfo.InvariantCulture);
            var curBottom = float.Parse(xmlNode["Bottom"], CultureInfo.InvariantCulture);

            // Создадим группу для отрисовки текущей "StandardLibrary.Lamp"
            var result = new SvgGroupElement
            {
                // Добавление кастомного атрибута data-state = "-1" к создаваемой группе, чтобы потом была подсветка, если придет значение
                CustomAttributes = new List<SvgCustomAttribute> { new SvgCustomAttribute("data-state", "-1") }
            };

            // Вычислим цвет обводки
            var objColor = GetColor.ConvertArgb(xmlNode["ObjectColor"]);

            // Добавление Стиля
            // TODO() - добавить параметр указания стиля

            // Отрисовка элемента прямоугольник с текстом или скругленного прямоугольника
            if (xmlNode["Shape"] == "Rectangle" || xmlNode["Shape"] == "RoundRectangle")
            {
                // Создадим группу для прямоугольника (поворот без этого не осуществить)
                var rectangleGroup = new SvgGroupElement();

                // Вычислим координаты для прямоугольника
                var curWidth = curRight - curLeft;
                var curHeight = curBottom - curTop;
                var curX = curLeft;
                var curY = curTop;

                // Были ли перевернуты координаты (рисовали из правого угла)
                if (curRight < curLeft)
                {
                    curWidth = curLeft - curRight;
                    curX = curRight;
                }

                if (curBottom < curTop)
                {
                    curHeight = curTop - curBottom;
                    curY = curBottom;
                }

                // Создадим стандартный прямоугольник
                var rectangle = new SvgRectElement()
                {
                    Width = new SvgLength(curWidth),
                    Height = new SvgLength(curHeight),

                    // Задаем координаты левого верхнего угла
                    X = new SvgLength(curX),
                    Y = new SvgLength(curY),

                    // Задаем ширину обводки
                    StrokeWidth = new SvgLength(float.Parse(xmlNode["LineWidth"], CultureInfo.InvariantCulture)),

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

                // Удалим границу, если задан есть соответствующий параметр со значением False
                rectangle.DelDrawBorder(xmlNode);

                // Добавим полученный прямоугольник в группу
                rectangleGroup.Children.Add(rectangle);

                // Добавим угол поворота, если он есть
                rectangleGroup.AddAngle(xmlNode, curLeft, curRight, curTop, curBottom);

                // Добавляем группу нашего прямоугольника в группу result
                result.Children.Add(rectangleGroup);

                // Если надо отображать текст, то добавим его
                if (CreateText.IsShouldDrawLabel(shouldDrawLabel))
                {
                    // Добавляем созданный текст
                    result.Children.Add(CreateText.AddSvgTextElement(xmlNode, name));
                }
            }

            // Отрисовка элемента стрелка влево/вправо или двухсторонняя стрелка с текстом
            if (ArrowShapes.Contains(xmlNode["Shape"]))
            {
                // Создадим группу для стрелки (поворот без этого не осуществить)
                var arrowGroup = new SvgGroupElement();

                // Создадим List для точек и вычислим их
                var listPoints = GetPointsList(xmlNode["Shape"], curLeft, curRight, curTop, curBottom).ToList();

                // Рисуем двухстороннюю стрелку
                var arrow = CreateSvgLeftRightArrow(listPoints, xmlNode["LineWidth"], objColor);

                // Удалим границу, если задан есть соответствующий параметр со значением False
                arrow.DelDrawBorder(xmlNode);

                // Добавим полученную стрелку в группу
                arrowGroup.Children.Add(arrow);

                // Добавим угол поворота, если он есть
                arrowGroup.AddAngle(xmlNode, curLeft, curRight, curTop, curBottom);

                // Добавляем группу нашей стрелки в группу result
                result.Children.Add(arrowGroup);

                // Если надо отображать текст, то добавим его
                if (CreateText.IsShouldDrawLabel(shouldDrawLabel))
                {
                    // Добавляем созданный текст
                    result.Children.Add(CreateText.AddSvgTextElement(xmlNode, name));
                }
            }

            // Отрисовка элемента круг с текстом
            if (xmlNode["Shape"] == "Circle")
            {
                // Создадим группу для эллипса (поворот без этого не осуществить)
                var ellipseGroup = new SvgGroupElement();

                // Вычислим координаты для эллипса
                var curRadiusX = (curRight - curLeft) / 2;
                var curRadiusY = (curBottom - curTop) / 2;
                var curCentreX = curLeft + curRadiusX;
                var curCentreY = curTop + curRadiusY;

                // Были ли перевернуты координаты (рисовали из правого угла)
                if (curRight < curLeft)
                {
                    curRadiusX = (curLeft - curRight) / 2;
                    curCentreX = curRight + curRadiusX;
                }

                if (curBottom < curTop)
                {
                    curRadiusY = (curTop - curBottom) / 2;
                    curCentreY = curBottom + curRadiusY;
                }

                // Создадим эллипс
                var ellipse = new SvgEllipseElement
                {
                    CenterX = new SvgLength(curCentreX),
                    CenterY = new SvgLength(curCentreY),
                    RadiusX = new SvgLength(curRadiusX),
                    RadiusY = new SvgLength(curRadiusY),

                    // Задаем ширину обводки
                    StrokeWidth = new SvgLength(float.Parse(xmlNode["LineWidth"], CultureInfo.InvariantCulture)),

                    // Задаем цвет внутри эллипса полностью прозрачным
                    Fill = new SvgPaint(Color.Transparent),

                    // Задаем цвет обводки, который берется с ObjectColor
                    //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                    Stroke = new SvgPaint(objColor)
                };

                // Удалим границу, если задан есть соответствующий параметр со значением False
                ellipse.DelDrawBorder(xmlNode);

                // Добавим полученный эллипс в группу
                ellipseGroup.Children.Add(ellipse);

                // Добавим угол поворота, если он есть
                ellipseGroup.AddAngle(xmlNode, curLeft, curRight, curTop, curBottom);

                // Добавляем группу нашего эллипса в группу result
                result.Children.Add(ellipseGroup);

                // Если надо отображать текст, то добавим его
                if (CreateText.IsShouldDrawLabel(shouldDrawLabel))
                {
                    // Добавляем созданный текст
                    result.Children.Add(CreateText.AddSvgTextElement(xmlNode, name));
                }
            }

            // Треугольник и ...
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

        /// <summary>
        /// Дополнительная функция для создания списка точек для той или иной стрелки
        /// </summary>
        /// <param name="curShape">Форма стрелки</param>
        /// <param name="curLeft"></param>
        /// <param name="curRight"></param>
        /// <param name="curTop"></param>
        /// <param name="curBottom"></param>
        /// <returns>Список точек для отрисовки стрелки</returns>
        private static IEnumerable<SvgPoint> GetPointsList(string curShape, float curLeft, float curRight, float curTop,
            float curBottom)
        {
            // Зададим всевозможные координаты для двухсторонней стрелки
            // TODO - Добавить вычисление по формуле
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

        //Функция для добавления стрелки влево или вправо
        private static SvgPolygonElement CreateSvgLeftRightArrow(IEnumerable<SvgPoint> points, string width,
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
                StrokeWidth = new SvgLength(float.Parse(width, CultureInfo.InvariantCulture)),

                // Задаем цвет внутри стрелки влево полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(objColor)
            };
        }
    }
}