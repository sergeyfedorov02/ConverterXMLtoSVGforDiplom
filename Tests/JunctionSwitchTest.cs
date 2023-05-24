using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class JunctionSwitchTest
    {
        private const string JunctionSwitchName = "StandardLibrary.JunctionSwitch";
        private const string JunctionSwitchWithoutNoControlName = "StandardLibrary.JunctionSwitchWithoutNoControl";
        private const string UkspsName = "StandardLibrary.Uksps";

        [Test]
        public void EmptyJunctionSwitchBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.emptyLeftTop.chr", JunctionSwitchName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.emptyLampSize.chr", JunctionSwitchName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.emptyLampSpace.chr", JunctionSwitchName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.emptyRowSpace.chr", JunctionSwitchName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void JunctionSwitch1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.junctionSwitch.chr", JunctionSwitchName);
            currentGroup.Should().NotBeNull();

            // Получение атрибутов текущей группы (верхний уровень)
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            // Получение значения атрибута по его имени
            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            // Проверка содержимого дочерних элементов
            var junctionSwitchGroup = currentGroup.SelectSingleNode("x:g", ns);
            junctionSwitchGroup.Should().NotBeNull();
            junctionSwitchGroup!.ChildNodes.Count.Should().Be(3);
            junctionSwitchGroup!.Attributes.Should().NotBeNull();
            junctionSwitchGroup !.Attributes!.Count.Should().Be(4);

            var junctionSwitchFill = junctionSwitchGroup!.Attributes!.GetNamedItem("fill")!.Value;
            junctionSwitchFill.Should().NotBeNull();
            junctionSwitchFill.Should().Be("darkgray");

            var junctionSwitchFillOpacity = junctionSwitchGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            junctionSwitchFillOpacity.Should().NotBeNull();
            junctionSwitchFillOpacity.Should().Be("1");

            var junctionSwitchStroke = junctionSwitchGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            junctionSwitchStroke.Should().NotBeNull();
            junctionSwitchStroke.Should().Be("#000");

            var junctionSwitchStrokeWidth = junctionSwitchGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            junctionSwitchStrokeWidth.Should().NotBeNull();
            junctionSwitchStrokeWidth.Should().Be("2");

            var rectangleFirst = junctionSwitchGroup.ChildNodes[0];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1159.891");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1413.985");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var rectangleSecond = junctionSwitchGroup.ChildNodes[1];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1169.891");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1403.985");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var rectangleThird = junctionSwitchGroup.ChildNodes[2];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1179.891");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1413.985");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Стрелочный коммутатор-1");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1025.517");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1388.057");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void JunctionSwitch2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.junctionSwitch2.chr", JunctionSwitchName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var junctionSwitchGroup = currentGroup.SelectSingleNode("x:g", ns);
            junctionSwitchGroup.Should().NotBeNull();
            junctionSwitchGroup!.ChildNodes.Count.Should().Be(3);
            junctionSwitchGroup!.Attributes.Should().NotBeNull();
            junctionSwitchGroup !.Attributes!.Count.Should().Be(4);

            var junctionSwitchFill = junctionSwitchGroup!.Attributes!.GetNamedItem("fill")!.Value;
            junctionSwitchFill.Should().NotBeNull();
            junctionSwitchFill.Should().Be("darkgray");

            var junctionSwitchFillOpacity = junctionSwitchGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            junctionSwitchFillOpacity.Should().NotBeNull();
            junctionSwitchFillOpacity.Should().Be("1");

            var junctionSwitchStroke = junctionSwitchGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            junctionSwitchStroke.Should().NotBeNull();
            junctionSwitchStroke.Should().Be("#000");

            var junctionSwitchStrokeWidth = junctionSwitchGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            junctionSwitchStrokeWidth.Should().NotBeNull();
            junctionSwitchStrokeWidth.Should().Be("2");

            var rectangleFirst = junctionSwitchGroup.ChildNodes[0];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1443.225");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1426.207");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var rectangleSecond = junctionSwitchGroup.ChildNodes[1];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1458.225");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1406.207");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var rectangleThird = junctionSwitchGroup.ChildNodes[2];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1473.225");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1426.207");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Стрелочный коммутатор-2");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1358.85");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1394.723");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void JunctionSwitchWithoutNoControl1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.junctionSwitchWithoutNoControl.chr",
                    JunctionSwitchWithoutNoControlName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var junctionSwitchWithoutNoControlGroup = currentGroup.SelectSingleNode("x:g", ns);
            junctionSwitchWithoutNoControlGroup.Should().NotBeNull();
            junctionSwitchWithoutNoControlGroup!.ChildNodes.Count.Should().Be(2);
            junctionSwitchWithoutNoControlGroup!.Attributes.Should().NotBeNull();
            junctionSwitchWithoutNoControlGroup !.Attributes!.Count.Should().Be(4);

            var junctionSwitchWithoutNoControlFill =
                junctionSwitchWithoutNoControlGroup!.Attributes!.GetNamedItem("fill")!.Value;
            junctionSwitchWithoutNoControlFill.Should().NotBeNull();
            junctionSwitchWithoutNoControlFill.Should().Be("darkgray");

            var junctionSwitchWithoutNoControlFillOpacity =
                junctionSwitchWithoutNoControlGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            junctionSwitchWithoutNoControlFillOpacity.Should().NotBeNull();
            junctionSwitchWithoutNoControlFillOpacity.Should().Be("1");

            var junctionSwitchWithoutNoControlStroke =
                junctionSwitchWithoutNoControlGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            junctionSwitchWithoutNoControlStroke.Should().NotBeNull();
            junctionSwitchWithoutNoControlStroke.Should().Be("#000");

            var junctionSwitchWithoutNoControlStrokeWidth =
                junctionSwitchWithoutNoControlGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            junctionSwitchWithoutNoControlStrokeWidth.Should().NotBeNull();
            junctionSwitchWithoutNoControlStrokeWidth.Should().Be("2");

            var rectangleFirst = junctionSwitchWithoutNoControlGroup.ChildNodes[0];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1112.114");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1499.541");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var rectangleSecond = junctionSwitchWithoutNoControlGroup.ChildNodes[1];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1132.114");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1499.541");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Стрелочный коммутатор-3");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1018.85");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1480.279");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void JunctionSwitchWithoutNoControl2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.junctionSwitchWithoutNoControl2.chr",
                    JunctionSwitchWithoutNoControlName);
            currentGroup.Should().NotBeNull();
            
                        var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var junctionSwitchWithoutNoControlGroup = currentGroup.SelectSingleNode("x:g", ns);
            junctionSwitchWithoutNoControlGroup.Should().NotBeNull();
            junctionSwitchWithoutNoControlGroup!.ChildNodes.Count.Should().Be(2);
            junctionSwitchWithoutNoControlGroup!.Attributes.Should().NotBeNull();
            junctionSwitchWithoutNoControlGroup !.Attributes!.Count.Should().Be(4);

            var junctionSwitchWithoutNoControlFill =
                junctionSwitchWithoutNoControlGroup!.Attributes!.GetNamedItem("fill")!.Value;
            junctionSwitchWithoutNoControlFill.Should().NotBeNull();
            junctionSwitchWithoutNoControlFill.Should().Be("darkgray");

            var junctionSwitchWithoutNoControlFillOpacity =
                junctionSwitchWithoutNoControlGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            junctionSwitchWithoutNoControlFillOpacity.Should().NotBeNull();
            junctionSwitchWithoutNoControlFillOpacity.Should().Be("1");

            var junctionSwitchWithoutNoControlStroke =
                junctionSwitchWithoutNoControlGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            junctionSwitchWithoutNoControlStroke.Should().NotBeNull();
            junctionSwitchWithoutNoControlStroke.Should().Be("#000");

            var junctionSwitchWithoutNoControlStrokeWidth =
                junctionSwitchWithoutNoControlGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            junctionSwitchWithoutNoControlStrokeWidth.Should().NotBeNull();
            junctionSwitchWithoutNoControlStrokeWidth.Should().Be("2");

            var rectangleFirst = junctionSwitchWithoutNoControlGroup.ChildNodes[0];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1449.891");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1509.541");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var rectangleSecond = junctionSwitchWithoutNoControlGroup.ChildNodes[1];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1479.891");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1509.541");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Стрелочный коммутатор-4");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1378.85");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1486.945");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void UkspsTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("JunctionSwitch.uksps.chr", UkspsName);
            currentGroup.Should().NotBeNull();
            
                        var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var ukspsGroup = currentGroup.SelectSingleNode("x:g", ns);
            ukspsGroup.Should().NotBeNull();
            ukspsGroup!.ChildNodes.Count.Should().Be(3);
            ukspsGroup!.Attributes.Should().NotBeNull();
            ukspsGroup !.Attributes!.Count.Should().Be(4);

            var ukspsFill = ukspsGroup!.Attributes!.GetNamedItem("fill")!.Value;
            ukspsFill.Should().NotBeNull();
            ukspsFill.Should().Be("darkgray");

            var ukspsFillOpacity = ukspsGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            ukspsFillOpacity.Should().NotBeNull();
            ukspsFillOpacity.Should().Be("1");

            var ukspsStroke = ukspsGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            ukspsStroke.Should().NotBeNull();
            ukspsStroke.Should().Be("#000");

            var ukspsStrokeWidth = ukspsGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            ukspsStrokeWidth.Should().NotBeNull();
            ukspsStrokeWidth.Should().Be("2");

            var rectangleFirst = ukspsGroup.ChildNodes[0];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("447.865");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1637.056");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");

            var rectangleSecond = ukspsGroup.ChildNodes[1];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("516.956");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1570.692");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");
            rectangleSecond!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("red");

            var rectangleThird = ukspsGroup.ChildNodes[2];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("586.046");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1637.056");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("20");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("10");
            rectangleThird!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("red");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("УКСПС-1");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("486.116");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1553.39");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}