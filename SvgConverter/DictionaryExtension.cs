using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using GrapeCity.Documents.Svg;

namespace SvgConverter
{
    internal static class DictionaryExtension
    {
        private const string DefaultWidth = "2";
        private const string DefaultObjectColor = "#FF000000";

        // Функция, в которой получаем значение атрибута по заданному key, если нет такого атрибута -> берем значение ""
        public static string GetValueOrDefault(this IReadOnlyDictionary<string, string> properties, string key,
            string defaultValue = "")
        {
            return properties.TryGetValue(key, out var result) ? result : defaultValue;
        }

        // Функция, в которой получаем значение атрибута "LineWidth", если нет такого атрибута -> берем значение DefaultWidth
        public static float GetLineWidth(this IReadOnlyDictionary<string, string> properties)
        {
            return float.Parse(properties.GetValueOrDefault("LineWidth", DefaultWidth), CultureInfo.InvariantCulture);
        }

        // Функция, в которой получаем значение атрибута "ObjectColor", если нет такого атрибута -> берем значение DefaultObjectColor
        public static Color GetObjectColor(this IReadOnlyDictionary<string, string> properties)
        {
            return GetColor.ConvertArgb(properties.GetValueOrDefault("ObjectColor", DefaultObjectColor));
        }

        // Функция для получения координат, если чего-то нет -> false
        public static bool TryGetBounds(this IReadOnlyDictionary<string, string> properties, out RectangleF rect)
        {
            rect = RectangleF.Empty;

            // Проверка атрибута "Left" из переданного Dictionary
            if (!properties.TryGetValue("Left", out var curLeftText)) return false;
            var curLeft = float.Parse(curLeftText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Right" из переданного Dictionary
            if (!properties.TryGetValue("Right", out var curRightText)) return false;
            var curRight = float.Parse(curRightText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Top" из переданного Dictionary
            if (!properties.TryGetValue("Top", out var curTopText)) return false;
            var curTop = float.Parse(curTopText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Bottom" из переданного Dictionary
            if (!properties.TryGetValue("Bottom", out var curBottomText)) return false;
            var curBottom = float.Parse(curBottomText, CultureInfo.InvariantCulture);

            // Если координаты поменяны места (рисовали из правого угла) -> надо изменить выходные значения
            if (curLeft > curRight)
            {
                (curLeft, curRight) = (curRight, curLeft);
            }

            if (curTop > curBottom)
            {
                (curTop, curBottom) = (curBottom, curTop);
            }


            rect = new RectangleF(curLeft, curTop, curRight - curLeft, curBottom - curTop);

            return true;
        }

        // Функция для получения координат для элемента "StandardLibrary.RailUnitEx", если чего-то нет -> false
        public static bool TryGetRailUnitBounds(this IReadOnlyDictionary<string, string> properties,
            out RectangleF rect)
        {
            rect = RectangleF.Empty;

            // Проверка атрибута "Start" из переданного Dictionary
            if (!properties.TryGetValue("Start", out var curStartText)) return false;
            var curLeft = float.Parse(curStartText.Split(",")[0], CultureInfo.InvariantCulture);
            var curTop = float.Parse(curStartText.Split(",")[1], CultureInfo.InvariantCulture);

            // Проверка атрибута "OffsetEnd" из переданного Dictionary
            if (!properties.TryGetValue("OffsetEnd", out var curOffsetEndText)) return false;
            var curWidth = float.Parse(curOffsetEndText, CultureInfo.InvariantCulture);

            // Если координаты поменяны места (рисовали справа налево) -> надо изменить выходные значения
            if (curLeft > curLeft + curWidth)
            {
                (curLeft, curWidth) = (curLeft + curWidth, -curWidth);
            }

            rect = new RectangleF(curLeft, curTop, curWidth, 0);

            return true;
        }

        // Функция для получения координат для элемента "StandardLibrary.RailUnitWithIntersection", если чего-то нет -> false
        public static bool TryGetRailUnitWithIntersectionBounds(this IReadOnlyDictionary<string, string> properties,
            out List<RectangleF> rectList)
        {
            rectList = new List<RectangleF>
            {
                RectangleF.Empty,
                RectangleF.Empty
            };

            // Проверка атрибута "Start" из переданного Dictionary
            if (!properties.TryGetValue("Start", out var curStartText)) return false;
            var curLeft = float.Parse(curStartText.Split(",")[0], CultureInfo.InvariantCulture);
            var curTop = float.Parse(curStartText.Split(",")[1], CultureInfo.InvariantCulture);

            // Проверка атрибута "OffsetIntervalStart" из переданного Dictionary
            if (!properties.TryGetValue("OffsetIntervalStart", out var curOffsetIntervalStartText)) return false;
            var curOffsetIntervalStart = float.Parse(curOffsetIntervalStartText, CultureInfo.InvariantCulture);

            // Проверка атрибута "IntervalLength" из переданного Dictionary
            if (!properties.TryGetValue("IntervalLength", out var curIntervalLengthText)) return false;
            var curIntervalLength = float.Parse(curIntervalLengthText, CultureInfo.InvariantCulture);

            // Проверка атрибута "OffsetIntervalEnd" из переданного Dictionary
            if (!properties.TryGetValue("OffsetIntervalEnd", out var curOffsetIntervalEndText)) return false;
            var curOffsetIntervalEnd = float.Parse(curOffsetIntervalEndText, CultureInfo.InvariantCulture);

            // Если координаты поменяны места (рисовали справа налево) -> надо изменить выходные значения
            // Start -> IntervalStart -> IntervalLength -> IntervalEnd
            if (curLeft > curLeft + curOffsetIntervalStart)
            {
                (curLeft, curOffsetIntervalStart, curIntervalLength, curOffsetIntervalEnd) = (
                    curLeft + curOffsetIntervalEnd + curIntervalLength + curOffsetIntervalEnd, -curOffsetIntervalEnd,
                    -curIntervalLength, -curOffsetIntervalEnd);
            }

            var rectFirst = new RectangleF(curLeft, curTop, curOffsetIntervalStart, 0);
            var rectSecond = new RectangleF(curLeft + curOffsetIntervalStart + curIntervalLength, curTop,
                curOffsetIntervalEnd, 0);

            rectList[0] = rectFirst;
            rectList[1] = rectSecond;

            return true;
        }

        // Функция для получения координат для элемента "StandardLibrary.IsoJoint", если чего-то нет -> false
        public static bool TryGetIsoJointBounds(this IReadOnlyDictionary<string, string> properties,
            out RectangleF rect)
        {
            rect = RectangleF.Empty;

            // Проверка атрибута "Left" из переданного Dictionary
            if (!properties.TryGetValue("Left", out var curLeftText)) return false;
            var curLeft = float.Parse(curLeftText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Top" из переданного Dictionary
            if (!properties.TryGetValue("Top", out var curTopText)) return false;
            var curTop = float.Parse(curTopText, CultureInfo.InvariantCulture);

            rect = new RectangleF(curLeft, curTop, 16, 16);

            return true;
        }

        // Функция для получения координат для элемента "StandardLibrary.RailTerminator", если чего-то нет -> false
        public static bool TryGetRailTerminatorBounds(this IReadOnlyDictionary<string, string> properties,
            out RectangleF rect)
        {
            rect = RectangleF.Empty;

            // Проверка атрибута "Left" из переданного Dictionary
            if (!properties.TryGetValue("Left", out var curLeftText)) return false;
            var curLeft = float.Parse(curLeftText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Top" из переданного Dictionary
            if (!properties.TryGetValue("Top", out var curTopText)) return false;
            var curTop = float.Parse(curTopText, CultureInfo.InvariantCulture);

            rect = new RectangleF(curLeft, curTop, 40, 16);

            return true;
        }

        // Функция для получения координат для элемента "StandardLibrary.JunctionSwitch" и "JunctionSwitchWithoutNoControl", если чего-то нет -> false
        public static bool TryGetJunctionSwitchBounds(this IReadOnlyDictionary<string, string> properties,
            out Dictionary<string, float> curProperties)
        {
            curProperties = new Dictionary<string, float>();

            // Проверка атрибута "LeftTop" из переданного Dictionary
            if (!properties.TryGetValue("LeftTop", out var curLeftTopText)) return false;
            var curLeft = float.Parse(curLeftTopText.Split(",")[0], CultureInfo.InvariantCulture);
            var curTop = float.Parse(curLeftTopText.Split(",")[1], CultureInfo.InvariantCulture);

            // Проверка атрибута "LampSize" из переданного Dictionary
            if (!properties.TryGetValue("LampSize", out var curLampSizeText)) return false;
            var curLampWidth = float.Parse(curLampSizeText.Split(",")[0], CultureInfo.InvariantCulture);
            var curLampHeight = float.Parse(curLampSizeText.Split(",")[1], CultureInfo.InvariantCulture);

            // Проверка атрибута "LampSpace" из переданного Dictionary
            if (!properties.TryGetValue("LampSpace", out var curLampSpaceText)) return false;
            var curLampSpace = float.Parse(curLampSpaceText, CultureInfo.InvariantCulture);

            // Проверка атрибута "RowSpace" из переданного Dictionary
            var curRowSpaceText = properties.TryGetValue("RowSpace", out var rowSpace) ? rowSpace : "-1.0";
            if (properties["ToolId"] != "StandardLibrary.JunctionSwitchWithoutNoControl" &&
                curRowSpaceText.Equals("-1.0")) return false;
            var curRowSpace = float.Parse(curRowSpaceText, CultureInfo.InvariantCulture);

            curProperties["curLeft"] = curLeft;
            curProperties["curTop"] = curTop;
            curProperties["curLampWidth"] = curLampWidth;
            curProperties["curLampHeight"] = curLampHeight;
            curProperties["curLampSpace"] = curLampSpace;
            curProperties["curRowSpace"] = curRowSpace;

            return true;
        }

        // Функция для получения координат для элемента "StandardLibrary.Semaphore", если чего-то нет -> false
        public static bool TryGetSemaphoreBounds(this IReadOnlyDictionary<string, string> properties,
            out RectangleF rect)
        {
            rect = RectangleF.Empty;

            // Проверка атрибута "Left" из переданного Dictionary
            if (!properties.TryGetValue("Left", out var curLeftText)) return false;
            var curLeft = float.Parse(curLeftText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Top" из переданного Dictionary
            if (!properties.TryGetValue("Top", out var curTopText)) return false;
            var curTop = float.Parse(curTopText, CultureInfo.InvariantCulture);

            rect = new RectangleF(curLeft, curTop, 0, 0);

            return true;
        }

        // Функция для получения координат для элемента "StandardLibrary.RailJunction", если чего-то нет -> false
        public static bool TryGetRailJunctionBounds(this IReadOnlyDictionary<string, string> properties,
            out Dictionary<string, float> curProperties)
        {
            curProperties = new Dictionary<string, float>();

            // Проверка атрибута "CenterPoint" из переданного Dictionary
            if (!properties.TryGetValue("CenterPoint", out var curCenterPointTopText)) return false;
            var curCenterX = float.Parse(curCenterPointTopText.Split(",")[0], CultureInfo.InvariantCulture);
            var curCenterY = float.Parse(curCenterPointTopText.Split(",")[1], CultureInfo.InvariantCulture);

            // Проверка атрибута "OffsetA2Center" из переданного Dictionary
            if (!properties.TryGetValue("OffsetA2Center", out var curOffsetA2Text)) return false;
            var curOffsetA2 = float.Parse(curOffsetA2Text, CultureInfo.InvariantCulture);

            // Проверка атрибута "OffsetC2Center" из переданного Dictionary
            if (!properties.TryGetValue("OffsetC2Center", out var curOffsetC2Text)) return false;
            var curOffsetC2 = float.Parse(curOffsetC2Text, CultureInfo.InvariantCulture);

            // Проверка атрибута "OffsetB2Center" из переданного Dictionary
            if (!properties.TryGetValue("OffsetB2Center", out var curOffsetB2Text)) return false;
            var curOffsetB2 = float.Parse(curOffsetB2Text, CultureInfo.InvariantCulture);

            // Проверка атрибута "OffsetB2Center" из переданного Dictionary
            if (!properties.TryGetValue("OffsetD2B", out var curOffsetD2BText)) return false;
            var curOffsetD2B = float.Parse(curOffsetD2BText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Angle" из переданного Dictionary
            if (!properties.TryGetValue("Angle", out var curAngleText)) return false;
            var curAngle = float.Parse(curAngleText, CultureInfo.InvariantCulture);

            curProperties["curCenterX"] = curCenterX;
            curProperties["curCenterY"] = curCenterY;
            curProperties["curOffsetA2"] = curOffsetA2;
            curProperties["curOffsetC2"] = curOffsetC2;
            curProperties["curOffsetB2"] = curOffsetB2;
            curProperties["curOffsetD2B"] = curOffsetD2B;
            curProperties["curAngle"] = curAngle;

            return true;
        }

        // Функция для получения координат для элемента "StandardLibrary.Measure", если чего-то нет -> false
        public static bool TryGetMeasureBounds(this IReadOnlyDictionary<string, string> properties,
            out RectangleF rect)
        {
            rect = RectangleF.Empty;

            // Проверка атрибута "Left" из переданного Dictionary
            if (!properties.TryGetValue("Left", out var curLeftText)) return false;
            var curLeft = float.Parse(curLeftText, CultureInfo.InvariantCulture);

            // Проверка атрибута "Top" из переданного Dictionary
            if (!properties.TryGetValue("Top", out var curTopText)) return false;
            var curTop = float.Parse(curTopText, CultureInfo.InvariantCulture);

            rect = new RectangleF(curLeft, curTop, 0, 0);

            return true;
        }

        // Функция для добавления стандартных кастомных атрибутов к группе в начале работы
        public static SvgGroupElement AddStandardStartResultAttributes(this IReadOnlyDictionary<string, string> xmlNode,
            string aShape, string aDrawBorder, string railCrossingType, string semaphoreHint,
            ISvgConvertOptions options)
        {
            var curResult = new SvgGroupElement
            {
                CustomAttributes = new List<SvgCustomAttribute>()
            };

            // Если присутствует атрибут "Shape" -> добавим кастомный атрибут data-object-hint = "Shape=..,DrawBorder=..."
            if (aShape != null)
            {
                curResult.CustomAttributes.Add
                (
                    new SvgCustomAttribute("data-object-hint",
                        "Shape=" + aShape + ",DrawBorder=" + aDrawBorder)
                );
            }

            // Если рассматриваем переезд -> есть три разных RailCrossingType
            if (railCrossingType != null)
            {
                curResult.CustomAttributes.Add
                (
                    new SvgCustomAttribute("data-object-hint",
                        "RailCrossingType=" + railCrossingType)
                );
            }

            // Если рассматриваем светофор -> есть несколько вариаций светофора
            if (semaphoreHint != null)
            {
                var curSemaphoreHint = semaphoreHint.Split(",");
                curResult.CustomAttributes.Add
                (
                    new SvgCustomAttribute("data-object-hint",
                        "SemaphoreType=" + curSemaphoreHint[0] + ",LegType=" + curSemaphoreHint[1] + ",LampShape=" +
                        curSemaphoreHint[2])
                );
            }

            // Если рассматриваем стрелочную секцию -> stroke-width="4" + fill-opacity="0" + data-isInverse="true/false"+
            // data-object-hint="Type=Type1/2/3/4, IsInverse=True/False"
            if (xmlNode["ToolId"] == "StandardLibrary.RailJunctionEx")
            {
                // stroke-width="4"
                curResult.CustomAttributes.Add
                (
                    new SvgCustomAttribute("stroke-width",
                        "4")
                );

                // fill-opacity="0"
                curResult.CustomAttributes.Add
                (
                    new SvgCustomAttribute("fill-opacity",
                        "0")
                );

                // data-isInverse="true/false"
                curResult.CustomAttributes.Add
                (
                    new SvgCustomAttribute("data-isInverse",
                        xmlNode["IsInverse"].ToLower())
                );

                // data-object-hint="Type=Type1/2/3/4, IsInverse=True/False"
                curResult.CustomAttributes.Add
                (
                    new SvgCustomAttribute("data-object-hint",
                        "Type=" + xmlNode["Type"] + ",IsInverse=" + xmlNode["IsInverse"])
                );
            }

            // Добавление кастомного атрибута data-object-type = "StandardLibrary.RailUnitEx" (имя этого атрибута - Рельсовая единица)
            curResult.CustomAttributes.Add
            (
                new SvgCustomAttribute("data-object-type", xmlNode["ToolId"])
            );

            // Добавление кастомного атрибута data-state = "-2" к создаваемой группе, чтобы потом была подсветка, если придет значение
            curResult.CustomAttributes.Add
            (
                new SvgCustomAttribute("data-state", "-2")
            );

            // Если указан ClientId
            if (xmlNode.TryGetValue("ClientId", out var objectId) && objectId != "0")
            {
                // Обновление data-state
                var dataStateAttribute =
                    curResult.CustomAttributes.Find(attribute => attribute.AttributeName == "data-state");
                dataStateAttribute.Value = "-1";
                // Добавление data-object-id
                curResult.CustomAttributes.Add(new SvgCustomAttribute("data-object-id", objectId));

                // Добавление Опций, если они есть
                if (options.AddTitles)
                {
                    var title = options.GetTitleForObject(long.Parse(objectId));
                    if (!string.IsNullOrEmpty(title))
                    {
                        curResult.Children.Add(new SvgTitleElement
                            { Children = { new SvgContentElement { Content = title } } });
                    }
                }
            }

            return curResult;
        }

        // Функция для добавления стандартных кастомных атрибутов к группе в конце работы
        public static void AddStandardEndResultAttributes(SvgElement curElement, SvgElement curResult,
            IReadOnlyDictionary<string, string> xmlNode, float curLeft, float curRight, float curTop, float curBottom,
            bool addAngle)
        {
            // Добавим угол поворота, если он есть
            if (addAngle)
            {
                curElement.AddAngle(xmlNode, curLeft, curRight, curTop, curBottom);
            }

            // Добавим полученный элемент в result
            curResult.Children.Add(curElement);

            // Если надо отображать текст, то добавим его в result
            if (CreateText.IsShouldDrawLabel(xmlNode["ShouldDrawLabel"]))
            {
                // Добавляем созданный текст
                curResult.Children.Add(CreateText.AddSvgTextElement(xmlNode, xmlNode["Label"]));
            }
        }
    }
}