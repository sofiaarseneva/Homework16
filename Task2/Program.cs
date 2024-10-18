using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            string filePath = "../../../Products.json";

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    jsonString = sr.ReadToEnd();
                }

                Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
                Product maxPriced = products[0];

                foreach (Product product in products)
                {
                    if (product.Price > maxPriced.Price)
                    {
                        maxPriced = product;
                    }
                }
                Console.WriteLine($"Самый дорогой товар - {maxPriced.Name}. Его стоимость {maxPriced.Price} единиц.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка!" + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
