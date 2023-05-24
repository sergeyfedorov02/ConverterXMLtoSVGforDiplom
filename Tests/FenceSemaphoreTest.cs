using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class FenceSemaphoreTest
    {
        private const string FenceSemaphoreElementName = "StandardLibrary.FenceSemaphore";

        [Test]
        public void EmptyFenceSemaphoreBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("FenceSemaphore.emptyLeft.chr", FenceSemaphoreElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("FenceSemaphore.emptyTop.chr", FenceSemaphoreElementName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void FenceSemaphore1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("FenceSemaphore.fenceSemaphore.chr", FenceSemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var fenceSemaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            fenceSemaphoreGroup.Should().NotBeNull();
            fenceSemaphoreGroup!.ChildNodes.Count.Should().Be(3);
            fenceSemaphoreGroup!.Attributes.Should().NotBeNull();
            fenceSemaphoreGroup!.Attributes!.Count.Should().Be(3);

            var fenceSemaphoreFill = fenceSemaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            fenceSemaphoreFill.Should().NotBeNull();
            fenceSemaphoreFill.Should().Be("rgba(255,255,255,0)");
            
            var fenceSemaphoreStroke = fenceSemaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            fenceSemaphoreStroke.Should().NotBeNull();
            fenceSemaphoreStroke.Should().Be("#000");

            var fenceSemaphoreStrokeWidth = fenceSemaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            fenceSemaphoreStrokeWidth.Should().NotBeNull();
            fenceSemaphoreStrokeWidth.Should().Be("2");

            var lineFirst = fenceSemaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2547.645");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1385.284");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2547.645");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1401.284");

            var lineSecond = fenceSemaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2539.645");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1393.284");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2547.645");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1393.284");

            var rectangle = fenceSemaphoreGroup.SelectSingleNode("x:rect", ns);
            rectangle.Should().NotBeNull();
            rectangle!.Attributes.Should().NotBeNull();
            rectangle!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fence-semaphore");
            rectangle!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2531.645,1393.284)");
            rectangle!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2525.988");
            rectangle!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1387.627");
            rectangle!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangle!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Заград-светофор-1");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2459.788");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1361.2");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}