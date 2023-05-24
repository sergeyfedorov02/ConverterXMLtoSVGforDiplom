using System;
using System.IO;
using System.Reflection;
using System.Xml;
using SvgConverter;

namespace Tests
{
    internal static class StandardFunctions
    {
        private static string GetXmlResource(string resourceName)
        {
            return System.Text.Encoding.UTF8.GetString(GetResource(resourceName));
        }

        private static byte[] GetResource(string resourceName)
        {
            var resourcePath = $"Tests.Resources.{resourceName}";
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);

            if (resourceStream == null)
            {
                return null;
            }

            using var memStream = new MemoryStream();

            resourceStream.CopyTo(memStream);
            var key = memStream.ToArray();
            return key;
        }
        
        internal static Tuple<XmlNode, XmlNamespaceManager> GetCurrentGroup(string resourceName, string objectType)
        {
            // Получение XML документа по имени ресурса
            var xml = GetXmlResource(resourceName);

            // Получение результата работы основной программы конвертации в виде SVG документа
            var svgDoc = Converter.FromXml(xml, null);
            var doc = new XmlDocument();
            doc.LoadXml(svgDoc);

            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("x", "http://www.w3.org/2000/svg");

            // Получение группы определённого элемента по его "objectType"
            var currentGroup =
                doc.SelectSingleNode($"/x:svg/x:g[@class='main-panel']/x:g[@data-object-type='{objectType}']", ns);

            return Tuple.Create(currentGroup, ns);
        }
    }
}