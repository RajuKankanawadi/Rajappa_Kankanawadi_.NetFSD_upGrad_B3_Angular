using System;
using System.Collections.Generic;
using W6_D2_C_TODBconnection;

class Program
{
    static void Main()
    {
        ProductDAL dal = new ProductDAL();

        while (true)
        {
            Console.WriteLine("\n===== PRODUCT MANAGEMENT =====");
            Console.WriteLine("1. Insert Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Product p = new Product();

                        Console.Write("Name: ");
                        p.ProductName = Console.ReadLine();

                        Console.Write("Category: ");
                        p.Category = Console.ReadLine();

                        Console.Write("Price: ");
                        string priceInput = Console.ReadLine();
                        p.Price = string.IsNullOrEmpty(priceInput) ? null : decimal.Parse(priceInput);

                        Console.Write("Stock: ");
                        string stockInput = Console.ReadLine();
                        p.Stock = string.IsNullOrEmpty(stockInput) ? null : int.Parse(stockInput);

                        dal.InsertProduct(p);
                        Console.WriteLine("Inserted Successfully");
                        break;

                    case 2:
                        List<Product> list = dal.GetAllProducts();

                        foreach (var item in list)
                        {
                            Console.WriteLine($"{item.ProductId} | {item.ProductName} | {item.Category} | {item.Price} | {item.Stock}");
                        }
                        break;

                    case 3:
                        Product up = new Product();

                        Console.Write("Enter ID: ");
                        up.ProductId = int.Parse(Console.ReadLine());

                        Console.Write("New Name: ");
                        up.ProductName = Console.ReadLine();

                        Console.Write("New Category: ");
                        up.Category = Console.ReadLine();

                        Console.Write("New Price: ");
                        up.Price = decimal.Parse(Console.ReadLine());

                        Console.Write("New Stock: ");
                        up.Stock = int.Parse(Console.ReadLine());

                        dal.UpdateProduct(up);
                        Console.WriteLine("Updated Successfully");
                        break;

                    case 4:
                        Console.Write("Enter ID to delete: ");
                        int id = int.Parse(Console.ReadLine());

                        dal.DeleteProduct(id);
                        Console.WriteLine("Deleted Successfully");
                        break;

                    case 5:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
