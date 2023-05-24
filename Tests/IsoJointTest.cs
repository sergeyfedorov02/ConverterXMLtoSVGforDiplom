using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class IsoJointTest
    {
        private const string IsoJointName = "StandardLibrary.IsoJoint";

        [Test]
        public void EmptyIsoJointBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("IsoJoint.isoJointEmptyLeft.chr", IsoJointName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("IsoJoint.isoJointEmptyTop.chr", IsoJointName);
            currentGroup.Should().BeNull();
            
            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("IsoJoint.isoJointEmptyType.chr", IsoJointName);
            currentGroup.Should().BeNull();
            
            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("IsoJoint.isoJointErrorType.chr", IsoJointName);
            currentGroup.Should().BeNull();
        }
        
        [Test]
        public void IsoJointOverallTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("IsoJoint.isoJointOverall.chr", IsoJointName);
            currentGroup.Should().BeNull();
        }
        
        [Test]
        public void IsoJointNoOverallTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("IsoJoint.isoJointNoOverall.chr", IsoJointName);
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
            var circleElement = currentGroup.SelectSingleNode("x:circle", ns);
            circleElement.Should().NotBeNull();
            circleElement!.Attributes.Should().NotBeNull();
            circleElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-31.2284 1516.606,1117.45)");
            circleElement!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("1516.606");
            circleElement!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1117.45");
            circleElement!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");
            circleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            circleElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("0");
            circleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("darkgray");
            circleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");
            
            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Изостык не габаритный против часовой");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1348.599");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1152.581");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void IsoJointCellTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("IsoJoint.isoJointCell.chr", IsoJointName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");
            
            currentGroup.ChildNodes.Count.Should().Be(1);

            var rectangleElement = currentGroup.SelectSingleNode("x:rect", ns);
            rectangleElement.Should().NotBeNull();
            rectangleElement!.Attributes.Should().NotBeNull();
            rectangleElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1583.213");
            rectangleElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1236.022");
            rectangleElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("2");
            rectangleElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("2");
            rectangleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            rectangleElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("0");
            rectangleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("darkgray");
            rectangleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");
        }
    }
}