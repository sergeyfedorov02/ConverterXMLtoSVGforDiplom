using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class XmlParser
    {
        public static string CreateSvgDocument(XmlDocument docXml, ISvgConvertOptions options)
        {
            // Найдем все узлы с именем "DesignerItem"
            var nodeList = docXml.GetElementsByTagName("DesignerItem");

            // Если ничего не нашли -> выходим
            if (nodeList.Count == 0)
            {
                return "";
            }

            // Создаем холст для рисования (Итоговый Svg файл будет здесь)
            var svgDoc = new GcSvgDocument();

            // Задаем начальные размеры поля
            var maxRightValue = 0f;
            var maxBottomValue = 0f;
            svgDoc.RootSvg.ViewBox = new SvgViewBox(0, 0, maxRightValue + 20, maxBottomValue + 20);

            // Добавим параметр стандартного шрифта
            svgDoc.RootSvg.FontFamily = new List<SvgFontFamily>
            {
                new SvgFontFamily("Segoe UI")
            };

            // для проверки на наличие всех элементов TODO - потом надо убрать
            var defaultList = new List<string>();

            // Создадим главную группу, которая будет содержать все элементы
            var mainGroup = new SvgGroupElement
            {
                FillOpacity = 0,
                Class = "main-panel",
                CustomAttributes = new List<SvgCustomAttribute>
                {
                    new SvgCustomAttribute("data-first-color", "0")
                }
            };

            // Пройдемся по всем полученным узлам
            foreach (XmlNode xmlNode in nodeList)
            {
                // Получим значение атрибута с именем "ToolId"
                var valueTollId = xmlNode.Attributes?["ToolId"] == null
                    ? string.Empty
                    : xmlNode.Attributes["ToolId"].InnerText;

                // Если атрибута с именем "ToolId" не оказалось, то ничего не делаем и переходим к следующему xmlNode
                if (valueTollId.Equals(string.Empty))
                {
                    continue;
                }

                // Переменная, которой будем присваивать значение нарисованной группы элементов
                SvgElement element = null;

                // Получим Dictionary, состоящий из свойств текущего элемента
                var dictionaryPropertiesFromCurrentNode = CreateDictionaryFromProperties(xmlNode);

                // Для обновления размеров поля вычислим координаты правого и нижнего краев
                var currentValues = GetCurrentRightBottomValues(dictionaryPropertiesFromCurrentNode);

                // Если координаты больше текущих(максимальных), то обновим максимальные
                if (currentValues[0] > maxRightValue)
                {
                    maxRightValue = currentValues[0];
                }

                if (currentValues[1] > maxBottomValue)
                {
                    maxBottomValue = currentValues[1];
                }

                // В зависимости от полученного имени нарисуем соответствующий элемент
                switch (valueTollId)
                {
                    case "StandardLibrary.Lamp":
                        // Нарисуем элемент типа "StandardLibrary.Lamp"
                        element = CreateLamp.CreateSvgImageLamp(dictionaryPropertiesFromCurrentNode);
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

                    case "StandardLibrary.Measure":
                        break;

                    // Если чего-то сверху не рассмотрели TODO - потом убрать
                    default:
                        if (!defaultList.Contains(valueTollId))
                        {
                            defaultList.Add(valueTollId);
                        }

                        break;
                }

                if (element != null)
                {
                    // Добавим новую группу из элементов в mainGroup
                    mainGroup.Children.Add(element);
                }
            }

            // Обновим значение ViewBox (зададим правый край по координате правого края самой правой фигуры + 20 и также с нижним краем)
            svgDoc.RootSvg.ViewBox = new SvgViewBox(0, 0, maxRightValue + 20, maxBottomValue + 20);

            // Добавим нарисованный элемент mainGroup на холст
            svgDoc.RootSvg.Children.Add(mainGroup);

            // Чего-то забыли рассмотреть TODO - потом убрать
            if (defaultList.Count != 0)
            {
                return defaultList.Aggregate("", (current, element) => current + element + " ");
            }

            // Выдадим полученный svgDoc в string формате
            var sb = new StringBuilder();
            svgDoc.Save(sb);
            return sb.ToString();
        }

        // Функция для получения Dictionary из свойств элемента (из Properties: name и value)
        private static Dictionary<string, string> CreateDictionaryFromProperties(XmlNode currentXmlNode)
        {
            var result = new Dictionary<string, string>
            {
                // Добавим ToolId, ClientId, Label и ShouldDrawLabel в result
                ["Label"] = currentXmlNode.SelectSingleNode("Label")?.InnerText ?? string.Empty,
                ["ShouldDrawLabel"] = currentXmlNode.SelectSingleNode("ShouldDrawLabel")?.InnerText ?? "false",
                ["ToolId"] = currentXmlNode.Attributes?["ToolId"].InnerText,
                ["ClientId"] = currentXmlNode.Attributes?["ClientId"] == null
                    ? "0"
                    : currentXmlNode.Attributes["ClientId"].InnerText
            };

            // Получим дочерний узел Properties
            var properties = currentXmlNode.SelectSingleNode("Properties");

            // Если узла "Properties" не существует -> вернём result
            if (properties == null) return result;

            // Разбираемся с узлом Properties
            var propertiesNodes = properties.SelectNodes("*");

            // Если узел Properties ничего не содержит -> вернём пустой result
            if (propertiesNodes == null) return result;

            // Иначе разберемся с содержимым
            foreach (XmlNode propertiesNode in propertiesNodes)
            {
                // Найдем текущие значения
                var name = propertiesNode.SelectSingleNode("Name")?.InnerText;
                var aValue = propertiesNode.SelectSingleNode("Value")?.InnerText;

                // Добавим найденные значения в result
                if (name != null && aValue != null)
                {
                    result[name] = aValue;
                }
            }

            return result;
        }

        // Дополнительная функция для вычисления размеров поля
        private static List<float> GetCurrentRightBottomValues(IReadOnlyDictionary<string, string> currentDictionary)
        {
            var result = new List<float>();

            var valueRight = currentDictionary.TryGetValue("Right", out var right) ? right : "";
            var valueLeft = currentDictionary.TryGetValue("Left", out var left) ? left : "";

            var valueBottom = currentDictionary.TryGetValue("Bottom", out var bottom) ? bottom : "";
            var valueTop = currentDictionary.TryGetValue("Top", out var top) ? top : "";

            var valueStart = currentDictionary.TryGetValue("Start", out var start) ? start : "";
            var valueEnd = currentDictionary.TryGetValue("OffsetEnd", out var end) ? end : "";

            var curRight = 0f;
            var curBottom = 0f;

            if (valueRight != "")
            {
                curRight = float.Parse(float.Parse(valueRight, CultureInfo.InvariantCulture) >
                                       float.Parse(valueLeft, CultureInfo.InvariantCulture)
                    ? valueRight
                    : valueLeft, CultureInfo.InvariantCulture);

                curBottom = float.Parse(float.Parse(valueBottom, CultureInfo.InvariantCulture) >
                                        float.Parse(valueTop, CultureInfo.InvariantCulture)
                    ? valueBottom
                    : valueTop, CultureInfo.InvariantCulture);
            }

            else if (valueStart != "")
            {
                var curLeft = valueStart.Split(",")[0];

                curRight = float.Parse(valueEnd, CultureInfo.InvariantCulture) > 0f
                    ? float.Parse(curLeft, CultureInfo.InvariantCulture) +
                      float.Parse(valueEnd, CultureInfo.InvariantCulture)
                    : float.Parse(curLeft, CultureInfo.InvariantCulture);

                curBottom = float.Parse(valueStart.Split(",")[1], CultureInfo.InvariantCulture);
            }

            result.Add(curRight);
            result.Add(curBottom);

            return result;
        }
    }
}