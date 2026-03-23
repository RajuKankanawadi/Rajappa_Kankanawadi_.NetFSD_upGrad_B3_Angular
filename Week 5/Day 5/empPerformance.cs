using System;

class EmployeePerformance
{
    public (double, int) GetData(double sales, int rating)
    {
        return (sales, rating);
    }

    public void Evaluate()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Sales: ");
        double sales = double.Parse(Console.ReadLine());

        Console.Write("Enter Rating: ");
        int rating = int.Parse(Console.ReadLine());

        var result = GetData(sales, rating);

        string performance = result switch
        {
            ( >= 100000, >= 4) => "High Performer",
            ( >= 50000, >= 3) => "Average Performer",
            _ => "Needs Improvement"
        };

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Sales: {sales}");
        Console.WriteLine($"Rating: {rating}");
        Console.WriteLine($"Performance: {performance}");
    }
}