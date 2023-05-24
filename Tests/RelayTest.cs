using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class RelayTest
    {
        private const string RelayName = "StandardLibrary.Relay";

        [Test]
        public void EmptyRelayBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Relay.emptyRelayLeft.chr", RelayName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Relay.emptyRelayRight.chr", RelayName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Relay.emptyRelayTop.chr", RelayName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Relay.emptyRelayBottom.chr", RelayName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void RailShapeTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Relay.emptyRelayShape.chr", RelayName);
            currentGroup.Should().BeNull();
            
            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Relay.errorRelayShape.chr", RelayName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void RelayTypeNTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Relay.relayTypeN.chr", RelayName);
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
            objectHint.Should().Be("RelayShape=TypeN");

            currentGroup.ChildNodes.Count.Should().Be(2);

            // Проверка содержимого дочерних элементов
            var lineRelayGroup = currentGroup.SelectSingleNode("x:line", ns);
            lineRelayGroup.Should().NotBeNull();
            lineRelayGroup!.Attributes.Should().NotBeNull();
            lineRelayGroup!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-26.02959 332.5,1419.541)");
            lineRelayGroup!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("300");
            lineRelayGroup!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1392.874");
            lineRelayGroup!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("365");
            lineRelayGroup!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1446.207");
            lineRelayGroup!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineRelayGroup!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Реле-нейтральный");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("234.2367");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1365.557");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void RelayTypePTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Relay.relayTypeP.chr", RelayName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint.Should().Be("RelayShape=TypeP");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var lineRelayGroup = currentGroup.SelectSingleNode("x:line", ns);
            lineRelayGroup.Should().NotBeNull();
            lineRelayGroup!.Attributes.Should().NotBeNull();
            lineRelayGroup!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("528.333");
            lineRelayGroup!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1452.874");
            lineRelayGroup!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("565");
            lineRelayGroup!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1376.207");
            lineRelayGroup!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineRelayGroup!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Реле-поляризованный");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("475.07");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1363.057");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void RelayTypeNMirrorTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Relay.relayTypeNMirror.chr", RelayName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint.Should().Be("RelayShape=TypeNMirror");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var lineRelayGroup = currentGroup.SelectSingleNode("x:line", ns);
            lineRelayGroup.Should().NotBeNull();
            lineRelayGroup!.Attributes.Should().NotBeNull();
            lineRelayGroup!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-346.908 865,1412.874)");
            lineRelayGroup!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("799.167");
            lineRelayGroup!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1434.541");
            lineRelayGroup!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("930.833");
            lineRelayGroup!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1391.207");
            lineRelayGroup!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineRelayGroup!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Реле-нейтрал зеркал");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("765.07");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1356.39");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}