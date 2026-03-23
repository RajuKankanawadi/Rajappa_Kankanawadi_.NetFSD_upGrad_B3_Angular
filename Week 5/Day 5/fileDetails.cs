using System;
using System.IO;

class FileDetails
{
    public void ShowFiles()
    {
        Console.Write("Enter folder path: ");
        string path = Console.ReadLine();

        try
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Exists)
            {
                Console.WriteLine("Invalid path");
                return;
            }

            FileInfo[] files = dir.GetFiles();

            foreach (var f in files)
            {
                Console.WriteLine($"{f.Name} {f.Length} {f.CreationTime}");
            }

            Console.WriteLine("Total Files: " + files.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}