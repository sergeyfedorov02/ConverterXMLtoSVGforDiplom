using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class PictureTest
    {
        private const string PictureName = "StandardLibrary.Picture";

        [Test]
        public void EmptyPictureBoundsTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Picture.emptyLeft.chr", PictureName);
            currentGroup.Should().BeNull();

            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Picture.emptyRight.chr", PictureName);
            currentGroup.Should().BeNull();
            
            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Picture.emptyTop.chr", PictureName);
            currentGroup.Should().BeNull();
            
            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Picture.emptyBottom.chr", PictureName);
            currentGroup.Should().BeNull();
            
            (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Picture.emptyPicture.chr", PictureName);
            currentGroup.Should().BeNull();
        }
        
        [Test]
        public void ErrorPicturePropertiesTest()
        {
            var (currentGroup, _) =
                StandardFunctions.GetCurrentGroup("Picture.errorFormat.chr", PictureName);
            currentGroup.Should().BeNull();
        }

        [Test]
        public void PictureJpegTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Picture.pictureJpeg.chr", PictureName);
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
            var imageElement = currentGroup.SelectSingleNode("x:image", ns);
            imageElement.Should().NotBeNull();
            imageElement!.Attributes.Should().NotBeNull();
            imageElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-348.906 3809.57,1580.815)");
            imageElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3735.29");
            imageElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1520.815");
            imageElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("148.5715");
            imageElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("120");
            imageElement!.Attributes!.GetNamedItem("href")!.Value.Should().NotBeNull();

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Изображение ");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3739.64");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1482.188");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
        
        [Test]
        public void PicturePngTest()
        {
            var (currentGroup, ns) =
                StandardFunctions.GetCurrentGroup("Picture.picturePng.chr", PictureName);
            currentGroup.Should().NotBeNull();
       
            var attributes = currentGroup!.Attributes;
            attributes.Should().NotBeNull();
            attributes!.Count.Should().Be(2);

            var dataState = attributes!.GetNamedItem("data-state")!.Value;
            dataState.Should().NotBeNull();
            dataState.Should().Be("-2");
            
            currentGroup.ChildNodes.Count.Should().Be(2);

            var imageElement = currentGroup.SelectSingleNode("x:image", ns);
            imageElement.Should().NotBeNull();
            imageElement!.Attributes.Should().NotBeNull();
            imageElement!.Attributes!.GetNamedItem("transform")!.Value.Should().Be("rotate(-348.906 3809.57,1580.815)");
            imageElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3735.29");
            imageElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1520.815");
            imageElement!.Attributes!.GetNamedItem("width")!.Value.Should().Be("148.5715");
            imageElement!.Attributes!.GetNamedItem("height")!.Value.Should().Be("120");
            imageElement!.Attributes!.GetNamedItem("href")!.Value.Should().NotBeNull();

            var textElement = currentGroup.SelectSingleNode("x:text", ns);
            textElement.Should().NotBeNull();
            textElement!.InnerText.Should().Be("Изображение ");
            textElement!.Attributes.Should().NotBeNull();
            textElement!.Attributes!.GetNamedItem("x")!.Value.Should().Be("3739.64");
            textElement!.Attributes!.GetNamedItem("y")!.Value.Should().Be("1482.188");
            textElement!.Attributes!.GetNamedItem("font-size")!.Value.Should().Be("22");
            textElement!.Attributes!.GetNamedItem("text-anchor")!.Value.Should().Be("start");
            textElement!.Attributes!.GetNamedItem("fill")!.Value.Should().Be("#000");
            textElement!.Attributes!.GetNamedItem("fill-opacity")!.Value.Should().Be("1");
            textElement!.Attributes!.GetNamedItem("stroke-width")!.Value.Should().Be("0");
        }
    }
}