using System;
using System.IO;

class DirectoryAnalyzer
{
    public void Analyze()
    {
        Console.Write("Enter root path: ");
        string path = Console.ReadLine();

        try
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Exists)
            {
                Console.WriteLine("Invalid path");
                return;
            }

            var dirs = dir.GetDirectories();

            foreach (var d in dirs)
            {
                Console.WriteLine(d.Name);
                Console.WriteLine("Files: " + d.GetFiles().Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}