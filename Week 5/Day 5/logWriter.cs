using System;
using System.IO;
using System.Text;

class LogWriter
{
    public void WriteLog()
    {
        string folder = @"D:\Upgrad\Week 5\Day 5\HandsOn";

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string path = folder + "\\log.txt";

        Console.Write("Enter message: ");
        string msg = Console.ReadLine();

        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                byte[] data = Encoding.UTF8.GetBytes(msg + Environment.NewLine);
                fs.Write(data, 0, data.Length);
            }

            Console.WriteLine("Message written successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}