using System.Xml;

namespace SvgConverter
{
    public static class Converter
    {
        private static readonly ISvgConvertOptions Defaults = new DefaultConvertOptions();

        public static string FromXml(string xml, ISvgConvertOptions options)
        {
            // Если нет опций -> возьмём их DefaultConvertOptions
            options ??= Defaults;

            // создаем объект класса XmlDocument
            var xmlDoc = new XmlDocument();

            // загрузим в созданный объект наш XML-документ
            xmlDoc.LoadXml(xml);

            // Вызовем функцию конвертора
            var result = XmlParser.CreateSvgDocument(xmlDoc, options);

            return result;
        }
    }
}