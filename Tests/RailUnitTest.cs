using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class RailUnitTest
    {
        private const string RailUnitExName = "StandardLibrary.RailUnitEx";
        private const string RailUnitWithIntersection = "StandardLibrary.RailUnitWithIntersection";

        [Test]
        public void EmptyRailUnitExBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailUnit.railUnitExEmptyStart.chr", RailUnitExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailUnit.railUnitExEmptyOffsetEnd.chr", RailUnitExName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void EmptyRailUnitWithIntersectionBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailUnit.railUnitWithIntersectionEmptyStart.chr",
                    RailUnitWithIntersection);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailUnit.railUnitWithIntersectionEmptyOffsetIntervalStart.chr",
                    RailUnitWithIntersection);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailUnit.railUnitWithIntersectionEmptyIntervalLength.chr",
                    RailUnitWithIntersection);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailUnit.railUnitWithIntersectionEmptyOffsetIntervalEnd.chr",
                    RailUnitWithIntersection);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void RailUnitLeftTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailUnit.left.chr", RailUnitExName);
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
            var linesGroup = currentGroup.SelectSingleNode("x:g", ns);
            linesGroup.Should().NotBeNull();
            linesGroup!.ChildNodes.Count.Should().Be(2);

            linesGroup!.Attributes.Should().NotBeNull();
            linesGroup !.Attributes!.Count.Should().Be(2);

            var linesStroke = linesGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            linesStroke.Should().NotBeNull();
            linesStroke.Should().Be("#000");

            var linesStrokeWidth = linesGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            linesStrokeWidth.Should().NotBeNull();
            linesStrokeWidth.Should().Be("0");

            var lineOuter = linesGroup.ChildNodes[0];
            lineOuter.Should().NotBeNull();
            lineOuter!.Attributes.Should().NotBeNull();
            lineOuter!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-outer");
            lineOuter!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1487.947");
            lineOuter!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1121.597");
            lineOuter!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1509.765");
            lineOuter!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1121.597");
            lineOuter!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineOuter!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineInner = linesGroup.ChildNodes[1];
            lineInner.Should().NotBeNull();
            lineInner!.Attributes.Should().NotBeNull();
            lineInner!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-inner");
            lineInner!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1488.947");
            lineInner!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1121.597");
            lineInner!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1508.765");
            lineInner!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1121.597");
            lineInner!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineInner!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Путь-левый");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1368.32");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1104.204");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailUnitRightTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailUnit.right.chr", RailUnitExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var linesGroup = currentGroup.SelectSingleNode("x:g", ns);
            linesGroup.Should().NotBeNull();
            linesGroup!.ChildNodes.Count.Should().Be(2);

            linesGroup!.Attributes.Should().NotBeNull();
            linesGroup !.Attributes!.Count.Should().Be(2);

            var linesStroke = linesGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            linesStroke.Should().NotBeNull();
            linesStroke.Should().Be("#000");

            var linesStrokeWidth = linesGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            linesStrokeWidth.Should().NotBeNull();
            linesStrokeWidth.Should().Be("0");

            var lineOuter = linesGroup.ChildNodes[0];
            lineOuter.Should().NotBeNull();
            lineOuter!.Attributes.Should().NotBeNull();
            lineOuter!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-outer");
            lineOuter!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1523.447");
            lineOuter!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1113.302");
            lineOuter!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1544.962");
            lineOuter!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1113.302");
            lineOuter!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineOuter!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineInner = linesGroup.ChildNodes[1];
            lineInner.Should().NotBeNull();
            lineInner!.Attributes.Should().NotBeNull();
            lineInner!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-inner");
            lineInner!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1524.447");
            lineInner!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1113.302");
            lineInner!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1543.962");
            lineInner!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1113.302");
            lineInner!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineInner!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Путь-правый");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1539.426");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1101.363");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailUnitLeftRightTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailUnit.leftRight.chr", RailUnitExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var linesGroup = currentGroup.SelectSingleNode("x:g", ns);
            linesGroup.Should().NotBeNull();
            linesGroup!.ChildNodes.Count.Should().Be(2);

            linesGroup!.Attributes.Should().NotBeNull();
            linesGroup !.Attributes!.Count.Should().Be(3);

            var linesTransform = linesGroup!.Attributes!.GetNamedItem("transform")!.Value;
            linesTransform.Should().NotBeNull();
            linesTransform.Should().Be("rotate(-45 1264.659,728.523)");

            var linesStroke = linesGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            linesStroke.Should().NotBeNull();
            linesStroke.Should().Be("#000");

            var linesStrokeWidth = linesGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            linesStrokeWidth.Should().NotBeNull();
            linesStrokeWidth.Should().Be("0");

            var lineOuter = linesGroup.ChildNodes[0];
            lineOuter.Should().NotBeNull();
            lineOuter!.Attributes.Should().NotBeNull();
            lineOuter!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-outer");
            lineOuter!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1264.659");
            lineOuter!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("728.523");
            lineOuter!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1475.909");
            lineOuter!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("728.523");
            lineOuter!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineOuter!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineInner = linesGroup.ChildNodes[1];
            lineInner.Should().NotBeNull();
            lineInner!.Attributes.Should().NotBeNull();
            lineInner!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-inner");
            lineInner!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1265.659");
            lineInner!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("728.523");
            lineInner!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1474.909");
            lineInner!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("728.523");
            lineInner!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineInner!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Путь слева направо");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1144.729");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("637.039");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#F0F");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailUnitRightLeftTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailUnit.rightLeft.chr", RailUnitExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var linesGroup = currentGroup.SelectSingleNode("x:g", ns);
            linesGroup.Should().NotBeNull();
            linesGroup!.ChildNodes.Count.Should().Be(2);

            linesGroup!.Attributes.Should().NotBeNull();
            linesGroup !.Attributes!.Count.Should().Be(3);

            var linesTransform = linesGroup!.Attributes!.GetNamedItem("transform")!.Value;
            linesTransform.Should().NotBeNull();
            linesTransform.Should().Be("rotate(-45 1441.25,620)");

            var linesStroke = linesGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            linesStroke.Should().NotBeNull();
            linesStroke.Should().Be("#000");

            var linesStrokeWidth = linesGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            linesStrokeWidth.Should().NotBeNull();
            linesStrokeWidth.Should().Be("0");

            var lineOuter = linesGroup.ChildNodes[0];
            lineOuter.Should().NotBeNull();
            lineOuter!.Attributes.Should().NotBeNull();
            lineOuter!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-outer");
            lineOuter!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1190");
            lineOuter!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("620");
            lineOuter!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1441.25");
            lineOuter!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("620");
            lineOuter!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineOuter!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineInner = linesGroup.ChildNodes[1];
            lineInner.Should().NotBeNull();
            lineInner!.Attributes.Should().NotBeNull();
            lineInner!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-inner");
            lineInner!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1191");
            lineInner!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("620");
            lineInner!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1440.25");
            lineInner!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("620");
            lineInner!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineInner!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Путь справа налево");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1408.195");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("688.516");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#6A5ACD");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void RailUnitWithLeftIntersectionTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailUnit.leftIntersection.chr", RailUnitWithIntersection);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var linesGroup = currentGroup.SelectSingleNode("x:g", ns);
            linesGroup.Should().NotBeNull();
            linesGroup!.ChildNodes.Count.Should().Be(4);

            linesGroup!.Attributes.Should().NotBeNull();
            linesGroup !.Attributes!.Count.Should().Be(2);

            var linesStroke = linesGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            linesStroke.Should().NotBeNull();
            linesStroke.Should().Be("#000");

            var linesStrokeWidth = linesGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            linesStrokeWidth.Should().NotBeNull();
            linesStrokeWidth.Should().Be("0");

            var lineOuterFirst = linesGroup.ChildNodes[0];
            lineOuterFirst.Should().NotBeNull();
            lineOuterFirst!.Attributes.Should().NotBeNull();
            lineOuterFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-outer");
            lineOuterFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("971.667");
            lineOuterFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1116.667");
            lineOuterFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1003.333");
            lineOuterFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1116.667");
            lineOuterFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineOuterFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineInnerFirst = linesGroup.ChildNodes[1];
            lineInnerFirst.Should().NotBeNull();
            lineInnerFirst!.Attributes.Should().NotBeNull();
            lineInnerFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-inner");
            lineInnerFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("972.667");
            lineInnerFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1116.667");
            lineInnerFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1002.333");
            lineInnerFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1116.667");
            lineInnerFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineInnerFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");
            
            var lineOuterSecond = linesGroup.ChildNodes[2];
            lineOuterSecond.Should().NotBeNull();
            lineOuterSecond!.Attributes.Should().NotBeNull();
            lineOuterSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-outer");
            lineOuterSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1091.667");
            lineOuterSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1116.667");
            lineOuterSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1268.333");
            lineOuterSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1116.667");
            lineOuterSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineOuterSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineInnerSecond = linesGroup.ChildNodes[3];
            lineInnerSecond.Should().NotBeNull();
            lineInnerSecond!.Attributes.Should().NotBeNull();
            lineInnerSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-inner");
            lineInnerSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1092.667");
            lineInnerSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1116.667");
            lineInnerSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1267.333");
            lineInnerSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1116.667");
            lineInnerSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineInnerSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Путь с разрывом слева");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1016.737");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1100.183");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#D2691E");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void RailUnitWithRightIntersectionTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailUnit.rightIntersection.chr", RailUnitWithIntersection);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var linesGroup = currentGroup.SelectSingleNode("x:g", ns);
            linesGroup.Should().NotBeNull();
            linesGroup!.ChildNodes.Count.Should().Be(4);

            linesGroup!.Attributes.Should().NotBeNull();
            linesGroup !.Attributes!.Count.Should().Be(2);

            var linesStroke = linesGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            linesStroke.Should().NotBeNull();
            linesStroke.Should().Be("#000");

            var linesStrokeWidth = linesGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            linesStrokeWidth.Should().NotBeNull();
            linesStrokeWidth.Should().Be("0");

            var lineOuterFirst = linesGroup.ChildNodes[0];
            lineOuterFirst.Should().NotBeNull();
            lineOuterFirst!.Attributes.Should().NotBeNull();
            lineOuterFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-outer");
            lineOuterFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1146.667");
            lineOuterFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1213.333");
            lineOuterFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1278.333");
            lineOuterFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1213.333");
            lineOuterFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineOuterFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineInnerFirst = linesGroup.ChildNodes[1];
            lineInnerFirst.Should().NotBeNull();
            lineInnerFirst!.Attributes.Should().NotBeNull();
            lineInnerFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-inner");
            lineInnerFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1147.667");
            lineInnerFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1213.333");
            lineInnerFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1277.333");
            lineInnerFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1213.333");
            lineInnerFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineInnerFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");
            
            var lineOuterSecond = linesGroup.ChildNodes[2];
            lineOuterSecond.Should().NotBeNull();
            lineOuterSecond!.Attributes.Should().NotBeNull();
            lineOuterSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-outer");
            lineOuterSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1351.667");
            lineOuterSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1213.333");
            lineOuterSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1376.667");
            lineOuterSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1213.333");
            lineOuterSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineOuterSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineInnerSecond = linesGroup.ChildNodes[3];
            lineInnerSecond.Should().NotBeNull();
            lineInnerSecond!.Attributes.Should().NotBeNull();
            lineInnerSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-line-inner");
            lineInnerSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("1352.667");
            lineInnerSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1213.333");
            lineInnerSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("1375.667");
            lineInnerSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1213.333");
            lineInnerSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineInnerSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Путь с разрывом справа");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1156.737");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1251.849");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#191970");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}