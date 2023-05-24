using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class SemaphoreTest
    {
        private const string SemaphoreElementName = "StandardLibrary.Semaphore";

        [Test]
        public void EmptySemaphoreBoundsTest()
        {
            var (currentGroup, _) = StandardFunctions.GetCurrentGroup("Semaphore.emptyLeft.chr", SemaphoreElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) = StandardFunctions.GetCurrentGroup("Semaphore.emptyTop.chr", SemaphoreElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Semaphore.emptySemaphoreType.chr", SemaphoreElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) = StandardFunctions.GetCurrentGroup("Semaphore.emptyLegType.chr", SemaphoreElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) = StandardFunctions.GetCurrentGroup("Semaphore.emptyLampShape.chr", SemaphoreElementName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void ErrorSemaphorePropertiesTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Semaphore.errorSemaphoreType.chr", SemaphoreElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Semaphore.errorLegType.chr", SemaphoreElementName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Semaphore.errorLampShape.chr", SemaphoreElementName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void SemaphoreDwarfCircle1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfCircle1.chr", SemaphoreElementName);
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

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=1");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(2);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("1");

            // Проверка содержимого дочерних элементов
            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2517.368");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("330.438");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2517.368");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("346.438");

            var circleFirst = semaphoreGroup.SelectSingleNode("x:circle", ns);
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2507.368");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("338.438");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-круг-1");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2497.089");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("319.925");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfCircle2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfCircle2.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=2");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(3);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(6);

            var semaphoreTransform = semaphoreGroup!.Attributes!.GetNamedItem("transform")!.Value;
            semaphoreTransform.Should().NotBeNull();
            semaphoreTransform.Should().Be("rotate(-55 2446.2,438.714)");

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("2");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2464.2");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("430.714");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2464.2");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("446.714");

            var circleFirst = semaphoreGroup.ChildNodes[1];
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2454.2");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("438.714");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleSecond = semaphoreGroup.ChildNodes[2];
            circleSecond.Should().NotBeNull();
            circleSecond!.Attributes.Should().NotBeNull();
            circleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp1");
            circleSecond!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2438.2");
            circleSecond!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("438.714");
            circleSecond!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-круг-2");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2383.2");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("386.63");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfCircle3Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfCircle3.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=3");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(4);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("3");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2475.475");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("522.143");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2475.475");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("538.143");

            var circleFirst = semaphoreGroup.ChildNodes[1];
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2465.475");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("530.143");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleSecond = semaphoreGroup.ChildNodes[2];
            circleSecond.Should().NotBeNull();
            circleSecond!.Attributes.Should().NotBeNull();
            circleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp1");
            circleSecond!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2449.475");
            circleSecond!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("530.143");
            circleSecond!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleThird = semaphoreGroup.ChildNodes[3];
            circleThird.Should().NotBeNull();
            circleThird!.Attributes.Should().NotBeNull();
            circleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp2");
            circleThird!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2433.475");
            circleThird!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("530.143");
            circleThird!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-круг-3");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2392.046");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("494.487");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfCircle4Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfCircle4.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=4");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(5);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("4");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2469.029");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("604.635");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2469.029");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("636.635");

            var circleFirst = semaphoreGroup.ChildNodes[1];
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2459.029");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("628.635");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleSecond = semaphoreGroup.ChildNodes[2];
            circleSecond.Should().NotBeNull();
            circleSecond!.Attributes.Should().NotBeNull();
            circleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp1");
            circleSecond!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2443.029");
            circleSecond!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("628.635");
            circleSecond!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleThird = semaphoreGroup.ChildNodes[3];
            circleThird.Should().NotBeNull();
            circleThird!.Attributes.Should().NotBeNull();
            circleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp2");
            circleThird!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2459.029");
            circleThird!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("612.635");
            circleThird!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleFourth = semaphoreGroup.ChildNodes[4];
            circleFourth.Should().NotBeNull();
            circleFourth!.Attributes.Should().NotBeNull();
            circleFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp3");
            circleFourth!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2443.029");
            circleFourth!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("612.635");
            circleFourth!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-круг-4");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2389.904");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("583.051");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfCircle5Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfCircle5.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=5");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(6);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("5");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2491.279");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("715.26");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2491.279");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("747.26");

            var circleFirst = semaphoreGroup.ChildNodes[1];
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2481.279");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("739.26");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleSecond = semaphoreGroup.ChildNodes[2];
            circleSecond.Should().NotBeNull();
            circleSecond!.Attributes.Should().NotBeNull();
            circleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp1");
            circleSecond!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2465.279");
            circleSecond!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("739.26");
            circleSecond!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleThird = semaphoreGroup.ChildNodes[3];
            circleThird.Should().NotBeNull();
            circleThird!.Attributes.Should().NotBeNull();
            circleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp2");
            circleThird!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2449.279");
            circleThird!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("739.26");
            circleThird!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleFourth = semaphoreGroup.ChildNodes[4];
            circleFourth.Should().NotBeNull();
            circleFourth!.Attributes.Should().NotBeNull();
            circleFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp3");
            circleFourth!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2481.279");
            circleFourth!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("723.26");
            circleFourth!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleFifth = semaphoreGroup.ChildNodes[5];
            circleFifth.Should().NotBeNull();
            circleFifth!.Attributes.Should().NotBeNull();
            circleFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp4");
            circleFifth!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2465.279");
            circleFifth!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("723.26");
            circleFifth!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-круг-5");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2391.779");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("690.551");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastCircle1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastCircle1.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=1");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(3);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("1");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2506.012");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("881.784");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2506.012");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("897.784");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2498.012");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("889.784");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2506.012");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("889.784");

            var circleFirst = semaphoreGroup.SelectSingleNode("x:circle", ns);
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2490.012");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("889.784");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-круг-1");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2399.297");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("841.897");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastCircle2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastCircle2.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=2");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(4);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("2");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2471.105");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("987.713");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2471.105");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1003.713");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2463.105");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("995.713");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2471.105");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("995.713");

            var circleFirst = semaphoreGroup.ChildNodes[2];
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2455.105");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("995.713");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleSecond = semaphoreGroup.ChildNodes[3];
            circleSecond.Should().NotBeNull();
            circleSecond!.Attributes.Should().NotBeNull();
            circleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp1");
            circleSecond!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2439.105");
            circleSecond!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("995.713");
            circleSecond!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-круг-2");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2405.772");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("943.629");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastCircle3Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastCircle3.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=3");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(5);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(6);

            var semaphoreTransform = semaphoreGroup!.Attributes!.GetNamedItem("transform")!.Value;
            semaphoreTransform.Should().NotBeNull();
            semaphoreTransform.Should().Be("rotate(-90 2453.38,1087.141)");

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("3");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2482.38");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1079.141");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2482.38");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1095.141");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2474.38");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1087.141");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2482.38");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1087.141");

            var circleFirst = semaphoreGroup.ChildNodes[2];
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2466.38");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1087.141");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleSecond = semaphoreGroup.ChildNodes[3];
            circleSecond.Should().NotBeNull();
            circleSecond!.Attributes.Should().NotBeNull();
            circleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp1");
            circleSecond!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2450.38");
            circleSecond!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1087.141");
            circleSecond!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleThird = semaphoreGroup.ChildNodes[4];
            circleThird.Should().NotBeNull();
            circleThird!.Attributes.Should().NotBeNull();
            circleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp2");
            circleThird!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2434.38");
            circleThird!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1087.141");
            circleThird!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-круг-3");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2392.951");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1051.486");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastCircle4Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastCircle4.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=4");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(6);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("4");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2507.933");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1161.634");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2507.933");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1177.634");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2499.933");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1169.634");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2507.933");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1169.634");

            var circleFirst = semaphoreGroup.ChildNodes[2];
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2491.933");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1169.634");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleSecond = semaphoreGroup.ChildNodes[3];
            circleSecond.Should().NotBeNull();
            circleSecond!.Attributes.Should().NotBeNull();
            circleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp1");
            circleSecond!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2475.933");
            circleSecond!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1169.634");
            circleSecond!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleThird = semaphoreGroup.ChildNodes[4];
            circleThird.Should().NotBeNull();
            circleThird!.Attributes.Should().NotBeNull();
            circleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp2");
            circleThird!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2459.933");
            circleThird!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1169.634");
            circleThird!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleFourth = semaphoreGroup.ChildNodes[5];
            circleFourth.Should().NotBeNull();
            circleFourth!.Attributes.Should().NotBeNull();
            circleFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp3");
            circleFourth!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2443.933");
            circleFourth!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1169.634");
            circleFourth!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-круг-4");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2390.808");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1140.05");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastCircle5Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastCircle5.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=5");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=0");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(7);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("5");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2530.183");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1272.259");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2530.183");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1288.259");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2522.183");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1280.259");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2530.183");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1280.259");

            var circleFirst = semaphoreGroup.ChildNodes[2];
            circleFirst.Should().NotBeNull();
            circleFirst!.Attributes.Should().NotBeNull();
            circleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            circleFirst!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2514.183");
            circleFirst!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1280.259");
            circleFirst!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleSecond = semaphoreGroup.ChildNodes[3];
            circleSecond.Should().NotBeNull();
            circleSecond!.Attributes.Should().NotBeNull();
            circleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp1");
            circleSecond!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2498.183");
            circleSecond!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1280.259");
            circleSecond!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleThird = semaphoreGroup.ChildNodes[4];
            circleThird.Should().NotBeNull();
            circleThird!.Attributes.Should().NotBeNull();
            circleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp2");
            circleThird!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2482.183");
            circleThird!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1280.259");
            circleThird!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleFourth = semaphoreGroup.ChildNodes[5];
            circleFourth.Should().NotBeNull();
            circleFourth!.Attributes.Should().NotBeNull();
            circleFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp3");
            circleFourth!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2466.183");
            circleFourth!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1280.259");
            circleFourth!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");

            var circleFifth = semaphoreGroup.ChildNodes[6];
            circleFifth.Should().NotBeNull();
            circleFifth!.Attributes.Should().NotBeNull();
            circleFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp4");
            circleFifth!.Attributes!.GetNamedItem("cx")!.Value.Should().Be("2450.183");
            circleFifth!.Attributes!.GetNamedItem("cy")!.Value.Should().Be("1280.259");
            circleFifth!.Attributes!.GetNamedItem("r")!.Value.Should().Be("8");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-круг-5");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2392.683");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1247.55");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfRhombus1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfRhombus1.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=1");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(2);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("1");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2852.073");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("319.929");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2852.073");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("335.929");

            var rectangleElement = semaphoreGroup.SelectSingleNode("x:rect", ns);
            rectangleElement.Should().NotBeNull();
            rectangleElement!.Attributes.Should().NotBeNull();
            rectangleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            rectangleElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2842.073,327.929)");
            rectangleElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2836.417");
            rectangleElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("322.272");
            rectangleElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-ромб-1");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2751.359");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("279.416");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfRhombus2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfRhombus2.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=2");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(3);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("2");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2816.452");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("425.857");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2816.452");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("441.857");

            var rectangleFirst = semaphoreGroup.ChildNodes[1];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            rectangleFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2806.452,433.857)");
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2800.796");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("428.2");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleSecond = semaphoreGroup.ChildNodes[2];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp1");
            rectangleSecond!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2790.452,433.857)");
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2784.796");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("428.2");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-ромб-2");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2735.452");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("381.773");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfRhombus3Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfRhombus3.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=3");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(4);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("3");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2828.441");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("517.286");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2828.441");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("533.286");

            var rectangleFirst = semaphoreGroup.ChildNodes[1];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            rectangleFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2818.441,525.286)");
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2812.784");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("519.629");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleSecond = semaphoreGroup.ChildNodes[2];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp1");
            rectangleSecond!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2802.441,525.286)");
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2796.784");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("519.629");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleThird = semaphoreGroup.ChildNodes[3];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp2");
            rectangleThird!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2786.441,525.286)");
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2780.784");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("519.629");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-ромб-3");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2745.013");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("489.63");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfRhombus4Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfRhombus4.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=4");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(5);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(6);
            
            var semaphoreTransform = semaphoreGroup!.Attributes!.GetNamedItem("transform")!.Value;
            semaphoreTransform.Should().NotBeNull();
            semaphoreTransform.Should().Be("rotate(320 2803.995,615.778)");

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("4");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2821.995");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("599.778");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2821.995");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("631.778");

            var rectangleFirst = semaphoreGroup.ChildNodes[1];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            rectangleFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2811.995,623.778)");
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2806.338");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("618.121");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleSecond = semaphoreGroup.ChildNodes[2];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp1");
            rectangleSecond!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2795.995,623.778)");
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2790.338");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("618.121");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleThird = semaphoreGroup.ChildNodes[3];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp2");
            rectangleThird!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2811.995,607.778)");
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2806.338");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("602.121");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleFourth = semaphoreGroup.ChildNodes[4];
            rectangleFourth.Should().NotBeNull();
            rectangleFourth!.Attributes.Should().NotBeNull();
            rectangleFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp3");
            rectangleFourth!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2795.995,607.778)");
            rectangleFourth!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2790.338");
            rectangleFourth!.Attributes!.GetNamedItem("y")!.Value.Should().Be("602.121");
            rectangleFourth!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFourth!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-ромб-4");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2743.584");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("578.909");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreDwarfRhombus5Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.dwarfRhombus5.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=5");
            objectHint!.Split(",")[1].Should().Be("LegType=0");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(6);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("5");

            var lineElement = semaphoreGroup.SelectSingleNode("x:line", ns);
            lineElement.Should().NotBeNull();
            lineElement!.Attributes.Should().NotBeNull();
            lineElement!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2844.245");
            lineElement!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("710.403");
            lineElement!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2844.245");
            lineElement!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("742.403");

            var rectangleFirst = semaphoreGroup.ChildNodes[1];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp0");
            rectangleFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2834.245,734.403)");
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2828.588");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("728.746");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleSecond = semaphoreGroup.ChildNodes[2];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp1");
            rectangleSecond!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2818.245,734.403)");
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2812.588");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("728.746");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleThird = semaphoreGroup.ChildNodes[3];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp2");
            rectangleThird!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2802.245,734.403)");
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2796.588");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("728.746");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleFourth = semaphoreGroup.ChildNodes[4];
            rectangleFourth.Should().NotBeNull();
            rectangleFourth!.Attributes.Should().NotBeNull();
            rectangleFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp3");
            rectangleFourth!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2834.245,718.403)");
            rectangleFourth!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2828.588");
            rectangleFourth!.Attributes!.GetNamedItem("y")!.Value.Should().Be("712.746");
            rectangleFourth!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFourth!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleFifth = semaphoreGroup.ChildNodes[5];
            rectangleFifth.Should().NotBeNull();
            rectangleFifth!.Attributes.Should().NotBeNull();
            rectangleFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("short-lamp4");
            rectangleFifth!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2818.245,718.403)");
            rectangleFifth!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2812.588");
            rectangleFifth!.Attributes!.GetNamedItem("y")!.Value.Should().Be("712.746");
            rectangleFifth!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFifth!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Карлик-ромб-5");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2744.745");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("685.694");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastRhombus1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastRhombus1.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=1");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(3);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("1");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2858.978");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("878.356");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2858.978");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("894.356");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2850.978");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("886.356");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2858.978");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("886.356");

            var rectangleElement = semaphoreGroup.SelectSingleNode("x:rect", ns);
            rectangleElement.Should().NotBeNull();
            rectangleElement!.Attributes.Should().NotBeNull();
            rectangleElement!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            rectangleElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2842.978,886.356)");
            rectangleElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2837.321");
            rectangleElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("880.699");
            rectangleElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-ромб-1");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2752.264");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("838.468");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastRhombus2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastRhombus2.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
                        var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=2");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(4);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("2");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2824.071");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("982.856");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2824.071");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("998.856");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2816.071");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("990.856");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2824.071");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("990.856");

            var rectangleFirst = semaphoreGroup.ChildNodes[2];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            rectangleFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2808.071,990.856)");
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2802.415");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("985.199");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleSecond = semaphoreGroup.ChildNodes[3];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp1");
            rectangleSecond!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2792.071,990.856)");
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2786.415");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("985.199");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-ромб-2");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2758.738");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("938.772");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastRhombus3Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastRhombus3.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=3");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(5);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("3");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2835.346");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1074.999");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2835.346");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1090.999");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2827.346");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1082.999");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2835.346");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1082.999");

            var rectangleFirst = semaphoreGroup.ChildNodes[2];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            rectangleFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2819.346,1082.999)");
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2813.689");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1077.342");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleSecond = semaphoreGroup.ChildNodes[3];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp1");
            rectangleSecond!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2803.346,1082.999)");
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2797.689");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1077.342");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleThird = semaphoreGroup.ChildNodes[4];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp2");
            rectangleThird!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2787.346,1082.999)");
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2781.689");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1077.342");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-ромб-3");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2745.917");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1047.343");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastRhombus4Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastRhombus4.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=4");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(6);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(5);

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("4");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2860.185");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1156.777");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2860.185");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1172.777");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2852.185");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1164.777");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2860.185");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1164.777");

            var rectangleFirst = semaphoreGroup.ChildNodes[2];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            rectangleFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2844.185,1164.777)");
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2838.528");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1159.12");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleSecond = semaphoreGroup.ChildNodes[3];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp1");
            rectangleSecond!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2828.185,1164.777)");
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2822.528");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1159.12");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleThird = semaphoreGroup.ChildNodes[4];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp2");
            rectangleThird!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2812.185,1164.777)");
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2806.528");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1159.12");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleFourth = semaphoreGroup.ChildNodes[5];
            rectangleFourth.Should().NotBeNull();
            rectangleFourth!.Attributes.Should().NotBeNull();
            rectangleFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp3");
            rectangleFourth!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2796.185,1164.777)");
            rectangleFourth!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2790.528");
            rectangleFourth!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1159.12");
            rectangleFourth!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFourth!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-ромб-4");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2743.06");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1135.193");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void SemaphoreMastRhombus5Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Semaphore.mastRhombus5.chr", SemaphoreElementName);
            currentGroup.Should().NotBeNull();
            
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(3);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();

            objectHint!.Split(",")[0].Should().Be("SemaphoreType=5");
            objectHint!.Split(",")[1].Should().Be("LegType=1");
            objectHint!.Split(",")[2].Should().Be("LampShape=1");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var semaphoreGroup = currentGroup.SelectSingleNode("x:g", ns);
            semaphoreGroup.Should().NotBeNull();
            semaphoreGroup!.ChildNodes.Count.Should().Be(7);
            semaphoreGroup!.Attributes.Should().NotBeNull();
            semaphoreGroup!.Attributes!.Count.Should().Be(6);
            
            var semaphoreTransform = semaphoreGroup!.Attributes!.GetNamedItem("transform")!.Value;
            semaphoreTransform.Should().NotBeNull();
            semaphoreTransform.Should().Be("rotate(-66 2838.149,1275.402)");

            var semaphoreFill = semaphoreGroup!.Attributes!.GetNamedItem("fill")!.Value;
            semaphoreFill.Should().NotBeNull();
            semaphoreFill.Should().Be("rgba(255,255,255,0)");

            var semaphoreFillOpacity = semaphoreGroup!.Attributes!.GetNamedItem("fill-opacity")!.Value;
            semaphoreFillOpacity.Should().NotBeNull();
            semaphoreFillOpacity.Should().Be("1");

            var semaphoreStroke = semaphoreGroup!.Attributes!.GetNamedItem("stroke")!.Value;
            semaphoreStroke.Should().NotBeNull();
            semaphoreStroke.Should().Be("#000");

            var semaphoreStrokeWidth = semaphoreGroup!.Attributes!.GetNamedItem("stroke-width")!.Value;
            semaphoreStrokeWidth.Should().NotBeNull();
            semaphoreStrokeWidth.Should().Be("2");

            var semaphoreDataLampCount = semaphoreGroup!.Attributes!.GetNamedItem("data-lamp-count")!.Value;
            semaphoreDataLampCount.Should().NotBeNull();
            semaphoreDataLampCount.Should().Be("5");

            var lineFirst = semaphoreGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2883.149");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1267.402");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2883.149");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1283.402");

            var lineSecond = semaphoreGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2875.149");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1275.402");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2883.149");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1275.402");

            var rectangleFirst = semaphoreGroup.ChildNodes[2];
            rectangleFirst.Should().NotBeNull();
            rectangleFirst!.Attributes.Should().NotBeNull();
            rectangleFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp0");
            rectangleFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2867.149,1275.402)");
            rectangleFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2861.493");
            rectangleFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1269.745");
            rectangleFirst!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFirst!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleSecond = semaphoreGroup.ChildNodes[3];
            rectangleSecond.Should().NotBeNull();
            rectangleSecond!.Attributes.Should().NotBeNull();
            rectangleSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp1");
            rectangleSecond!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2851.149,1275.402)");
            rectangleSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2845.493");
            rectangleSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1269.745");
            rectangleSecond!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleSecond!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleThird = semaphoreGroup.ChildNodes[4];
            rectangleThird.Should().NotBeNull();
            rectangleThird!.Attributes.Should().NotBeNull();
            rectangleThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp2");
            rectangleThird!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2835.149,1275.402)");
            rectangleThird!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2829.493");
            rectangleThird!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1269.745");
            rectangleThird!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleThird!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleFourth = semaphoreGroup.ChildNodes[5];
            rectangleFourth.Should().NotBeNull();
            rectangleFourth!.Attributes.Should().NotBeNull();
            rectangleFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp3");
            rectangleFourth!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2819.149,1275.402)");
            rectangleFourth!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2813.493");
            rectangleFourth!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1269.745");
            rectangleFourth!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFourth!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");
            
            var rectangleFifth = semaphoreGroup.ChildNodes[6];
            rectangleFifth.Should().NotBeNull();
            rectangleFifth!.Attributes.Should().NotBeNull();
            rectangleFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("mast-lamp4");
            rectangleFifth!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-45 2803.149,1275.402)");
            rectangleFifth!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2797.493");
            rectangleFifth!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1269.745");
            rectangleFifth!.Attributes!.GetNamedItem("width")!.Value.Should().Be("11.31371");
            rectangleFifth!.Attributes!.GetNamedItem("height")!.Value.Should().Be("11.31371");


            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Мачтовый-ромб-5");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2745.649");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1242.693");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}