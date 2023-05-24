using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class RailCrossingTest
    {
        private const string RailCrossingName = "StandardLibrary.RailCrossing";

        [Test]
        public void EmptyRailCrossingBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailCrossing.emptyRailCrossingLeft.chr", RailCrossingName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailCrossing.emptyRailCrossingRight.chr", RailCrossingName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailCrossing.emptyRailCrossingTop.chr", RailCrossingName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailCrossing.emptyRailCrossingBottom.chr", RailCrossingName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void RailCrossingTypeTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailCrossing.emptyRailCrossingType.chr", RailCrossingName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailCrossing.errorRailCrossingType.chr", RailCrossingName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void RailCrossingType0Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailCrossing.railCrossingType0.chr", RailCrossingName);
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
            objectHint.Should().Be("RailCrossingType=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            // Проверка содержимого дочерних элементов
            var railCrossingTopGroup = currentGroup.SelectSingleNode("x:g", ns);
            railCrossingTopGroup.Should().NotBeNull();
            railCrossingTopGroup!.ChildNodes.Count.Should().Be(1);

            railCrossingTopGroup!.Attributes.Should().NotBeNull();
            railCrossingTopGroup!.Attributes!.Count.Should().Be(2);

            var railCrossingTransform = railCrossingTopGroup!.Attributes!.GetNamedItem("transform")!.Value;
            railCrossingTransform.Should().NotBeNull();
            railCrossingTransform.Should().Be("rotate(-348.624 2035,332.333)");

            var railCrossingStroke = railCrossingTopGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            railCrossingStroke.Should().NotBeNull();
            railCrossingStroke.Should().Be("#000");

            var railCrossingGroup = railCrossingTopGroup.SelectSingleNode("x:g", ns);
            railCrossingGroup.Should().NotBeNull();
            railCrossingGroup!.ChildNodes.Count.Should().Be(2);

            railCrossingGroup!.Attributes.Should().NotBeNull();
            railCrossingGroup!.Attributes!.Count.Should().Be(3);

            var railCrossingClass = railCrossingGroup!.Attributes!.GetNamedItem("class")!.Value;
            railCrossingClass.Should().NotBeNull();
            railCrossingClass.Should().Be("rail-crossing");

            var railCrossingFillOpacity = railCrossingGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingFillOpacity.Should().NotBeNull();
            railCrossingFillOpacity.Should().Be("0");

            var railCrossingStrokeWidth = railCrossingGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            railCrossingStrokeWidth.Should().NotBeNull();
            railCrossingStrokeWidth.Should().Be("4");

            var polylineFirst = railCrossingGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2010,173.3333 2026.667,190 2026.667,474.667 2010,491.333");

            var polylineSecond = railCrossingGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2060,173.3333 2043.333,190 2043.333,474.667 2060,491.333");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Переезд без шлагбаума");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1895.655");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("135.4748");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailCrossingType1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailCrossing.railCrossingType1.chr", RailCrossingName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint.Should().Be("RailCrossingType=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var railCrossingTopGroup = currentGroup.SelectSingleNode("x:g", ns);
            railCrossingTopGroup.Should().NotBeNull();
            railCrossingTopGroup!.ChildNodes.Count.Should().Be(4);
            railCrossingTopGroup!.Attributes.Should().NotBeNull();
            railCrossingTopGroup!.Attributes!.Count.Should().Be(2);

            var railCrossingTransform = railCrossingTopGroup!.Attributes!.GetNamedItem("transform")!.Value;
            railCrossingTransform.Should().NotBeNull();
            railCrossingTransform.Should().Be("rotate(-8.33367 1985,760.667)");

            var railCrossingStroke = railCrossingTopGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            railCrossingStroke.Should().NotBeNull();
            railCrossingStroke.Should().Be("#000");

            var railCrossingGroup = railCrossingTopGroup.ChildNodes[0];
            railCrossingGroup.Should().NotBeNull();
            railCrossingGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingGroup!.Attributes.Should().NotBeNull();
            railCrossingGroup!.Attributes!.Count.Should().Be(3);

            var railCrossingClass = railCrossingGroup!.Attributes!.GetNamedItem("class")!.Value;
            railCrossingClass.Should().NotBeNull();
            railCrossingClass.Should().Be("rail-crossing");

            var railCrossingFillOpacity = railCrossingGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingFillOpacity.Should().NotBeNull();
            railCrossingFillOpacity.Should().Be("0");

            var railCrossingStrokeWidth = railCrossingGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            railCrossingStrokeWidth.Should().NotBeNull();
            railCrossingStrokeWidth.Should().Be("4");

            var polylineFirst = railCrossingGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1960,637.31 1976.667,653.977 1976.667,867.357 1960,884.023");

            var polylineSecond = railCrossingGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2010,637.31 1993.333,653.977 1993.333,867.357 2010,884.023");

            var railCrossingBarOpenGroup = railCrossingTopGroup.ChildNodes[1];
            railCrossingBarOpenGroup.Should().NotBeNull();
            railCrossingBarOpenGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarOpenGroup!.Attributes.Should().NotBeNull();
            railCrossingBarOpenGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingBarOpenStrokeOpacity =
                railCrossingBarOpenGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingBarOpenStrokeOpacity.Should().NotBeNull();
            railCrossingBarOpenStrokeOpacity.Should().Be("1");

            var lineBarOpenFirst = railCrossingBarOpenGroup.ChildNodes[0];
            lineBarOpenFirst.Should().NotBeNull();
            lineBarOpenFirst!.Attributes.Should().NotBeNull();
            lineBarOpenFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-open");
            lineBarOpenFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1968.333");
            lineBarOpenFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("658.143");
            lineBarOpenFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1968.333");
            lineBarOpenFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("699.81");
            lineBarOpenFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineBarOpenSecond = railCrossingBarOpenGroup.ChildNodes[1];
            lineBarOpenSecond.Should().NotBeNull();
            lineBarOpenSecond!.Attributes.Should().NotBeNull();
            lineBarOpenSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-open");
            lineBarOpenSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2001.667");
            lineBarOpenSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("863.19");
            lineBarOpenSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2001.667");
            lineBarOpenSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("821.523");
            lineBarOpenSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railCrossingBarClosedGroup = railCrossingTopGroup.ChildNodes[2];
            railCrossingBarClosedGroup.Should().NotBeNull();
            railCrossingBarClosedGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarClosedGroup!.Attributes.Should().NotBeNull();
            railCrossingBarClosedGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingBarClosedStrokeOpacity =
                railCrossingBarClosedGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingBarClosedStrokeOpacity.Should().NotBeNull();
            railCrossingBarClosedStrokeOpacity.Should().Be("0");

            var lineBarClosedFirst = railCrossingBarClosedGroup.ChildNodes[0];
            lineBarClosedFirst.Should().NotBeNull();
            lineBarClosedFirst!.Attributes.Should().NotBeNull();
            lineBarClosedFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-closed");
            lineBarClosedFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1968.333");
            lineBarClosedFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("658.143");
            lineBarClosedFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2010");
            lineBarClosedFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("658.143");
            lineBarClosedFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineBarClosedSecond = railCrossingBarClosedGroup.ChildNodes[1];
            lineBarClosedSecond.Should().NotBeNull();
            lineBarClosedSecond!.Attributes.Should().NotBeNull();
            lineBarClosedSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-closed");
            lineBarClosedSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2001.667");
            lineBarClosedSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("863.19");
            lineBarClosedSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1960");
            lineBarClosedSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("863.19");
            lineBarClosedSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railCrossingBarBaseGroup = railCrossingTopGroup.ChildNodes[3];
            railCrossingBarBaseGroup.Should().NotBeNull();
            railCrossingBarBaseGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarBaseGroup!.Attributes.Should().NotBeNull();
            railCrossingBarBaseGroup!.Attributes!.Count.Should().Be(2);

            var railCrossingBarBaseFill = railCrossingBarBaseGroup!.Attributes!.GetNamedItem("fill")!.Value;
            railCrossingBarBaseFill.Should().NotBeNull();
            railCrossingBarBaseFill.Should().Be("#000");

            var railCrossingBarBaseFillOpacity =
                railCrossingBarBaseGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingBarBaseFillOpacity.Should().NotBeNull();
            railCrossingBarBaseFillOpacity.Should().Be("1");

            var rectangleBarBaseFirst = railCrossingBarBaseGroup.ChildNodes[0];
            rectangleBarBaseFirst.Should().NotBeNull();
            rectangleBarBaseFirst!.Attributes.Should().NotBeNull();
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-base");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1964.167");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("653.977");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("8.33333");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("8.33333");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var rectangleBarBaseSecond = railCrossingBarBaseGroup.ChildNodes[1];
            rectangleBarBaseSecond.Should().NotBeNull();
            rectangleBarBaseSecond!.Attributes.Should().NotBeNull();
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-base");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1997.5");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("859.023");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("8.33333");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("8.33333");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Переезд с шлагбаумом");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2029.407");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("696.812");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailCrossingType2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailCrossing.railCrossingType2.chr", RailCrossingName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint.Should().Be("RailCrossingType=2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var railCrossingTopGroup = currentGroup.SelectSingleNode("x:g", ns);
            railCrossingTopGroup.Should().NotBeNull();
            railCrossingTopGroup!.ChildNodes.Count.Should().Be(5);
            railCrossingTopGroup!.Attributes.Should().NotBeNull();
            railCrossingTopGroup!.Attributes!.Count.Should().Be(2);

            var railCrossingTransform = railCrossingTopGroup!.Attributes!.GetNamedItem("transform")!.Value;
            railCrossingTransform.Should().NotBeNull();
            railCrossingTransform.Should().Be("rotate(-269.0924 2060,1075.667)");

            var railCrossingStroke = railCrossingTopGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            railCrossingStroke.Should().NotBeNull();
            railCrossingStroke.Should().Be("#000");

            var railCrossingGroup = railCrossingTopGroup.ChildNodes[0];
            railCrossingGroup.Should().NotBeNull();
            railCrossingGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingGroup!.Attributes.Should().NotBeNull();
            railCrossingGroup!.Attributes!.Count.Should().Be(3);

            var railCrossingClass = railCrossingGroup!.Attributes!.GetNamedItem("class")!.Value;
            railCrossingClass.Should().NotBeNull();
            railCrossingClass.Should().Be("rail-crossing");

            var railCrossingFillOpacity = railCrossingGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingFillOpacity.Should().NotBeNull();
            railCrossingFillOpacity.Should().Be("0");

            var railCrossingStrokeWidth = railCrossingGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            railCrossingStrokeWidth.Should().NotBeNull();
            railCrossingStrokeWidth.Should().Be("4");

            var polylineFirst = railCrossingGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2035,929.667 2051.667,946.333 2051.667,1205 2035,1221.667");

            var polylineSecond = railCrossingGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2085,929.667 2068.333,946.333 2068.333,1205 2085,1221.667");

            var railCrossingBarOpenGroup = railCrossingTopGroup.ChildNodes[1];
            railCrossingBarOpenGroup.Should().NotBeNull();
            railCrossingBarOpenGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarOpenGroup!.Attributes.Should().NotBeNull();
            railCrossingBarOpenGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingBarOpenStrokeOpacity =
                railCrossingBarOpenGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingBarOpenStrokeOpacity.Should().NotBeNull();
            railCrossingBarOpenStrokeOpacity.Should().Be("1");

            var lineBarOpenFirst = railCrossingBarOpenGroup.ChildNodes[0];
            lineBarOpenFirst.Should().NotBeNull();
            lineBarOpenFirst!.Attributes.Should().NotBeNull();
            lineBarOpenFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-open");
            lineBarOpenFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2043.333");
            lineBarOpenFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("950.5");
            lineBarOpenFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2043.333");
            lineBarOpenFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("992.167");
            lineBarOpenFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineBarOpenSecond = railCrossingBarOpenGroup.ChildNodes[1];
            lineBarOpenSecond.Should().NotBeNull();
            lineBarOpenSecond!.Attributes.Should().NotBeNull();
            lineBarOpenSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-open");
            lineBarOpenSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2076.667");
            lineBarOpenSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1200.833");
            lineBarOpenSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2076.667");
            lineBarOpenSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1159.167");
            lineBarOpenSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railCrossingBarClosedGroup = railCrossingTopGroup.ChildNodes[2];
            railCrossingBarClosedGroup.Should().NotBeNull();
            railCrossingBarClosedGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarClosedGroup!.Attributes.Should().NotBeNull();
            railCrossingBarClosedGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingBarClosedStrokeOpacity =
                railCrossingBarClosedGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingBarClosedStrokeOpacity.Should().NotBeNull();
            railCrossingBarClosedStrokeOpacity.Should().Be("0");

            var lineBarClosedFirst = railCrossingBarClosedGroup.ChildNodes[0];
            lineBarClosedFirst.Should().NotBeNull();
            lineBarClosedFirst!.Attributes.Should().NotBeNull();
            lineBarClosedFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-closed");
            lineBarClosedFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2043.333");
            lineBarClosedFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("950.5");
            lineBarClosedFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2085");
            lineBarClosedFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("950.5");
            lineBarClosedFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineBarClosedSecond = railCrossingBarClosedGroup.ChildNodes[1];
            lineBarClosedSecond.Should().NotBeNull();
            lineBarClosedSecond!.Attributes.Should().NotBeNull();
            lineBarClosedSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-closed");
            lineBarClosedSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2076.667");
            lineBarClosedSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1200.833");
            lineBarClosedSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2035");
            lineBarClosedSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1200.833");
            lineBarClosedSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railCrossingBarBaseGroup = railCrossingTopGroup.ChildNodes[3];
            railCrossingBarBaseGroup.Should().NotBeNull();
            railCrossingBarBaseGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarBaseGroup!.Attributes.Should().NotBeNull();
            railCrossingBarBaseGroup!.Attributes!.Count.Should().Be(2);

            var railCrossingBarBaseFill = railCrossingBarBaseGroup!.Attributes!.GetNamedItem("fill")!.Value;
            railCrossingBarBaseFill.Should().NotBeNull();
            railCrossingBarBaseFill.Should().Be("#000");

            var railCrossingBarBaseFillOpacity =
                railCrossingBarBaseGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingBarBaseFillOpacity.Should().NotBeNull();
            railCrossingBarBaseFillOpacity.Should().Be("1");

            var rectangleBarBaseFirst = railCrossingBarBaseGroup.ChildNodes[0];
            rectangleBarBaseFirst.Should().NotBeNull();
            rectangleBarBaseFirst!.Attributes.Should().NotBeNull();
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-base");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2039.167");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("946.333");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("8.33333");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("8.33333");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var rectangleBarBaseSecond = railCrossingBarBaseGroup.ChildNodes[1];
            rectangleBarBaseSecond.Should().NotBeNull();
            rectangleBarBaseSecond!.Attributes.Should().NotBeNull();
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-base");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2072.5");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1196.667");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("8.33333");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("8.33333");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railCrossingUzpGroup = railCrossingTopGroup.ChildNodes[4];
            railCrossingUzpGroup.Should().NotBeNull();
            railCrossingUzpGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingUzpGroup!.Attributes.Should().NotBeNull();
            railCrossingUzpGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingUzpStrokeOpacity = railCrossingUzpGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingUzpStrokeOpacity.Should().NotBeNull();
            railCrossingUzpStrokeOpacity.Should().Be("1");

            var lineRailCrossingUzpFirst = railCrossingUzpGroup.ChildNodes[0];
            lineRailCrossingUzpFirst.Should().NotBeNull();
            lineRailCrossingUzpFirst!.Attributes.Should().NotBeNull();
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-uzp");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2051.667");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("946.333");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2068.333");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("946.333");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineRailCrossingUzpSecond = railCrossingUzpGroup.ChildNodes[1];
            lineRailCrossingUzpSecond.Should().NotBeNull();
            lineRailCrossingUzpSecond!.Attributes.Should().NotBeNull();
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-uzp");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2051.667");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1205");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2068.333");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1205");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Переезд шлагбаум и УЗП");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1901.955");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1145.665");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailCrossingType1WithoutBarTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailCrossing.railCrossingType1WithoutBar.chr", RailCrossingName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint.Should().Be("RailCrossingType=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var railCrossingTopGroup = currentGroup.SelectSingleNode("x:g", ns);
            railCrossingTopGroup.Should().NotBeNull();
            railCrossingTopGroup!.ChildNodes.Count.Should().Be(1);
            railCrossingTopGroup!.Attributes.Should().NotBeNull();
            railCrossingTopGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingStroke = railCrossingTopGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            railCrossingStroke.Should().NotBeNull();
            railCrossingStroke.Should().Be("#000");

            var railCrossingGroup = railCrossingTopGroup.SelectSingleNode("x:g", ns);
            railCrossingGroup.Should().NotBeNull();
            railCrossingGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingGroup!.Attributes.Should().NotBeNull();
            railCrossingGroup!.Attributes!.Count.Should().Be(3);

            var railCrossingClass = railCrossingGroup!.Attributes!.GetNamedItem("class")!.Value;
            railCrossingClass.Should().NotBeNull();
            railCrossingClass.Should().Be("rail-crossing");

            var railCrossingFillOpacity = railCrossingGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingFillOpacity.Should().NotBeNull();
            railCrossingFillOpacity.Should().Be("0");

            var railCrossingStrokeWidth = railCrossingGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            railCrossingStrokeWidth.Should().NotBeNull();
            railCrossingStrokeWidth.Should().Be("4");

            var polylineFirst = railCrossingGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1720.682,664.273 1737.348,680.939 1737.348,680.858 1720.682,697.525");

            var polylineSecond = railCrossingGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1770.682,664.273 1754.015,680.939 1754.015,680.858 1770.682,697.525");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Переезд-нет");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1637.418");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("636.748");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailCrossingType1WithBarTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailCrossing.railCrossingType1WithBar.chr", RailCrossingName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint.Should().Be("RailCrossingType=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var railCrossingTopGroup = currentGroup.SelectSingleNode("x:g", ns);
            railCrossingTopGroup.Should().NotBeNull();
            railCrossingTopGroup!.ChildNodes.Count.Should().Be(4);
            railCrossingTopGroup!.Attributes.Should().NotBeNull();
            railCrossingTopGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingStroke = railCrossingTopGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            railCrossingStroke.Should().NotBeNull();
            railCrossingStroke.Should().Be("#000");

            var railCrossingGroup = railCrossingTopGroup.ChildNodes[0];
            railCrossingGroup.Should().NotBeNull();
            railCrossingGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingGroup!.Attributes.Should().NotBeNull();
            railCrossingGroup!.Attributes!.Count.Should().Be(3);

            var railCrossingClass = railCrossingGroup!.Attributes!.GetNamedItem("class")!.Value;
            railCrossingClass.Should().NotBeNull();
            railCrossingClass.Should().Be("rail-crossing");

            var railCrossingFillOpacity = railCrossingGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingFillOpacity.Should().NotBeNull();
            railCrossingFillOpacity.Should().Be("0");

            var railCrossingStrokeWidth = railCrossingGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            railCrossingStrokeWidth.Should().NotBeNull();
            railCrossingStrokeWidth.Should().Be("4");

            var polylineFirst = railCrossingGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1800.305,654.466 1816.972,671.133 1816.972,690.858 1800.305,707.525");

            var polylineSecond = railCrossingGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1850.305,654.466 1833.638,671.133 1833.638,690.858 1850.305,707.525");

            var railCrossingBarOpenGroup = railCrossingTopGroup.ChildNodes[1];
            railCrossingBarOpenGroup.Should().NotBeNull();
            railCrossingBarOpenGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarOpenGroup!.Attributes.Should().NotBeNull();
            railCrossingBarOpenGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingBarOpenStrokeOpacity =
                railCrossingBarOpenGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingBarOpenStrokeOpacity.Should().NotBeNull();
            railCrossingBarOpenStrokeOpacity.Should().Be("1");

            var lineBarOpenFirst = railCrossingBarOpenGroup.ChildNodes[0];
            lineBarOpenFirst.Should().NotBeNull();
            lineBarOpenFirst!.Attributes.Should().NotBeNull();
            lineBarOpenFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-open");
            lineBarOpenFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1808.638");
            lineBarOpenFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("675.3");
            lineBarOpenFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1808.638");
            lineBarOpenFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("686.692");
            lineBarOpenFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineBarOpenSecond = railCrossingBarOpenGroup.ChildNodes[1];
            lineBarOpenSecond.Should().NotBeNull();
            lineBarOpenSecond!.Attributes.Should().NotBeNull();
            lineBarOpenSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-open");
            lineBarOpenSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1841.972");
            lineBarOpenSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("686.692");
            lineBarOpenSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1841.972");
            lineBarOpenSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("675.3");
            lineBarOpenSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railCrossingBarClosedGroup = railCrossingTopGroup.ChildNodes[2];
            railCrossingBarClosedGroup.Should().NotBeNull();
            railCrossingBarClosedGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarClosedGroup!.Attributes.Should().NotBeNull();
            railCrossingBarClosedGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingBarClosedStrokeOpacity =
                railCrossingBarClosedGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingBarClosedStrokeOpacity.Should().NotBeNull();
            railCrossingBarClosedStrokeOpacity.Should().Be("0");

            var lineBarClosedFirst = railCrossingBarClosedGroup.ChildNodes[0];
            lineBarClosedFirst.Should().NotBeNull();
            lineBarClosedFirst!.Attributes.Should().NotBeNull();
            lineBarClosedFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-closed");
            lineBarClosedFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1808.638");
            lineBarClosedFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("675.3");
            lineBarClosedFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1850.305");
            lineBarClosedFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("675.3");
            lineBarClosedFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineBarClosedSecond = railCrossingBarClosedGroup.ChildNodes[1];
            lineBarClosedSecond.Should().NotBeNull();
            lineBarClosedSecond!.Attributes.Should().NotBeNull();
            lineBarClosedSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-closed");
            lineBarClosedSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1841.972");
            lineBarClosedSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("686.692");
            lineBarClosedSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1800.305");
            lineBarClosedSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("686.692");
            lineBarClosedSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railCrossingBarBaseGroup = railCrossingTopGroup.ChildNodes[3];
            railCrossingBarBaseGroup.Should().NotBeNull();
            railCrossingBarBaseGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingBarBaseGroup!.Attributes.Should().NotBeNull();
            railCrossingBarBaseGroup!.Attributes!.Count.Should().Be(2);

            var railCrossingBarBaseFill = railCrossingBarBaseGroup!.Attributes!.GetNamedItem("fill")!.Value;
            railCrossingBarBaseFill.Should().NotBeNull();
            railCrossingBarBaseFill.Should().Be("#000");

            var railCrossingBarBaseFillOpacity =
                railCrossingBarBaseGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingBarBaseFillOpacity.Should().NotBeNull();
            railCrossingBarBaseFillOpacity.Should().Be("1");

            var rectangleBarBaseFirst = railCrossingBarBaseGroup.ChildNodes[0];
            rectangleBarBaseFirst.Should().NotBeNull();
            rectangleBarBaseFirst!.Attributes.Should().NotBeNull();
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-base");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1804.472");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("671.133");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("8.33333");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("8.33333");
            rectangleBarBaseFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var rectangleBarBaseSecond = railCrossingBarBaseGroup.ChildNodes[1];
            rectangleBarBaseSecond.Should().NotBeNull();
            rectangleBarBaseSecond!.Attributes.Should().NotBeNull();
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-bar-base");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1837.805");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("682.525");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("8.33333");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("8.33333");
            rectangleBarBaseSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Переезд-есть");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1814.542");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("639.762");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailCrossingType2Small1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailCrossing.railCrossingType2Small1.chr", RailCrossingName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint.Should().Be("RailCrossingType=2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var railCrossingTopGroup = currentGroup.SelectSingleNode("x:g", ns);
            railCrossingTopGroup.Should().NotBeNull();
            railCrossingTopGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingTopGroup!.Attributes.Should().NotBeNull();
            railCrossingTopGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingStroke = railCrossingTopGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            railCrossingStroke.Should().NotBeNull();
            railCrossingStroke.Should().Be("#000");

            var railCrossingGroup = railCrossingTopGroup.ChildNodes[0];
            railCrossingGroup.Should().NotBeNull();
            railCrossingGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingGroup!.Attributes.Should().NotBeNull();
            railCrossingGroup!.Attributes!.Count.Should().Be(3);

            var railCrossingClass = railCrossingGroup!.Attributes!.GetNamedItem("class")!.Value;
            railCrossingClass.Should().NotBeNull();
            railCrossingClass.Should().Be("rail-crossing");

            var railCrossingFillOpacity = railCrossingGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingFillOpacity.Should().NotBeNull();
            railCrossingFillOpacity.Should().Be("0");

            var railCrossingStrokeWidth = railCrossingGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            railCrossingStrokeWidth.Should().NotBeNull();
            railCrossingStrokeWidth.Should().Be("4");

            var polylineFirst = railCrossingGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1701.949,759.025 1718.616,775.692 1718.616,774.358 1701.949,791.025");

            var polylineSecond = railCrossingGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1751.949,759.025 1735.283,775.692 1735.283,774.358 1751.949,791.025");

            var railCrossingUzpGroup = railCrossingTopGroup.ChildNodes[1];
            railCrossingUzpGroup.Should().NotBeNull();
            railCrossingUzpGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingUzpGroup!.Attributes.Should().NotBeNull();
            railCrossingUzpGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingUzpStrokeOpacity = railCrossingUzpGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingUzpStrokeOpacity.Should().NotBeNull();
            railCrossingUzpStrokeOpacity.Should().Be("1");

            var lineRailCrossingUzpFirst = railCrossingUzpGroup.ChildNodes[0];
            lineRailCrossingUzpFirst.Should().NotBeNull();
            lineRailCrossingUzpFirst!.Attributes.Should().NotBeNull();
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-uzp");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1718.616");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("775.692");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1735.283");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("775.692");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineRailCrossingUzpSecond = railCrossingUzpGroup.ChildNodes[1];
            lineRailCrossingUzpSecond.Should().NotBeNull();
            lineRailCrossingUzpSecond!.Attributes.Should().NotBeNull();
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-uzp");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1718.616");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("774.358");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1735.283");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("774.358");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Переезд-УЗП1");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1662.519");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("746.541");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailCrossingType2Small2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailCrossing.railCrossingType2Small2.chr", RailCrossingName);
            currentGroup.Should().NotBeNull();

                        var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint.Should().Be("RailCrossingType=2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var railCrossingTopGroup = currentGroup.SelectSingleNode("x:g", ns);
            railCrossingTopGroup.Should().NotBeNull();
            railCrossingTopGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingTopGroup!.Attributes.Should().NotBeNull();
            railCrossingTopGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingStroke = railCrossingTopGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            railCrossingStroke.Should().NotBeNull();
            railCrossingStroke.Should().Be("#000");

            var railCrossingGroup = railCrossingTopGroup.ChildNodes[0];
            railCrossingGroup.Should().NotBeNull();
            railCrossingGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingGroup!.Attributes.Should().NotBeNull();
            railCrossingGroup!.Attributes!.Count.Should().Be(3);

            var railCrossingClass = railCrossingGroup!.Attributes!.GetNamedItem("class")!.Value;
            railCrossingClass.Should().NotBeNull();
            railCrossingClass.Should().Be("rail-crossing");

            var railCrossingFillOpacity = railCrossingGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            railCrossingFillOpacity.Should().NotBeNull();
            railCrossingFillOpacity.Should().Be("0");

            var railCrossingStrokeWidth = railCrossingGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            railCrossingStrokeWidth.Should().NotBeNull();
            railCrossingStrokeWidth.Should().Be("4");

            var polylineFirst = railCrossingGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1838.449,759.025 1855.116,775.692 1855.116,778.358 1838.449,795.025");

            var polylineSecond = railCrossingGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1888.449,759.025 1871.783,775.692 1871.783,778.358 1888.449,795.025");

            var railCrossingUzpGroup = railCrossingTopGroup.ChildNodes[1];
            railCrossingUzpGroup.Should().NotBeNull();
            railCrossingUzpGroup!.ChildNodes.Count.Should().Be(2);
            railCrossingUzpGroup!.Attributes.Should().NotBeNull();
            railCrossingUzpGroup!.Attributes!.Count.Should().Be(1);

            var railCrossingUzpStrokeOpacity = railCrossingUzpGroup!.Attributes!.GetNamedItem("stroke-opacity")!.Value;
            railCrossingUzpStrokeOpacity.Should().NotBeNull();
            railCrossingUzpStrokeOpacity.Should().Be("1");

            var lineRailCrossingUzpFirst = railCrossingUzpGroup.ChildNodes[0];
            lineRailCrossingUzpFirst.Should().NotBeNull();
            lineRailCrossingUzpFirst!.Attributes.Should().NotBeNull();
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-uzp");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1855.116");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("775.692");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1871.783");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("775.692");
            lineRailCrossingUzpFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineRailCrossingUzpSecond = railCrossingUzpGroup.ChildNodes[1];
            lineRailCrossingUzpSecond.Should().NotBeNull();
            lineRailCrossingUzpSecond!.Attributes.Should().NotBeNull();
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-crossing-uzp");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1855.116");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("778.358");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1871.783");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("778.358");
            lineRailCrossingUzpSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Переезд-УЗП2");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1815.519");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("746.541");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}