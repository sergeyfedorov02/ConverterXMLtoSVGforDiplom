using System.IO;
using System.Reflection;
using System.Xml;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SvgConverter;
using System;

namespace Tests
{
    public class ConverterTest
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

        [Test]
        public void SimpleConvertTest()
        {
            var options = new Mock<ISvgConvertOptions>();
            options.Setup(t => t.AddTitles).Returns(true);
            options.Setup(t => t.GetTitleForObject(It.IsAny<long>())).Returns("комментарий");

            var xml = GetXmlResource("Converter.singleLamp.chr");
            var svgDoc = Converter.FromXml(xml, options.Object);

            var doc = new XmlDocument();
            doc.LoadXml(svgDoc);

            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("x", "http://www.w3.org/2000/svg");

            // Получение группы main-panel
            var mainPanelGroup = doc.SelectSingleNode($"/x:svg/x:g[@class='main-panel']", ns);

            // Получение группы определённого элемента
            var lampElement = "StandardLibrary.Lamp";
            var currentGroup =
                doc.SelectSingleNode($"/x:svg/x:g[@class='main-panel']/x:g[@data-object-type='{lampElement}']", ns);
            currentGroup.Should().NotBeNull();

            // Получение атрибутов текущей группы (верхний уровень)
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();

            // Получение значения атрибута по его имени
            var attributeValueByName = attributes!.GetNamedItem("data-state")!.Value;
            attributeValueByName.Should().NotBeNull();

            // Получение дочернего элемента по его имени
            var elementByName = currentGroup.SelectSingleNode("x:title", ns);
            elementByName.Should().NotBeNull();

            // Проверка содержимого первого дочернего элемента (это элемент Title)
            var titleElement = currentGroup.ChildNodes[0];
            titleElement.Should().NotBeNull();
            Assert.AreEqual(titleElement!.InnerText, "комментарий");
        }

        [Test]
        public void EmptyNodeListTest()
        {
            var xml = GetXmlResource("Converter.emptyNodeList.chr");
            var svgDoc = Converter.FromXml(xml, null);
            svgDoc.Should().Be("");
        }

        [Test]
        public void EmptyToolIdTest()
        {
            var xml = GetXmlResource("Converter.emptyToolId.chr");
            var svgDoc = Converter.FromXml(xml, null);
            svgDoc.Should().NotBeNull();

            var doc = new XmlDocument();
            doc.LoadXml(svgDoc);

            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("x", "http://www.w3.org/2000/svg");

            var mainPanelGroup = doc.SelectSingleNode($"/x:svg/x:g[@class='main-panel']", ns);
            mainPanelGroup.Should().NotBeNull();
            mainPanelGroup!.ChildNodes.Count.Should().Be(0);

            var attributes = mainPanelGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataFirstColor = attributes!.GetNamedItem("data-first-color")!.Value;
            dataFirstColor.Should().NotBeNull();
            dataFirstColor.Should().Be("0");
        }

        [Test]
        public void EmptyPropertiesTest()
        {
            // Узла Properties нет в документе
            var xml = GetXmlResource("Converter.emptyPropertiesFull.chr");
            var svgDoc = Converter.FromXml(xml, null);
            svgDoc.Should().NotBeNull();

            var doc = new XmlDocument();
            doc.LoadXml(svgDoc);

            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("x", "http://www.w3.org/2000/svg");

            var mainPanelGroup = doc.SelectSingleNode($"/x:svg/x:g[@class='main-panel']", ns);
            mainPanelGroup.Should().NotBeNull();
            mainPanelGroup!.ChildNodes.Count.Should().Be(0);

            // Properties существует, но там ничего нет
            xml = GetXmlResource("Converter.emptyProperties.chr");
            svgDoc = Converter.FromXml(xml, null);
            svgDoc.Should().NotBeNull();

            doc = new XmlDocument();
            doc.LoadXml(svgDoc);

            mainPanelGroup = doc.SelectSingleNode($"/x:svg/x:g[@class='main-panel']", ns);
            mainPanelGroup.Should().NotBeNull();
            mainPanelGroup!.ChildNodes.Count.Should().Be(0);
        }

        [Test]
        public void SvgAttributesTest()
        {
            var xml = GetXmlResource("Converter.svgAttributes.chr");
            var svgDoc = Converter.FromXml(xml, null);
            svgDoc.Should().NotBeNull();

            var doc = new XmlDocument();
            doc.LoadXml(svgDoc);

            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("x", "http://www.w3.org/2000/svg");

            var svgGroup = doc.SelectSingleNode($"/x:svg", ns);
            svgGroup.Should().NotBeNull();
            svgGroup!.ChildNodes.Count.Should().Be(1);

            var attributes = svgGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var xmlns = attributes!.GetNamedItem("xmlns")!.Value;
            xmlns.Should().NotBeNull();
            xmlns.Should().Be("http://www.w3.org/2000/svg");

            var width = attributes!.GetNamedItem("width")!.Value;
            width.Should().NotBeNull();
            width.Should().Be("1600");

            var height = attributes!.GetNamedItem("height")!.Value;
            height.Should().NotBeNull();
            height.Should().Be("900");

            var fontFamily = attributes!.GetNamedItem("font-family")!.Value;
            fontFamily.Should().NotBeNull();
            fontFamily.Should().Be("Segoe UI");

            var viewBox = attributes!.GetNamedItem("viewBox")!.Value;
            viewBox.Should().NotBeNull();
            viewBox.Should().Be("0 0 506.721 343");

            var version = attributes!.GetNamedItem("version")!.Value;
            version.Should().NotBeNull();
            version.Should().Be("1.1");
        }

        [Test]
        public void CreateTextTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Converter.createText.chr", "StandardLibrary.Lamp");
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(4);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-1");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=Triangle");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var polygonElement = currentGroup.SelectSingleNode("x:polygon", ns);
            polygonElement.Should().NotBeNull();
            polygonElement!.Attributes.Should().NotBeNull();
            polygonElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            polygonElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            polygonElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polygonElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");
            polygonElement!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("415.556,323 430.556,293 445.556,323");
            polygonElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-308.0683 430.556,308)");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("треугольник");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("276.1811");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("309.2938");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("font-style")!.Value.Should().Be("normal");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#EE82EE");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void GetColorTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Converter.getColor.chr", "StandardLibrary.Lamp");
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(4);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-1");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=Triangle");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var polygonElement = currentGroup.SelectSingleNode("x:polygon", ns);
            polygonElement.Should().NotBeNull();
            polygonElement!.Attributes.Should().NotBeNull();
            polygonElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            polygonElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            polygonElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polygonElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");
            polygonElement!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("415.556,323 430.556,293 445.556,323");
            polygonElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-308.0683 430.556,308)");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("треугольник");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("276.1811");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("309.2938");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("font-style")!.Value.Should().Be("italic");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#EE82EE");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}