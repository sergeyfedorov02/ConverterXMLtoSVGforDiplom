// ReSharper disable All
// See https://aka.ms/new-console-template for more information

// Подключаем библиотеки

using System;
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
            List<string> files_names = new List<string>();

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
                    if (rg.IsMatch(entry.FullName))
                    {
                        files_names.Add(entry.FullName);
                    }

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
                                        Dictionary<string, string> parser_result = parser_Lamp(xmlnode);

                                        // Печать в консоль результата после парсинга
                                        foreach (var element in parser_result)
                                        {
                                            Console.Write("{0} - {1}\n", element.Key, element.Value);
                                        }

                                        Console.Write("\n\n");

                                        // Нарисуем элемент "StandardLibrary.Lamp"
                                        var svg_result = svg_image_Lamp(parser_result,
                                            xmlnode?.SelectSingleNode("ShouldDrawLabel")?.InnerText,
                                            xmlnode?.SelectSingleNode("Label")?.InnerText);

                                        // Добавим нарисованные элементы на холст
                                        svgDoc.RootSvg.Children.Add(svg_result);

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
                                        Console.WriteLine("default");
                                        break;
                                }
                            }

                            // Сохраним получившийся SVG файл
                            // C:\Users\fsergey\RiderProjects\Diploma_Project\Diploma_Project\src
                            // D:\\Imsat\\svg_images\\
                            var cur_name = entry.FullName.Split(".")[0];
                            string path = "C:\\Users\\fsergey\\RiderProjects\\Diploma_Project\\Diploma_Project\\src\\" +
                                          cur_name + ".svg";
                            svgDoc.Save(path);
                        }

                        Dictionary<string, int> my_dictionary = new Dictionary<string, int>();
                    }
                }
            }

            // Тестируем различные фичи
            //test();
        }


        // Функция для формирования SVG картинки для "StandardLibrary.Lamp"
        static SvgGroupElement svg_image_Lamp(Dictionary<string, string> xmlnode, string? should_draw_label,
            string? name)
        {
            // Приведем координаты к типу float
            var cur_left = float.Parse(xmlnode["Left"], CultureInfo.InvariantCulture);
            var cur_right = float.Parse(xmlnode["Right"], CultureInfo.InvariantCulture);
            var cur_top = float.Parse(xmlnode["Top"], CultureInfo.InvariantCulture);
            var cur_bottom = float.Parse(xmlnode["Bottom"], CultureInfo.InvariantCulture);

            // Создадим группу для отрисовки текущей "StandardLibrary.Lamp"
            var result = new SvgGroupElement();

            // Добавление кастомного атрибута data-state = "-1" к создаваемой группе, чтобы потом была подсветка, если придет значение
            result.CustomAttributes = new List<SvgCustomAttribute> { new SvgCustomAttribute("data-state", "-1") };

            // Вычислим цвет обводки
            var obj_color = convert_argb(xmlnode["ObjectColor"]);

            // Добавление Стиля
            // TODO() - добавить параметр указания стиля

            // Отрисовка элемента прямоугольник с текстом или скругленного прямоугольника
            if (xmlnode["Shape"] == "Rectangle" || xmlnode["Shape"] == "RoundRectangle")
            {
                // Создадим группу для прямоугольника (поворот без этого не осуществить)
                var rectangle_group = new SvgGroupElement();
                
                // Вычислим координаты для прямоугольника
                var cur_width = cur_right - cur_left;
                var cur_height = cur_bottom - cur_top;
                var cur_x = cur_left;
                var cur_y = cur_top;

                // Были ли перевернуты координаты (рисовали из правого угла)
                if (cur_right < cur_left)
                {
                    cur_width = cur_left - cur_right;
                    cur_height = cur_top - cur_bottom;
                    cur_x = cur_right;
                    cur_y = cur_bottom;
                }

                // Создадим стандартный прямоугольник
                var rectangle = new SvgRectElement()
                {
                    Width = new SvgLength(cur_width),
                    Height = new SvgLength(cur_height),

                    // Задаем координаты левого верхнего угла
                    X = new SvgLength(cur_x),
                    Y = new SvgLength(cur_y),

                    // Задаем ширину обводки
                    StrokeWidth = new SvgLength(float.Parse(xmlnode["LineWidth"], CultureInfo.InvariantCulture)),

                    // Задаем цвет внутри прямоугольника полностью прозрачным
                    Fill = new SvgPaint(Color.Transparent),

                    // Задаем цвет обводки, который берется с ObjectColor
                    //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                    Stroke = new SvgPaint(Color.FromArgb(obj_color[0], obj_color[1], obj_color[2], obj_color[3]))
                };

                // Если задан RoundRectangle, то установим скругление углов
                if (xmlnode["Shape"] == "RoundRectangle")
                {
                    rectangle.RadiusX = new SvgLength(10f);
                }

                // Если задан параметр, что границу отображать не надо
                if (xmlnode.ContainsKey("DrawBorder") && xmlnode["DrawBorder"] == "False")
                {
                    // Границу отображать не будем
                    rectangle.Stroke = new SvgPaint(Color.Transparent);
                }
                
                // Добавим полученный прямоугольник в группу
                rectangle_group.Children.Add(rectangle);

                // Добавим угол поворота, если он есть
                if (xmlnode.ContainsKey("Angle") && float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture) != 0.0f)
                {
                    // Вычислим угол поворота
                    var angle_of_rotation = float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture);
                    var center_x = cur_left + (cur_right - cur_left) / 2;
                    var center_y = cur_top + (cur_bottom - cur_top) / 2;

                    // Добавим угол поворота
                    rectangle_group.Transform = new List<SvgTransform>
                    {
                        new SvgRotateTransform()
                        {
                            Angle = new SvgAngle(angle_of_rotation),
                            CenterX = new SvgLength(center_x),
                            CenterY = new SvgLength(center_y)
                        }
                    };
                }

                // Добавляем группу нашего прямоугольника в группу result
                result.Children.Add(rectangle_group);

                // Если надо отображать текст, то добавим его
                if (should_draw_label != null && should_draw_label.Equals("true"))
                {
                    // Создадим текст
                    var svg_text_element = add_svg_text_element(xmlnode, name);

                    // Добавляем созданный текст
                    result.Children.Add(svg_text_element);
                }
            }

            // Отрисовка элемента стрелка влево/вправо или двухсторонняя стрелка с текстом
            if (xmlnode["Shape"] == "ArrowLeftRight" || xmlnode["Shape"] == "ArrowLeft" ||
                xmlnode["Shape"] == "ArrowRight")
            {
                // Создадим группу для стрелки (поворот без этого не осуществить)
                var arrow_group = new SvgGroupElement();

                // Создадим List для точек и вычислим их
                var list_points = get_points_list(xmlnode["Shape"], cur_left, cur_right, cur_top, cur_bottom);

                // Рисуем двухстороннюю стрелку
                var arrow = add_svg_left_right_arrow(list_points, xmlnode["LineWidth"], obj_color);

                // Надо ли отображать границу?
                if (xmlnode.ContainsKey("DrawBorder"))
                {
                    // Границу отображать не надо
                    if (xmlnode["DrawBorder"] == "False")
                    {
                        arrow.Stroke = new SvgPaint(Color.Transparent);
                    }
                }

                // Добавим полученную стрелку в группу
                arrow_group.Children.Add(arrow);

                // Добавим угол поворота, если он есть
                if (xmlnode.ContainsKey("Angle") && float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture) != 0.0f)
                {
                    // Вычислим угол поворота
                    var angle_of_rotation = float.Parse(xmlnode["Angle"], CultureInfo.InvariantCulture);
                    var center_x = cur_left + (cur_right - cur_left) / 2;
                    var center_y = cur_top + (cur_bottom - cur_top) / 2;

                    // Добавим угол поворота
                    arrow_group.Transform = new List<SvgTransform>
                    {
                        new SvgRotateTransform()
                        {
                            Angle = new SvgAngle(angle_of_rotation),
                            CenterX = new SvgLength(center_x),
                            CenterY = new SvgLength(center_y)
                        }
                    };
                }

                // Добавляем группу нашей стрелки в группу result
                result.Children.Add(arrow_group);

                // Если надо отображать текст, то добавим его
                if (should_draw_label != null && should_draw_label.Equals("true"))
                {
                    // Создадим текст
                    var svg_text_element = add_svg_text_element(xmlnode, name);

                    // Добавляем созданный текст
                    result.Children.Add(svg_text_element);
                }
            }

            // Отрисовка элемента круг с текстом
            if (xmlnode["Shape"] == "Circle")
            {
                // Рисуем круг
                //TODO() - нарисовать круг
                var circle = new SvgCircleElement();

                // Надо ли отображать границу?
                if (xmlnode.ContainsKey("DrawBorder"))
                {
                    // Границу отображать не надо
                    if (xmlnode["DrawBorder"] == "False")
                    {
                        circle.Stroke = new SvgPaint(Color.Transparent);
                    }
                }

                // Добавляем нарисованный элемент прямоугольника на холст
                result.Children.Add(circle);

                // Если надо отображать текст, то добавим его
                if (should_draw_label != null && should_draw_label.Equals("true"))
                {
                    // Создадим текст
                    var svg_text_element = add_svg_text_element(xmlnode, name);

                    // Добавляем созданный текст
                    result.Children.Add(svg_text_element);
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
        static List<float> get_points_list(string cur_shape, float cur_left, float cur_right, float cur_top, float cur_bottom)
        {
            var result = new List<float>();

            // Зададим всевозможные координаты для двухсторонней стрелки
            // Остриё стрелки справа
            var right_arrowhead_x = cur_right;
            var right_arrowhead_y = cur_top +
                                    (cur_bottom - cur_top) / 2;

            // Верхний угол наконечника стрелки справа
            var right_arrow_top_x = cur_right -
                                    (cur_right - cur_left) / 3;
            var right_arrow_top_y = cur_top;

            // Правый верхний угол прямоугольника стрелки
            var right_arrow_rectangle_top_x = right_arrow_top_x;
            var right_arrow_rectangle_top_y = cur_top +
                                              (cur_bottom - cur_top) / 3;

            // Левый верхний угол прямоугольника стрелки
            var left_arrow_rectangle_top_x = cur_left +
                                             (cur_right - cur_left) / 3;
            var left_arrow_rectangle_top_y = right_arrow_rectangle_top_y;

            // Верхний угол наконечника стрелки справа
            var left_arrow_top_x = left_arrow_rectangle_top_x;
            var left_arrow_top_y = right_arrow_top_y;

            // Остриё стрелки слева
            var left_arrowhead_x = cur_left;
            var left_arrowhead_y = right_arrowhead_y;

            // Нижний угол наконечника стрелки слева
            var left_arrow_bottom_x = left_arrow_rectangle_top_x;
            var left_arrow_bottom_y = cur_bottom;

            // Левый нижний угол прямоугольника стрелки
            var left_arrow_rectangle_bottom_x = left_arrow_rectangle_top_x;
            var left_arrow_rectangle_bottom_y = cur_bottom -
                                                (cur_bottom - cur_top) / 3;

            // Правый нижний угол прямоугольника стрелки
            var right_arrow_rectangle_bottom_x = right_arrow_top_x;
            var right_arrow_rectangle_bottom_y = left_arrow_rectangle_bottom_y;

            // Нижний угол наконечника стрелки справа
            var right_arrow_bottom_x = right_arrow_top_x;
            var right_arrow_bottom_y = left_arrow_bottom_y;

            // Правый верхний угол прямоугольника
            var right_rectangle_top_x = right_arrowhead_x;
            var right_rectangle_top_y = right_arrow_rectangle_top_y;

            // Правый нижний угол прямоугольника
            var right_rectangle_bottom_x = right_arrowhead_x;
            var right_rectangle_bottom_y = right_arrow_rectangle_bottom_y;

            // Левый верхний угол прямоугольника
            var left_rectangle_top_x = left_arrowhead_x;
            var left_rectangle_top_y = left_arrow_rectangle_top_y;

            var left_rectangle_bottom_x = left_arrowhead_x;
            var left_rectangle_bottom_y = left_arrow_rectangle_bottom_y;

            // Если стрелка влево, то добавим нужные координаты 
            if (cur_shape == "ArrowLeft")
            {
                //Добавим нужные координаты
                result.Add(left_arrowhead_x);
                result.Add(left_arrowhead_y);
                result.Add(left_arrow_top_x);
                result.Add(left_arrow_top_y);
                result.Add(left_arrow_rectangle_top_x);
                result.Add(left_arrow_rectangle_top_y);
                result.Add(right_rectangle_top_x);
                result.Add(right_rectangle_top_y);
                result.Add(right_rectangle_bottom_x);
                result.Add(right_rectangle_bottom_y);
                result.Add(left_arrow_rectangle_bottom_x);
                result.Add(left_arrow_rectangle_bottom_y);
                result.Add(left_arrow_bottom_x);
                result.Add(left_arrow_bottom_y);
            }

            // Если стрелка влево, то добавим нужные координаты 
            if (cur_shape == "ArrowRight")
            {
                //Добавим нужные координаты
                result.Add(right_arrowhead_x);
                result.Add(right_arrowhead_y);
                result.Add(right_arrow_top_x);
                result.Add(right_arrow_top_y);
                result.Add(right_arrow_rectangle_top_x);
                result.Add(right_arrow_rectangle_top_y);
                result.Add(left_rectangle_top_x);
                result.Add(left_rectangle_top_y);
                result.Add(left_rectangle_bottom_x);
                result.Add(left_rectangle_bottom_y);
                result.Add(right_arrow_rectangle_bottom_x);
                result.Add(right_arrow_rectangle_bottom_y);
                result.Add(right_arrow_bottom_x);
                result.Add(right_arrow_bottom_y);
            }

            // Если стрелка влево, то добавим нужные координаты 
            if (cur_shape == "ArrowLeftRight")
            {
                //Добавим нужные координаты
                result.Add(right_arrowhead_x);
                result.Add(right_arrowhead_y);
                result.Add(right_arrow_top_x);
                result.Add(right_arrow_top_y);
                result.Add(right_arrow_rectangle_top_x);
                result.Add(right_arrow_rectangle_top_y);
                result.Add(left_arrow_rectangle_top_x);
                result.Add(left_arrow_rectangle_top_y);
                result.Add(left_arrow_top_x);
                result.Add(left_arrow_top_y);
                result.Add(left_arrowhead_x);
                result.Add(left_arrowhead_y);
                result.Add(left_arrow_bottom_x);
                result.Add(left_arrow_bottom_y);
                result.Add(left_arrow_rectangle_bottom_x);
                result.Add(left_arrow_rectangle_bottom_y);
                result.Add(right_arrow_rectangle_bottom_x);
                result.Add(right_arrow_rectangle_bottom_y);
                result.Add(right_arrow_bottom_x);
                result.Add(right_arrow_bottom_y);
            }

            return result;
        }

        //Функция для добалвения стрелки влево или вправо
        static SvgPolygonElement add_svg_left_right_arrow(List<float> points, string width, List<int> obj_color)
        {
            // Создадим полигон из точек
            var all_points = new List<SvgPoint>();
            for (int i = 0; i < points.Count; i += 2)
            {
                all_points.Add(new SvgPoint(new SvgLength(points[i]), new SvgLength(points[i + 1])));
            }

            // Рисуем стрелку влево
            var arrow_left_or_right = new SvgPolygonElement
            {
                // Добавим полигон из точек
                Points = all_points,

                // Задаем ширину обводки
                StrokeWidth = new SvgLength(float.Parse(width, CultureInfo.InvariantCulture)),

                // Задаем цвет внутри стрелки влево полностью прозрачным
                //(alfa = 0, если alfa = 255 - НЕ прозрачный)
                Fill = new SvgPaint(Color.FromArgb(0, 0, 0, 0)),

                // Задаем цвет обводки, который берется с ObjectColor
                Stroke = new SvgPaint(Color.FromArgb(obj_color[0], obj_color[1], obj_color[2], obj_color[3]))
            };

            return arrow_left_or_right;
        }

        //Функция для добавления элемента SvgTextElement
        static SvgTextElement add_svg_text_element(Dictionary<string, string> xmlnode, string? name)
        {
            var cur_text = "";
            // Проверим, есть ли заданное имя или же будем брать значение Default
            if (name != null)
            {
                cur_text = name;
            }
            else
            {
                cur_text = xmlnode["LabelDefaultText"];
            }

            // Получим значения позиции
            var position = xmlnode["LabelPosition"];
            var cur_x = float.Parse(xmlnode["LabelPosition"].Split(",")[0], CultureInfo.InvariantCulture);
            var cur_y = float.Parse(xmlnode["LabelPosition"].Split(",")[1], CultureInfo.InvariantCulture);

            var text = new SvgTextElement
            {
                // Создаем сам текст
                Children =
                {
                    new SvgContentElement
                    {
                        Content = cur_text,
                    },
                },

                // Задаем расположение надписи по формуле согласно заданным координатам
                // TODO() - добавить формулу
                X = new List<SvgLength> { new SvgLength(cur_x) },
                Y = new List<SvgLength> { new SvgLength(cur_y) },

                // Задаем размер текста
                FontSize = new SvgLength((float)Double.Parse(xmlnode["LabelFontSize"])),

                // Задаем стандартный цвет надписи (черный НЕ прозрачный цвет)
                Fill = new SvgPaint(Color.FromArgb(255, 0, 0, 0))
            };

            // Задаем цвет надписи согласно LabelBrush, если такой узел присутствует
            if (xmlnode.ContainsKey("LabelBrush"))
            {
                var label_brush_color = convert_argb(xmlnode["LabelBrush"]);
                text.Fill = new SvgPaint(Color.FromArgb(label_brush_color[0], label_brush_color[1],
                    label_brush_color[2], label_brush_color[3]));
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
        static List<int> convert_argb(string str)
        {
            List<int> result = new List<int>();
            int length = str.Length;
            var color_a = 255;
            var color_r = 0;
            var color_g = 0;
            var color_b = 0;
            // Если пришел формат rgb
            if (length == 7)
            {
                color_r = Convert.ToInt32(str.Substring(1, 2), 16);
                color_g = Convert.ToInt32(str.Substring(3, 2), 16);
                color_b = Convert.ToInt32(str.Substring(5, 2), 16);
            }
            // Если Argb
            else if (length == 9)
            {
                color_a = Convert.ToInt32(str.Substring(1, 2), 16);
                color_r = Convert.ToInt32(str.Substring(3, 2), 16);
                color_g = Convert.ToInt32(str.Substring(5, 2), 16);
                color_b = Convert.ToInt32(str.Substring(7, 2), 16);
            }

            result.Add(color_a);
            result.Add(color_r);
            result.Add(color_g);
            result.Add(color_b);
            return result;
        }

        // Функция для парсинга элемента с ToolId = "StandardLibrary.Lamp"
        static Dictionary<string, string> parser_Lamp(XmlNode current_xmlnode)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            // Получим дочерний узел Properties
            XmlNode? properties = current_xmlnode.SelectSingleNode("Properties");

            // Разбираемся с узлом Properties
            XmlNodeList? properties_nodes = properties?.SelectNodes("*");
            if (properties_nodes != null)
            {
                foreach (XmlNode properties_node in properties_nodes)
                {
                    // Найдем текущие значения
                    var name = properties_node.SelectSingleNode("Name")?.InnerText;
                    var value = properties_node.SelectSingleNode("Value")?.InnerText;

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