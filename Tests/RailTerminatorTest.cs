using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class RailTerminatorTest
    {
        private const string RailTerminatorName = "StandardLibrary.RailTerminator";

        [Test]
        public void EmptyRailTerminatorBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailTerminator.railTerminatorEmptyLeft.chr", RailTerminatorName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailTerminator.railTerminatorEmptyTop.chr", RailTerminatorName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void RailTerminatorClockwiseTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailTerminator.railTerminatorClockwise.chr", RailTerminatorName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var polylineGroup = currentGroup.SelectSingleNode("x:g", ns);
            polylineGroup.Should().NotBeNull();
            polylineGroup!.ChildNodes.Count.Should().Be(2);

            polylineGroup!.Attributes.Should().NotBeNull();
            polylineGroup !.Attributes!.Count.Should().Be(5);

            var polylineTransform = polylineGroup!.Attributes!.GetNamedItem("transform")!.Value;
            polylineTransform.Should().NotBeNull();
            polylineTransform.Should().Be("rotate(-331.073 747.491,1207.855)");

            var polylineFill = polylineGroup!.Attributes!.GetNamedItem("fill")!.Value;
            polylineFill.Should().NotBeNull();
            polylineFill.Should().Be("rgba(255,255,255,0)");
            
            var polylineFillOpacity = polylineGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            polylineFillOpacity.Should().NotBeNull();
            polylineFillOpacity.Should().Be("0");

            var polylineStroke = polylineGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            polylineStroke.Should().NotBeNull();
            polylineStroke.Should().Be("#000");

            var linesStrokeWidth = polylineGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            linesStrokeWidth.Should().NotBeNull();
            linesStrokeWidth.Should().Be("4");

            var polylineFirst = polylineGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-terminator");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should().Be("727.491,1207.855 747.491,1207.855");

            var polylineSecond = polylineGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-terminator");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("767.491,1199.855 747.491,1199.855 747.491,1215.855 767.491,1215.855");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Тупик по часовой");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("688.394");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1185.038");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void RailTerminatorCounterClockwiseTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailTerminator.railTerminatorCounterClockwise.chr",
                    RailTerminatorName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var polylineGroup = currentGroup.SelectSingleNode("x:g", ns);
            polylineGroup.Should().NotBeNull();
            polylineGroup!.ChildNodes.Count.Should().Be(2);

            polylineGroup!.Attributes.Should().NotBeNull();
            polylineGroup !.Attributes!.Count.Should().Be(5);

            var polylineTransform = polylineGroup!.Attributes!.GetNamedItem("transform")!.Value;
            polylineTransform.Should().NotBeNull();
            polylineTransform.Should().Be("rotate(-33.2749 522.394,1224.578)");

            var polylineFill = polylineGroup!.Attributes!.GetNamedItem("fill")!.Value;
            polylineFill.Should().NotBeNull();
            polylineFill.Should().Be("rgba(255,255,255,0)");
            
            var polylineFillOpacity = polylineGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            polylineFillOpacity.Should().NotBeNull();
            polylineFillOpacity.Should().Be("0");

            var polylineStroke = polylineGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            polylineStroke.Should().NotBeNull();
            polylineStroke.Should().Be("#000");

            var linesStrokeWidth = polylineGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            linesStrokeWidth.Should().NotBeNull();
            linesStrokeWidth.Should().Be("4");

            var polylineFirst = polylineGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-terminator");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should().Be("502.394,1224.578 522.394,1224.578");

            var polylineSecond = polylineGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rc-terminator");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("542.394,1216.578 522.394,1216.578 522.394,1232.578 542.394,1232.578");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Тупик против часовой");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("378.131");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1181.76");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}