
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };

        }
    }
    class program2
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            Console.WriteLine("1. FMCG Products");
            var q1 = from p in products
                     where p.ProCategory == "FMCG"
                     select p;
            foreach (var i in q1)
                Console.WriteLine($"{i.ProCode} {i.ProName} {i.ProMrp}");

            Console.WriteLine("\n2. Grain Products");
            var q2 = from p in products
                     where p.ProCategory == "Grain"
                     select p;
            foreach (var i in q2)
                Console.WriteLine($"{i.ProCode} {i.ProName} {i.ProMrp}");

            Console.WriteLine("\n3. Sort by Product Code in Asc Order");
            var q3 = from p in products
                     orderby p.ProCode
                     select p;
            foreach (var i in q3)
                Console.WriteLine($"{i.ProCode} {i.ProName}");

            // 4
            Console.WriteLine("\n4. Sort by Category in Asc order");
            var q4 = from p in products
                     orderby p.ProCategory
                     select p;
            foreach (var i in q4)
                Console.WriteLine($"{i.ProCategory} {i.ProName}");

            // 5
            Console.WriteLine("\n5. Sort by MRP in ASC");
            var q5 = from p in products
                     orderby p.ProMrp
                     select p;
            foreach (var i in q5)
                Console.WriteLine($ "{i.ProName} {i.ProMrp}");

            // 6
            Console.WriteLine("\n6. Sort by MRP in DESC");
            var q6 = from p in products
                     orderby p.ProMrp descending
                     select p;
            foreach (var i in q6)
                Console.WriteLine($"{i.ProName} {i.ProMrp}");

            // 7
            Console.WriteLine("\n7. Group by Category");
            var q7 = from p in products
                     group p by p.ProCategory;
            foreach (var g in q7)
            {
                Console.WriteLine($"Category: {g.Key}");
                foreach (var i in g)
                    Console.WriteLine(i.ProName);
            }

            // 8
            Console.WriteLine("\n8. Group by MRP");
            var q8 = products.GroupBy(p => p.ProMrp);
            foreach (var g in q8)
            {
                Console.WriteLine($"MRP: {g.Key}");
                foreach (var i in g)
                    Console.WriteLine(i.ProName);
            }

            // 9
            Console.WriteLine("\n9. Highest Price Product in FMCG");
            var q9 = products.Where(p => p.ProCategory == "FMCG")
                             .OrderByDescending(p => p.ProMrp)
                             .First();
            Console.WriteLine($"{q9.ProName} {q9.ProMrp}");

            // 10
            Console.WriteLine("\n10. Total Products Count");
            Console.WriteLine(products.Count());

            // 11
            Console.WriteLine("\n11. FMCG Products Count");
            Console.WriteLine(products.Count(p => p.ProCategory == "FMCG"));

            // 12
            Console.WriteLine("\n12. Maximum Price");
            Console.WriteLine(products.Max(p => p.ProMrp));

            // 13
            Console.WriteLine("\n13. Minimum Price");
            Console.WriteLine(products.Min(p => p.ProMrp));

            // 14
            Console.WriteLine("\n14. All Products Below 30?");
            Console.WriteLine(products.All(p => p.ProMrp < 30));

            // 15
            Console.WriteLine("\n15. Any Product Below 30?");
            Console.WriteLine(products.Any(p => p.ProMrp < 30));

            Console.ReadLine();
        }
    }
}