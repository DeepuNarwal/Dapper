using Dapper;
using Dapper.NetCore;
using Microsoft.Data.SqlClient;

namespace DapperExample
{
    class Program
    {
        private static string connectionString = "Server=DESKTOP-EI2CNGP\\SQLEXPRESS;Database=DapperExampleDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            GetAllProduct();
        }

        /// <summary>
        /// Get All Products from Table
        /// </summary>
        private static void GetAllProduct()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var products = connection.Query<Product>("SELECT * FROM Products").ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                }
                Console.WriteLine();
            }
        }

    }
}