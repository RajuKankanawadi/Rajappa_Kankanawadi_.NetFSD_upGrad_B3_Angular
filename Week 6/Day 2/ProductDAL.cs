using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace W6_D2_C_TODBconnection
{
    class ProductDAL
    {
        private string connStr;

        public ProductDAL()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",optional: false, reloadOnChange: true)
                .Build();

            connStr = config.GetConnectionString("DefaultConnection");
        }

        // INSERT
        public void InsertProduct(Product p)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Price", p.Price ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Stock", p.Stock ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();

                    p.ProductId = reader.GetInt32(0);
                    p.ProductName = reader.GetString(1);
                    p.Category = reader.GetString(2);

                    p.Price = reader.IsDBNull(3) ? null : reader.GetDecimal(3);
                    p.Stock = reader.IsDBNull(4) ? null : reader.GetInt32(4);

                    list.Add(p);
                }

                reader.Close();
            }

            return list;
        }

        // UPDATE
        public void UpdateProduct(Product p)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", p.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Price", p.Price ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Stock", p.Stock ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteProduct(int id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
