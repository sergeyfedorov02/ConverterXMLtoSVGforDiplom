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
        public static SvgGroupElement CreateSvgImageLamp(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
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

            // Получим значение атрибута "Shape", если такого нет -> берем значение "Rectangle"
            var aShape = xmlNode.GetValueOrDefault("Shape", "Rectangle");

            // Получим значение атрибута "DrawBorder", если такого нет -> берем значение "True"
            var aDrawBorder = xmlNode.GetValueOrDefault("DrawBorder", "True");

            // Создадим группу для отрисовки текущей "StandardLibrary.Lamp" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(aShape, aDrawBorder, null, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Если текущая лампа относится к классу "fill-indicator"
            if (FillIndicators.Contains(aShape))
            {
                // Выберем тот или иной метод для рисования
                switch (aShape)
                {
                    case "Rectangle":
                    case "RoundRectangle":

                        // Получим прямоугольник
                        var rectangle = CreateRectangleSvg(xmlNode, curLeft, curRight, curTop, curBottom, objColor,
                            aShape);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesFillIndicator(rectangle, result, xmlNode, curLeft, curRight, curTop,
                            curBottom, aDrawBorder);
                        break;

                    case "ArrowLeftRight":
                    case "ArrowLeft":
                    case "ArrowRight":
                        // Создадим List для точек и вычислим их
                        var arrowListPoints =
                            GetArrowsPointsList(aShape, curLeft, curRight, curTop, curBottom).ToList();

                        // Получим стрелку
                        var arrow = CreateLeftRightArrowSvg(arrowListPoints, xmlNode.GetLineWidth(), objColor);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesFillIndicator(arrow, result, xmlNode, curLeft, curRight, curTop,
                            curBottom, aDrawBorder);

                        break;

                    case "Circle":
                        // Получим круг
                        var circle = CreateCircleSvg(xmlNode, curLeft, curRight, curTop, curBottom, objColor);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesFillIndicator(circle, result, xmlNode, curLeft, curRight, curTop,
                            curBottom, aDrawBorder);

                        break;
                    case "Triangle":
                        // Получим треугольник
                        var triangle = CreateTriangleSvg(xmlNode, curLeft, curRight, curTop, curBottom, objColor);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesFillIndicator(triangle, result, xmlNode, curLeft, curRight, curTop,
                            curBottom, aDrawBorder);

                        break;

                    case "KeyBarrel":
                        // Создадим List для точек и вычислим их
                        var keyBarrelListPoints = GetKeyBarrelPathBuilder(curLeft, curRight, curTop, curBottom);

                        // Получим ключ жезл
                        var keyBarrel = CreateKeyBarrelSvg(keyBarrelListPoints, xmlNode.GetLineWidth(), objColor);

                        // Добавим угол поворота, если он есть
                        keyBarrel.AddAngle(xmlNode, curLeft, curRight, curTop, curBottom);

                        // Добавим полученный элемент в result
                        result.Children.Add(keyBarrel);

                        // Если надо отображать текст, то добавим его в result
                        if (CreateText.IsShouldDrawLabel(xmlNode["ShouldDrawLabel"]))
                        {
                            // Добавляем созданный текст
                            result.Children.Add(CreateText.AddSvgTextElement(xmlNode, xmlNode["Label"]));
                        }

                        break;
                }
            }
            // Иначе к классу "line-indicator"
            else if (LineIndicators.Contains(aShape))
            {
                // Выберем тот или иной метод для рисования
                switch (aShape)
                {
                    case "GroundControl":
                        // Добавим все составляющие части элемента "Контроль заземления" в общую группу
                        var groundControl = CreateGroundControlSvg(curLeft, curRight, curTop, curBottom);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesLineIndicator(groundControl, result, xmlNode, objColor, aShape, curLeft,
                            curRight, curTop, curBottom);

                        break;

                    case "RailEndCoupling":
                    case "RailEndBox":
                        // Добавим все составляющие части элемента "Муфта/Коробка релейная" в общую группу
                        var railEndElement = CreateRailEndCouplingBoxSvg(curLeft, curRight, curTop, curBottom, aShape);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesLineIndicator(railEndElement, result, xmlNode, objColor, aShape, curLeft,
                            curRight, curTop, curBottom);

                        break;

                    case "FeedEndCoupling":
                    case "FeedEndBox":
                        // Добавим все составляющие части элемента "Муфта/Коробка питающая" в общую группу
                        var feedEndElement =
                            CreateFeedEndCouplingBoxSvg(curLeft, curRight, curTop, curBottom, aShape, objColor);

                        // Добавим стандартные атрибуты
                        AddStandardAttributesLineIndicator(feedEndElement, result, xmlNode, objColor, aShape, curLeft,
                            curRight, curTop, curBottom);
                        break;
                }
            }

            return result;
        }

        // Функция для получения Прямоугольника в формате Svg
        private static SvgRectElement CreateRectangleSvg(IReadOnlyDictionary<string, string> xmlNode, float curLeft,
            float curRight, float curTop, float curBottom, Color objColor, string aShape)
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
            if (aShape == "RoundRectangle")
            {
                var radius = curWidth / 4;
                rectangle.RadiusX = new SvgLength(radius);
                rectangle.RadiusY = new SvgLength(radius);
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

                // Задаем цвет внутри треугольника полностью прозрачным
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

        // Функция для получения Ключ Жезла в формате Svg
        private static SvgGroupElement CreateKeyBarrelSvg(SvgPathBuilder pb, float width,
            Color objColor)
        {
            // Создадим группу для ключ-жезла, тк это составной элемент, у которого внутри свободное пространство
            var result = new SvgGroupElement
            {
                // Задаем ширину обводки
                StrokeWidth = new SvgLength(width),

                // Добавим указатель класса "fill-indicator"
                Class = "fill-indicator"
            };

            // Рисуем ключ жезл
            var keyBarrel = new SvgPathElement
            {
                PathData = pb.ToPathData(),

                // Определяем внутреннюю часть фигуры
                FillRule = SvgFillRule.EvenOdd,

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(objColor)
            };

            result.Children.Add(keyBarrel);

            return result;
        }

        // Функция для получения Контроля заземления в формате Svg
        private static SvgGroupElement CreateGroundControlSvg(float curLeft, float curRight, float curTop,
            float curBottom)
        {
            return new SvgGroupElement
            {
                Children =
                {
                    // Вертикальная линия
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curLeft + (curRight - curLeft) / 2),
                        Y1 = new SvgLength(curTop),
                        X2 = new SvgLength(curLeft + (curRight - curLeft) / 2),
                        Y2 = new SvgLength(curTop + (curBottom - curTop) / 2),
                    },

                    // Верхняя горизонтальная линия (самая длинная)
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curLeft),
                        Y1 = new SvgLength(curTop + (curBottom - curTop) / 2),
                        X2 = new SvgLength(curRight),
                        Y2 = new SvgLength(curTop + (curBottom - curTop) / 2),
                    },

                    // Центральная горизонтальная линия (средняя)
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curLeft + (curRight - curLeft) / 4),
                        Y1 = new SvgLength(curTop + 3 * (curBottom - curTop) / 4),
                        X2 = new SvgLength(curLeft + 3 * (curRight - curLeft) / 4),
                        Y2 = new SvgLength(curTop + 3 * (curBottom - curTop) / 4),
                    },

                    // Нижняя горизонтальная линия (маленькая)
                    new SvgLineElement
                    {
                        X1 = new SvgLength(curLeft + (curRight - curLeft) / 2.4f),
                        Y1 = new SvgLength(curBottom),
                        X2 = new SvgLength(curRight - (curRight - curLeft) / 2.4f),
                        Y2 = new SvgLength(curBottom),
                    }
                }
            };
        }

        // Функция для получения Муфты или Коробки релейной в формате Svg
        private static SvgGroupElement CreateRailEndCouplingBoxSvg(float curLeft, float curRight, float curTop,
            float curBottom, string aShape)
        {
            var result = new SvgGroupElement();

            // Вычислим координаты центра фигуры
            var curCentreX = curLeft + (curRight - curLeft) / 2;
            var curCentreY = curTop + (curBottom - curTop) / 2;
            var radius = Math.Min((curRight - curLeft) / 2, (curBottom - curTop) / 2);

            // В зависимости от типа РЦ (муфта или коробка) добавим круг или прямоугольник
            switch (aShape)
            {
                // Муфта релейная
                case "RailEndCoupling":
                    // Добавим круг
                    result.Children.Add
                    (
                        new SvgCircleElement
                        {
                            // Координаты центра и значение радиуса
                            CenterX = new SvgLength(curCentreX),
                            CenterY = new SvgLength(curCentreY),
                            Radius = new SvgLength(radius)
                        }
                    );
                    break;

                // Коробка релейная
                case "RailEndBox":
                    // Добавим прямоугольник
                    result.Children.Add
                    (
                        new SvgRectElement
                        {
                            // Зададим ширину и высоту прямоугольника
                            Width = new SvgLength(curRight - curLeft),
                            Height = new SvgLength(curBottom - curTop),

                            // Задаем координаты левого верхнего угла
                            X = new SvgLength(curLeft),
                            Y = new SvgLength(curTop),
                        }
                    );
                    break;
            }

            // Добавим горизонтальную линию
            result.Children.Add
            (
                new SvgLineElement
                {
                    X1 = new SvgLength(curCentreX - radius / 2),
                    Y1 = new SvgLength(curCentreY),
                    X2 = new SvgLength(curCentreX + radius / 2),
                    Y2 = new SvgLength(curCentreY),
                }
            );

            // Добавим вертикальную линию
            result.Children.Add
            (
                // Создадим горизонтальную линию
                new SvgLineElement
                {
                    X1 = new SvgLength(curCentreX),
                    Y1 = new SvgLength(curCentreY - radius / 2),
                    X2 = new SvgLength(curCentreX),
                    Y2 = new SvgLength(curCentreY + radius / 2),
                }
            );

            return result;
        }

        // Функция для получения Муфты или Коробки питающей в формате Svg
        private static SvgGroupElement CreateFeedEndCouplingBoxSvg(float curLeft, float curRight, float curTop,
            float curBottom, string aShape, Color objColor)
        {
            var result = new SvgGroupElement();

            // Вычислим координаты центра фигуры
            var curCentreX = curLeft + (curRight - curLeft) / 2;
            var curCentreY = curTop + (curBottom - curTop) / 2;
            var radius = Math.Min((curRight - curLeft) / 2, (curBottom - curTop) / 2);

            // В зависимости от типа РЦ (муфта или коробка) добавим круг или прямоугольник
            switch (aShape)
            {
                // Муфта питающая
                case "FeedEndCoupling":
                    // Добавим круг
                    result.Children.Add
                    (
                        new SvgCircleElement
                        {
                            // Координаты центра и значение радиуса
                            CenterX = new SvgLength(curCentreX),
                            CenterY = new SvgLength(curCentreY),
                            Radius = new SvgLength(radius),

                            Class = "line-indicator"
                        }
                    );
                    break;

                // Коробка питающая
                case "FeedEndBox":
                    // Добавим прямоугольник
                    result.Children.Add
                    (
                        new SvgRectElement
                        {
                            // Зададим ширину и высоту прямоугольника
                            Width = new SvgLength(curRight - curLeft),
                            Height = new SvgLength(curBottom - curTop),

                            // Задаем координаты левого верхнего угла
                            X = new SvgLength(curLeft),
                            Y = new SvgLength(curTop),

                            Class = "line-indicator"
                        }
                    );
                    break;
            }

            var fillIndicatorGroup = new SvgGroupElement
            {
                // Задаем цвет закрашивания (чёрный и полностью НЕ прозрачный)
                Fill = new SvgPaint(Color.FromArgb(255, 0, 0, 0)),

                // Делаем элемент видимым
                FillOpacity = 1,

                Children =
                {
                    new SvgCircleElement
                    {
                        // Координаты центра и значение радиуса
                        CenterX = new SvgLength(curCentreX),
                        CenterY = new SvgLength(curCentreY),
                        Radius = new SvgLength(radius / 3),

                        Class = "fill-indicator",

                        // Задаем ширину обводки
                        StrokeWidth = new SvgLength(0),

                        // Задаем цвет обводки, который берется с ObjectColor
                        //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                        Stroke = new SvgPaint(objColor)
                    }
                }
            };

            result.Children.Add(fillIndicatorGroup);

            return result;
        }

        // Функция для добавления стандартных атрибутов к элементу FillIndicator (граница, текущая группа, угол поворота, добавление в result, текст)
        private static void AddStandardAttributesFillIndicator(SvgGeometryElement curElement, SvgElement curResult,
            IReadOnlyDictionary<string, string> xmlNode, float curLeft, float curRight, float curTop, float curBottom,
            string aDrawBorder)
        {
            // Добавим указатель класса "fill-indicator"
            curElement.Class = "fill-indicator";

            // Удалим границу, если атрибута "DrawBorder" нет или его значение False
            curElement.DelDrawBorder(aDrawBorder);

            // Добавим угол поворота, если он есть
            curElement.AddAngle(xmlNode, curLeft, curRight, curTop, curBottom);

            // Добавим полученный элемент в result
            curResult.Children.Add(curElement);

            // Если надо отображать текст, то добавим его в result
            if (CreateText.IsShouldDrawLabel(xmlNode["ShouldDrawLabel"]))
            {
                // Добавляем созданный текст
                curResult.Children.Add(CreateText.AddSvgTextElement(xmlNode, xmlNode["Label"]));
            }
        }

        // Функция для добавления стандартных атрибутов к элементу LineIndicator(класс, ширина линий, добавление в result, текст)
        private static void AddStandardAttributesLineIndicator(SvgElement curElementGroup, SvgElement curResult,
            IReadOnlyDictionary<string, string> xmlNode, Color objColor, string aShape, float curLeft, float curRight,
            float curTop, float curBottom)
        {
            if (aShape != "FeedEndCoupling" && aShape != "FeedEndBox")
            {
                // Добавим указатель класса "line-indicator"
                curElementGroup.Class = "line-indicator";
            }

            // Зададим ширину обводки
            curElementGroup.StrokeWidth = new SvgLength(xmlNode.GetLineWidth());

            // Задаем цвет обводки, который берется с ObjectColor
            //(alfa = 0, если alfa = 255 - НЕ прозрачный)
            curElementGroup.Stroke = new SvgPaint(objColor);

            // Добавим угол поворота, если он есть
            curElementGroup.AddAngle(xmlNode, curLeft, curRight, curTop, curBottom);

            // Добавим полученный элемент в result
            curResult.Children.Add(curElementGroup);

            // Если надо отображать текст, то добавим его в result
            if (CreateText.IsShouldDrawLabel(xmlNode["ShouldDrawLabel"]))
            {
                // Добавляем созданный текст
                curResult.Children.Add(CreateText.AddSvgTextElement(xmlNode, xmlNode["Label"]));
            }
        }

        // Дополнительная функция для создания списка точек для Ключ жезла
        private static SvgPathBuilder GetKeyBarrelPathBuilder(float curLeft, float curRight, float curTop,
            float curBottom)
        {
            // Создадим конструктор нашего пути
            var result = new SvgPathBuilder();

            // Внешний контур
            // Добавим начальную точку - левый верхний угол внешнего квадрата
            result.AddMoveTo(false, curLeft, curTop + (curBottom - curTop) / 10);

            // правый верхний угол внешнего квадрата
            result.AddLineTo(false, curLeft + (curRight - curLeft) / 2.5f, curTop + (curBottom - curTop) / 10);

            // левый верхний угол прямоугольника ключа
            result.AddLineTo(false, curLeft + (curRight - curLeft) / 2.5f, curTop + (curBottom - curTop) / 2.5f);

            // правый верхний угол прямоугольника ключа
            result.AddLineTo(false, curRight, curTop + (curBottom - curTop) / 2.5f);

            // правый нижний угол конца ключа
            result.AddLineTo(false, curRight, curTop + (curBottom - curTop) / 1.25f);

            // левый нижний угол конца ключа
            result.AddLineTo(false, curRight - (curBottom - curTop) / 5f, curTop + (curBottom - curTop) / 1.25f);

            // правый нижний угол прямоугольника ключа
            result.AddLineTo(false, curRight - (curBottom - curTop) / 5f, curTop + 3 * (curBottom - curTop) / 5);

            // левый нижний угол прямоугольника ключа
            result.AddLineTo(false, curLeft + (curRight - curLeft) / 2.5f, curTop + 3 * (curBottom - curTop) / 5);

            // правый нижний угол внешнего квадрата
            result.AddLineTo(false, curLeft + (curRight - curLeft) / 2.5f, curBottom - (curBottom - curTop) / 10);

            // левый нижний угол внешнего квадрата
            result.AddLineTo(false, curLeft, curBottom - (curBottom - curTop) / 10);

            // Возвращение в начальную точку
            result.AddLineTo(false, curLeft, curTop + (curBottom - curTop) / 10);

            // Закрываем внешний контур ключа
            result.AddClosePath();

            // Внутренний контур
            // Найдем значение высоты и ширины квадрата - отверстия под ключ
            var keyHoleWidth = Math.Min((curRight - curLeft) * 0.4f / 3, (curBottom - curTop) * 0.8f / 2);

            // Добавим вторую начальную точку - левый верхний угол внутреннего квадрата
            result.AddMoveTo(false, curLeft + ((curRight - curLeft) * 0.4f - keyHoleWidth) / 2,
                (curBottom + curTop) / 2 - keyHoleWidth / 2);

            // правый верхний угол внутреннего квадрата
            result.AddLineTo(false, curLeft + ((curRight - curLeft) * 0.4f - keyHoleWidth) / 2 + keyHoleWidth,
                (curBottom + curTop) / 2 - keyHoleWidth / 2);

            // правый нижний угол внутреннего квадрата
            result.AddLineTo(false, curLeft + ((curRight - curLeft) * 0.4f - keyHoleWidth) / 2 + keyHoleWidth,
                (curBottom + curTop) / 2 - keyHoleWidth / 2 + keyHoleWidth);

            // левый нижний угол внутреннего квадрата
            result.AddLineTo(false, curLeft + ((curRight - curLeft) * 0.4f - keyHoleWidth) / 2,
                (curBottom + curTop) / 2 - keyHoleWidth / 2 + keyHoleWidth);

            // Возвращение в начальную точку
            result.AddLineTo(false, curLeft + ((curRight - curLeft) * 0.4f - keyHoleWidth) / 2,
                (curBottom + curTop) / 2 - keyHoleWidth / 2);

            // Закрываем внутренний контур ключа
            result.AddClosePath();

            return result;
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
        private static IEnumerable<SvgPoint> GetArrowsPointsList(string curShape, float curLeft, float curRight,
            float curTop, float curBottom)
        {
            // Зададим всевозможные координаты для двухсторонней стрелки
            // Острие стрелки справа
            var rightArrowheadX = curRight;
            var rightArrowheadY = curTop + (curBottom - curTop) / 2;

            // Верхний угол наконечника стрелки справа
            var rightArrowTopX = curRight - (curRight - curLeft) / 3;
            var rightArrowTopY = curTop;

            // Правый верхний угол прямоугольника стрелки
            var rightArrowRectangleTopX = rightArrowTopX;
            var rightArrowRectangleTopY = curTop + (curBottom - curTop) / 4;

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
            var leftArrowRectangleBottomY = curBottom - (curBottom - curTop) / 4;

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
                    yield return new SvgPoint(new SvgLength(curLeft + (curRight - curLeft) / 2),
                        new SvgLength(leftArrowTopY));
                    yield return new SvgPoint(new SvgLength(curLeft + (curRight - curLeft) / 2),
                        new SvgLength(leftArrowRectangleTopY));
                    yield return new SvgPoint(new SvgLength(rightRectangleTopX), new SvgLength(rightRectangleTopY));
                    yield return new SvgPoint(new SvgLength(rightRectangleBottomX),
                        new SvgLength(rightRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(curLeft + (curRight - curLeft) / 2),
                        new SvgLength(leftArrowRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(curLeft + (curRight - curLeft) / 2),
                        new SvgLength(leftArrowBottomY));
                    break;

                // Если стрелка вправо, то добавим нужные координаты 
                case "ArrowRight":
                    //Добавим нужные координаты
                    yield return new SvgPoint(new SvgLength(rightArrowheadX), new SvgLength(rightArrowheadY));
                    yield return new SvgPoint(new SvgLength(curRight - (curRight - curLeft) / 2),
                        new SvgLength(rightArrowTopY));
                    yield return new SvgPoint(new SvgLength(curRight - (curRight - curLeft) / 2),
                        new SvgLength(rightArrowRectangleTopY));
                    yield return new SvgPoint(new SvgLength(leftRectangleTopX), new SvgLength(leftRectangleTopY));
                    yield return new SvgPoint(new SvgLength(leftRectangleBottomX), new SvgLength(leftRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(curRight - (curRight - curLeft) / 2),
                        new SvgLength(rightArrowRectangleBottomY));
                    yield return new SvgPoint(new SvgLength(curRight - (curRight - curLeft) / 2),
                        new SvgLength(rightArrowBottomY));
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