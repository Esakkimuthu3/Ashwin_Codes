using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            for(int i =1 ; i<=10 ; i++)
            {
                Console.WriteLine($"Enter the Details of an Product {i}:");
                Console.WriteLine("Product Name: ");
                string prodname = Console.ReadLine();
                Console.WriteLine("Price of the Product: ");
                double price = Convert.ToDouble(Console.ReadLine());
                products.Add(new Product(i, prodname, price));
                Console.ReadLine();
            }
            products = products.OrderBy(p => p.PriceOfProduct).ToList();
            Console.WriteLine("\n" + " Sorted Products by Price: \n");
            foreach(var product in products)
            {
                Console.WriteLine($"Product Id: {product.ProdId} \n Product name: {product.ProdName} \n Product Price: {product.PriceOfProduct}");
                Console.ReadLine();
            }
        }
    }
    class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public double PriceOfProduct { get; set; }
        public Product(int prodid , string prodname, double price)
        {
            ProdId = prodid;
            ProdName = prodname;
            PriceOfProduct = price;
        }
    }
}
