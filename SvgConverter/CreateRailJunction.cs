using System;
using System.Collections.Generic;
using System.Drawing;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class CreateRailJunction
    {
        // Функция для формирования SVG картинки для "StandardLibrary.RailJunction"
        public static SvgGroupElement CreateSvgImageRailJunction(IReadOnlyDictionary<string, string> xmlNode,
            ISvgConvertOptions options)
        {
            // Проверка координат 
            if (!xmlNode.TryGetRailJunctionBounds(out var bounds))
            {
                return null;
            }

            // Вычислим все координаты
            var curCenterX = bounds["curCenterX"];
            var curCenterY = bounds["curCenterY"];
            var curOffsetA2 = bounds["curOffsetA2"];
            var curOffsetC2 = bounds["curOffsetC2"];
            var curOffsetB2 = bounds["curOffsetB2"];
            var curOffsetD2B = bounds["curOffsetD2B"];
            var curAngle = bounds["curAngle"];
            
            // Получим тип стрелочной секции
            if (!xmlNode.TryGetValue("Type", out var railJunctionType)) return null;

            // Если указан несуществующий тип
            if (!railJunctionType.Equals("Type1") && !railJunctionType.Equals("Type2") &&
                !railJunctionType.Equals("Type3") && !railJunctionType.Equals("Type4")) return null;
            
            // Не указано значение IsInverse
            if (!xmlNode.TryGetValue("IsInverse", out var railJunctionIsInverse)) return null;

            // Указан несуществующий тип IsInverse
            if (!railJunctionIsInverse.Equals("False") && !railJunctionIsInverse.Equals("True")) return null;

            // Создадим группу для отрисовки текущей "StandardLibrary.RailJunction" со стандартными атрибутами
            var result = xmlNode.AddStandardStartResultAttributes(null, null, null, null, options);

            // Вычислим цвет обводки
            var objColor = xmlNode.GetObjectColor();

            // Получим значение ширины внешней линии
            var externalStrokeWidth = xmlNode.GetLineWidth();

            // Вычислим значение ширины внутренней линии
            var internalWidth = (int)(externalStrokeWidth - 2 * (int)(externalStrokeWidth / 3));

            // Вычислим значение отступа внутренней линии от края внешней
            var innerLineOffset = (float)internalWidth / 2;

            // Вычислим координаты точек для Type1
            var allPointsType1Dictionary = GetAllPointsType1(curCenterX, curCenterY, curOffsetA2,
                curOffsetC2, curOffsetB2, curOffsetD2B, curAngle, innerLineOffset);

            // Вычислим координаты точек для Type2
            var allPointsType2Dictionary = GetAllPointsType2(curCenterX, curCenterY, curOffsetA2,
                curOffsetC2, curOffsetB2, curOffsetD2B, curAngle, innerLineOffset, railJunctionType);

            // Выберем один из двух наборов точек в зависимости от типа стрелочной секции 
            var allPointsDictionary =
                railJunctionType == "Type1" || railJunctionType == "Type4"
                    ? allPointsType1Dictionary
                    : allPointsType2Dictionary;

            // Добавим элемент class="rail-junction-plus"
            result.Children.Add(CreateRailJunctionSvg(xmlNode, curOffsetB2, objColor,
                "rail-junction-plus", allPointsDictionary, externalStrokeWidth, internalWidth, railJunctionType));

            // Добавим элемент class="rail-junction-minus"
            result.Children.Add(CreateRailJunctionSvg(xmlNode, curOffsetB2, objColor,
                "rail-junction-minus", allPointsDictionary, externalStrokeWidth, internalWidth, railJunctionType));

            // Добавим элемент class="rail-junction-no-control"
            result.Children.Add(CreateRailJunctionSvg(xmlNode, curOffsetB2, objColor,
                "rail-junction-no-control", allPointsDictionary, externalStrokeWidth, internalWidth, railJunctionType));

            // Если надо отображать текст, то добавим его в result
            if (CreateText.IsShouldDrawLabel(xmlNode["ShouldDrawLabel"]))
            {
                // Добавляем созданный текст
                result.Children.Add(CreateText.AddSvgTextElement(xmlNode, xmlNode["Label"]));
            }

            return result;
        }

        // Функция для получения элемента "Стрелочная секция" в формате Svg
        private static SvgGroupElement CreateRailJunctionSvg(IReadOnlyDictionary<string, string> xmlNode,
                float curOffsetB2, Color objColor, string className,
                IReadOnlyDictionary<string, SvgPoint> allPointsDictionary,
                float externalStrokeWidth, float internalWidth, string railJunctionType)

            // IReadOnlyDictionary<string, SvgGeometryElement> allLinesDictionary
        {
            /*      Type1 && Type4                        Type2 && Type 3
             * 
             * D-----B         B-----D               D-----A         C-----D
             *        \       /                             \       /
             *         \     /                               \     /
             *          N   N                                 M   K
             *           \ /                                   \ /
             * A----M--Center--K--------C            B----N--Center--N--------B
             *           / \                                   / \
             *          N   N                                 M   K
             *         /     \                               /     \
             *        /       \                             /       \
             * D-----B         B-----D               D-----A         C-----D
            */

            var allLinesDictionary = GetAllLines(allPointsDictionary, externalStrokeWidth, internalWidth, objColor);

            var lineACOuter = allLinesDictionary["lineACOuter"];
            var lineNBOuter = allLinesDictionary["lineNBOuter"];
            var lineKCOuter = allLinesDictionary["lineKCOuter"];
            var lineAMOuter = allLinesDictionary["lineAMOuter"];

            var lineACInner = allLinesDictionary["lineACInner"];
            var lineNBInner = allLinesDictionary["lineNBInner"];
            var lineKCInner = allLinesDictionary["lineKCInner"];
            var lineAMInner = allLinesDictionary["lineAMInner"];

            var polylineOuterACenterB = allLinesDictionary["polylineOuterACenterB"];
            var polylineInnerACenterB = allLinesDictionary["polylineInnerACenterB"];
            var polylineOuterCCenterB = allLinesDictionary["polylineOuterCCenterB"];
            var polylineInnerCCenterB = allLinesDictionary["polylineInnerCCenterB"];

            var polylineOuterNBD = allLinesDictionary["polylineOuterNBD"];
            var polylineInnerNBD = allLinesDictionary["polylineInnerNBD"];
            var polylineOuterACenterBD = allLinesDictionary["polylineOuterACenterBD"];
            var polylineInnerACenterBD = allLinesDictionary["polylineInnerACenterBD"];
            var polylineOuterCCenterBD = allLinesDictionary["polylineOuterCCenterBD"];
            var polylineInnerCCenterBD = allLinesDictionary["polylineInnerCCenterBD"];
            var polylineOuterKCD = allLinesDictionary["polylineOuterKCD"];
            var polylineInnerKCD = allLinesDictionary["polylineInnerKCD"];
            var polylineOuterACD = allLinesDictionary["polylineOuterACD"];
            var polylineInnerACD = allLinesDictionary["polylineInnerACD"];
            var polylineOuterCAD = allLinesDictionary["polylineOuterCAD"];
            var polylineInnerCAD = allLinesDictionary["polylineInnerCAD"];
            var polylineOuterMAD = allLinesDictionary["polylineOuterMAD"];
            var polylineInnerMAD = allLinesDictionary["polylineInnerMAD"];

            // Добавим атрибуты создаваемой группе линий
            var resultElement = new SvgGroupElement
            {
                Visibility = className == "rail-junction-plus" ? null : (SvgVisibility?)1,
                Class = className,
            };

            // Выберем нужные линии и polyline в зависимости от className, знака curOffsetB2 и Инверсии
            switch (className)
            {
                case ("rail-junction-plus"):
                    // AC + NB or AC + NBD or ACD + NB or CAD + NB
                    if (xmlNode["IsInverse"].Equals("False"))
                    {
                        // ACD or CAD
                        if (railJunctionType.Equals("Type3"))
                        {
                            // ACD
                            if (curOffsetB2 > 0)
                            {
                                resultElement.Children.Add(polylineOuterACD);
                                resultElement.Children.Add(polylineInnerACD);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // CAD
                            else
                            {
                                resultElement.Children.Add(polylineOuterCAD);
                                resultElement.Children.Add(polylineInnerCAD);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }
                        }

                        // AC
                        else
                        {
                            resultElement.Children.Add(lineACOuter);
                            resultElement.Children.Add(lineACInner);
                            resultElement.Children[0].Class = "rail-junction-main-outer";
                            resultElement.Children[1].Class = "rail-junction-main-inner";
                        }

                        // NBD
                        if (railJunctionType.Equals("Type4"))
                        {
                            resultElement.Children.Add(polylineOuterNBD);
                            resultElement.Children.Add(polylineInnerNBD);
                            resultElement.Children[2].Class = "rail-junction-other-outer";
                            resultElement.Children[3].Class = "rail-junction-other-inner";
                        }

                        // NB
                        else
                        {
                            resultElement.Children.Add(lineNBOuter);
                            resultElement.Children.Add(lineNBInner);
                            resultElement.Children[2].Class = "rail-junction-other-outer";
                            resultElement.Children[3].Class = "rail-junction-other-inner";
                        }
                    }
                    else
                    {
                        // A_center_B + KC or A_center_B_D + KC or A_center_B + KCD
                        if (curOffsetB2 > 0)
                        {
                            // A_center_B_D
                            if (railJunctionType.Equals("Type4"))
                            {
                                resultElement.Children.Add(polylineOuterACenterBD);
                                resultElement.Children.Add(polylineInnerACenterBD);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // A_center_B
                            else
                            {
                                resultElement.Children.Add(polylineOuterACenterB);
                                resultElement.Children.Add(polylineInnerACenterB);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // KCD
                            if (railJunctionType.Equals("Type3"))
                            {
                                resultElement.Children.Add(polylineOuterKCD);
                                resultElement.Children.Add(polylineInnerKCD);
                                resultElement.Children[2].Class = "rail-junction-other-outer";
                                resultElement.Children[3].Class = "rail-junction-other-inner";
                            }

                            // KC
                            else
                            {
                                resultElement.Children.Add(lineKCOuter);
                                resultElement.Children.Add(lineKCInner);
                                resultElement.Children[2].Class = "rail-junction-other-outer";
                                resultElement.Children[3].Class = "rail-junction-other-inner";
                            }
                        }

                        // C_center_B + AM or C_center_B_D + AM or C_center_B + MAD
                        else
                        {
                            // C_center_B_D
                            if (railJunctionType.Equals("Type4"))
                            {
                                resultElement.Children.Add(polylineOuterCCenterBD);
                                resultElement.Children.Add(polylineInnerCCenterBD);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // C_center_B
                            else
                            {
                                resultElement.Children.Add(polylineOuterCCenterB);
                                resultElement.Children.Add(polylineInnerCCenterB);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // MAD
                            if (railJunctionType.Equals("Type3"))
                            {
                                resultElement.Children.Add(polylineOuterMAD);
                                resultElement.Children.Add(polylineInnerMAD);
                                resultElement.Children[2].Class = "rail-junction-other-outer";
                                resultElement.Children[3].Class = "rail-junction-other-inner";
                            }

                            // AM
                            else
                            {
                                resultElement.Children.Add(lineAMOuter);
                                resultElement.Children.Add(lineAMInner);
                                resultElement.Children[2].Class = "rail-junction-other-outer";
                                resultElement.Children[3].Class = "rail-junction-other-inner";
                            }
                        }
                    }

                    break;

                case ("rail-junction-minus"):
                    // AC + NB or AC + NBD or ACD + NB or CAD + NB
                    if (xmlNode["IsInverse"].Equals("True"))
                    {
                        // ACD or CAD
                        if (railJunctionType.Equals("Type3"))
                        {
                            // ACD
                            if (curOffsetB2 > 0)
                            {
                                resultElement.Children.Add(polylineOuterACD);
                                resultElement.Children.Add(polylineInnerACD);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // CAD
                            else
                            {
                                resultElement.Children.Add(polylineOuterCAD);
                                resultElement.Children.Add(polylineInnerCAD);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }
                        }

                        // AC
                        else
                        {
                            resultElement.Children.Add(lineACOuter);
                            resultElement.Children.Add(lineACInner);
                            resultElement.Children[0].Class = "rail-junction-main-outer";
                            resultElement.Children[1].Class = "rail-junction-main-inner";
                        }

                        // NBD
                        if (railJunctionType.Equals("Type4"))
                        {
                            resultElement.Children.Add(polylineOuterNBD);
                            resultElement.Children.Add(polylineInnerNBD);
                            resultElement.Children[2].Class = "rail-junction-other-outer";
                            resultElement.Children[3].Class = "rail-junction-other-inner";
                        }

                        // NB
                        else
                        {
                            resultElement.Children.Add(lineNBOuter);
                            resultElement.Children.Add(lineNBInner);
                            resultElement.Children[2].Class = "rail-junction-other-outer";
                            resultElement.Children[3].Class = "rail-junction-other-inner";
                        }
                    }
                    else
                    {
                        // A_center_B + KC or A_center_B_D + KC or A_center_B + KCD
                        if (curOffsetB2 > 0)
                        {
                            // A_center_B_D
                            if (railJunctionType.Equals("Type4"))
                            {
                                resultElement.Children.Add(polylineOuterACenterBD);
                                resultElement.Children.Add(polylineInnerACenterBD);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // A_center_B
                            else
                            {
                                resultElement.Children.Add(polylineOuterACenterB);
                                resultElement.Children.Add(polylineInnerACenterB);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // KCD
                            if (railJunctionType.Equals("Type3"))
                            {
                                resultElement.Children.Add(polylineOuterKCD);
                                resultElement.Children.Add(polylineInnerKCD);
                                resultElement.Children[2].Class = "rail-junction-other-outer";
                                resultElement.Children[3].Class = "rail-junction-other-inner";
                            }

                            // KC
                            else
                            {
                                resultElement.Children.Add(lineKCOuter);
                                resultElement.Children.Add(lineKCInner);
                                resultElement.Children[2].Class = "rail-junction-other-outer";
                                resultElement.Children[3].Class = "rail-junction-other-inner";
                            }
                        }

                        // C_center_B + AM or C_center_B_D + AM or C_center_B + MAD
                        else
                        {
                            // C_center_B_D
                            if (railJunctionType.Equals("Type4"))
                            {
                                resultElement.Children.Add(polylineOuterCCenterBD);
                                resultElement.Children.Add(polylineInnerCCenterBD);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // C_center_B
                            else
                            {
                                resultElement.Children.Add(polylineOuterCCenterB);
                                resultElement.Children.Add(polylineInnerCCenterB);
                                resultElement.Children[0].Class = "rail-junction-main-outer";
                                resultElement.Children[1].Class = "rail-junction-main-inner";
                            }

                            // MAD
                            if (railJunctionType.Equals("Type3"))
                            {
                                resultElement.Children.Add(polylineOuterMAD);
                                resultElement.Children.Add(polylineInnerMAD);
                                resultElement.Children[2].Class = "rail-junction-other-outer";
                                resultElement.Children[3].Class = "rail-junction-other-inner";
                            }

                            // AM
                            else
                            {
                                resultElement.Children.Add(lineAMOuter);
                                resultElement.Children.Add(lineAMInner);
                                resultElement.Children[2].Class = "rail-junction-other-outer";
                                resultElement.Children[3].Class = "rail-junction-other-inner";
                            }
                        }
                    }

                    break;

                case ("rail-junction-no-control"):
                    // NB or NBD + KC or KCD + AM or MAD

                    // NB or NBD
                    if (railJunctionType.Equals("Type4"))
                    {
                        // NBD
                        resultElement.Children.Add(polylineOuterNBD);
                        resultElement.Children.Add(polylineInnerNBD);
                        resultElement.Children[0].Class = "rail-junction-no-control-outer";
                        resultElement.Children[1].Class = "rail-junction-no-control-inner";
                    }

                    // NB
                    else
                    {
                        resultElement.Children.Add(lineNBOuter);
                        resultElement.Children.Add(lineNBInner);
                        resultElement.Children[0].Class = "rail-junction-no-control-outer";
                        resultElement.Children[1].Class = "rail-junction-no-control-inner";
                    }

                    // (KC or AM) + (KCD or MAD)
                    if (railJunctionType.Equals("Type3"))
                    {
                        // AM + KCD
                        if (curOffsetB2 > 0)
                        {
                            // AM 
                            resultElement.Children.Add(lineAMOuter);
                            resultElement.Children.Add(lineAMInner);
                            resultElement.Children[2].Class = "rail-junction-no-control-outer";
                            resultElement.Children[3].Class = "rail-junction-no-control-inner";

                            // KCD 
                            resultElement.Children.Add(polylineOuterKCD);
                            resultElement.Children.Add(polylineInnerKCD);
                            resultElement.Children[4].Class = "rail-junction-no-control-outer";
                            resultElement.Children[5].Class = "rail-junction-no-control-inner";
                        }

                        // KC + MAD
                        else
                        {
                            // KC 
                            resultElement.Children.Add(lineKCOuter);
                            resultElement.Children.Add(lineKCInner);
                            resultElement.Children[2].Class = "rail-junction-no-control-outer";
                            resultElement.Children[3].Class = "rail-junction-no-control-inner";

                            // MAD
                            resultElement.Children.Add(polylineOuterMAD);
                            resultElement.Children.Add(polylineInnerMAD);
                            resultElement.Children[4].Class = "rail-junction-no-control-outer";
                            resultElement.Children[5].Class = "rail-junction-no-control-inner";
                        }
                    }

                    // KC + AM 
                    else
                    {
                        // KC 
                        resultElement.Children.Add(lineKCOuter);
                        resultElement.Children.Add(lineKCInner);
                        resultElement.Children[2].Class = "rail-junction-no-control-outer";
                        resultElement.Children[3].Class = "rail-junction-no-control-inner";

                        // AM 
                        resultElement.Children.Add(lineAMOuter);
                        resultElement.Children.Add(lineAMInner);
                        resultElement.Children[4].Class = "rail-junction-no-control-outer";
                        resultElement.Children[5].Class = "rail-junction-no-control-inner";
                    }

                    break;
            }

            return resultElement;
        }

        // Дополнительная функция для получения новой линии
        private static SvgLineElement GetNewLine(SvgPoint pointFirst, SvgPoint pointSecond, float lineWidth,
            Color objColor)
        {
            return new SvgLineElement
            {
                X1 = new SvgLength(pointFirst.X.Value),
                Y1 = new SvgLength(pointFirst.Y.Value),
                X2 = new SvgLength(pointSecond.X.Value),
                Y2 = new SvgLength(pointSecond.Y.Value),
                Stroke = new SvgPaint(objColor),
                StrokeWidth = new SvgLength(lineWidth)
            };
        }

        // Дополнительная функция для получения нового polyline
        private static SvgPolylineElement GetNewPolyline(SvgPoint pointFirst, SvgPoint pointSecond, SvgPoint pointThird,
            SvgPoint pointFourth, float lineWidth, Color objColor, bool fourthFlag)
        {
            var result = new SvgPolylineElement
            {
                Points =
                    new List<SvgPoint>
                    {
                        new SvgPoint(new SvgLength(pointFirst.X.Value),
                            new SvgLength(pointFirst.Y.Value)),
                        new SvgPoint(new SvgLength(pointSecond.X.Value),
                            new SvgLength(pointSecond.Y.Value)),
                        new SvgPoint(new SvgLength(pointThird.X.Value), new SvgLength(pointThird.Y.Value))
                    },
                Stroke = new SvgPaint(objColor),
                StrokeWidth = new SvgLength(lineWidth)
            };

            if (fourthFlag)
            {
                result.Points.Add(new SvgPoint(new SvgLength(pointFourth.X.Value),
                    new SvgLength(pointFourth.Y.Value)));
            }

            return result;
        }

        // Дополнительная функция для вычисления координат всех Точек для Type1
        private static IReadOnlyDictionary<string, SvgPoint> GetAllPointsType1(float curCenterX, float curCenterY,
            float curOffsetA2, float curOffsetC2, float curOffsetB2, float curOffsetD2B, float curAngle,
            float innerLineOffset)
        {
            // Center_M == Center_K == Center_N
            /*
             *      Type1 && Type4
             * D-----B         B-----D
             *        \       /
             *         \     /
             *          N   N
             *           \ /
             * A----M--Center--K--------C
             *           / \
             *          N   N
             *         /     \
             *        /       \
             * D-----B         B-----D
            */

            // Вычислим координаты всех точек
            var pointCenter = new SvgPoint(new SvgLength(curCenterX), new SvgLength(curCenterY));

            var outerPointA = new SvgPoint(new SvgLength(curCenterX + curOffsetA2), new SvgLength(curCenterY));
            var outerPointC = new SvgPoint(new SvgLength(curCenterX + curOffsetC2), new SvgLength(curCenterY));

            var innerPointA = new SvgPoint(new SvgLength(curCenterX + curOffsetA2 + innerLineOffset),
                new SvgLength(curCenterY));
            var innerPointC = new SvgPoint(new SvgLength(curCenterX + curOffsetC2 - innerLineOffset),
                new SvgLength(curCenterY));

            // Вычислим отступы от центра 
            var offsetM = Math.Abs(curOffsetA2 / 2) > 10 ? 10 : Math.Abs(curOffsetA2 / 2);
            var offsetK = Math.Abs(curOffsetC2 / 2) > 10 ? 10 : Math.Abs(curOffsetC2 / 2);
            var offsetN = Math.Abs(curOffsetB2) > 10 ? 10 : Math.Abs(curOffsetB2 / 2);

            var outerPointM = new SvgPoint(new SvgLength(curCenterX - offsetM), new SvgLength(curCenterY));
            var outerPointK = new SvgPoint(new SvgLength(curCenterX + offsetK), new SvgLength(curCenterY));

            var innerPointM =
                new SvgPoint(new SvgLength(curCenterX - offsetM - innerLineOffset), new SvgLength(curCenterY));
            var innerPointK =
                new SvgPoint(new SvgLength(curCenterX + offsetK + innerLineOffset), new SvgLength(curCenterY));

            // Переведем градусы, чтобы применить их в вычислении sin и cos 
            var angle = Math.PI * (curAngle + 90) / 180.0;

            // Если curOffsetB2 больше нуля -> "+sin" и "-cos"
            var outerPointN = curOffsetB2 > 0
                ? new SvgPoint(
                    new SvgLength((float)(curCenterX + offsetN * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY - offsetN * Math.Cos(angle))))
                : new SvgPoint(
                    new SvgLength((float)(curCenterX - offsetN * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY + offsetN * Math.Cos(angle))));

            var outerPointB = curOffsetB2 > 0
                ? new SvgPoint(
                    new SvgLength((float)(curCenterX + Math.Abs(curOffsetB2) * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY - Math.Abs(curOffsetB2) * Math.Cos(angle))))
                : new SvgPoint(
                    new SvgLength((float)(curCenterX - Math.Abs(curOffsetB2) * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY + Math.Abs(curOffsetB2) * Math.Cos(angle))));

            var innerPointN = curOffsetB2 > 0
                ? new SvgPoint(
                    new SvgLength((float)(curCenterX + (offsetN + innerLineOffset) * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY - (offsetN + innerLineOffset) * Math.Cos(angle))))
                : new SvgPoint(
                    new SvgLength((float)(curCenterX - (offsetN + innerLineOffset) * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY + (offsetN + innerLineOffset) * Math.Cos(angle))));

            var innerPointB = curOffsetB2 > 0
                ? new SvgPoint(
                    new SvgLength((float)(curCenterX + (Math.Abs(curOffsetB2) - innerLineOffset) * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY - (Math.Abs(curOffsetB2) - innerLineOffset) * Math.Cos(angle))))
                : new SvgPoint(
                    new SvgLength((float)(curCenterX - (Math.Abs(curOffsetB2) - innerLineOffset) * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY + (Math.Abs(curOffsetB2) - innerLineOffset) * Math.Cos(angle))));

            var outerPointD = curOffsetB2 > 0
                ? new SvgPoint(new SvgLength(outerPointB.X.Value + curOffsetD2B), new SvgLength(outerPointB.Y.Value))
                : new SvgPoint(new SvgLength(outerPointB.X.Value - curOffsetD2B), new SvgLength(outerPointB.Y.Value));

            var innerPointD = curOffsetB2 > 0
                ? new SvgPoint(new SvgLength(outerPointB.X.Value + curOffsetD2B - innerLineOffset),
                    new SvgLength(outerPointB.Y.Value))
                : new SvgPoint(new SvgLength(outerPointB.X.Value - curOffsetD2B + innerLineOffset),
                    new SvgLength(outerPointB.Y.Value));

            return new Dictionary<string, SvgPoint>
            {
                ["pointCenter"] = pointCenter,
                ["outerPointB"] = outerPointB,
                ["outerPointN"] = outerPointN,
                ["innerPointB"] = innerPointB,
                ["innerPointN"] = innerPointN,
                ["outerPointA"] = outerPointA,
                ["outerPointC"] = outerPointC,
                ["innerPointA"] = innerPointA,
                ["innerPointC"] = innerPointC,
                ["outerPointK"] = outerPointK,
                ["outerPointM"] = outerPointM,
                ["innerPointK"] = innerPointK,
                ["innerPointM"] = innerPointM,
                ["outerPointD"] = outerPointD,
                ["innerPointD"] = innerPointD
            };
        }

        // Дополнительная функция для вычисления координат всех Точек для Type2 и Type3
        private static IReadOnlyDictionary<string, SvgPoint> GetAllPointsType2(float curCenterX, float curCenterY,
            float curOffsetA2, float curOffsetC2, float curOffsetB2, float curOffsetD2B, float curAngle,
            float innerLineOffset, string railJunctionType)
        {
            // Center_M == Center_K == Center_N
            /*
             *      Type2 && Type3
             * D-----A         C-----D
             *        \       /
             *         \     /
             *          M   K
             *           \ /
             * B----N--Center--N--------B
             *           / \
             *          M   K
             *         /     \
             *        /       \
             * D-----A         C-----D
            */

            // Переведем градусы, чтобы применить их в вычислении sin и cos 
            var angle = Math.PI * (curAngle + 90) / 180.0;

            // Вычислим координаты всех точек
            var pointCenter = new SvgPoint(new SvgLength(curCenterX), new SvgLength(curCenterY));

            // Вычислим отступы от центра 
            var offsetM = Math.Abs(curOffsetA2 / 2) > 10 ? 10 : Math.Abs(curOffsetA2 / 2);
            var offsetK = Math.Abs(curOffsetC2 / 2) > 10 ? 10 : Math.Abs(curOffsetC2 / 2);
            var offsetN = Math.Abs(curOffsetB2 / 2) > 10 ? 10 : Math.Abs(curOffsetB2 / 2);

            var outerPointB = new SvgPoint(new SvgLength(curCenterX + curOffsetB2), new SvgLength(curCenterY));
            var outerPointN = curOffsetB2 > 0
                ? new SvgPoint(new SvgLength(curCenterX + offsetN), new SvgLength(curCenterY))
                : new SvgPoint(new SvgLength(curCenterX - offsetN), new SvgLength(curCenterY));

            var innerPointB = curOffsetB2 > 0
                ? new SvgPoint(new SvgLength(curCenterX + curOffsetB2 - innerLineOffset), new SvgLength(curCenterY))
                : new SvgPoint(new SvgLength(curCenterX + curOffsetB2 + innerLineOffset), new SvgLength(curCenterY));
            var innerPointN = curOffsetB2 > 0
                ? new SvgPoint(new SvgLength(curCenterX + offsetN + innerLineOffset), new SvgLength(curCenterY))
                : new SvgPoint(new SvgLength(curCenterX - offsetN - innerLineOffset), new SvgLength(curCenterY));

            var outerPointK = new SvgPoint(
                new SvgLength((float)(curCenterX + offsetK * Math.Sin(angle))),
                new SvgLength((float)(curCenterY - offsetK * Math.Cos(angle))));
            var outerPointM = new SvgPoint(
                new SvgLength((float)(curCenterX - offsetM * Math.Sin(angle))),
                new SvgLength((float)(curCenterY + offsetM * Math.Cos(angle))));

            var outerPointA = new SvgPoint(
                new SvgLength((float)(curCenterX + curOffsetA2 * Math.Sin(angle))),
                new SvgLength((float)(curCenterY - curOffsetA2 * Math.Cos(angle))));
            var outerPointC = new SvgPoint(
                new SvgLength((float)(curCenterX + curOffsetC2 * Math.Sin(angle))),
                new SvgLength((float)(curCenterY - curOffsetC2 * Math.Cos(angle))));
            var innerPointA = new SvgPoint(
                new SvgLength((float)(curCenterX + (curOffsetA2 + innerLineOffset) * Math.Sin(angle))),
                new SvgLength((float)(curCenterY - (curOffsetA2 + innerLineOffset) * Math.Cos(angle))));
            var innerPointC = new SvgPoint(
                new SvgLength((float)(curCenterX + (curOffsetC2 - innerLineOffset) * Math.Sin(angle))),
                new SvgLength((float)(curCenterY - (curOffsetC2 - innerLineOffset) * Math.Cos(angle))));

            if (railJunctionType.Equals("Type3") && curOffsetB2 < 0)
            {
                outerPointA = new SvgPoint(
                    new SvgLength((float)(curCenterX - curOffsetC2 * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY + curOffsetC2 * Math.Cos(angle))));
                outerPointC = new SvgPoint(
                    new SvgLength((float)(curCenterX - curOffsetA2 * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY + curOffsetA2 * Math.Cos(angle))));
                innerPointA = new SvgPoint(
                    new SvgLength((float)(curCenterX - (curOffsetC2 + innerLineOffset) * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY + (curOffsetC2 + innerLineOffset) * Math.Cos(angle))));
                innerPointC = new SvgPoint(
                    new SvgLength((float)(curCenterX - (curOffsetA2 - innerLineOffset) * Math.Sin(angle))),
                    new SvgLength((float)(curCenterY + (curOffsetA2 - innerLineOffset) * Math.Cos(angle))));
            }

            var innerPointK = new SvgPoint(
                new SvgLength((float)(curCenterX + (offsetK + innerLineOffset) * Math.Sin(angle))),
                new SvgLength((float)(curCenterY - (offsetK + innerLineOffset) * Math.Cos(angle))));

            var innerPointM = new SvgPoint(
                new SvgLength((float)(curCenterX - (offsetM + innerLineOffset) * Math.Sin(angle))),
                new SvgLength((float)(curCenterY + (offsetM + innerLineOffset) * Math.Cos(angle))));

            var outerPointD = curOffsetB2 > 0
                ? new SvgPoint(new SvgLength(outerPointC.X.Value + curOffsetD2B), new SvgLength(outerPointC.Y.Value))
                : new SvgPoint(new SvgLength(outerPointA.X.Value - curOffsetD2B), new SvgLength(outerPointA.Y.Value));
            var innerPointD = curOffsetB2 > 0
                ? new SvgPoint(new SvgLength(outerPointC.X.Value + curOffsetD2B + innerLineOffset),
                    new SvgLength(outerPointC.Y.Value))
                : new SvgPoint(new SvgLength(outerPointA.X.Value - curOffsetD2B - innerLineOffset),
                    new SvgLength(outerPointA.Y.Value));

            return new Dictionary<string, SvgPoint>
            {
                ["pointCenter"] = pointCenter,
                ["outerPointB"] = outerPointB,
                ["outerPointN"] = outerPointN,
                ["innerPointB"] = innerPointB,
                ["innerPointN"] = innerPointN,
                ["outerPointA"] = outerPointA,
                ["outerPointC"] = outerPointC,
                ["innerPointA"] = innerPointA,
                ["innerPointC"] = innerPointC,
                ["outerPointK"] = outerPointK,
                ["outerPointM"] = outerPointM,
                ["innerPointK"] = innerPointK,
                ["innerPointM"] = innerPointM,
                ["outerPointD"] = outerPointD,
                ["innerPointD"] = innerPointD
            };
        }

        // Дополнительная функция для получения всех Линий
        private static IReadOnlyDictionary<string, SvgGeometryElement> GetAllLines(
            IReadOnlyDictionary<string, SvgPoint> allPointsDictionary, float externalStrokeWidth, float internalWidth,
            Color objColor)
        {
            // Center_M == Center_K == Center_N
            /*      Type1 && Type4                        Type2 && Type 3
             * 
             * D-----B         B-----D               D-----A         C-----D
             *        \       /                             \       /
             *         \     /                               \     /
             *          N   N                                 M   K
             *           \ /                                   \ /
             * A----M--Center--K--------C            B----N--Center--N--------B
             *           / \                                   / \
             *          N   N                                 M   K
             *         /     \                               /     \
             *        /       \                             /       \
             * D-----B         B-----D               D-----A         C-----D
            */

            // Получим значения всех точек
            var pointCenter = allPointsDictionary["pointCenter"];

            var outerPointA = allPointsDictionary["outerPointA"];
            var outerPointC = allPointsDictionary["outerPointC"];
            var innerPointA = allPointsDictionary["innerPointA"];
            var innerPointC = allPointsDictionary["innerPointC"];
            var outerPointM = allPointsDictionary["outerPointM"];
            var outerPointK = allPointsDictionary["outerPointK"];
            var innerPointM = allPointsDictionary["innerPointM"];
            var innerPointK = allPointsDictionary["innerPointK"];
            var outerPointN = allPointsDictionary["outerPointN"];
            var outerPointB = allPointsDictionary["outerPointB"];
            var innerPointN = allPointsDictionary["innerPointN"];
            var innerPointB = allPointsDictionary["innerPointB"];
            var outerPointD = allPointsDictionary["outerPointD"];
            var innerPointD = allPointsDictionary["innerPointD"];

            // Создадим 8 линии и 4 polyline, а далее выберем в зависимости от инверсии и знака curOffsetB2
            var lineACOuter = GetNewLine(outerPointA, outerPointC, externalStrokeWidth, objColor);

            var lineNBOuter = GetNewLine(outerPointN, outerPointB, externalStrokeWidth, objColor);

            var lineKCOuter = GetNewLine(outerPointK, outerPointC, externalStrokeWidth, objColor);

            var lineAMOuter = GetNewLine(outerPointA, outerPointM, externalStrokeWidth, objColor);

            var lineACInner = GetNewLine(outerPointA, outerPointC, internalWidth, objColor);

            var lineNBInner = GetNewLine(innerPointN, innerPointB, internalWidth, objColor);

            var lineKCInner = GetNewLine(innerPointK, innerPointC, internalWidth, objColor);

            var lineAMInner = GetNewLine(innerPointA, innerPointM, internalWidth, objColor);

            var emptyPoint = new SvgPoint();

            var polylineOuterACenterB =
                GetNewPolyline(outerPointA, pointCenter, outerPointB, emptyPoint,
                    externalStrokeWidth, objColor, false);

            var polylineInnerACenterB =
                GetNewPolyline(innerPointA, pointCenter, innerPointB, emptyPoint,
                    internalWidth, objColor, false);

            var polylineOuterCCenterB =
                GetNewPolyline(outerPointC, pointCenter, outerPointB, emptyPoint,
                    externalStrokeWidth, objColor, false);

            var polylineInnerCCenterB =
                GetNewPolyline(innerPointC, pointCenter, innerPointB, emptyPoint,
                    internalWidth, objColor, false);

            var polylineOuterNBD =
                GetNewPolyline(outerPointN, outerPointB, outerPointD, emptyPoint,
                    externalStrokeWidth, objColor, false);

            var polylineInnerNBD =
                GetNewPolyline(innerPointN, outerPointB, innerPointD, emptyPoint,
                    internalWidth, objColor, false);

            var polylineOuterACenterBD =
                GetNewPolyline(outerPointA, pointCenter, outerPointB, outerPointD,
                    externalStrokeWidth, objColor, true);

            var polylineInnerACenterBD =
                GetNewPolyline(innerPointA, pointCenter, outerPointB, innerPointD,
                    internalWidth, objColor, true);

            var polylineOuterCCenterBD =
                GetNewPolyline(outerPointC, pointCenter, outerPointB, outerPointD,
                    externalStrokeWidth, objColor, true);

            var polylineInnerCCenterBD =
                GetNewPolyline(innerPointC, pointCenter, outerPointB, innerPointD,
                    internalWidth, objColor, true);

            var polylineOuterKCD =
                GetNewPolyline(outerPointK, outerPointC, outerPointD, emptyPoint,
                    externalStrokeWidth, objColor, false);

            var polylineInnerKCD =
                GetNewPolyline(innerPointK, outerPointC, innerPointD, emptyPoint,
                    internalWidth, objColor, false);

            var polylineOuterACD =
                GetNewPolyline(outerPointA, outerPointC, outerPointD, emptyPoint,
                    externalStrokeWidth, objColor, false);

            var polylineInnerACD =
                GetNewPolyline(innerPointA, outerPointC, innerPointD, emptyPoint,
                    internalWidth, objColor, false);

            var polylineOuterCAD =
                GetNewPolyline(outerPointC, outerPointA, outerPointD, emptyPoint,
                    externalStrokeWidth, objColor, false);

            var polylineInnerCAD =
                GetNewPolyline(innerPointC, outerPointA, innerPointD, emptyPoint,
                    internalWidth, objColor, false);

            var polylineOuterMAD =
                GetNewPolyline(outerPointM, outerPointA, outerPointD, emptyPoint,
                    externalStrokeWidth, objColor, false);

            var polylineInnerMAD =
                GetNewPolyline(innerPointM, outerPointA, innerPointD, emptyPoint,
                    internalWidth, objColor, false);

            return new Dictionary<string, SvgGeometryElement>
            {
                ["lineACOuter"] = lineACOuter,
                ["lineNBOuter"] = lineNBOuter,
                ["lineKCOuter"] = lineKCOuter,
                ["lineAMOuter"] = lineAMOuter,
                ["lineACInner"] = lineACInner,
                ["lineNBInner"] = lineNBInner,
                ["lineKCInner"] = lineKCInner,
                ["lineAMInner"] = lineAMInner,
                ["polylineOuterACenterB"] = polylineOuterACenterB,
                ["polylineInnerACenterB"] = polylineInnerACenterB,
                ["polylineOuterCCenterB"] = polylineOuterCCenterB,
                ["polylineInnerCCenterB"] = polylineInnerCCenterB,
                ["polylineOuterNBD"] = polylineOuterNBD,
                ["polylineInnerNBD"] = polylineInnerNBD,
                ["polylineOuterACenterBD"] = polylineOuterACenterBD,
                ["polylineInnerACenterBD"] = polylineInnerACenterBD,
                ["polylineOuterCCenterBD"] = polylineOuterCCenterBD,
                ["polylineInnerCCenterBD"] = polylineInnerCCenterBD,
                ["polylineOuterKCD"] = polylineOuterKCD,
                ["polylineInnerKCD"] = polylineInnerKCD,
                ["polylineOuterACD"] = polylineOuterACD,
                ["polylineInnerACD"] = polylineInnerACD,
                ["polylineOuterCAD"] = polylineOuterCAD,
                ["polylineInnerCAD"] = polylineInnerCAD,
                ["polylineOuterMAD"] = polylineOuterMAD,
                ["polylineInnerMAD"] = polylineInnerMAD
            };
        }
    }
}