using System.Collections.Generic;
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

            // Создаем холст для рисования (Итоговый Svg файл будет здесь)
            var svgDoc = new GcSvgDocument();
            // TODO - добавить вычисление по формуле
            svgDoc.RootSvg.Width = new SvgLength(4000, SvgLengthUnits.Pixels);
            svgDoc.RootSvg.Height = new SvgLength(2000, SvgLengthUnits.Pixels);

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
                var valueTollId = xmlNode.Attributes?["ToolId"]?.InnerText;

                // Получим Dictionary, состоящий из свойств текущего элемента
                
                SvgElement element = null;
                
                // Получим Dictionary, состоящий из свойств текущего элемента
                var dictionaryPropertiesFromCurrentNode = CreateDictionaryFromProperties(xmlNode);
                
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
                ["Label"] = currentXmlNode.SelectSingleNode("Label")?.InnerText,
                ["ShouldDrawLabel"] = currentXmlNode.SelectSingleNode("ShouldDrawLabel")?.InnerText,
                ["ToolId"] = currentXmlNode.Attributes?["ToolId"]?.InnerText,
                ["ClientId"] = currentXmlNode.Attributes?["ClientId"]?.InnerText
            };

            // Получим дочерний узел Properties
            var properties = currentXmlNode.SelectSingleNode("Properties");

            // Разбираемся с узлом Properties
            var propertiesNodes = properties?.SelectNodes("*");

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
    }
}