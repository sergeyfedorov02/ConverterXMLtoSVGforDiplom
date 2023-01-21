using System;
using System.Drawing;

namespace SvgConverter
{
    internal static class GetColor
    {
        //Функция для конвертации строки с цветом в десятичную систему счисления в формате Argb
        public static Color ConvertArgb(string str)
        {
            var length = str.Length;
            var colorA = 255;
            var colorR = 0;
            var colorG = 0;
            var colorB = 0;

            switch (length)
            {
                // Если пришёл формат rgb
                case 7:
                    colorR = Convert.ToInt32(str.Substring(1, 2), 16);
                    colorG = Convert.ToInt32(str.Substring(3, 2), 16);
                    colorB = Convert.ToInt32(str.Substring(5, 2), 16);
                    break;
                // Если Argb
                case 9:
                    colorA = Convert.ToInt32(str.Substring(1, 2), 16);
                    colorR = Convert.ToInt32(str.Substring(3, 2), 16);
                    colorG = Convert.ToInt32(str.Substring(5, 2), 16);
                    colorB = Convert.ToInt32(str.Substring(7, 2), 16);
                    break;
            }

            // Если alfa = 0 - Прозрачный
            // Если alfa = 255 - НЕ прозрачный
            return Color.FromArgb(colorA, colorR, colorG, colorB);
        }
    }
}