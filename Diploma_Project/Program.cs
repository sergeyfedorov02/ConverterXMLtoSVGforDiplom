// ReSharper disable All
// See https://aka.ms/new-console-template for more information

// Подключаем библиотеки

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using GrapeCity.Documents.Common;
using GrapeCity.Documents.Drawing;
using static Diploma_Project.Test;
using GrapeCity.Documents.Imaging;
using GrapeCity.Documents.Svg;

namespace Diploma_Project // Пространство имен
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Устанавливаем кодировку консоли.
            // Нужно только если при использовании англоязычной Windows
            // на консоль вместо кириллицы выводятся знаки вопроса (??? ????? ??????)
            Console.OutputEncoding = Encoding.Unicode;

            // путь к архиву
            const string archivePath = @"D:\Imsat\project_24_4287.zip";

            //Переменная для хранения имен нужных нам файлов
           var filesNames = new List<string>();

            // Консольный выбор нужного файла при помощи ввода его номера
            //Console.Write("Введите номер интересующего файла: ");
            //int chr_number = Convert.ToInt32(Console.ReadLine());

            // открытие архива в режиме чтения
            using (ZipArchive zipArchive = ZipFile.OpenRead(archivePath))
            {
                // проход циклом всех сущностей в архиве
                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {
                    var pattern = @"^chart_\d{1,}.chr$";
                    Regex rg = new Regex(pattern);

                    // Если файл с данными, то добавим его в List со всем именами файлов с данными
                    // TODO - не испольузется
                    if (rg.IsMatch(entry.FullName))
                    {
                        filesNames.Add(entry.FullName);
                    }
                    
                    // Для проверки valueTollId case
                    // TODO - просто проверка
                    var defaultList = new List<string>();

                    // Пройдемся по всем файлам с данными
                    // Circle - 140, 141
                    if (rg.IsMatch(entry.FullName) && entry.FullName.Equals("chart_140.chr"))
                    {
                        // открываем этот файл
                        using (var stream = entry.Open())
                        {
                            // создаем объект класса XmlDocument
                            XmlDocument docXML = new XmlDocument();

                            // загрузим в созданный объект наш XML-документ
                            docXML.Load(stream);

                            // Найдем все узлы с именем "DesignerItem"
                            XmlNodeList nodeList = docXML.GetElementsByTagName("DesignerItem");

                            // Создаем холст для рисования
                            var svgDoc = new GcSvgDocument();
                            svgDoc.RootSvg.Width = new SvgLength(4000, SvgLengthUnits.Pixels);
                            svgDoc.RootSvg.Height = new SvgLength(2000, SvgLengthUnits.Pixels);

                            // Пройдемся по всем полученным узлам
                            foreach (XmlNode xmlnode in nodeList)
                            {
                                // Получим значение атрибута с именем "ToolId"
                                string? valueTollId = xmlnode.Attributes?["ToolId"]?.InnerText;

                                // В зависимости от полученного имени применим соответствующий парсер
                                switch (valueTollId)
                                {
                                    case "StandardLibrary.Lamp":
                                        // Осуществим парсинг узла с ToolId = "StandardLibrary.Lamp"
                                        Console.Write("Label_Name - {0}\n",
                                            xmlnode.SelectSingleNode("Label")?.InnerText);

                                        // Получим Dictionary, состоящий из свойств текущего элемента StandardLibrary.Lamp
                                        Dictionary<string, string> parserResult = ParserLamp(xmlnode);

                                        // Печать в консоль результата после парсинга
                                        foreach (var element in parserResult)
                                        {
                                            Console.Write("{0} - {1}\n", element.Key, element.Value);
                                        }

                                        Console.Write("\n\n");

                                        // Нарисуем элемент "StandardLibrary.Lamp"
                                        var svgResult = SvgImageLamp(parserResult,
                                            xmlnode?.SelectSingleNode("ShouldDrawLabel")?.InnerText,
                                            xmlnode?.SelectSingleNode("Label")?.InnerText);

                                        // Добавим нарисованные элементы на холст
                                        svgDoc.RootSvg.Children.Add(svgResult);

                                        break;

                                    case "StandardLibrary.RailUnitEx":
                                        break;

                                    case "StandardLibrary.RailJunctionEx":
                                        break;

                                    case "StandardLibrary.IsoJoint":
                                        break;

                                    case "StandardLibrary.Semaphore":
                                        break;

                                    case "StandardLibrary.Label":
                                        break;

                                    case "StandardLibrary.RailCrossing":
                                        break;

                                    default:
                                        if (!defaultList.Contains(valueTollId))
                                        {
                                            defaultList.Add(valueTollId);
                                        }
                                        Console.WriteLine("default");
                                        break;
                                }
                            }

                            // Сохраним получившийся SVG файл
                            // C:\Users\fsergey\RiderProjects\Diploma_Project\Diploma_Project\src
                            // D:\\Imsat\\svg_images\\
                            var curName = entry.FullName.Split(".")[0];
                            string path = "C:\\Users\\fsergey\\RiderProjects\\Diploma_Project\\Diploma_Project\\src\\" +
                                          curName + ".svg";
                            svgDoc.Save(path);
                        }

                        Dictionary<string, int> myDictionary = new Dictionary<string, int>();
                    }

                    // TODO -для тестирования отсутствующий case
                    foreach (var element in defaultList)
                    {
                        Console.Write("{0}\n", element);
                    }
                }
            }

            // Тестируем различные фичи
            //test();
        }


        // Функция для формирования SVG картинки для "StandardLibrary.Lamp"
        static SvgGroupElement SvgImageLamp(Dictionary<string, string> xmlnode, string? shouldDrawLabel,
            string? name)
        {
            // Приведем координаты к типу float
            var curLeft = float.Parse(xmlnode["Left"], CultureInfo.InvariantCulture);
            var curRight = float.Parse(xmlnode["Right"], CultureInfo.InvariantCulture);
            var curTop = float.Parse(xmlnode["Top"], CultureInfo.InvariantCulture);
            var curBottom = float.Parse(xmlnode["Bottom"], CultureInfo.InvariantCulture);

            // Создадим группу для отрисовки текущей "StandardLibrary.Lamp"
            var result = new SvgGroupElement();

            // Добавление кастомного атрибута data-state = "-1" к создаваемой группе, чтобы потом была подсветка, если придет значение
            result.CustomAttributes = new List<SvgCustomAttribute> { new SvgCustomAttribute("data-state", "-1") };

            // Вычислим цвет обводки
            var objColor = ConvertArgb(xmlnode["ObjectColor"]);

            // Добавление Стиля
            // TODO() - добавить параметр указания стиля

            // Отрисовка элемента прямоугольник с текстом или скругленного прямоугольника
            if (xmlnode["Shape"] == "Rectangle" || xmlnode["Shape"] == "RoundRectangle")
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
                    StrokeWidth = new SvgLength(float.Parse(xmlnode["LineWidth"], CultureInfo.InvariantCulture)),

                    // Задаем цвет внутри прямоугольника полностью прозрачным
                    Fill = new SvgPaint(Color.Transparent),

                    // Задаем цвет обводки, который берется с ObjectColor
                    //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                    Stroke = new SvgPaint(Color.FromArgb(objColor[0], objColor[1], objColor[2], objColor[3]))
                };

                // Если задан RoundRectangle, то установим скругление углов
                // TODO - Задать стандартное закругление
                if (xmlnode["Shape"] == "RoundRectangle")
                {
                    var radius = 10f;
                    rectangle.RadiusX = new SvgLength(radius);
                    rectangle.RadiusX = new SvgLength(radius);
                }

                // Если задан параметр, что границу отображать не надо
                if (xmlnode.ContainsKey("DrawBorder") && xmlnode["DrawBorder"] == "False")
                {
                    // Границу отображать не будем
                    rectangle.Stroke = new SvgPaint(Color.Transparent);
                }

                // Добавим полученный прямоугольник в группу
                rectangleGroup.Children.Add(rectangle);

                // Добавим угол поворота, если он есть
                if (xmlnode.ContainsKey("Angle") && float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture) != 0.0f)
                {
                    // Вычислим угол поворота
                    var angleOfRotation = float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture);
                    var centerX = curLeft + (curRight - curLeft) / 2;
                    var centerY = curTop + (curBottom - curTop) / 2;

                    // Добавим угол поворота
                    rectangleGroup.Transform = new List<SvgTransform>
                    {
                        new SvgRotateTransform()
                        {
                            Angle = new SvgAngle(angleOfRotation),
                            CenterX = new SvgLength(centerX),
                            CenterY = new SvgLength(centerY)
                        }
                    };
                }

                // Добавляем группу нашего прямоугольника в группу result
                result.Children.Add(rectangleGroup);

                // Если надо отображать текст, то добавим его
                if (shouldDrawLabel != null && shouldDrawLabel.Equals("true"))
                {
                    // Создадим текст
                    var svgTextElement = AddSvgTextElement(xmlnode, name);

                    // Добавляем созданный текст
                    result.Children.Add(svgTextElement);
                }
            }

            // Отрисовка элемента стрелка влево/вправо или двухсторонняя стрелка с текстом
            if (xmlnode["Shape"] == "ArrowLeftRight" || xmlnode["Shape"] == "ArrowLeft" ||
                xmlnode["Shape"] == "ArrowRight")
            {
                // Создадим группу для стрелки (поворот без этого не осуществить)
                var arrowGroup = new SvgGroupElement();

                // Создадим List для точек и вычислим их
                var listPoints = GetPointsList(xmlnode["Shape"], curLeft, curRight, curTop, curBottom);

                // Рисуем двухстороннюю стрелку
                var arrow = AddSvgLeftRightArrow(listPoints, xmlnode["LineWidth"], objColor);

                // Если задан параметр, что границу отображать не надо
                if (xmlnode.ContainsKey("DrawBorder") && xmlnode["DrawBorder"] == "False")
                {
                    // Границу отображать не будем
                    arrow.Stroke = new SvgPaint(Color.Transparent);
                }

                // Добавим полученную стрелку в группу
                arrowGroup.Children.Add(arrow);

                // Добавим угол поворота, если он есть
                if (xmlnode.ContainsKey("Angle") && float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture) != 0.0f)
                {
                    // Вычислим угол поворота
                    var angleOfRotation = float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture);
                    var centerX = curLeft + (curRight - curLeft) / 2;
                    var centerY = curTop + (curBottom - curTop) / 2;

                    // Добавим угол поворота
                    arrowGroup.Transform = new List<SvgTransform>
                    {
                        new SvgRotateTransform()
                        {
                            Angle = new SvgAngle(angleOfRotation),
                            CenterX = new SvgLength(centerX),
                            CenterY = new SvgLength(centerY),
                        }
                    };
                }

                // Добавляем группу нашей стрелки в группу result
                result.Children.Add(arrowGroup);

                // Если надо отображать текст, то добавим его
                if (shouldDrawLabel != null && shouldDrawLabel.Equals("true"))
                {
                    // Создадим текст
                    var svgTextElement = AddSvgTextElement(xmlnode, name);

                    // Добавляем созданный текст
                    result.Children.Add(svgTextElement);
                }
            }

            // Отрисовка элемента круг с текстом
            if (xmlnode["Shape"] == "Circle")
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
                    StrokeWidth = new SvgLength(float.Parse(xmlnode["LineWidth"], CultureInfo.InvariantCulture)),

                    // Задаем цвет внутри ээлипса полностью прозрачным
                    Fill = new SvgPaint(Color.Transparent),

                    // Задаем цвет обводки, который берется с ObjectColor
                    //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                    Stroke = new SvgPaint(Color.FromArgb(objColor[0], objColor[1], objColor[2], objColor[3]))
                };

                // Если задан параметр, что границу отображать не надо
                if (xmlnode.ContainsKey("DrawBorder") && xmlnode["DrawBorder"] == "False")
                {
                    // Границу отображать не будем
                    ellipse.Stroke = new SvgPaint(Color.Transparent);
                }

                // Добавим полученный эллипс в группу
                ellipseGroup.Children.Add(ellipse);

                // Добавим угол поворота, если он есть
                if (xmlnode.ContainsKey("Angle") && float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture) != 0.0f)
                {
                    // Вычислим угол поворота
                    var angleOfRotation = float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture);
                    var centerX = curLeft + (curRight - curLeft) / 2;
                    var centerY = curTop + (curBottom - curTop) / 2;

                    // Добавим угол поворота
                    ellipseGroup.Transform = new List<SvgTransform>
                    {
                        new SvgRotateTransform()
                        {
                            Angle = new SvgAngle(angleOfRotation),
                            CenterX = new SvgLength(centerX),
                            CenterY = new SvgLength(centerY)
                        }
                    };
                }

                // Добавляем группу нашего эллипса в группу result
                result.Children.Add(ellipseGroup);

                // Если надо отображать текст, то добавим его
                if (shouldDrawLabel != null && shouldDrawLabel.Equals("true"))
                {
                    // Создадим текст
                    var svgTextElement = AddSvgTextElement(xmlnode, name);

                    // Добавляем созданный текст
                    result.Children.Add(svgTextElement);
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

        // Дополнительная функция для создания списка точек для той или иной стрелки
        static List<float> GetPointsList(string curShape, float curLeft, float curRight, float curTop, float curBottom)
        {
            var result = new List<float>();

            // Зададим всевозможные координаты для двухсторонней стрелки
            // TODO - Добавить вычисление по формуле
            // Остриё стрелки справа
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

            // Остриё стрелки слева
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

            // Если стрелка влево, то добавим нужные координаты 
            if (curShape == "ArrowLeft")
            {
                //Добавим нужные координаты
                result.Add(leftArrowheadX);
                result.Add(leftArrowheadY);
                result.Add(leftArrowTopX);
                result.Add(leftArrowTopY);
                result.Add(leftArrowRectangleTopX);
                result.Add(leftArrowRectangleTopY);
                result.Add(rightRectangleTopX);
                result.Add(rightRectangleTopY);
                result.Add(rightRectangleBottomX);
                result.Add(rightRectangleBottomY);
                result.Add(leftArrowRectangleBottomX);
                result.Add(leftArrowRectangleBottomY);
                result.Add(leftArrowBottomX);
                result.Add(leftArrowBottomY);
            }

            // Если стрелка влево, то добавим нужные координаты 
            if (curShape == "ArrowRight")
            {
                //Добавим нужные координаты
                result.Add(rightArrowheadX);
                result.Add(rightArrowheadY);
                result.Add(rightArrowTopX);
                result.Add(rightArrowTopY);
                result.Add(rightArrowRectangleTopX);
                result.Add(rightArrowRectangleTopY);
                result.Add(leftRectangleTopX);
                result.Add(leftRectangleTopY);
                result.Add(leftRectangleBottomX);
                result.Add(leftRectangleBottomY);
                result.Add(rightArrowRectangleBottomX);
                result.Add(rightArrowRectangleBottomY);
                result.Add(rightArrowBottomX);
                result.Add(rightArrowBottomY);
            }

            // Если стрелка влево, то добавим нужные координаты 
            if (curShape == "ArrowLeftRight")
            {
                //Добавим нужные координаты
                result.Add(rightArrowheadX);
                result.Add(rightArrowheadY);
                result.Add(rightArrowTopX);
                result.Add(rightArrowTopY);
                result.Add(rightArrowRectangleTopX);
                result.Add(rightArrowRectangleTopY);
                result.Add(leftArrowRectangleTopX);
                result.Add(leftArrowRectangleTopY);
                result.Add(leftArrowTopX);
                result.Add(leftArrowTopY);
                result.Add(leftArrowheadX);
                result.Add(leftArrowheadY);
                result.Add(leftArrowBottomX);
                result.Add(leftArrowBottomY);
                result.Add(leftArrowRectangleBottomX);
                result.Add(leftArrowRectangleBottomY);
                result.Add(rightArrowRectangleBottomX);
                result.Add(rightArrowRectangleBottomY);
                result.Add(rightArrowBottomX);
                result.Add(rightArrowBottomY);
            }

            return result;
        }

        //Функция для добалвения стрелки влево или вправо
        static SvgPolygonElement AddSvgLeftRightArrow(List<float> points, string width, List<int> objColor)
        {
            // Создадим полигон из точек
            var allPoints = new List<SvgPoint>();
            for (int i = 0; i < points.Count; i += 2)
            {
                allPoints.Add(new SvgPoint(new SvgLength(points[i]), new SvgLength(points[i + 1])));
            }

            // Рисуем стрелку
            var arrowLeftOrRight = new SvgPolygonElement
            {
                // Добавим полигон из точек
                Points = allPoints,

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(float.Parse(width, CultureInfo.InvariantCulture)),

                // Задаем цвет внутри стрелки влево полностью прозрачным
                Fill = new SvgPaint(Color.Transparent),

                // Задаем цвет обводки, который берется с ObjectColor
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Stroke = new SvgPaint(Color.FromArgb(objColor[0], objColor[1], objColor[2], objColor[3]))
            };

            return arrowLeftOrRight;
        }

        //Функция для добавления элемента SvgTextElement
        static SvgTextElement AddSvgTextElement(Dictionary<string, string> xmlnode, string? name)
        {
            var curText = "";
            // Проверим, есть ли заданное имя или же будем брать значение Default
            if (name != null)
            {
                curText = name;
            }
            else
            {
                curText = xmlnode["LabelDefaultText"];
            }

            // Получим значения позиции
            var position = xmlnode["LabelPosition"];
            var curX = float.Parse(xmlnode["LabelPosition"].Split(",")[0], CultureInfo.InvariantCulture);
            var curY = float.Parse(xmlnode["LabelPosition"].Split(",")[1], CultureInfo.InvariantCulture);

            var text = new SvgTextElement
            {
                // Создаем сам текст
                Children =
                {
                    new SvgContentElement
                    {
                        Content = curText,
                    },
                },

                // Задаем расположение надписи по формуле согласно заданным координатам
                // TODO() - добавить вычисление по формуле
                X = new List<SvgLength> { new SvgLength(curX) },
                Y = new List<SvgLength> { new SvgLength(curY) },

                // Задаем размер текста
                FontSize = new SvgLength(float.Parse(xmlnode["LabelFontSize"], CultureInfo.InvariantCulture)),

                // Задаем стандартный цвет надписи (черный НЕ прозрачный цвет)
                Fill = new SvgPaint(Color.FromArgb(255, 0, 0, 0))
            };

            // Задаем цвет надписи согласно LabelBrush, если такой узел присутствует
            if (xmlnode.ContainsKey("LabelBrush"))
            {
                var labelBrushColor = ConvertArgb(xmlnode["LabelBrush"]);
                text.Fill = new SvgPaint(Color.FromArgb(labelBrushColor[0], labelBrushColor[1],
                    labelBrushColor[2], labelBrushColor[3]));
            }

            // Есть задан стиль текста, то добавим его
            if (xmlnode.ContainsKey("LabelFontStyle"))
            {
                if (xmlnode["LabelFontStyle"] == "Normal")
                {
                    text.FontStyle = SvgFontStyle.Normal;
                }

                if (xmlnode["LabelFontStyle"] == "Italic")
                {
                    text.FontStyle = SvgFontStyle.Italic;
                }
            }

            return text;
        }


        //Функция для конвертации строки с цветом в десятичную систему счисления в формате Argb
        static List<int> ConvertArgb(string str)
        {
            List<int> result = new List<int>();
            int length = str.Length;
            var colorA = 255;
            var colorR = 0;
            var colorG = 0;
            var colorB = 0;
            // Если пришел формат rgb
            if (length == 7)
            {
                colorR = Convert.ToInt32(str.Substring(1, 2), 16);
                colorG = Convert.ToInt32(str.Substring(3, 2), 16);
                colorB = Convert.ToInt32(str.Substring(5, 2), 16);
            }
            // Если Argb
            else if (length == 9)
            {
                colorA = Convert.ToInt32(str.Substring(1, 2), 16);
                colorR = Convert.ToInt32(str.Substring(3, 2), 16);
                colorG = Convert.ToInt32(str.Substring(5, 2), 16);
                colorB = Convert.ToInt32(str.Substring(7, 2), 16);
            }

            result.Add(colorA);
            result.Add(colorR);
            result.Add(colorG);
            result.Add(colorB);
            return result;
        }

        // Функция для парсинга элемента с ToolId = "StandardLibrary.Lamp"
        static Dictionary<string, string> ParserLamp(XmlNode currentXmlnode)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            // Получим дочерний узел Properties
            XmlNode? properties = currentXmlnode.SelectSingleNode("Properties");

            // Разбираемся с узлом Properties
            XmlNodeList? propertiesNodes = properties?.SelectNodes("*");
            if (propertiesNodes != null)
            {
                foreach (XmlNode propertiesNode in propertiesNodes)
                {
                    // Найдем текущие значения
                    var name = propertiesNode.SelectSingleNode("Name")?.InnerText;
                    var value = propertiesNode.SelectSingleNode("Value")?.InnerText;

                    // Добавим найденные значения в result
                    if (name != null && value != null)
                    {
                        result.Add(name, value);
                    }
                }
            }

            return result;
        }
    }
}