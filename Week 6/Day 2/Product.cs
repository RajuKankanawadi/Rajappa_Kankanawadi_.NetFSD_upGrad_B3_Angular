using System;
using System.Collections.Generic;
using System.Text;

namespace W6_D2_C_TODBconnection
{ 
        class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public decimal? Price { get; set; }
            public int? Stock { get; set; }
        }
    }

