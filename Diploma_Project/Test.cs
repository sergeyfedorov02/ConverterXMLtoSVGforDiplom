// ReSharper disable All

using System.Xml;
using static Diploma_Project.Person;
using System.Xml.Linq;

namespace Diploma_Project;

using GrapeCity.Documents.Imaging;
using GrapeCity.Documents.Svg;
using System.Drawing;

public class Test
{
    internal static void test()
    {
        // Достаточно хорошее чтение с заданием именем элементов нашего xml-файла
        //XML_Element_reader(@"C:\Users\fsergey\RiderProjects\Diploma_Project\Diploma_Project\Person.xml");

        // Для большого файла, разобраны все случаи
        //XML_reader(@"C:\Users\fsergey\RiderProjects\Diploma_Project\Diploma_Project\Person.xml");
        //XML_reader(@"C:\Users\fsergey\RiderProjects\Diploma_Project\Diploma_Project\items.xml");

        // Для чтения при помощи URL на xml файл
        //URL_XML_reader("https://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
        Console.WriteLine("Hello, World!");

        // тип int (целые положиектльные, отрицательные и ноль)
        int int_number = Int32.MinValue;
        Console.WriteLine("Переменная типа int =  " + int_number);

        // тип данных только для положительных чисел
        uint uint_number = 5;
        Console.WriteLine("Переменная типа uint =  " + uint_number +
                          ", которая может быть только положительным числом");

        // Тоже самое, что и int, но нельзя хранить значения больше 255
        // Это тип данных затрачивает в 4 раза меньше Операционной памяти, чем integer
        byte byte_number = 255;
        Console.WriteLine("Переменная типа byte =  " + byte_number +
                          ", значение которой может быть только в диапазоне от 0 до 255");

        // Тоже самое, что и byte, но расширен диапазон от [-32768; 32767]
        // Используем в 2 раза больше Операционной памяти, чем в byte
        short short_number = 32767;
        Console.WriteLine("Переменная типа short =  " + short_number +
                          ", значение которой может быть только в диапазоне от -32768 до 32767");

        // Для сверхбольших чисел
        long long_number = long.MinValue;
        Console.WriteLine("Переменная типа long =  " + long_number + ", используемая для сверхбольших чисел");

        // Аналог uint, только для типа Long
        ulong ulong_number = long.MaxValue;
        Console.WriteLine("Переменная типа ulong =  " + ulong_number +
                          ", используемая для сверхбольших Положительных чисел");

        // Дробные значения
        float float_number = 4.5555f;
        Console.WriteLine("Переменная типа float =  " + float_number +
                          ", используемая для дробных чисел, имеет не большой диапазон и требует указания f в конце числа");

        // Расширение диапазона представления дробных чисел
        double double_number = Double.MinValue;
        Console.WriteLine("Переменная типа float =  " + double_number + ", используемая для больших дробных чисел");

        // Для хранения строк
        string word = "Всем Привет!";
        Console.WriteLine("Переменная типа string =  " + word);

        // Для хранения 1 символа
        char symbol = '1';
        Console.WriteLine("Переменная типа char =  " + symbol);

        // Булевский тип, который принимает true или false
        bool isHappy = true;
        if (isHappy)
            Console.WriteLine("Переменная типа bool =  true");
        else
            Console.WriteLine("Переменная типа bool =  false");

        // Получим некое значение от пользователя
        Console.Write("Введите любое целое число: ");
        // При получении значения из консоли там будет строка, поэтому следует ее конвертировать в нужный нам тип данных
        int user_number = Convert.ToInt32(Console.ReadLine());
        Console.Write("Теперь введите какой-либо текст: ");
        string? user_word = Console.ReadLine();


        List<Person> employees = new List<Person>
        {
            new Person("Tom", 37, "Microsoft"),
            new Person("Bob", 41, "Google")
        };

        string first = employees[0].Name;
        employees[0].Age = 25;
        int second = employees[0].Age;
        employees[1].Company = "Politech";
        string third = employees[0].Company;

        int x = 3;
        double y = Math.Pow(x, 2);

        Console.WriteLine("{0} ^ 2 = {1}", x, y);
    }

    // Функция для чтения при помощи URL на xml файл
    internal static void URL_XML_reader(string url_name)
    {
        XmlReader xmlReader = XmlReader.Create(url_name);
        while (xmlReader.Read())
        {
            if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Cube"))
            {
                if (xmlReader.HasAttributes)
                    Console.WriteLine(xmlReader.GetAttribute("currency") + ": " + xmlReader.GetAttribute("rate"));
            }
        }

        Console.Write("\n\n\n");
    }

    // Первый способ с использованием FileStream
    /*using var zipStream = new FileStream(archivePath, FileMode.Open) ;
    using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
    {
        foreach (var entry in archive.Entries)
        {
            if (entry.FullName.Equals(String.Format("chart_{0}.chr", chr_number)))
            {
                using (var stream = entry.Open())
                using (var reader = new StreamReader(stream))
                {
                    string? new_line;
                    StreamWriter writer = new StreamWriter(@"C:\Users\fsergey\RiderProjects\Diploma_Project\Diploma_Project\chart.xml", true);
                    while ((new_line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(new_line);
                        // добавление в файл
                        writer.WriteLine(new_line);
                    }
                    writer.Close();
                }    
            }
        }
    }*/

    static Dictionary<string, List<Dictionary<string, string>>> parser_Lamp_test(XmlNode current_xmlnode)
    {
        Dictionary<string, List<Dictionary<string, string>>> result =
            new Dictionary<string, List<Dictionary<string, string>>>();

        // Получим все интересующие нас дочерние узлы
        XmlNode? label = current_xmlnode.SelectSingleNode("Label");
        XmlNode? should_draw_label = current_xmlnode.SelectSingleNode("ShouldDrawLabel");
        XmlNode? properties = current_xmlnode.SelectSingleNode("Properties");
        XmlNode? connections = current_xmlnode.SelectSingleNode("Connections");

        // Получим значения для узлов Label и ShouldDrawLabel
        String? label_value = label?.InnerText;
        String? should_draw_label_value = should_draw_label?.InnerText;

        // Добавим в result Label и ShouldDrawLabel
        result.Add("Label",
            new List<Dictionary<string, string>>()
                { new Dictionary<string, string>() { { "Value", label_value } } });
        result.Add("ShouldDrawLabel",
            new List<Dictionary<string, string>>()
                { new Dictionary<string, string>() { { "Value", should_draw_label_value } } });

        // Разбираемся с узлом Properties
        XmlNodeList? properties_nodes = properties?.SelectNodes("*");
        List<Dictionary<string, string>> properties_list = new List<Dictionary<string, string>>();
        foreach (XmlNode properties_node in properties_nodes)
        {
            // Найдем текущие значения
            String? name = properties_node.SelectSingleNode("Name")?.InnerText;
            String? value = properties_node.SelectSingleNode("Value")?.InnerText;
            String? type = properties_node.SelectSingleNode("Type")?.InnerText;

            // Добавим найденные значения в новый Dictionary
            Dictionary<string, string> current_properties = new Dictionary<string, string>();
            current_properties.Add("Name", name);
            current_properties.Add("Value", value);
            current_properties.Add("Type", type);

            //Добавим полученный Dictionary в result
            properties_list.Add(current_properties);
        }

        result.Add("Properties", properties_list);

        // Проверим Connections и добавим их в result
        if (connections.InnerText == "")
        {
            result.Add("Connections",
                new List<Dictionary<string, string>>()
                    { new Dictionary<string, string>() { { "Value", null } } });
        }

        return result;
    }

    // Если нужно прочитать xml файл большого размера, и не хочется загружать весь этот файл в память,
    // то нужно использовать XmlReader. Этот класс позволяет читать XML в манере близкой к SAX.
    // Итератор пробегает по всем элементам дерева, а пользователю нужно определить как обрабатывать каждый из таких элементов
    static void XML_reader(string filename)
    {
        XmlTextReader? reader = null;

        try
        {
            // Загружаем в reader наш файл и игнорируем все пустые строки
            reader = new XmlTextReader(filename);
            reader.WhitespaceHandling = WhitespaceHandling.None;

            // Разбор каждого из узлов файла.
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    // Нашлелся элемент (его блок)
                    case XmlNodeType.Element:
                        Console.Write("<{0}>", reader.Name);
                        break;

                    // Нашлось поле нашего элемента и мы распечатаем название этого поля
                    case XmlNodeType.Text:
                        Console.Write(reader.Value);
                        break;

                    // Значение задано в виде даты
                    case XmlNodeType.CDATA:
                        Console.Write("<![CDATA[{0}]]>", reader.Value);
                        break;

                    //...
                    case XmlNodeType.ProcessingInstruction:
                        Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                        break;

                    // Строка является комментарием
                    case XmlNodeType.Comment:
                        Console.Write("<!--{0}-->", reader.Value);
                        break;

                    // Строка объявления нашего файла с указанием версии, кодировки и т.д.
                    case XmlNodeType.XmlDeclaration:
                        Console.WriteLine("<?xml {0}?>", reader.Value);
                        break;

                    //...
                    case XmlNodeType.Document:
                        break;

                    // Строка с указанием типа документа
                    case XmlNodeType.DocumentType:
                        Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                        break;

                    // Ссылка на сущность
                    case XmlNodeType.EntityReference:
                        Console.Write(reader.Name);
                        break;

                    // Блок элемента завершился
                    case XmlNodeType.EndElement:
                        Console.Write("</{0}>", reader.Name);
                        break;
                }
            }
        }

        finally
        {
            if (reader != null)
                reader.Close();
        }

        Console.Write("\n\n\n");
    }

    // Достаточно хорошее чтение с заданием именем элементов нашего xml-файла
    static void XML_Element_reader(string filename)
    {
        // Используем using для создания переменной, чтобы после обработки кода с ее использованием сборщиком мусор мы сразу ее убрали
        using (var xmlReader = XmlReader.Create(filename))
        {
            while (xmlReader.Read())
            {
                if (xmlReader.ReadToFollowing("person"))
                {
                    XmlReader personSubtree = xmlReader.ReadSubtree();
                    XElement personElement = XElement.Load(personSubtree);
                    // здесь обрабатываем personElement
                    Console.WriteLine("<{0} {1}>", personElement.Name.LocalName, personElement.FirstAttribute);
                }
            }
        }

        Console.Write("\n\n\n");
    }

    static void XML_string_reader(string xml_line, Dictionary<string, int> attribute_dictionary)
    {
        var new_line = xml_line.TrimStart(' ');
        XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(new_line));
        reader.Read();
        switch (reader.NodeType)
        {
            // Нашлелся элемент (его блок)
            case XmlNodeType.Element:
                string? current_attribute = reader.GetAttribute("ToolId");
                if (current_attribute != null)
                {
                    if (attribute_dictionary.ContainsKey(current_attribute))
                    {
                        attribute_dictionary[current_attribute]++;
                    }
                    else
                    {
                        attribute_dictionary.Add(current_attribute, 1);
                    }
                }

                Console.Write("<{0}>", reader.Name);
                break;
            // Нашлось поле нашего элемента и мы распечатаем название этого поля
            case XmlNodeType.Text:
                Console.Write(reader.Value);
                break;

            // Значение задано в виде даты
            case XmlNodeType.CDATA:
                Console.Write("<![CDATA[{0}]]>", reader.Value);
                break;

            //...
            case XmlNodeType.ProcessingInstruction:
                Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                break;

            // Строка является комментарием
            case XmlNodeType.Comment:
                Console.Write("<!--{0}-->", reader.Value);
                break;

            // Строка объявления нашего файла с указанием версии, кодировки и т.д.
            case XmlNodeType.XmlDeclaration:
                Console.WriteLine("<?xml {0}?>", reader.Value);
                break;

            //...
            case XmlNodeType.Document:
                break;

            // Строка с указанием типа документа
            case XmlNodeType.DocumentType:
                Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                break;

            // Ссылка на сущность
            case XmlNodeType.EntityReference:
                Console.Write(reader.Name);
                break;

            // Блок элемента завершился
            case XmlNodeType.EndElement:
                Console.Write("</{0}>", reader.Name);
                break;
        }
    }
    static void create_svg()
        {
            var svgDoc = new GcSvgDocument();
            svgDoc.RootSvg.Width = new SvgLength(250, SvgLengthUnits.Pixels);
            svgDoc.RootSvg.Height = new SvgLength(150, SvgLengthUnits.Pixels);

            //Outer circle using Ellipse Element 
            var outerCircle = new SvgEllipseElement()
            {
                CenterX = new SvgLength(160, SvgLengthUnits.Pixels),
                CenterY = new SvgLength(92, SvgLengthUnits.Pixels),
                RadiusX = new SvgLength(90, SvgLengthUnits.Pixels),
                RadiusY = new SvgLength(80, SvgLengthUnits.Pixels),
                Fill = new SvgPaint(Color.FromArgb(81, 59, 116)),
                Stroke = new SvgPaint(Color.FromArgb(81, 59, 116))
            };

            //Inner cirlce using Circle Element
            var innerCircle = new SvgCircleElement()
            {
                CenterX = new SvgLength(160, SvgLengthUnits.Pixels),
                CenterY = new SvgLength(92, SvgLengthUnits.Pixels),
                Radius = new SvgLength(45, SvgLengthUnits.Pixels),
                Fill = new SvgPaint(Color.White),
                Stroke = new SvgPaint(Color.FromArgb(81, 59, 116))
            };


            //Configure Path builder to draw the left and right side logo handles
            var pb = new SvgPathBuilder();

            pb.AddMoveTo(false, 8, 121);
            pb.AddLineTo(false, 297, 25);
            pb.AddLineTo(false, 314, 68);
            pb.AddLineTo(false, 23, 164);
            pb.AddLineTo(false, 8, 121);
            pb.AddClosePath();

            var handles = new SvgPathElement()
            {
                PathData = pb.ToPathData(),
                Fill = new SvgPaint(Color.FromArgb(81, 59, 116)),
            };

            svgDoc.RootSvg.Children.Insert(0, handles);
            svgDoc.RootSvg.Children.Insert(1, outerCircle);
            svgDoc.RootSvg.Children.Insert(2, innerCircle);

            SvgViewBox view = new SvgViewBox();
            view.MinX = 0;
            view.MinY = 0;
            view.Width = 320;
            view.Height = 175;

            svgDoc.RootSvg.ViewBox = view;

            svgDoc.Save("D:\\Imsat\\svg_images\\Logo.svg");
        }
}