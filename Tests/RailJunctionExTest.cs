using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class RailJunctionExTest
    {
        private const string RailJunctionExName = "StandardLibrary.RailJunctionEx";

        [Test]
        public void EmptyRailJunctionExBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.emptyCenterPoint.chr", RailJunctionExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.emptyOffsetA2.chr", RailJunctionExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.emptyOffsetC2.chr", RailJunctionExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.emptyOffsetB2.chr", RailJunctionExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.emptyOffsetD2B.chr", RailJunctionExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.emptyAngle.chr", RailJunctionExName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void ErrorRailJunctionPropertiesTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.emptyType.chr", RailJunctionExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.errorType.chr", RailJunctionExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.emptyIsInverse.chr", RailJunctionExName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.errorIsInverse.chr", RailJunctionExName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void Type1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type1.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            // Получение атрибутов текущей группы (верхний уровень)
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            // Получение значения атрибута по его имени
            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type1");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2473.75");
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2244.375");
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2627.083");
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2244.375");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2473.75");
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2244.375");
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2627.083");
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2244.375");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            lineThirdPlus.Should().NotBeNull();
            lineThirdPlus!.Attributes.Should().NotBeNull();
            lineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2528.75");
            lineThirdPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2235.715");
            lineThirdPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2555.739");
            lineThirdPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2188.969");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            lineFourthPlus.Should().NotBeNull();
            lineFourthPlus!.Attributes.Should().NotBeNull();
            lineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2529.25");
            lineFourthPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2234.849");
            lineFourthPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2555.239");
            lineFourthPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2189.835");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2473.75,2244.375 2523.75,2244.375 2555.739,2188.969");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2474.75,2244.375 2523.75,2244.375 2555.239,2189.835");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2533.75");
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2244.375");
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2627.083");
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2244.375");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2534.75");
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2244.375");
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2626.083");
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2244.375");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2528.75");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2235.715");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2555.739");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2188.969");
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2529.25");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2234.849");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2555.239");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2189.835");
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2533.75");
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2244.375");
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2627.083");
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2244.375");
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2534.75");
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2244.375");
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2626.083");
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2244.375");
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2473.75");
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2244.375");
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2513.75");
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2244.375");
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2474.75");
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2244.375");
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2512.75");
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2244.375");
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Первая стрелочная секция");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2371.32");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2162.904");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type1XTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type1X.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type1");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2466.428");
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2021.597");
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2619.762");
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2021.597");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2466.428");
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2021.597");
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2619.762");
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2021.597");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            lineThirdPlus.Should().NotBeNull();
            lineThirdPlus!.Attributes.Should().NotBeNull();
            lineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2521.428");
            lineThirdPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2030.257");
            lineThirdPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2548.417");
            lineThirdPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2077.003");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            lineFourthPlus.Should().NotBeNull();
            lineFourthPlus!.Attributes.Should().NotBeNull();
            lineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2521.928");
            lineFourthPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2031.123");
            lineFourthPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2547.917");
            lineFourthPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2076.137");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2466.428,2021.597 2516.428,2021.597 2548.417,2077.003");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2467.428,2021.597 2516.428,2021.597 2547.917,2076.137");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2526.428");
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2021.597");
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2619.762");
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2021.597");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2527.428");
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2021.597");
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2618.762");
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2021.597");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2521.428");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2030.257");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2548.417");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2077.003");
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2521.928");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2031.123");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2547.917");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2076.137");
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2526.428");
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2021.597");
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2619.762");
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2021.597");
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2527.428");
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2021.597");
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2618.762");
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2021.597");
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2466.428");
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2021.597");
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2506.428");
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2021.597");
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2467.428");
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2021.597");
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2505.428");
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2021.597");
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Первая вниз");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2476.856");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1968.697");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type1YTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type1Y.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type1");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2472.963");
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2361.851");
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2626.296");
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2361.851");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2472.963");
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2361.851");
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2626.296");
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2361.851");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            lineThirdPlus.Should().NotBeNull();
            lineThirdPlus!.Attributes.Should().NotBeNull();
            lineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2517.963");
            lineThirdPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2353.191");
            lineThirdPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2490.974");
            lineThirdPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2306.445");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            lineFourthPlus.Should().NotBeNull();
            lineFourthPlus!.Attributes.Should().NotBeNull();
            lineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2517.463");
            lineFourthPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2352.325");
            lineFourthPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2491.474");
            lineFourthPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2307.311");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2626.296,2361.851 2522.963,2361.851 2490.974,2306.445");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2625.296,2361.851 2522.963,2361.851 2491.474,2307.311");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2472.963");
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2361.851");
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2512.963");
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2361.851");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2473.963");
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2361.851");
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2511.963");
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2361.851");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2517.963");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2353.191");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2490.974");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2306.445");
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2517.463");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2352.325");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2491.474");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2307.311");
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2532.963");
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2361.851");
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2626.296");
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2361.851");
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2533.963");
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2361.851");
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2625.296");
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2361.851");
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2472.963");
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2361.851");
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2512.963");
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2361.851");
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2473.963");
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2361.851");
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2511.963");
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2361.851");
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Обратная");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2516.088");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2301.491");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type1XYTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type1XY.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type1");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var y1 = "1796.96";
            var y2 = "1805.62";
            var y3 = "1852.366";
            var y4 = "1806.486";
            var y5 = "1851.5";

            var x1 = "2432.741";
            var x2 = "2586.074";
            var x3 = "2477.741";
            var x4 = "2450.752";
            var x5 = "2477.241";
            var x6 = "2451.252";
            var x7 = "2433.741";
            var x8 = "2472.741";
            var x9 = "2471.741";
            var x10 = "2492.741";
            var x11 = "2586.074";
            var x12 = "2493.741";
            var x13 = "2585.074";

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            lineThirdPlus.Should().NotBeNull();
            lineThirdPlus!.Attributes.Should().NotBeNull();
            lineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineThirdPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThirdPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineThirdPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            lineFourthPlus.Should().NotBeNull();
            lineFourthPlus!.Attributes.Should().NotBeNull();
            lineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFourthPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourthPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineFourthPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2586.074,1796.96 2482.741,1796.96 2450.752,1852.366");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2585.074,1796.96 2482.741,1796.96 2451.252,1851.5");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x10);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x11);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x12);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x13);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Обратная вниз");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2443.168");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1744.06");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType1Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType1.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type1");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2703.333,2248.987 2753.333,2248.987 2788.688,2187.75");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2704.333,2248.987 2753.333,2248.987 2788.188,2188.616");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.333");
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2248.987");
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2856.667");
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2248.987");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2764.333");
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2248.987");
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2855.667");
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2248.987");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2703.333");
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2248.987");
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2856.667");
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2248.987");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2703.333");
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2248.987");
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2856.667");
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2248.987");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            lineThirdMinus.Should().NotBeNull();
            lineThirdMinus!.Attributes.Should().NotBeNull();
            lineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2758.333");
            lineThirdMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2240.327");
            lineThirdMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2788.688");
            lineThirdMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2187.75");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            lineFourthMinus.Should().NotBeNull();
            lineFourthMinus!.Attributes.Should().NotBeNull();
            lineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2758.833");
            lineFourthMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2239.461");
            lineFourthMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2788.188");
            lineFourthMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2188.616");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2758.333");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2240.327");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2788.688");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2187.75");
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2758.833");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2239.461");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2788.188");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2188.616");
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.333");
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2248.987");
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2856.667");
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2248.987");
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2764.333");
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2248.987");
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2855.667");
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2248.987");
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2703.333");
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2248.987");
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2743.333");
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2248.987");
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2704.333");
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2248.987");
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2742.333");
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2248.987");
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсная");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2748.403");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2176.266");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType1XTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType1X.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type1");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2708.333,2016.667 2758.333,2016.667 2790.322,2072.073");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2709.333,2016.667 2758.333,2016.667 2789.822,2071.207");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2768.333");
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2016.667");
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2861.667");
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2016.667");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2769.333");
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2016.667");
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2860.667");
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2016.667");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2708.333");
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2016.667");
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2861.667");
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2016.667");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2708.333");
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2016.667");
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2861.667");
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2016.667");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            lineThirdMinus.Should().NotBeNull();
            lineThirdMinus!.Attributes.Should().NotBeNull();
            lineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.333");
            lineThirdMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2025.327");
            lineThirdMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2790.322");
            lineThirdMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2072.073");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            lineFourthMinus.Should().NotBeNull();
            lineFourthMinus!.Attributes.Should().NotBeNull();
            lineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.833");
            lineFourthMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2026.193");
            lineFourthMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2789.822");
            lineFourthMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2071.207");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.333");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2025.327");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2790.322");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2072.073");
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.833");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2026.193");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2789.822");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2071.207");
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2768.333");
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2016.667");
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2861.667");
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2016.667");
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2769.333");
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2016.667");
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2860.667");
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2016.667");
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2708.333");
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2016.667");
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2748.333");
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2016.667");
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2709.333");
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2016.667");
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2747.333");
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2016.667");
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Вниз инверсная");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2718.76");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1963.767");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }


        [Test]
        public void InverseType1YTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType1Y.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type1");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2856.188,2364 2752.855,2364 2720.866,2308.594");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2855.188,2364 2752.855,2364 2721.366,2309.46");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2702.855");
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2364");
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2742.855");
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2364");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2703.855");
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2364");
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2741.855");
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2364");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2702.855");
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2364");
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2856.188");
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2364");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2702.855");
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2364");
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2856.188");
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2364");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            lineThirdMinus.Should().NotBeNull();
            lineThirdMinus!.Attributes.Should().NotBeNull();
            lineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2747.855");
            lineThirdMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2355.34");
            lineThirdMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2720.866");
            lineThirdMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2308.594");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            lineFourthMinus.Should().NotBeNull();
            lineFourthMinus!.Attributes.Should().NotBeNull();
            lineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2747.355");
            lineFourthMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2354.474");
            lineFourthMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2721.366");
            lineFourthMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2309.46");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2747.855");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2355.34");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2720.866");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2308.594");
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2747.355");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2354.474");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2721.366");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2309.46");
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2762.855");
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2364");
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2856.188");
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2364");
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.855");
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2364");
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2855.188");
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2364");
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2702.855");
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2364");
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2742.855");
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2364");
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2703.855");
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("2364");
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2741.855");
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("2364");
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Обратная инверсная");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2745.981");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2303.64");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType1XYTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType1XY.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type1");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2872.265,1797.744 2768.932,1797.744 2736.943,1853.151");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2871.265,1797.744 2768.932,1797.744 2737.443,1852.284");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2718.932");
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1797.744");
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2758.932");
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1797.744");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2719.932");
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1797.744");
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2757.932");
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1797.744");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2718.932");
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1797.744");
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2872.265");
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1797.744");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2718.932");
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1797.744");
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2872.265");
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1797.744");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            lineThirdMinus.Should().NotBeNull();
            lineThirdMinus!.Attributes.Should().NotBeNull();
            lineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.932");
            lineThirdMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1806.405");
            lineThirdMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2736.943");
            lineThirdMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1853.151");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            lineFourthMinus.Should().NotBeNull();
            lineFourthMinus!.Attributes.Should().NotBeNull();
            lineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.432");
            lineFourthMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1807.271");
            lineFourthMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2737.443");
            lineFourthMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1852.284");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.932");
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1806.405");
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2736.943");
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1853.151");
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2763.432");
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1807.271");
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2737.443");
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1852.284");
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2778.932");
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1797.744");
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2872.265");
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1797.744");
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2779.932");
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1797.744");
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2871.265");
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1797.744");
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2718.932");
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1797.744");
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2758.932");
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1797.744");
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be("2719.932");
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be("1797.744");
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be("2757.932");
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be("1797.744");
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Вниз инверсная обратная");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2670.787");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1746.273");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type2.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1994.393";
            var x2 = "2063.751";
            var x3 = "2047.702";
            var x4 = "2111.487";
            var x5 = "2048.702";
            var x6 = "2110.487";
            var x7 = "2042.702";
            var x8 = "2043.202";
            var x9 = "2063.251";
            var x10 = "2032.702";
            var x11 = "1994.893";
            var x12 = "2032.202";

            var y1 = "1802.058";
            var y2 = "1681.927";
            var y3 = "1727.045";
            var y4 = "1718.384";
            var y5 = "1717.518";
            var y6 = "1682.793";
            var y7 = "1735.705";
            var y8 = "1801.192";
            var y9 = "1736.571";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type2");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            lineThirdPlus.Should().NotBeNull();
            lineThirdPlus!.Attributes.Should().NotBeNull();
            lineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineThirdPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineThirdPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            lineFourthPlus.Should().NotBeNull();
            lineFourthPlus!.Attributes.Should().NotBeNull();
            lineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFourthPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFourthPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineFourthPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1994.393,1802.058 2037.702,1727.045 2111.487,1727.045");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1994.893,1801.192 2037.702,1727.045 2110.487,1727.045");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x10);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y7);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x11);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y8);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x12);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y9);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Второй тип");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2008.555");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1647.958");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type2XTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type2X.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1787.052";
            var x2 = "1856.409";
            var x3 = "1840.361";
            var x4 = "1904.146";
            var x5 = "1841.361";
            var x6 = "1903.146";
            var x7 = "1835.361";
            var x8 = "1835.861";
            var x9 = "1855.909";
            var x10 = "1825.361";
            var x11 = "1787.552";
            var x12 = "1824.861";

            var y1 = "1676.973";
            var y2 = "1797.104";
            var y3 = "1751.987";
            var y4 = "1760.647";
            var y5 = "1761.513";
            var y6 = "1796.238";
            var y7 = "1743.326";
            var y8 = "1677.839";
            var y9 = "1742.46";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type2");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            lineThirdPlus.Should().NotBeNull();
            lineThirdPlus!.Attributes.Should().NotBeNull();
            lineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineThirdPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineThirdPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            lineFourthPlus.Should().NotBeNull();
            lineFourthPlus!.Attributes.Should().NotBeNull();
            lineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFourthPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFourthPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineFourthPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1787.052,1676.973 1830.361,1751.987 1904.146,1751.987");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1787.552,1677.839 1830.361,1751.987 1903.146,1751.987");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x10);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y7);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x11);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y8);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x12);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y9);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия X");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1760.102");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1652.9");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type2YTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type2Y.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1594.007";
            var x2 = "1663.365";
            var x3 = "1627.316";
            var x4 = "1563.531";
            var x5 = "1626.316";
            var x6 = "1564.531";
            var x7 = "1632.316";
            var x8 = "1594.507";
            var x9 = "1631.816";
            var x10 = "1642.316";
            var x11 = "1642.816";
            var x12 = "1662.865";

            var y1 = "1673.897";
            var y2 = "1794.029";
            var y3 = "1748.911";
            var y4 = "1740.251";
            var y5 = "1674.763";
            var y6 = "1739.385";
            var y7 = "1757.571";
            var y8 = "1758.437";
            var y9 = "1793.163";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type2");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            lineThirdPlus.Should().NotBeNull();
            lineThirdPlus!.Attributes.Should().NotBeNull();
            lineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineThirdPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineThirdPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            lineFourthPlus.Should().NotBeNull();
            lineFourthPlus!.Attributes.Should().NotBeNull();
            lineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFourthPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFourthPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineFourthPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1663.365,1794.029 1637.316,1748.911 1563.531,1748.911");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1662.865,1793.163 1637.316,1748.911 1564.531,1748.911");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x7);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x10);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y7);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x11);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y8);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x12);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y9);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x7);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1553.724");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1650.936");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type2XYTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type2XY.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1402.151";
            var x2 = "1471.509";
            var x3 = "1435.46";
            var x4 = "1371.675";
            var x5 = "1434.46";
            var x6 = "1372.675";
            var x7 = "1440.46";
            var x8 = "1402.651";
            var x9 = "1439.96";
            var x10 = "1450.46";
            var x11 = "1450.96";
            var x12 = "1471.009";

            var y1 = "1808.687";
            var y2 = "1688.556";
            var y3 = "1733.673";
            var y4 = "1742.333";
            var y5 = "1807.821";
            var y6 = "1743.199";
            var y7 = "1725.013";
            var y8 = "1724.147";
            var y9 = "1689.422";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type2");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            lineThirdPlus.Should().NotBeNull();
            lineThirdPlus!.Attributes.Should().NotBeNull();
            lineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineThirdPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineThirdPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            lineFourthPlus.Should().NotBeNull();
            lineFourthPlus!.Attributes.Should().NotBeNull();
            lineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFourthPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFourthPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineFourthPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1471.509,1688.556 1445.46,1733.673 1371.675,1733.673");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1471.009,1689.422 1445.46,1733.673 1372.675,1733.673");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x7);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x10);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y7);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x11);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y8);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x12);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y9);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x7);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия X Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1338.535");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1652.364");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType2Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType2.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "2038.941";
            var x2 = "2059.99";
            var x3 = "2039.441";
            var x4 = "2059.49";
            var x5 = "1990.632";
            var x6 = "2059.99";
            var x7 = "2043.941";
            var x8 = "2107.726";
            var x9 = "2044.941";
            var x10 = "2106.726";
            var x11 = "2028.941";
            var x12 = "1991.132";
            var x13 = "2028.441";

            var y1 = "1959.231";
            var y2 = "1922.774";
            var y3 = "1958.365";
            var y4 = "1923.64";
            var y5 = "2042.906";
            var y6 = "1967.892";
            var y7 = "1976.552";
            var y8 = "2042.04";
            var y9 = "1977.418";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type2");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1990.632,2042.906 2033.941,1967.892 2107.726,1967.892");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1991.132,2042.04 2033.941,1967.892 2106.726,1967.892");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            lineThirdMinus.Should().NotBeNull();
            lineThirdMinus!.Attributes.Should().NotBeNull();
            lineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineThirdMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineThirdMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineThirdMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            lineFourthMinus.Should().NotBeNull();
            lineFourthMinus!.Attributes.Should().NotBeNull();
            lineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x9);
            lineFourthMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineFourthMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x10);
            lineFourthMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x9);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x10);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x11);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y7);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x12);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y8);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x13);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y9);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Второй тип");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2004.794");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1888.805");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType2XTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType2X.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1817.314";
            var x2 = "1838.363";
            var x3 = "1817.814";
            var x4 = "1837.863";
            var x5 = "1769.005";
            var x6 = "1838.363";
            var x7 = "1822.314";
            var x8 = "1886.099";
            var x9 = "1823.314";
            var x10 = "1885.099";
            var x11 = "1807.314";
            var x12 = "1769.505";
            var x13 = "1806.814";

            var y1 = "2032.923";
            var y2 = "2069.38";
            var y3 = "2033.789";
            var y4 = "2068.514";
            var y5 = "1949.248";
            var y6 = "2024.262";
            var y7 = "2015.602";
            var y8 = "1950.115";
            var y9 = "2014.736";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type2");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1769.005,1949.248 1812.314,2024.262 1886.099,2024.262");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1769.505,1950.115 1812.314,2024.262 1885.099,2024.262");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            lineThirdMinus.Should().NotBeNull();
            lineThirdMinus!.Attributes.Should().NotBeNull();
            lineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineThirdMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineThirdMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineThirdMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            lineFourthMinus.Should().NotBeNull();
            lineFourthMinus!.Attributes.Should().NotBeNull();
            lineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x9);
            lineFourthMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineFourthMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x10);
            lineFourthMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x9);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x10);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y5);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x11);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y7);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x12);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y8);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x13);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y9);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия X");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1742.056");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1925.176");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType2YTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType2Y.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1594.531";
            var x2 = "1632.841";
            var x3 = "1595.031";
            var x4 = "1632.341";
            var x5 = "1663.889";
            var x6 = "1627.841";
            var x7 = "1564.056";
            var x8 = "1626.841";
            var x9 = "1565.056";
            var x10 = "1642.841";
            var x11 = "1643.341";
            var x12 = "1663.389";

            var y1 = "1961.887";
            var y2 = "2028.241";
            var y3 = "1962.753";
            var y4 = "2027.375";
            var y5 = "2082.019";
            var y6 = "2036.901";
            var y7 = "2045.562";
            var y8 = "2046.427";
            var y9 = "2081.153";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type2");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1663.889,2082.019 1637.841,2036.901 1564.056,2036.901");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1663.389,2081.153 1637.841,2036.901 1565.056,2036.901");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            lineThirdMinus.Should().NotBeNull();
            lineThirdMinus!.Attributes.Should().NotBeNull();
            lineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x6);
            lineThirdMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineThirdMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x7);
            lineThirdMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            lineFourthMinus.Should().NotBeNull();
            lineFourthMinus!.Attributes.Should().NotBeNull();
            lineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineFourthMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineFourthMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineFourthMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x6);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x7);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x10);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y7);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x11);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y8);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x12);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y9);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1472.82");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1938.926");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType2XYTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType2XY.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1372.675";
            var x2 = "1410.985";
            var x3 = "1373.175";
            var x4 = "1410.485";
            var x5 = "1442.033";
            var x6 = "1405.985";
            var x7 = "1342.2";
            var x8 = "1404.985";
            var x9 = "1343.2";
            var x10 = "1420.985";
            var x11 = "1421.485";
            var x12 = "1441.533";

            var y1 = "2038.106";
            var y2 = "1971.752";
            var y3 = "2037.24";
            var y4 = "1972.618";
            var y5 = "1917.974";
            var y6 = "1963.092";
            var y7 = "1954.431";
            var y8 = "1953.565";
            var y9 = "1918.84";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type2");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1442.033,1917.974 1415.985,1963.092 1342.2,1963.092");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1441.533,1918.84 1415.985,1963.092 1343.2,1963.092");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            lineThirdMinus.Should().NotBeNull();
            lineThirdMinus!.Attributes.Should().NotBeNull();
            lineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineThirdMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x6);
            lineThirdMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineThirdMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x7);
            lineThirdMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            lineFourthMinus.Should().NotBeNull();
            lineFourthMinus!.Attributes.Should().NotBeNull();
            lineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineFourthMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineFourthMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineFourthMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineFourthMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x6);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x7);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x8);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y6);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x9);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y6);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x10);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y7);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x11);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y8);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x12);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y9);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFifth = railJunctionNoControlGroup.ChildNodes[4];
            lineFifth.Should().NotBeNull();
            lineFifth!.Attributes.Should().NotBeNull();
            lineFifth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFifth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFifth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFifth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFifth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y2);
            lineFifth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFifth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSixth = railJunctionNoControlGroup.ChildNodes[5];
            lineSixth.Should().NotBeNull();
            lineSixth!.Attributes.Should().NotBeNull();
            lineSixth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSixth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSixth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y3);
            lineSixth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSixth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y4);
            lineSixth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSixth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия X Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1224.774");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1878.926");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type3Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type3.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "2030.944";
            var x2 = "2084.922";
            var x3 = "2031.944";
            var x4 = "2083.922";
            var x5 = "1992.099";
            var x6 = "2015.944";
            var x7 = "1992.599";
            var x8 = "2015.444";

            var y1 = "2271.136";
            var y2 = "2321.098";
            var y3 = "2279.796";
            var y4 = "2320.232";
            var y5 = "2280.663";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type3");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1992.099,2321.098 2072.169,2182.413 2109.375,2182.413");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1992.599,2320.232 2072.169,2182.413 2110.375,2182.413");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1992.099,2321.098 2020.944,2271.136 2084.922,2271.136");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1992.599,2320.232 2020.944,2271.136 2083.922,2271.136");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            polylineThirdMinus.Should().NotBeNull();
            polylineThirdMinus!.Attributes.Should().NotBeNull();
            polylineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineThirdMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2025.944,2262.476 2072.169,2182.413 2109.375,2182.413");
            polylineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            polylineFourthMinus.Should().NotBeNull();
            polylineFourthMinus!.Attributes.Should().NotBeNull();
            polylineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineFourthMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2026.444,2261.61 2072.169,2182.413 2110.375,2182.413");
            polylineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");


            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[4];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2025.944,2262.476 2072.169,2182.413 2109.375,2182.413");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[5];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2026.444,2261.61 2072.169,2182.413 2110.375,2182.413");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Третий тип");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2041.12");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2154.479");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type3XTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type3X.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1846.288";
            var x2 = "1900.265";
            var x3 = "1847.288";
            var x4 = "1899.265";
            var x5 = "1807.442";
            var x6 = "1831.288";
            var x7 = "1807.942";
            var x8 = "1830.788";

            var y1 = "2226.067";
            var y2 = "2176.105";
            var y3 = "2217.407";
            var y4 = "2176.971";
            var y5 = "2216.541";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type3");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1807.442,2176.105 1887.512,2314.79 1924.719,2314.79");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1807.942,2176.971 1887.512,2314.79 1925.719,2314.79");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1807.442,2176.105 1836.288,2226.067 1900.265,2226.067");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1807.942,2176.971 1836.288,2226.067 1899.265,2226.067");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            polylineThirdMinus.Should().NotBeNull();
            polylineThirdMinus!.Attributes.Should().NotBeNull();
            polylineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineThirdMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1841.288,2234.727 1887.512,2314.79 1924.719,2314.79");
            polylineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            polylineFourthMinus.Should().NotBeNull();
            polylineFourthMinus!.Attributes.Should().NotBeNull();
            polylineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineFourthMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1841.788,2235.593 1887.512,2314.79 1925.719,2314.79");
            polylineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");


            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[4];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1841.288,2234.727 1887.512,2314.79 1924.719,2314.79");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[5];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1841.788,2235.593 1887.512,2314.79 1925.719,2314.79");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия X");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1836.463");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2159.409");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type3YTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type3Y.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1701.534";
            var x2 = "1647.557";
            var x3 = "1700.534";
            var x4 = "1648.557";
            var x5 = "1716.534";
            var x6 = "1740.38";
            var x7 = "1717.034";
            var x8 = "1740.88";

            var y1 = "2267.053";
            var y2 = "2275.713";
            var y3 = "2317.015";
            var y4 = "2276.579";
            var y5 = "2317.881";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type3");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1740.38,2317.015 1660.31,2178.33 1623.103,2178.33");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1740.88,2317.881 1660.31,2178.33 1622.103,2178.33");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1740.38,2317.015 1711.534,2267.053 1647.557,2267.053");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1740.88,2317.881 1711.534,2267.053 1648.557,2267.053");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            polylineThirdMinus.Should().NotBeNull();
            polylineThirdMinus!.Attributes.Should().NotBeNull();
            polylineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineThirdMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1706.534,2258.393 1660.31,2178.33 1623.103,2178.33");
            polylineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            polylineFourthMinus.Should().NotBeNull();
            polylineFourthMinus!.Attributes.Should().NotBeNull();
            polylineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineFourthMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1706.034,2257.527 1660.31,2178.33 1622.103,2178.33");
            polylineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");


            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[4];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1706.534,2258.393 1660.31,2178.33 1623.103,2178.33");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[5];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1706.034,2257.527 1660.31,2178.33 1622.103,2178.33");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1628.853");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2141.824");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type3XYTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type3XY.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "1496.1";
            var x2 = "1442.123";
            var x3 = "1495.1";
            var x4 = "1443.123";
            var x5 = "1511.1";
            var x6 = "1534.946";
            var x7 = "1511.6";
            var x8 = "1535.446";

            var y1 = "2227.053";
            var y2 = "2218.393";
            var y3 = "2177.091";
            var y4 = "2217.527";
            var y5 = "2176.225";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type3");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            // Проверка содержимого дочерних элементов
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1534.946,2177.091 1454.876,2315.776 1417.669,2315.776");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1535.446,2176.225 1454.876,2315.776 1416.669,2315.776");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1534.946,2177.091 1506.1,2227.053 1442.123,2227.053");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1535.446,2176.225 1506.1,2227.053 1443.123,2227.053");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineThirdMinus = railJunctionMinusGroup.ChildNodes[2];
            polylineThirdMinus.Should().NotBeNull();
            polylineThirdMinus!.Attributes.Should().NotBeNull();
            polylineThirdMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineThirdMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1501.1,2235.713 1454.876,2315.776 1417.669,2315.776");
            polylineThirdMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineThirdMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineFourthMinus = railJunctionMinusGroup.ChildNodes[3];
            polylineFourthMinus.Should().NotBeNull();
            polylineFourthMinus!.Attributes.Should().NotBeNull();
            polylineFourthMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineFourthMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1500.6,2236.579 1454.876,2315.776 1416.669,2315.776");
            polylineFourthMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFourthMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");
            
            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[4];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1501.1,2235.713 1454.876,2315.776 1417.669,2315.776");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[5];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1500.6,2236.579 1454.876,2315.776 1416.669,2315.776");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия X Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1369.133");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2147.538");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void InverseType3Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType3.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "2043.263";
            var x2 = "2097.241";
            var x3 = "2044.263";
            var x4 = "2096.241";
            var x5 = "2004.418";
            var x6 = "2028.263";
            var x7 = "2004.918";
            var x8 = "2027.763";

            var y1 = "2550.85";
            var y2 = "2600.812";
            var y3 = "2559.51";
            var y4 = "2599.946";
            var y5 = "2560.376";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type3");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);
            
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2004.418,2600.812 2033.263,2550.85 2097.241,2550.85");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2004.918,2599.946 2033.263,2550.85 2096.241,2550.85");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            polylineThirdPlus.Should().NotBeNull();
            polylineThirdPlus!.Attributes.Should().NotBeNull();
            polylineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineThirdPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2038.263,2542.19 2084.488,2462.127 2121.695,2462.127");
            polylineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            polylineFourthPlus.Should().NotBeNull();
            polylineFourthPlus!.Attributes.Should().NotBeNull();
            polylineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineFourthPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2038.763,2541.323 2084.488,2462.127 2122.695,2462.127");
            polylineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2004.418,2600.812 2084.488,2462.127 2121.695,2462.127");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2004.918,2599.946 2084.488,2462.127 2122.695,2462.127");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[4];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2038.263,2542.19 2084.488,2462.127 2121.695,2462.127");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[5];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("2038.763,2541.323 2084.488,2462.127 2122.695,2462.127");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Третий тип");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("2053.439");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2434.192");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void InverseType3XTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType3X.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();
            
            var x1 = "1821.464";
            var x2 = "1875.442";
            var x3 = "1822.464";
            var x4 = "1874.442";
            var x5 = "1782.619";
            var x6 = "1806.464";
            var x7 = "1783.119";
            var x8 = "1805.964";

            var y1 = "2451.495";
            var y2 = "2401.533";
            var y3 = "2442.835";
            var y4 = "2402.399";
            var y5 = "2441.969";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type3");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);
            
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1782.619,2401.533 1811.464,2451.495 1875.442,2451.495");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1783.119,2402.399 1811.464,2451.495 1874.442,2451.495");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            polylineThirdPlus.Should().NotBeNull();
            polylineThirdPlus!.Attributes.Should().NotBeNull();
            polylineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineThirdPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1816.464,2460.155 1862.688,2540.218 1899.895,2540.218");
            polylineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            polylineFourthPlus.Should().NotBeNull();
            polylineFourthPlus!.Attributes.Should().NotBeNull();
            polylineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineFourthPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1816.964,2461.021 1862.688,2540.218 1900.895,2540.218");
            polylineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1782.619,2401.533 1862.688,2540.218 1899.895,2540.218");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1783.119,2402.399 1862.688,2540.218 1900.895,2540.218");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[4];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1816.464,2460.155 1862.688,2540.218 1899.895,2540.218");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[5];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1816.964,2461.021 1862.688,2540.218 1900.895,2540.218");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия X");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1811.639");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2384.837");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void InverseType3YTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType3Y.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();
            
            var x1 = "1623.854";
            var x2 = "1569.876";
            var x3 = "1622.854";
            var x4 = "1570.876";
            var x5 = "1638.854";
            var x6 = "1662.699";
            var x7 = "1639.354";
            var x8 = "1663.199";

            var y1 = "2596.767";
            var y2 = "2605.427";
            var y3 = "2646.729";
            var y4 = "2606.293";
            var y5 = "2647.595";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type3");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);
            
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1662.699,2646.729 1633.854,2596.767 1569.876,2596.767");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1663.199,2647.595 1633.854,2596.767 1570.876,2596.767");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            polylineThirdPlus.Should().NotBeNull();
            polylineThirdPlus!.Attributes.Should().NotBeNull();
            polylineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineThirdPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1628.854,2588.106 1582.629,2508.043 1545.422,2508.043");
            polylineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            polylineFourthPlus.Should().NotBeNull();
            polylineFourthPlus!.Attributes.Should().NotBeNull();
            polylineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineFourthPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1628.354,2587.24 1582.629,2508.043 1544.422,2508.043");
            polylineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1662.699,2646.729 1582.629,2508.043 1545.422,2508.043");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1663.199,2647.595 1582.629,2508.043 1544.422,2508.043");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[4];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1628.854,2588.106 1582.629,2508.043 1545.422,2508.043");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[5];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1628.354,2587.24 1582.629,2508.043 1544.422,2508.043");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1551.172");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2471.538");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void InverseType3XYTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType3XY.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();
            
             var x1 = "1431.277";
            var x2 = "1377.299";
            var x3 = "1430.277";
            var x4 = "1378.299";
            var x5 = "1446.277";
            var x6 = "1470.122";
            var x7 = "1446.777";
            var x8 = "1470.622";

            var y1 = "2492.481";
            var y2 = "2483.821";
            var y3 = "2442.519";
            var y4 = "2482.955";
            var y5 = "2441.653";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type3");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);
            
            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1470.122,2442.519 1441.277,2492.481 1377.299,2492.481");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1470.622,2441.653 1441.277,2492.481 1378.299,2492.481");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineThirdPlus = railJunctionPlusGroup.ChildNodes[2];
            polylineThirdPlus.Should().NotBeNull();
            polylineThirdPlus!.Attributes.Should().NotBeNull();
            polylineThirdPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineThirdPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1436.277,2501.141 1390.052,2581.204 1352.845,2581.204");
            polylineThirdPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineThirdPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineFourthPlus = railJunctionPlusGroup.ChildNodes[3];
            polylineFourthPlus.Should().NotBeNull();
            polylineFourthPlus!.Attributes.Should().NotBeNull();
            polylineFourthPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineFourthPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1435.777,2502.007 1390.052,2581.204 1351.845,2581.204");
            polylineFourthPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFourthPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1470.122,2442.519 1390.052,2581.204 1352.845,2581.204");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1470.622,2441.653 1390.052,2581.204 1351.845,2581.204");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[0];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[1];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[2];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y2);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y3);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[3];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y4);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y5);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[4];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1436.277,2501.141 1390.052,2581.204 1352.845,2581.204");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[5];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("1435.777,2502.007 1390.052,2581.204 1351.845,2581.204");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия X Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("1304.309");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2412.966");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type4Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type4.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "906.667";
            var x2 = "1060";
            var x3 = "966.667";
            var x4 = "967.667";
            var x5 = "1059";
            var x6 = "946.667";
            var x7 = "907.667";
            var x8 = "945.667";

            var y1 = "2057.906";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type4");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("961.667,2049.246 988.655,2002.5 1018.655,2002.5");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("962.167,2048.38 988.655,2002.5 1017.655,2002.5");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("906.667,2057.906 956.667,2057.906 988.655,2002.5 1018.655,2002.5");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("907.667,2057.906 956.667,2057.906 988.655,2002.5 1017.655,2002.5");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x4);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("961.667,2049.246 988.655,2002.5 1018.655,2002.5");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("962.167,2048.38 988.655,2002.5 1017.655,2002.5");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[2];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[3];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[4];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[5];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Четвертый тип");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("914.237");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1969.768");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type4XTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type4X.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "712.083";
            var x2 = "865.417";
            var x3 = "772.083";
            var x4 = "773.083";
            var x5 = "864.417";
            var x6 = "752.083";
            var x7 = "713.083";
            var x8 = "751.083";

            var y1 = "1994.989";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type4");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("767.083,2003.65 794.072,2050.396 824.072,2050.396");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("767.583,2004.516 794.072,2050.396 823.072,2050.396");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("712.083,1994.989 762.083,1994.989 794.072,2050.396 824.072,2050.396");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("713.083,1994.989 762.083,1994.989 794.072,2050.396 823.072,2050.396");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x4);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("767.083,2003.65 794.072,2050.396 824.072,2050.396");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("767.583,2004.516 794.072,2050.396 823.072,2050.396");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[2];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[3];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[4];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[5];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия Х");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("720.903");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1958.102");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type4YTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type4Y.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "550.739";
            var x2 = "704.072";
            var x3 = "590.739";
            var x4 = "551.739";
            var x5 = "589.739";
            var x6 = "610.739";
            var x7 = "611.739";
            var x8 = "703.072";

            var y1 = "2045.396";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type4");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("595.739,2036.735 568.75,1989.989 538.75,1989.989");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("595.239,2035.869 568.75,1989.989 539.75,1989.989");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("704.072,2045.396 600.739,2045.396 568.75,1989.989 538.75,1989.989");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("703.072,2045.396 600.739,2045.396 568.75,1989.989 539.75,1989.989");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x3);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x4);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("595.739,2036.735 568.75,1989.989 538.75,1989.989");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("595.239,2035.869 568.75,1989.989 539.75,1989.989");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[2];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x6);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[3];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[4];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x3);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[5];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x4);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("517.059");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1962.258");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void Type4XYTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.type4XY.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "336.155";
            var x2 = "489.489";
            var x3 = "376.155";
            var x4 = "337.155";
            var x5 = "375.155";
            var x6 = "396.155";
            var x7 = "397.155";
            var x8 = "488.489";

            var y1 = "1992.896";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type4");
            objectHint!.Split(",")[1].Should().Be("IsInverse=False");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("false");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("381.155,2001.556 354.167,2048.302 324.167,2048.302");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("380.655,2002.422 354.167,2048.302 325.167,2048.302");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("489.489,1992.896 386.155,1992.896 354.167,2048.302 324.167,2048.302");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("488.489,1992.896 386.155,1992.896 354.167,2048.302 325.167,2048.302");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x3);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x4);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("381.155,2001.556 354.167,2048.302 324.167,2048.302");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("380.655,2002.422 354.167,2048.302 325.167,2048.302");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[2];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x6);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[3];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[4];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x3);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[5];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x4);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Симметрия X Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("321.225");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1956.008");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType4Test()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType4.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "991.989";
            var x2 = "1085.322";
            var x3 = "992.989";
            var x4 = "1084.322";
            var x5 = "931.989";
            var x6 = "971.989";
            var x7 = "932.989";
            var x8 = "970.989";

            var y1 = "2304.979";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type4");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("931.989,2304.979 981.989,2304.979 1013.977,2249.573 1043.977,2249.573");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("932.989,2304.979 981.989,2304.979 1013.977,2249.573 1042.977,2249.573");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("986.989,2296.319 1013.977,2249.573 1043.977,2249.573");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("987.489,2295.452 1013.977,2249.573 1042.977,2249.573");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("986.989,2296.319 1013.977,2249.573 1043.977,2249.573");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("987.489,2295.452 1013.977,2249.573 1042.977,2249.573");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[2];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[3];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[4];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[5];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Четвертый тип");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("975.809");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2225.591");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType4XTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType4X.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "797.405";
            var x2 = "890.739";
            var x3 = "798.405";
            var x4 = "889.739";
            var x5 = "737.405";
            var x6 = "777.405";
            var x7 = "738.405";
            var x8 = "776.405";

            var y1 = "2242.062";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type4");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("737.405,2242.062 787.405,2242.062 819.394,2297.468 849.394,2297.468");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("738.405,2242.062 787.405,2242.062 819.394,2297.468 848.394,2297.468");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("792.405,2250.722 819.394,2297.468 849.394,2297.468");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("792.905,2251.589 819.394,2297.468 848.394,2297.468");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("792.405,2250.722 819.394,2297.468 849.394,2297.468");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("792.905,2251.589 819.394,2297.468 848.394,2297.468");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[2];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[3];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[4];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x5);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x6);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[5];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия Х");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("708.725");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2205.174");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType4YTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType4Y.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "521.061";
            var x2 = "561.061";
            var x3 = "522.061";
            var x4 = "560.061";
            var x5 = "674.394";
            var x6 = "581.061";
            var x7 = "582.061";
            var x8 = "673.394";

            var y1 = "2328.718";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type4");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("674.394,2328.718 571.061,2328.718 539.072,2273.312 509.072,2273.312");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("673.394,2328.718 571.061,2328.718 539.072,2273.312 510.072,2273.312");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("566.061,2320.058 539.072,2273.312 509.072,2273.312");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("565.561,2319.192 539.072,2273.312 510.072,2273.312");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("566.061,2320.058 539.072,2273.312 509.072,2273.312");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("565.561,2319.192 539.072,2273.312 510.072,2273.312");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[2];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x6);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[3];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[4];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[5];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("487.381");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2245.58");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }

        [Test]
        public void InverseType4XYTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("RailJunctionEx.inverseType4XY.chr", RailJunctionExName);
            currentGroup.Should().NotBeNull();

            var x1 = "270.2274";
            var x2 = "310.2274";
            var x3 = "271.2274";
            var x4 = "309.2274";
            var x5 = "423.561";
            var x6 = "330.227";
            var x7 = "331.227";
            var x8 = "422.561";

            var y1 = "2247.468";

            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(6);

            var objectHint = attributes!.GetNamedItem("data-object-hint")!.Value;
            objectHint.Should().NotBeNull();
            objectHint!.Split(",")[0].Should().Be("Type=Type4");
            objectHint!.Split(",")[1].Should().Be("IsInverse=True");

            var isInverse = attributes!.GetNamedItem("data-isInverse")!.Value;
            isInverse.Should().NotBeNull();
            isInverse.Should().Be("true");

            var strokeWidth = attributes!.GetNamedItem("stroke-width")!.Value;
            strokeWidth.Should().NotBeNull();
            strokeWidth.Should().Be("4");

            var fillOpacity = attributes!.GetNamedItem("fill-opacity")!.Value;
            fillOpacity.Should().NotBeNull();
            fillOpacity.Should().Be("0");

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");

            currentGroup.ChildNodes.Count.Should().Be(4);

            var railJunctionPlusGroup = currentGroup.ChildNodes[0];
            railJunctionPlusGroup.Should().NotBeNull();
            railJunctionPlusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionPlusGroup!.Attributes.Should().NotBeNull();
            railJunctionPlusGroup !.Attributes!.Count.Should().Be(1);

            var railJunctionPlusClass = railJunctionPlusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionPlusClass.Should().NotBeNull();
            railJunctionPlusClass.Should().Be("rail-junction-plus");

            var polylineFirstPlus = railJunctionPlusGroup.ChildNodes[0];
            polylineFirstPlus.Should().NotBeNull();
            polylineFirstPlus!.Attributes.Should().NotBeNull();
            polylineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            polylineFirstPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("423.561,2247.468 320.227,2247.468 288.2387,2302.874 258.2387,2302.874");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondPlus = railJunctionPlusGroup.ChildNodes[1];
            polylineSecondPlus.Should().NotBeNull();
            polylineSecondPlus!.Attributes.Should().NotBeNull();
            polylineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            polylineSecondPlus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("422.561,2247.468 320.227,2247.468 288.2387,2302.874 259.2387,2302.874");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirstPlus = railJunctionPlusGroup.ChildNodes[2];
            lineFirstPlus.Should().NotBeNull();
            lineFirstPlus!.Attributes.Should().NotBeNull();
            lineFirstPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            lineFirstPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineFirstPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondPlus = railJunctionPlusGroup.ChildNodes[3];
            lineSecondPlus.Should().NotBeNull();
            lineSecondPlus!.Attributes.Should().NotBeNull();
            lineSecondPlus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            lineSecondPlus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineSecondPlus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineSecondPlus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondPlus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondPlus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionMinusGroup = currentGroup.ChildNodes[1];
            railJunctionMinusGroup.Should().NotBeNull();
            railJunctionMinusGroup!.ChildNodes.Count.Should().Be(4);
            railJunctionMinusGroup!.Attributes.Should().NotBeNull();
            railJunctionMinusGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionMinusClass = railJunctionMinusGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionMinusClass.Should().NotBeNull();
            railJunctionMinusClass.Should().Be("rail-junction-minus");

            var railJunctionMinusVisibility = railJunctionMinusGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionMinusVisibility.Should().NotBeNull();
            railJunctionMinusVisibility.Should().Be("hidden");

            var lineFirstMinus = railJunctionMinusGroup.ChildNodes[0];
            lineFirstMinus.Should().NotBeNull();
            lineFirstMinus!.Attributes.Should().NotBeNull();
            lineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-outer");
            lineFirstMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineFirstMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineFirstMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecondMinus = railJunctionMinusGroup.ChildNodes[1];
            lineSecondMinus.Should().NotBeNull();
            lineSecondMinus!.Attributes.Should().NotBeNull();
            lineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-main-inner");
            lineSecondMinus!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineSecondMinus!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineSecondMinus!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var polylineFirstMinus = railJunctionMinusGroup.ChildNodes[2];
            polylineFirstMinus.Should().NotBeNull();
            polylineFirstMinus!.Attributes.Should().NotBeNull();
            polylineFirstMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-outer");
            polylineFirstMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("315.2274,2256.128 288.2387,2302.874 258.2387,2302.874");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirstMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecondMinus = railJunctionMinusGroup.ChildNodes[3];
            polylineSecondMinus.Should().NotBeNull();
            polylineSecondMinus!.Attributes.Should().NotBeNull();
            polylineSecondMinus!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-other-inner");
            polylineSecondMinus!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("314.7274,2256.995 288.2387,2302.874 259.2387,2302.874");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecondMinus!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var railJunctionNoControlGroup = currentGroup.ChildNodes[2];
            railJunctionNoControlGroup.Should().NotBeNull();
            railJunctionNoControlGroup!.ChildNodes.Count.Should().Be(6);
            railJunctionNoControlGroup!.Attributes.Should().NotBeNull();
            railJunctionNoControlGroup !.Attributes!.Count.Should().Be(2);

            var railJunctionNoControlClass = railJunctionNoControlGroup!.Attributes!.GetNamedItem("class")!.Value;
            railJunctionNoControlClass.Should().NotBeNull();
            railJunctionNoControlClass.Should().Be("rail-junction-no-control");

            var railJunctionNoControlVisibility =
                railJunctionNoControlGroup!.Attributes!.GetNamedItem("visibility")!.Value;
            railJunctionNoControlVisibility.Should().NotBeNull();
            railJunctionNoControlVisibility.Should().Be("hidden");

            var polylineFirst = railJunctionNoControlGroup.ChildNodes[0];
            polylineFirst.Should().NotBeNull();
            polylineFirst!.Attributes.Should().NotBeNull();
            polylineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            polylineFirst!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("315.2274,2256.128 288.2387,2302.874 258.2387,2302.874");
            polylineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var polylineSecond = railJunctionNoControlGroup.ChildNodes[1];
            polylineSecond.Should().NotBeNull();
            polylineSecond!.Attributes.Should().NotBeNull();
            polylineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            polylineSecond!.Attributes!.GetNamedItem("points")!.Value.Should()
                .Be("314.7274,2256.995 288.2387,2302.874 259.2387,2302.874");
            polylineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            polylineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineFirst = railJunctionNoControlGroup.ChildNodes[2];
            lineFirst.Should().NotBeNull();
            lineFirst!.Attributes.Should().NotBeNull();
            lineFirst!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineFirst!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x6);
            lineFirst!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x5);
            lineFirst!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFirst!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFirst!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineSecond = railJunctionNoControlGroup.ChildNodes[3];
            lineSecond.Should().NotBeNull();
            lineSecond!.Attributes.Should().NotBeNull();
            lineSecond!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineSecond!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x7);
            lineSecond!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x8);
            lineSecond!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineSecond!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineSecond!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var lineThird = railJunctionNoControlGroup.ChildNodes[4];
            lineThird.Should().NotBeNull();
            lineThird!.Attributes.Should().NotBeNull();
            lineThird!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-outer");
            lineThird!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x1);
            lineThird!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x2);
            lineThird!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineThird!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineThird!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("4");

            var lineFourth = railJunctionNoControlGroup.ChildNodes[5];
            lineFourth.Should().NotBeNull();
            lineFourth!.Attributes.Should().NotBeNull();
            lineFourth!.Attributes!.GetNamedItem("class")!.Value.Should().Be("rail-junction-no-control-inner");
            lineFourth!.Attributes!.GetNamedItem("x1")!.Value.Should().Be(x3);
            lineFourth!.Attributes!.GetNamedItem("y1")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("x2")!.Value.Should().Be(x4);
            lineFourth!.Attributes!.GetNamedItem("y2")!.Value.Should().Be(y1);
            lineFourth!.Attributes!.GetNamedItem("stroke")!.Value.Should().Be("#000");
            lineFourth!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("2");

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Инверсия Симметрия X Y");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("221.5475");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("2211.83");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}