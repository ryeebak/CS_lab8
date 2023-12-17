using System;
using System.IO;
using System.IO.Compression;

class lab8task2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к папке, в которой нужно выполнить поиск:");
        string searchDirectory = Console.ReadLine();

        Console.WriteLine("Введите имя файла для поиска (с расширением, например, example.txt):");
        string targetFileName = Console.ReadLine();

        string[] files = Directory.GetFiles(searchDirectory, targetFileName, SearchOption.AllDirectories);

        if (files.Length == 0)
        {
            Console.WriteLine("Файл не найден.");
        }
        else
        {
            foreach (string filePath in files)
            {

                Console.WriteLine($"Найден файл: {filePath}");

                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string fileContent = reader.ReadToEnd();
                        Console.WriteLine($"Содержимое файла:\n{fileContent}");
                    }
                }
                string fileToZip = filePath;
                string outputFile = Path.ChangeExtension(filePath, ".zip");
                using (var archive = ZipFile.Open(outputFile, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(fileToZip, Path.GetFileName(fileToZip));
                }
                Console.WriteLine($"Файл сжат и сохранен как: {outputFile}");
            }
        }
    }
}
