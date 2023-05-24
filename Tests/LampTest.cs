using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class LampTest
    {
        private const string LampElementName = "StandardLibrary.Lamp";
        
        [Test]
        public void EmptyRectangleBoundsTest()
        {
            var (currentGroup, _) = StandardFunctions.GetCurrentGroup("Lamps.emptyRectangleLeft.chr", LampElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) = StandardFunctions.GetCurrentGroup("Lamps.emptyRectangleRight.chr", LampElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) = StandardFunctions.GetCurrentGroup("Lamps.emptyRectangleTop.chr", LampElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) = StandardFunctions.GetCurrentGroup("Lamps.emptyRectangleBottom.chr", LampElementName);
            currentGroup.Should().BeNull();
        }
        
        [Test]
        public void RectangleTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.rectangle.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            // Получение атрибутов текущей группы (верхний уровень)
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            // Получение значения атрибута по его имени
            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=Rectangle");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            // Проверка содержимого дочерних элементов
            var rectangleElement = currentGroup.SelectSingleNode("x:rect", ns);
            rectangleElement.Should().NotBeNull();
            rectangleElement!.Attributes.Should().NotBeNull();
            rectangleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            rectangleElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-334.11 638.5,163.5)");
            rectangleElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("441.5");
            rectangleElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("98");
            rectangleElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("394");
            rectangleElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("131");
            rectangleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            rectangleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            rectangleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Прямоугольник");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("545.403");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("154.7155");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("24");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#FF8C00");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RectangleRoundTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.rectangleRound.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=RoundRectangle");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var rectangleElement = currentGroup.SelectSingleNode("x:rect", ns);
            rectangleElement.Should().NotBeNull();
            rectangleElement!.Attributes.Should().NotBeNull();
            rectangleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            rectangleElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("412.5");
            rectangleElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("805");
            rectangleElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("412.5");
            rectangleElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("116.25");
            rectangleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            rectangleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            rectangleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Перевернутый прямоугольник");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("459.445");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("861.016");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#8B0000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RectangleWithoutDrawBorderTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.rectangleWithoutDrawBorder.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=Rectangle");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=False");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var rectangleElement = currentGroup.SelectSingleNode("x:rect", ns);
            rectangleElement.Should().NotBeNull();
            rectangleElement!.Attributes.Should().NotBeNull();
            rectangleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            rectangleElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("419.5");
            rectangleElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("971.633");
            rectangleElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("394");
            rectangleElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("130.9999");
            rectangleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            rectangleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            rectangleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Прямоугольник без границы");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("475.403");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1028.349");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("24");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#FF6347");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }


        [Test]
        public void TriangleTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.triangle.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

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

        [Test]
        public void TriangleRotateTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.triangleRotated.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

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
                .Be("399.552,421.389 431.054,360 462.556,421.389");
            polygonElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-40.008 431.054,390.694)");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Треугольник перевернутый");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("227.815");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("379.769");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("13");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#228B22");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void TriangleObtuseTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.triangleObtuse.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

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
                .Be("901.219,632.5 996.219,602.5 1091.219,632.5");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("тупоугольный треугольник");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("862.539");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("665.183");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#191970");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void CircleTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.circle.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=Circle");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var circleElement = currentGroup.SelectSingleNode("x:circle", ns);
            circleElement.Should().NotBeNull();
            circleElement!.Attributes.Should().NotBeNull();
            circleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            circleElement!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("1069.792");
            circleElement!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("221.25");
            circleElement!.Attributes!.GetNamedItem("r")!.Value.Should().Be("73.125");
            circleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            circleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            circleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Круг");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1046.945");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("221.8493");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#6B3839");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void CircleReverseTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.circleReverse.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=Circle");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var circleElement = currentGroup.SelectSingleNode("x:circle", ns);
            circleElement.Should().NotBeNull();
            circleElement!.Attributes.Should().NotBeNull();
            circleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            circleElement!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("1079.984");
            circleElement!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("459.375");
            circleElement!.Attributes!.GetNamedItem("r")!.Value.Should().Be("77.2917");
            circleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            circleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            circleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Круг перевернутый");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("981.528");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("354.349");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#FF6347");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void CircleWithoutTextTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.circleWithoutText.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=Circle");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(1);

            var circleElement = currentGroup.SelectSingleNode("x:circle", ns);
            circleElement.Should().NotBeNull();
            circleElement!.Attributes.Should().NotBeNull();
            circleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            circleElement!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("1382.042");
            circleElement!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("320.717");
            circleElement!.Attributes!.GetNamedItem("r")!.Value.Should().Be("73.125");
            circleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            circleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            circleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().BeNull();
        }

        [Test]
        public void ArrowLeftTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.arrowLeft.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=ArrowLeft");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var polygonElement = currentGroup.SelectSingleNode("x:polygon", ns);
            polygonElement.Should().NotBeNull();
            polygonElement!.Attributes.Should().NotBeNull();
            polygonElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            polygonElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-38.6598 486.25,516.25)");
            polygonElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            polygonElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polygonElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");
            polygonElement!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("395,516.25 486.25,496.25 486.25,506.25 577.5,506.25 577.5,526.25 486.25,526.25 486.25,536.25");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("влево");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("451.32");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("571.016");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#66CDAA");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void ArrowRightTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.arrowRight.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=ArrowRight");
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
                .Be("807.5,571.25 715.625,548.75 715.625,560 623.75,560 623.75,582.5 715.625,582.5 715.625,593.75");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("вправо");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("666.945");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("526.016");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#F00");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void ArrowLeftRightTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.arrowLeftRight.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=ArrowLeftRight");
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
                .Be(
                    "778.75,674.375 668.333,627.5 668.333,650.938 557.917,650.938 557.917,627.5 " +
                    "447.5,674.375 557.917,721.25 557.917,697.812 668.333,697.812 668.333,721.25");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("в две стороны");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("535.695");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("761.361");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("21");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#8B008B");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailEndCouplingTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.railEndCoupling.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=RailEndCoupling");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var lineIndicatorGroup = currentGroup.SelectSingleNode("x:g", ns);
            lineIndicatorGroup.Should().NotBeNull();
            lineIndicatorGroup!.ChildNodes.Count.Should().Be(3);

            lineIndicatorGroup!.Attributes.Should().NotBeNull();
            lineIndicatorGroup!.Attributes!.Count.Should().Be(3);

            var lineIndicatorClass = lineIndicatorGroup!.Attributes!.GetNamedItem("class")!.Value;
            lineIndicatorClass.Should().NotBeNull();
            lineIndicatorClass.Should().Be("line-indicator");

            var lineIndicatorStroke = lineIndicatorGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            lineIndicatorStroke.Should().NotBeNull();
            lineIndicatorStroke.Should().Be("#000");

            var lineIndicatorStrokeWidth = lineIndicatorGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            lineIndicatorStrokeWidth.Should().NotBeNull();
            lineIndicatorStrokeWidth.Should().Be("2");

            var circle = lineIndicatorGroup.SelectSingleNode("x:circle", ns);
            circle.Should().NotBeNull();
            circle!.Attributes.Should().NotBeNull();
            circle!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("575.222");
            circle!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("306.7778");
            circle!.Attributes!.GetNamedItem("r")!.Value.Should().Be("15");

            var firstLine = lineIndicatorGroup.ChildNodes[1];
            firstLine.Should().NotBeNull();
            firstLine!.Attributes.Should().NotBeNull();
            firstLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("567.722");
            firstLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("306.7778");
            firstLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("582.722");
            firstLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("306.7778");

            var secondLine = lineIndicatorGroup.ChildNodes[2];
            secondLine.Should().NotBeNull();
            secondLine!.Attributes.Should().NotBeNull();
            secondLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("575.222");
            secondLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("299.2778");
            secondLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("575.222");
            secondLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("314.2778");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("муфта-релейная");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("483.528");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("281.921");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("16");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#191970");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailEndCouplingReverseTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.railEndCouplingReverse.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=RailEndCoupling");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var lineIndicatorGroup = currentGroup.SelectSingleNode("x:g", ns);
            lineIndicatorGroup.Should().NotBeNull();
            lineIndicatorGroup!.ChildNodes.Count.Should().Be(3);

            lineIndicatorGroup!.Attributes.Should().NotBeNull();
            lineIndicatorGroup!.Attributes!.Count.Should().Be(3);

            var lineIndicatorClass = lineIndicatorGroup!.Attributes!.GetNamedItem("class")!.Value;
            lineIndicatorClass.Should().NotBeNull();
            lineIndicatorClass.Should().Be("line-indicator");

            var lineIndicatorStroke = lineIndicatorGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            lineIndicatorStroke.Should().NotBeNull();
            lineIndicatorStroke.Should().Be("#000");

            var lineIndicatorStrokeWidth = lineIndicatorGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            lineIndicatorStrokeWidth.Should().NotBeNull();
            lineIndicatorStrokeWidth.Should().Be("2");

            var circle = lineIndicatorGroup.SelectSingleNode("x:circle", ns);
            circle.Should().NotBeNull();
            circle!.Attributes.Should().NotBeNull();
            circle!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("578.15");
            circle!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("380.839");
            circle!.Attributes!.GetNamedItem("r")!.Value.Should().Be("38.05");

            var firstLine = lineIndicatorGroup.ChildNodes[1];
            firstLine.Should().NotBeNull();
            firstLine!.Attributes.Should().NotBeNull();
            firstLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("559.125");
            firstLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("380.839");
            firstLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("597.175");
            firstLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("380.839");

            var secondLine = lineIndicatorGroup.ChildNodes[2];
            secondLine.Should().NotBeNull();
            secondLine!.Attributes.Should().NotBeNull();
            secondLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("578.15");
            secondLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("361.814");
            secondLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("578.15");
            secondLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("399.864");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("муфта-релейная перевер");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("472.344");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("438.814");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("16");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#556B2F");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void FeedEndCouplingTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.feedEndCoupling.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=FeedEndCoupling");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var indicatorGroup = currentGroup.SelectSingleNode("x:g", ns);
            indicatorGroup.Should().NotBeNull();
            indicatorGroup!.ChildNodes.Count.Should().Be(2);

            indicatorGroup!.Attributes.Should().NotBeNull();
            indicatorGroup!.Attributes!.Count.Should().Be(2);

            var indicatorStroke = indicatorGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            indicatorStroke.Should().NotBeNull();
            indicatorStroke.Should().Be("#000");

            var indicatorStrokeWidth = indicatorGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            indicatorStrokeWidth.Should().NotBeNull();
            indicatorStrokeWidth.Should().Be("2");

            var circleLineIndicator = indicatorGroup.SelectSingleNode("x:circle", ns);
            circleLineIndicator.Should().NotBeNull();
            circleLineIndicator!.Attributes.Should().NotBeNull();
            circleLineIndicator!.Attributes!.GetNamedItem("class")!.Value.Should().Be("line-indicator");
            circleLineIndicator!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("716.556");
            circleLineIndicator!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("302.5555");
            circleLineIndicator!.Attributes!.GetNamedItem("r")!.Value.Should().Be("15");

            var fillIndicatorGroup = indicatorGroup.SelectSingleNode("x:g", ns);
            fillIndicatorGroup.Should().NotBeNull();

            fillIndicatorGroup!.Attributes.Should().NotBeNull();
            fillIndicatorGroup!.Attributes!.Count.Should().Be(2);

            var indicatorFill = fillIndicatorGroup!.Attributes!.GetNamedItem("fill")!.Value;
            indicatorFill.Should().NotBeNull();
            indicatorFill.Should().Be("#000");

            var indicatorFillOpacity = fillIndicatorGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            indicatorFillOpacity.Should().NotBeNull();
            indicatorFillOpacity.Should().Be("1");

            var circleFillIndicator = fillIndicatorGroup.SelectSingleNode("x:circle", ns);
            circleFillIndicator.Should().NotBeNull();
            circleFillIndicator!.Attributes.Should().NotBeNull();
            circleFillIndicator!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            circleFillIndicator!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("716.556");
            circleFillIndicator!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("302.5555");
            circleFillIndicator!.Attributes!.GetNamedItem("r")!.Value.Should().Be("5");
            circleFillIndicator!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            circleFillIndicator!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("муфта-питающая");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("651.831");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("268.8752");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("16");
            textElement!.Attributes!.GetNamedItem("font-style")!.Value.Should().Be("italic");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#F4A460");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void FeedEndCouplingReverseTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.feedEndCouplingReverse.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=FeedEndCoupling");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var indicatorGroup = currentGroup.SelectSingleNode("x:g", ns);
            indicatorGroup.Should().NotBeNull();
            indicatorGroup!.ChildNodes.Count.Should().Be(2);

            indicatorGroup!.Attributes.Should().NotBeNull();
            indicatorGroup!.Attributes!.Count.Should().Be(2);

            var indicatorStroke = indicatorGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            indicatorStroke.Should().NotBeNull();
            indicatorStroke.Should().Be("#000");

            var indicatorStrokeWidth = indicatorGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            indicatorStrokeWidth.Should().NotBeNull();
            indicatorStrokeWidth.Should().Be("2");

            var circleLineIndicator = indicatorGroup.SelectSingleNode("x:circle", ns);
            circleLineIndicator.Should().NotBeNull();
            circleLineIndicator!.Attributes.Should().NotBeNull();
            circleLineIndicator!.Attributes!.GetNamedItem("class")!.Value.Should().Be("line-indicator");
            circleLineIndicator!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("717.9");
            circleLineIndicator!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("375.394");
            circleLineIndicator!.Attributes!.GetNamedItem("r")!.Value.Should().Be("41.8278");

            var fillIndicatorGroup = indicatorGroup.SelectSingleNode("x:g", ns);
            fillIndicatorGroup.Should().NotBeNull();

            fillIndicatorGroup!.Attributes.Should().NotBeNull();
            fillIndicatorGroup!.Attributes!.Count.Should().Be(2);

            var indicatorFill = fillIndicatorGroup!.Attributes!.GetNamedItem("fill")!.Value;
            indicatorFill.Should().NotBeNull();
            indicatorFill.Should().Be("#000");

            var indicatorFillOpacity = fillIndicatorGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            indicatorFillOpacity.Should().NotBeNull();
            indicatorFillOpacity.Should().Be("1");

            var circleFillIndicator = fillIndicatorGroup.SelectSingleNode("x:circle", ns);
            circleFillIndicator.Should().NotBeNull();
            circleFillIndicator!.Attributes.Should().NotBeNull();
            circleFillIndicator!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            circleFillIndicator!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("717.9");
            circleFillIndicator!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("375.394");
            circleFillIndicator!.Attributes!.GetNamedItem("r")!.Value.Should().Be("13.94259");
            circleFillIndicator!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            circleFillIndicator!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("муфта-пит-перевер");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("673.645");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("435.746");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("15");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#008080");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailEndBoxTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.railEndBox.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=RailEndBox");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var lineIndicatorGroup = currentGroup.SelectSingleNode("x:g", ns);
            lineIndicatorGroup.Should().NotBeNull();
            lineIndicatorGroup!.ChildNodes.Count.Should().Be(3);

            lineIndicatorGroup!.Attributes.Should().NotBeNull();
            lineIndicatorGroup!.Attributes!.Count.Should().Be(4);

            var lineIndicatorClass = lineIndicatorGroup!.Attributes!.GetNamedItem("class")!.Value;
            lineIndicatorClass.Should().NotBeNull();
            lineIndicatorClass.Should().Be("line-indicator");

            var lineIndicatorTransform = lineIndicatorGroup!.Attributes!.GetNamedItem("transform")!.Value;
            lineIndicatorTransform.Should().NotBeNull();
            lineIndicatorTransform.Should().Be("rotate(-283.0895 1012.273,759.977)");

            var lineIndicatorStroke = lineIndicatorGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            lineIndicatorStroke.Should().NotBeNull();
            lineIndicatorStroke.Should().Be("#000");

            var lineIndicatorStrokeWidth = lineIndicatorGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            lineIndicatorStrokeWidth.Should().NotBeNull();
            lineIndicatorStrokeWidth.Should().Be("2");

            var rectangle = lineIndicatorGroup.SelectSingleNode("x:rect", ns);
            rectangle.Should().NotBeNull();
            rectangle!.Attributes.Should().NotBeNull();
            rectangle!.Attributes!.GetNamedItem("x")!.Value.Should().Be("986.364");
            rectangle!.Attributes!.GetNamedItem("y")!.Value.Should().Be("734.068");
            rectangle!.Attributes!.GetNamedItem("width")!.Value.Should().Be("51.8181");
            rectangle!.Attributes!.GetNamedItem("height")!.Value.Should().Be("51.8182");

            var firstLine = lineIndicatorGroup.ChildNodes[1];
            firstLine.Should().NotBeNull();
            firstLine!.Attributes.Should().NotBeNull();
            firstLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("999.318");
            firstLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("759.977");
            firstLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1025.227");
            firstLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("759.977");

            var secondLine = lineIndicatorGroup.ChildNodes[2];
            secondLine.Should().NotBeNull();
            secondLine!.Attributes.Should().NotBeNull();
            secondLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1012.273");
            secondLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("747.023");
            secondLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1012.273");
            secondLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("772.932");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Коробка-релейная");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("930.922");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("706.732");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#0FF");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void FeedEndBoxTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.feedEndBox.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=FeedEndBox");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var indicatorGroup = currentGroup.SelectSingleNode("x:g", ns);
            indicatorGroup.Should().NotBeNull();
            indicatorGroup!.ChildNodes.Count.Should().Be(2);

            indicatorGroup!.Attributes.Should().NotBeNull();
            indicatorGroup!.Attributes!.Count.Should().Be(3);

            var indicatorTransform = indicatorGroup!.Attributes!.GetNamedItem("transform")!.Value;
            indicatorTransform.Should().NotBeNull();
            indicatorTransform.Should().Be("rotate(-122.8935 1013.182,843.614)");

            var indicatorStroke = indicatorGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            indicatorStroke.Should().NotBeNull();
            indicatorStroke.Should().Be("#000");

            var indicatorStrokeWidth = indicatorGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            indicatorStrokeWidth.Should().NotBeNull();
            indicatorStrokeWidth.Should().Be("2");

            var rectangleLineIndicator = indicatorGroup.SelectSingleNode("x:rect", ns);
            rectangleLineIndicator.Should().NotBeNull();
            rectangleLineIndicator!.Attributes.Should().NotBeNull();
            rectangleLineIndicator!.Attributes!.GetNamedItem("class")!.Value.Should().Be("line-indicator");
            rectangleLineIndicator!.Attributes!.GetNamedItem("x")!.Value.Should().Be("985.455");
            rectangleLineIndicator!.Attributes!.GetNamedItem("y")!.Value.Should().Be("820.432");
            rectangleLineIndicator!.Attributes!.GetNamedItem("width")!.Value.Should().Be("55.4545");
            rectangleLineIndicator!.Attributes!.GetNamedItem("height")!.Value.Should().Be("46.3636");

            var fillIndicatorGroup = indicatorGroup.SelectSingleNode("x:g", ns);
            fillIndicatorGroup.Should().NotBeNull();

            fillIndicatorGroup!.Attributes.Should().NotBeNull();
            fillIndicatorGroup!.Attributes!.Count.Should().Be(2);

            var indicatorFill = fillIndicatorGroup!.Attributes!.GetNamedItem("fill")!.Value;
            indicatorFill.Should().NotBeNull();
            indicatorFill.Should().Be("#000");

            var indicatorFillOpacity = fillIndicatorGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            indicatorFillOpacity.Should().NotBeNull();
            indicatorFillOpacity.Should().Be("1");

            var circleFillIndicator = fillIndicatorGroup.SelectSingleNode("x:circle", ns);
            circleFillIndicator.Should().NotBeNull();
            circleFillIndicator!.Attributes.Should().NotBeNull();
            circleFillIndicator!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            circleFillIndicator!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("1013.182");
            circleFillIndicator!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("843.614");
            circleFillIndicator!.Attributes!.GetNamedItem("r")!.Value.Should().Be("7.72727");
            circleFillIndicator!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            circleFillIndicator!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Коробка-питающая");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("940.07");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("893.493");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#FFC0CB");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void GroundControlTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.groundControl.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=GroundControl");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var lineIndicatorGroup = currentGroup.SelectSingleNode("x:g", ns);
            lineIndicatorGroup.Should().NotBeNull();
            lineIndicatorGroup!.ChildNodes.Count.Should().Be(4);

            lineIndicatorGroup!.Attributes.Should().NotBeNull();
            lineIndicatorGroup!.Attributes!.Count.Should().Be(3);

            var lineIndicatorClass = lineIndicatorGroup!.Attributes!.GetNamedItem("class")!.Value;
            lineIndicatorClass.Should().NotBeNull();
            lineIndicatorClass.Should().Be("line-indicator");

            var lineIndicatorStroke = lineIndicatorGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            lineIndicatorStroke.Should().NotBeNull();
            lineIndicatorStroke.Should().Be("#000");

            var lineIndicatorStrokeWidth = lineIndicatorGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            lineIndicatorStrokeWidth.Should().NotBeNull();
            lineIndicatorStrokeWidth.Should().Be("2");

            var firstLine = lineIndicatorGroup.ChildNodes[0];
            firstLine.Should().NotBeNull();
            firstLine!.Attributes.Should().NotBeNull();
            firstLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("220");
            firstLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("500");
            firstLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("220");
            firstLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("580.455");

            var secondLine = lineIndicatorGroup.ChildNodes[1];
            secondLine.Should().NotBeNull();
            secondLine!.Attributes.Should().NotBeNull();
            secondLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("140");
            secondLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("580.455");
            secondLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("300");
            secondLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("580.455");

            var thirdLine = lineIndicatorGroup.ChildNodes[2];
            thirdLine.Should().NotBeNull();
            thirdLine!.Attributes.Should().NotBeNull();
            thirdLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("180");
            thirdLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("620.682");
            thirdLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("260");
            thirdLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("620.682");

            var fourthLine = lineIndicatorGroup.ChildNodes[3];
            fourthLine.Should().NotBeNull();
            fourthLine!.Attributes.Should().NotBeNull();
            fourthLine!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("206.6667");
            fourthLine!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("660.909");
            fourthLine!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("233.3333");
            fourthLine!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("660.909");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Контроль заземления");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("119.1609");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("486.705");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("20");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#D2691E");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void KeyBarrelTest()
        {
            var (currentGroup, ns) = StandardFunctions.GetCurrentGroup("Lamps.keyBarrel.chr", LampElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("Shape=KeyBarrel");
            objectHint!.Split(",")[1].Should().Be("DrawBorder=True");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var fillIndicatorGroup = currentGroup.SelectSingleNode("x:g", ns);
            fillIndicatorGroup.Should().NotBeNull();
            fillIndicatorGroup!.ChildNodes.Count.Should().Be(1);

            fillIndicatorGroup!.Attributes.Should().NotBeNull();
            fillIndicatorGroup !.Attributes!.Count.Should().Be(3);

            var fillIndicatorClass = fillIndicatorGroup!.Attributes!.GetNamedItem("class")!.Value;
            fillIndicatorClass.Should().NotBeNull();
            fillIndicatorClass.Should().Be("fill-indicator");

            var fillIndicatorTransform = fillIndicatorGroup!.Attributes!.GetNamedItem("transform")!.Value;
            fillIndicatorTransform.Should().NotBeNull();
            fillIndicatorTransform.Should().Be("rotate(-282.6526 229,757.75)");

            var fillIndicatorStrokeWidth = fillIndicatorGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            fillIndicatorStrokeWidth.Should().NotBeNull();
            fillIndicatorStrokeWidth.Should().Be("2");

            var pathElement = fillIndicatorGroup.SelectSingleNode("x:path", ns);
            pathElement.Should().NotBeNull();
            pathElement!.Attributes.Should().NotBeNull();
            pathElement!.Attributes!.GetNamedItem("fill-rule")!.Value.Should().Be("evenodd");
            pathElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            pathElement!.Attributes!.GetNamedItem("d")!.Value.Should().Be(
                "M172,728.55H217.6V750.45H286V779.65H271.4V765.05H217.6V786.95H172V728.55zM187.2,750.15H202.4V765.35H187.2V750.15z");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Ключ-Жезл");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("171.57");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("822.766");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#800080");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}