using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class PanelTest
    {
        private const string PanelName = "StandardLibrary.Panel";

        [Test]
        public void EmptyPanelBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Panel.emptyLeft.chr", PanelName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Panel.emptyRight.chr", PanelName);
            currentGroup.Should().BeNull();
            
            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Panel.emptyTop.chr", PanelName);
            currentGroup.Should().BeNull();
            
            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Panel.emptyBottom.chr", PanelName);
            currentGroup.Should().BeNull();
        }
        
        [Test]
        public void PanelMainTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Panel.panelMain.chr", PanelName);
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
            var rectangleElement = currentGroup.SelectSingleNode("x:rect", ns);
            rectangleElement.Should().NotBeNull();
            rectangleElement!.Attributes.Should().NotBeNull();
            rectangleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("fill-indicator");
            rectangleElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3729.57");
            rectangleElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1125.101");
            rectangleElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("191.4285");
            rectangleElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("280");
            rectangleElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("rgba(255,255,255,0)");
            rectangleElement!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            rectangleElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Панель ");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3787.5");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1095.045");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}