using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using SvgConverter;

namespace Diploma_Project
{
    public static class TestConsole
    {
        public static void Main(string[] args)
        {
            // Устанавливаем кодировку Console.
            // Нужно только если при использовании англоязычной Windows
            // на консоль вместо кириллицы выводятся знаки вопроса (??? ????? ??????)
            Console.OutputEncoding = Encoding.Unicode;

            // путь к архиву
            const string archivePath = @"D:\Imsat\project_24_4287.zip";

            // Console выбор нужного файла при помощи ввода его номера
            //Console.Write("Введите номер интересующего файла: ");
            //int chr_number = Convert.ToInt32(Console.ReadLine());

            // открытие архива в режиме чтения
            using var zipArchive = ZipFile.OpenRead(archivePath);
            
            // проход циклом всех сущностей в архиве
            foreach (var entry in zipArchive.Entries)
            {
                const string pattern = @"^chart_\d{1,}.chr$";
                var rg = new Regex(pattern);

                // Пройдемся по всем файлам с данными
                if (rg.IsMatch(entry.FullName) && entry.FullName.Equals("chart_0.chr"))
                {
                    // открываем этот файл
                    using var stream = entry.Open();
                    
                    //Открываем поток для чтения
                    using var sr = new StreamReader(stream, Encoding.UTF8);

                    // Получим результат конвертации
                    var convertResult = Converter.FromXml(sr.ReadToEnd(), null);
                    
                    // Сохраним получившийся SVG файл
                    var curName = entry.FullName.Split(".")[0];
                    var path = "D:\\RiderProjects\\Diploma_Project\\SvgConverter\\src\\" +
                               curName + ".svg";
                            
                    using var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    using var sw = new StreamWriter(fs, Encoding.UTF8);
                    sw.Write(convertResult);
                }
            }
        }
    }
}