using System;
using System.Reflection.Metadata;

class Program
{
    static void Main()
    {
        //RunLogWriter();
        //RunFileDetails();
        //RunEmployee();
        //RunDirectory();
        RunDrive();
    }

    static void RunLogWriter()
    {
        LogWriter obj = new LogWriter();
        obj.WriteLog();
    }

    static void RunFileDetails()
    {
        FileDetails obj = new FileDetails();
        obj.ShowFiles();
    }

    static void RunEmployee()
    {
        EmployeePerformance obj = new EmployeePerformance();
        obj.Evaluate();
    }

    static void RunDirectory()
    {
        DirectoryAnalyzer obj = new DirectoryAnalyzer();
        obj.Analyze();
    }

    static void RunDrive()
    {
        DriveChecker obj = new DriveChecker();
        obj.Check();
    }
}