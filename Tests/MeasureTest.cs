using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class MeasureTest
    {
        private const string MeasureName = "StandardLibrary.Measure";

        [Test]
        public void EmptyMeasureBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Measure.emptyLeft.chr", MeasureName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Measure.emptyTop.chr", MeasureName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void MeasureShowZeroesAfterPointTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Measure.showZeroesAfterPoint.chr", MeasureName);
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
            var textFirst = currentGroup.ChildNodes[0];
            textFirst.Should().NotBeNull();
            textFirst!.InnerText.Should().Be("");
            textFirst!.Attributes.Should().NotBeNull();
            textFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-339.828 3535.06,1315.748)");
            textFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3535.06");
            textFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1328.422");
            textFirst!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("14");
            textFirst!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textFirst!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#3CB371");
            textFirst!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textFirst!.Attributes!.GetNamedItem("data-measure-showzerosafterpoint")!.Value.Should().Be("true");

            var textSecond = currentGroup.ChildNodes[1];
            textSecond.Should().NotBeNull();
            textSecond!.InnerText.Should().Be("С точками");
            textSecond!.Attributes.Should().NotBeNull();
            textSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3529.11");
            textSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1289.819");
            textSecond!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textSecond!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textSecond!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#F08080");
            textSecond!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void MeasureDontShowZeroesAfterPointTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Measure.dontShowZeroesAfterPoint.chr", MeasureName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var textFirst = currentGroup.ChildNodes[0];
            textFirst.Should().NotBeNull();
            textFirst!.InnerText.Should().Be("");
            textFirst!.Attributes.Should().NotBeNull();
            textFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-22.69154 3553.5,1205.583)");
            textFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3553.5");
            textFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1218.257");
            textFirst!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("14");
            textFirst!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textFirst!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textFirst!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textFirst!.Attributes!.GetNamedItem("data-measure-showzerosafterpoint")!.Value.Should().Be("false");

            var textSecond = currentGroup.ChildNodes[1];
            textSecond.Should().NotBeNull();
            textSecond!.InnerText.Should().Be("Без точек");
            textSecond!.Attributes.Should().NotBeNull();
            textSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3520.46");
            textSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1163.127");
            textSecond!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textSecond!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textSecond!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textSecond!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void MeasureWithFontStyleTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Measure.measureWithFontStyle.chr", MeasureName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var textFirst = currentGroup.ChildNodes[0];
            textFirst.Should().NotBeNull();
            textFirst!.InnerText.Should().Be("");
            textFirst!.Attributes.Should().NotBeNull();
            textFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-22.69154 3553.5,1205.583)");
            textFirst!.Attributes!.GetNamedItem("font-style")!.Value.Should().Be("italic");
            textFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3553.5");
            textFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1218.257");
            textFirst!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("14");
            textFirst!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textFirst!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textFirst!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textFirst!.Attributes!.GetNamedItem("data-measure-showzerosafterpoint")!.Value.Should().Be("false");

            var textSecond = currentGroup.ChildNodes[1];
            textSecond.Should().NotBeNull();
            textSecond!.InnerText.Should().Be("Без точек");
            textSecond!.Attributes.Should().NotBeNull();
            textSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3520.46");
            textSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1163.127");
            textSecond!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textSecond!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textSecond!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textSecond!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void MeasureWithWithIdTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Measure.measureWithId.chr", MeasureName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(2);

            var textFirst = currentGroup.ChildNodes[0];
            textFirst.Should().NotBeNull();
            textFirst!.InnerText.Should().Be("");
            textFirst!.Attributes.Should().NotBeNull();
            textFirst!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-22.69154 3553.5,1205.583)");
            textFirst!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3553.5");
            textFirst!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1218.257");
            textFirst!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("14");
            textFirst!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textFirst!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textFirst!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textFirst!.Attributes!.GetNamedItem("data-measure-showzerosafterpoint")!.Value.Should().Be("false");
            textFirst!.Attributes!.GetNamedItem("data-measure-objectid")!.Value.Should().Be("100");
            textFirst!.Attributes!.GetNamedItem("data-measure-id")!.Value.Should().Be("500");

            var textSecond = currentGroup.ChildNodes[1];
            textSecond.Should().NotBeNull();
            textSecond!.InnerText.Should().Be("Без точек");
            textSecond!.Attributes.Should().NotBeNull();
            textSecond!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3520.46");
            textSecond!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1163.127");
            textSecond!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textSecond!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textSecond!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textSecond!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}