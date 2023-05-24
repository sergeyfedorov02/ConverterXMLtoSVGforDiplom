using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class XmlParser
    {
        public static string CreateSvgDocument(XmlDocument docXml, ISvgConvertOptions options)
        {
            options ??= new DefaultConvertOptions();
            // Найдем все узлы с именем "DesignerItem"
            var nodeList = docXml.GetElementsByTagName("DesignerItem");

            // Если ничего не нашли -> выходим
            if (nodeList.Count == 0)
            {
                return "";
            }

            // Создаем холст для рисования (Итоговый Svg файл будет здесь)
            var svgDoc = new GcSvgDocument();

            // Задаем начальные размеры поля
            var maxRightValue = 0f;
            var maxBottomValue = 0f;
            svgDoc.RootSvg.ViewBox = new SvgViewBox(0, 0, maxRightValue + 20, maxBottomValue + 20);
            svgDoc.RootSvg.Width = new SvgLength(1600f);
            svgDoc.RootSvg.Height = new SvgLength(900f);

            // Добавим параметр стандартного шрифта
            svgDoc.RootSvg.FontFamily = new List<SvgFontFamily>
            {
                new SvgFontFamily("Segoe UI")
            };

            // Добавим версию, xmlns:xlink и xmlns:xml
            svgDoc.RootSvg.CustomAttributes = new List<SvgCustomAttribute>
            {
                new SvgCustomAttribute("version", "1.1"),
            };

            // Создадим главную группу, которая будет содержать все элементы
            var mainGroup = new SvgGroupElement
            {
                FillOpacity = 0,
                Class = "main-panel",
                CustomAttributes = new List<SvgCustomAttribute>
                {
                    new SvgCustomAttribute("data-first-color", "0")
                }
            };

            // Пройдемся по всем полученным узлам
            foreach (XmlNode xmlNode in nodeList)
            {
                // Получим значение атрибута с именем "ToolId"
                var valueTollId = xmlNode.Attributes?["ToolId"] == null
                    ? string.Empty
                    : xmlNode.Attributes["ToolId"].InnerText;

                // Если атрибута с именем "ToolId" не оказалось, то ничего не делаем и переходим к следующему xmlNode
                if (valueTollId.Equals(string.Empty))
                {
                    continue;
                }

                // Переменная, которой будем присваивать значение нарисованной группы элементов
                SvgElement element = null;

                // Получим Dictionary, состоящий из свойств текущего элемента
                var dictionaryPropertiesFromCurrentNode = CreateDictionaryFromProperties(xmlNode);

                // В зависимости от полученного имени нарисуем соответствующий элемент
                switch (valueTollId)
                {
                    case "StandardLibrary.Lamp":
                        // Нарисуем элемент типа "StandardLibrary.Lamp" - Индикатор
                        element = CreateLamp.CreateSvgImageLamp(dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.RailUnitEx":
                        // Нарисуем элемент типа "StandardLibrary.RailUnitEx" - Путь
                        element = CreateRailUnit.CreateSvgImageRailUnit(dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.RailUnitWithIntersection":
                        // Нарисуем элемент типа "StandardLibrary.RailUnitWithIntersection" - Путь с разрывом
                        element = CreateRailUnitWithIntersection.CreateSvgImageRailUnitWithIntersection(
                            dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.IsoJoint":
                        // Нарисуем элемент типа "StandardLibrary.IsoJoint" - Изостык
                        element = CreateIsoJoint.CreateSvgImageIsoJoint(dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.RailTerminator":
                        // Нарисуем элемент типа "StandardLibrary.RailTerminator" - Тупик
                        element = CreateRailTerminator.CreateSvgImageRailTerminator(
                            dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.RailCrossing":
                        // Нарисуем элемент типа "StandardLibrary.RailCrossing" - Переезд
                        element = CreateRailCrossing.CreateSvgImageRailCrossing(dictionaryPropertiesFromCurrentNode,
                            options);
                        break;

                    case "StandardLibrary.Relay":
                        // Нарисуем элемент типа "StandardLibrary.Relay" - Контакт/Реле
                        element = CreateRelay.CreateSvgImageRelay(dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.JunctionSwitch":
                    case "StandardLibrary.JunctionSwitchWithoutNoControl":
                    case "StandardLibrary.Uksps":
                        // Нарисуем элемент типа "StandardLibrary.JunctionSwitch" и "JunctionSwitchWithoutNoControl"- Стрелочный коммутатор
                        // Также элемент типа "StandardLibrary.Uksps" - УКСПС
                        element = CreateJunctionSwitch.CreateSvgImageJunctionSwitch(
                            dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.Semaphore":
                        // Нарисуем элемент типа "StandardLibrary.Semaphore" - Светофор
                        element = CreateSemaphore.CreateSvgImageSemaphore(dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.FenceSemaphore":
                        // Нарисуем элемент типа "StandardLibrary.FenceSemaphore" - Заградительный светофор
                        element = CreateFenceSemaphore.CreateSvgImageFenceSemaphore(
                            dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.RailJunctionEx":
                        // Нарисуем элемент типа "StandardLibrary.RailJunctionEx" - Стрелочная секция
                        element = CreateRailJunction.CreateSvgImageRailJunction(dictionaryPropertiesFromCurrentNode,
                            options);
                        break;

                    case "StandardLibrary.Panel":
                        // Нарисуем элемент типа "StandardLibrary.Panel" - Панель
                        element = CreatePanel.CreateSvgImagePanel(dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.Measure":
                        // Нарисуем элемент типа "StandardLibrary.Measure" - Измерение
                        element = CreateMeasure.CreateSvgImageMeasure(dictionaryPropertiesFromCurrentNode, options);
                        break;

                    case "StandardLibrary.Picture":
                        // Нарисуем элемент типа "StandardLibrary.Picture" - Изображение
                        element = CreatePicture.CreateSvgImagePicture(dictionaryPropertiesFromCurrentNode, options);
                        break;
                }

                if (element != null)
                {
                    // Добавим новую группу из элементов в mainGroup
                    mainGroup.Children.Add(element);

                    // Для обновления размеров поля вычислим координаты правого и нижнего краев
                    var currentValues = GetCurrentRightBottomValues(dictionaryPropertiesFromCurrentNode);

                    // Если координаты больше текущих(максимальных), то обновим максимальные
                    if (currentValues[0] > maxRightValue)
                    {
                        maxRightValue = currentValues[0];
                    }

                    if (currentValues[1] > maxBottomValue)
                    {
                        maxBottomValue = currentValues[1];
                    }
                }
            }

            // Обновим значение ViewBox (зададим правый край по координате правого края самой правой фигуры + 20 и также с нижним краем)
            svgDoc.RootSvg.ViewBox = new SvgViewBox(0, 0, maxRightValue + 20, maxBottomValue + 20);

            // Добавим нарисованный элемент mainGroup на холст
            svgDoc.RootSvg.Children.Add(mainGroup);

            // Выдадим полученный svgDoc в string формате
            var sb = new StringBuilder();
            svgDoc.Save(sb);
            return sb.ToString();
        }

        // Функция для получения Dictionary из свойств элемента (из Properties: name и value)
        private static Dictionary<string, string> CreateDictionaryFromProperties(XmlNode currentXmlNode)
        {
            var result = new Dictionary<string, string>
            {
                // Добавим ToolId, ClientId, Label и ShouldDrawLabel в result
                ["Label"] = currentXmlNode.SelectSingleNode("Label")?.InnerText ?? string.Empty,
                ["ShouldDrawLabel"] = currentXmlNode.SelectSingleNode("ShouldDrawLabel")?.InnerText ?? "false",
                ["ToolId"] = currentXmlNode.Attributes?["ToolId"].InnerText,
                ["ClientId"] = currentXmlNode.Attributes?["ClientId"] == null
                    ? "0"
                    : currentXmlNode.Attributes["ClientId"].InnerText
            };

            // Получим дочерний узел Properties
            var properties = currentXmlNode.SelectSingleNode("Properties");

            // Если узла "Properties" не существует -> вернём result
            if (properties == null) return result;

            // Разбираемся с узлом Properties
            var propertiesNodes = properties.SelectNodes("*");

            // Если узел Properties ничего не содержит -> вернём пустой result
            if (propertiesNodes!.Count == 0) return result;

            // Иначе разберемся с содержимым
            foreach (XmlNode propertiesNode in propertiesNodes)
            {
                // Найдем текущие значения
                var name = propertiesNode.SelectSingleNode("Name")?.InnerText;
                var aValue = propertiesNode.SelectSingleNode("Value")?.InnerText;

                // Добавим найденные значения в result
                if (name != null && aValue != null)
                {
                    result[name] = aValue;
                }
            }

            return result;
        }

        // Дополнительная функция для вычисления размеров поля
        private static List<float> GetCurrentRightBottomValues(IReadOnlyDictionary<string, string> currentDictionary)
        {
            var result = new List<float>();

            var valueRight = currentDictionary.TryGetValue("Right", out var right) ? right : "";
            var valueLeft = currentDictionary.TryGetValue("Left", out var left) ? left : "";

            var valueBottom = currentDictionary.TryGetValue("Bottom", out var bottom) ? bottom : "";
            var valueTop = currentDictionary.TryGetValue("Top", out var top) ? top : "";

            var valueStart = currentDictionary.TryGetValue("Start", out var start) ? start : "";
            var valueOffsetEnd = currentDictionary.TryGetValue("OffsetEnd", out var offsetEnd) ? offsetEnd : "";

            var valueOffsetIntervalEnd = currentDictionary.TryGetValue("OffsetIntervalEnd", out var offsetIntervalEnd)
                ? offsetIntervalEnd
                : "";
            var valueOffsetIntervalStart =
                currentDictionary.TryGetValue("OffsetIntervalStart", out var offsetIntervalStart)
                    ? offsetIntervalStart
                    : "";
            var valueIntervalLength = currentDictionary.TryGetValue("IntervalLength", out var intervalLength)
                ? intervalLength
                : "";

            var valueLeftTop = currentDictionary.TryGetValue("LeftTop", out var leftTop) ? leftTop : "";
            var valueLampSize = currentDictionary.TryGetValue("LampSize", out var lampSize) ? lampSize : "";
            var valueLampSpace = currentDictionary.TryGetValue("LampSpace", out var lampSpace) ? lampSpace : "";
            var valueRowSpace = currentDictionary.TryGetValue("RowSpace", out var rowSpace) ? rowSpace : "";

            var valueSemaphoreType = currentDictionary.TryGetValue("SemaphoreType", out var semaphoreType)
                ? semaphoreType
                : "";
            var valueSemaphoreLegType = currentDictionary.TryGetValue("LegType", out var semaphoreLegType)
                ? semaphoreLegType
                : "";
            var valueLineWidth = currentDictionary.TryGetValue("LineWidth", out var lineWidth) ? lineWidth : "";

            var curRight = 0f;
            var curBottom = 0f;

            // Если фигура вписана в прямоугольник
            if (valueRight != "")
            {
                curRight = float.Parse(float.Parse(valueRight, CultureInfo.InvariantCulture) >
                                       float.Parse(valueLeft, CultureInfo.InvariantCulture)
                    ? valueRight
                    : valueLeft, CultureInfo.InvariantCulture);

                curBottom = float.Parse(float.Parse(valueBottom, CultureInfo.InvariantCulture) >
                                        float.Parse(valueTop, CultureInfo.InvariantCulture)
                    ? valueBottom
                    : valueTop, CultureInfo.InvariantCulture);
            }

            // Если у фигуры задан параметр "Start"
            else if (valueStart != "")
            {
                var curLeft = valueStart.Split(",")[0];

                // Путь без разрыва
                if (valueOffsetEnd != "")
                {
                    curRight = float.Parse(valueOffsetEnd, CultureInfo.InvariantCulture) > 0f
                        ? float.Parse(curLeft, CultureInfo.InvariantCulture) +
                          float.Parse(valueOffsetEnd, CultureInfo.InvariantCulture)
                        : float.Parse(curLeft, CultureInfo.InvariantCulture);
                }
                // Путь с разрывом
                else if (valueOffsetIntervalEnd != "")
                {
                    curRight = float.Parse(valueOffsetIntervalEnd, CultureInfo.InvariantCulture) > 0f
                        ? float.Parse(curLeft, CultureInfo.InvariantCulture) +
                          float.Parse(valueOffsetIntervalEnd, CultureInfo.InvariantCulture) +
                          float.Parse(valueOffsetIntervalStart, CultureInfo.InvariantCulture) +
                          float.Parse(valueIntervalLength, CultureInfo.InvariantCulture)
                        : float.Parse(curLeft, CultureInfo.InvariantCulture);
                }

                curBottom = float.Parse(valueStart.Split(",")[1], CultureInfo.InvariantCulture);
            }

            // Если изостык
            else if (currentDictionary["ToolId"] == "StandardLibrary.IsoJoint")
            {
                curRight = float.Parse(valueLeft, CultureInfo.InvariantCulture) + 16f;
                curBottom = float.Parse(valueTop, CultureInfo.InvariantCulture) + 16f;
            }

            // Если тупик
            else if (currentDictionary["ToolId"] == "StandardLibrary.RailTerminator")
            {
                curRight = float.Parse(valueLeft, CultureInfo.InvariantCulture) + 40f;
                curBottom = float.Parse(valueTop, CultureInfo.InvariantCulture) + 20f;
            }

            // Если стрелочный коммутатор или УКСПС
            else if (currentDictionary["ToolId"] == "StandardLibrary.JunctionSwitch" ||
                     currentDictionary["ToolId"] == "StandardLibrary.JunctionSwitchWithoutNoControl" ||
                     currentDictionary["ToolId"] == "StandardLibrary.Uksps")
            {
                var curLeft = float.Parse(valueLeftTop.Split(",")[0], CultureInfo.InvariantCulture);
                var curTop = float.Parse(valueLeftTop.Split(",")[1], CultureInfo.InvariantCulture);

                curRight = curLeft + float.Parse(valueLampSpace, CultureInfo.InvariantCulture) +
                           2 * float.Parse(valueLampSize.Split(",")[0], CultureInfo.InvariantCulture);

                if (valueRowSpace != "")
                {
                    curBottom = curTop + float.Parse(valueRowSpace, CultureInfo.InvariantCulture) +
                                2 * float.Parse(valueLampSize.Split(",")[1], CultureInfo.InvariantCulture);
                }
                else
                {
                    curBottom = curTop + float.Parse(valueLampSize.Split(",")[1], CultureInfo.InvariantCulture);
                }
            }

            // Если светофор
            else if (currentDictionary["ToolId"] == "StandardLibrary.Semaphore")
            {
                switch (valueSemaphoreLegType)
                {
                    // Если тип светофора - карликовый
                    case "0":
                        // Если меньше 4 индикаторов -> они расположены в линию
                        if (float.Parse(valueSemaphoreType, CultureInfo.InvariantCulture) < 4)
                        {
                            curRight = float.Parse(valueLeft, CultureInfo.InvariantCulture) +
                                       2 * float.Parse(valueLineWidth, CultureInfo.InvariantCulture) +
                                       8 * 2 * float.Parse(valueSemaphoreType, CultureInfo.InvariantCulture);
                            curBottom = float.Parse(valueTop, CultureInfo.InvariantCulture) +
                                        8 * 2;
                        }
                        // Если 4 или 5 индикаторов -> они расположены в прямоугольнике длиной 3 или 2 индикатора
                        else
                        {
                            curRight = valueSemaphoreType.Equals("4")
                                ? float.Parse(valueLeft, CultureInfo.InvariantCulture) +
                                  2 * float.Parse(valueLineWidth, CultureInfo.InvariantCulture) + 8 * 2 * 2
                                : float.Parse(valueLeft, CultureInfo.InvariantCulture) +
                                  2 * float.Parse(valueLineWidth, CultureInfo.InvariantCulture) + 8 * 2 * 3;
                            curBottom = float.Parse(valueTop, CultureInfo.InvariantCulture) +
                                        8 * 2 * 2;
                        }

                        break;

                    // Если тип светофора - мачтовый
                    case "1":
                        curRight = float.Parse(valueLeft, CultureInfo.InvariantCulture) +
                                   2 * float.Parse(valueLineWidth, CultureInfo.InvariantCulture) +
                                   8 * 2 * float.Parse(valueSemaphoreType, CultureInfo.InvariantCulture) +
                                   6;
                        curBottom = float.Parse(valueTop, CultureInfo.InvariantCulture) + 16f;
                        break;
                }
            }

            // Если заградительный светофор
            else if (currentDictionary["ToolId"] == "StandardLibrary.FenceSemaphore")
            {
                curRight = float.Parse(valueLeft, CultureInfo.InvariantCulture) +
                           2 * float.Parse(valueLineWidth, CultureInfo.InvariantCulture) + 8 * 2 + 6;
                curBottom = float.Parse(valueTop, CultureInfo.InvariantCulture) + 16f;
            }

            // Если стрелочная секция
            else if (currentDictionary["ToolId"] == "StandardLibrary.RailJunctionEx")
            {
                // Вычислим все координаты
                var curCenterX = float.Parse(currentDictionary["CenterPoint"].Split(",")[0],
                    CultureInfo.InvariantCulture);
                var curCenterY = float.Parse(currentDictionary["CenterPoint"].Split(",")[1],
                    CultureInfo.InvariantCulture);
                var curOffsetA2 = float.Parse(currentDictionary["OffsetA2Center"], CultureInfo.InvariantCulture);
                var curOffsetC2 = float.Parse(currentDictionary["OffsetC2Center"], CultureInfo.InvariantCulture);
                var curOffsetB2 = float.Parse(currentDictionary["OffsetB2Center"], CultureInfo.InvariantCulture);
                var curOffsetD2B = float.Parse(currentDictionary["OffsetD2B"], CultureInfo.InvariantCulture);
                var curAngle = float.Parse(currentDictionary["Angle"], CultureInfo.InvariantCulture);

                // Переведем градусы, чтобы применить их в вычислении sin и cos 
                var angle = Math.PI * (curAngle + 90) / 180.0;

                // Вычислим координаты всех точек
                var pointCenter = new SvgPoint(new SvgLength(curCenterX), new SvgLength(curCenterY));

                // Вычислим отступы от центра 
                var offsetM = Math.Abs(curOffsetA2 / 2) > 10 ? 10 : Math.Abs(curOffsetA2 / 2);
                var offsetK = Math.Abs(curOffsetC2 / 2) > 10 ? 10 : Math.Abs(curOffsetC2 / 2);
                var offsetN = Math.Abs(curOffsetB2 / 2) > 10 ? 10 : Math.Abs(curOffsetB2 / 2);

                // Объявим все точки и вычислим их значения в зависимости от типа стрелочной секции
                SvgPoint pointA, pointB, pointC, pointD, pointM, pointN, pointK;

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
                if (currentDictionary["Type"].Equals("Type1") || currentDictionary["Type"].Equals("Type4"))
                {
                    pointA = new SvgPoint(new SvgLength(curCenterX + curOffsetA2), new SvgLength(curCenterY));
                    pointC = new SvgPoint(new SvgLength(curCenterX + curOffsetC2), new SvgLength(curCenterY));

                    pointM = new SvgPoint(new SvgLength(curCenterX - offsetM), new SvgLength(curCenterY));
                    pointK = new SvgPoint(new SvgLength(curCenterX + offsetK), new SvgLength(curCenterY));

                    pointN = curOffsetB2 > 0
                        ? new SvgPoint(
                            new SvgLength((float)(curCenterX + offsetN * Math.Sin(angle))),
                            new SvgLength((float)(curCenterY - offsetN * Math.Cos(angle))))
                        : new SvgPoint(
                            new SvgLength((float)(curCenterX - offsetN * Math.Sin(angle))),
                            new SvgLength((float)(curCenterY + offsetN * Math.Cos(angle))));

                    pointB = curOffsetB2 > 0
                        ? new SvgPoint(
                            new SvgLength((float)(curCenterX + Math.Abs(curOffsetB2) * Math.Sin(angle))),
                            new SvgLength((float)(curCenterY - Math.Abs(curOffsetB2) * Math.Cos(angle))))
                        : new SvgPoint(
                            new SvgLength((float)(curCenterX - Math.Abs(curOffsetB2) * Math.Sin(angle))),
                            new SvgLength((float)(curCenterY + Math.Abs(curOffsetB2) * Math.Cos(angle))));

                    pointD = curOffsetB2 > 0
                        ? new SvgPoint(new SvgLength(pointB.X.Value + curOffsetD2B), new SvgLength(pointB.Y.Value))
                        : new SvgPoint(new SvgLength(pointB.X.Value - curOffsetD2B), new SvgLength(pointB.Y.Value));
                }

                else
                {
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
                    pointB = new SvgPoint(new SvgLength(curCenterX + curOffsetB2), new SvgLength(curCenterY));
                    pointN = curOffsetB2 > 0
                        ? new SvgPoint(new SvgLength(curCenterX + offsetN), new SvgLength(curCenterY))
                        : new SvgPoint(new SvgLength(curCenterX - offsetN), new SvgLength(curCenterY));
                    pointK = new SvgPoint(
                        new SvgLength((float)(curCenterX + offsetK * Math.Sin(angle))),
                        new SvgLength((float)(curCenterY - offsetK * Math.Cos(angle))));
                    pointM = new SvgPoint(
                        new SvgLength((float)(curCenterX - offsetM * Math.Sin(angle))),
                        new SvgLength((float)(curCenterY + offsetM * Math.Cos(angle))));

                    pointA = new SvgPoint(
                        new SvgLength((float)(curCenterX + curOffsetA2 * Math.Sin(angle))),
                        new SvgLength((float)(curCenterY - curOffsetA2 * Math.Cos(angle))));
                    pointC = new SvgPoint(
                        new SvgLength((float)(curCenterX + curOffsetC2 * Math.Sin(angle))),
                        new SvgLength((float)(curCenterY - curOffsetC2 * Math.Cos(angle))));

                    if (currentDictionary["Type"].Equals("Type3") && curOffsetB2 < 0)
                    {
                        pointA = new SvgPoint(
                            new SvgLength((float)(curCenterX - curOffsetC2 * Math.Sin(angle))),
                            new SvgLength((float)(curCenterY + curOffsetC2 * Math.Cos(angle))));
                        pointC = new SvgPoint(
                            new SvgLength((float)(curCenterX - curOffsetA2 * Math.Sin(angle))),
                            new SvgLength((float)(curCenterY + curOffsetA2 * Math.Cos(angle))));
                    }

                    pointD = curOffsetB2 > 0
                        ? new SvgPoint(new SvgLength(pointC.X.Value + curOffsetD2B), new SvgLength(pointC.Y.Value))
                        : new SvgPoint(new SvgLength(pointA.X.Value - curOffsetD2B), new SvgLength(pointA.Y.Value));
                }

                // Теперь вычислим значения для maxXValue и maxYValue
                curRight = Math.Max(pointCenter.X.Value,
                    Math.Max(pointA.X.Value,
                        Math.Max(pointB.X.Value,
                            Math.Max(pointC.X.Value,
                                Math.Max(pointM.X.Value, Math.Max(pointN.X.Value, pointK.X.Value))))));
                curBottom = Math.Max(pointCenter.Y.Value,
                    Math.Max(pointA.Y.Value,
                        Math.Max(pointB.Y.Value,
                            Math.Max(pointC.Y.Value,
                                Math.Max(pointM.Y.Value, Math.Max(pointN.Y.Value, pointK.Y.Value))))));

                if (currentDictionary["Type"].Equals("Type3") || currentDictionary["Type"].Equals("Type4"))
                {
                    curRight = Math.Max(curRight, pointD.X.Value);
                    curBottom = Math.Max(curBottom, pointD.Y.Value);
                }
            }

            // Если текстовая метка находится правее или ниже самой фигуры
            var curFontSize = float.Parse(currentDictionary["LabelFontSize"], CultureInfo.InvariantCulture);
            var labelX = float.Parse(currentDictionary["LabelPosition"].Split(",")[0], CultureInfo.InvariantCulture);
            var labelY = float.Parse(currentDictionary["LabelPosition"].Split(",")[1], CultureInfo.InvariantCulture);

            labelY += curFontSize * 1854f / 2048f;
            labelX += 0.87f * curFontSize * currentDictionary["Label"].Length;

            if (labelX > curRight)
            {
                curRight = labelX;
            }

            if (labelY > curBottom)
            {
                curBottom = labelY;
            }

            result.Add(curRight);
            result.Add(curBottom);

            return result;
        }
    }
}