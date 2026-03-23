using System;
using System.IO;

class DriveChecker
{
    public void Check()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();

        foreach (var d in drives)
        {
            if (!d.IsReady) continue;

            Console.WriteLine($"Drive: {d.Name}");
            Console.WriteLine($"Type: {d.DriveType}");
            Console.WriteLine($"Total: {d.TotalSize}");
            Console.WriteLine($"Free: {d.AvailableFreeSpace}");

            double freePercent = (double)d.AvailableFreeSpace / d.TotalSize * 100;

            if (freePercent < 15)
                Console.WriteLine("Warning: Low Disk Space");

            Console.WriteLine();
        }
    }
}