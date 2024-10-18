using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            string filePath = "../../../Products.json";
            string workingPath = Path.GetFullPath(filePath);
            int id;
            string name;
            double price;
            Product[] products = new Product[n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите код товара:");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите наименование товара:");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите стоимость товара:");
                    price = Convert.ToDouble(Console.ReadLine());
                    products[i] = new Product()
                    {
                        Id = id,
                        Name = name,
                        Price = price
                    };
                }

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(products, options);

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(jsonString);
                }

                Console.WriteLine("Данные записаны в файл!");
                //откроет созданный файл в программе по умолчанию (так удобнее проверять, что записалось в файл :))
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = workingPath;
                    process.Start();
                    process.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oшибка!"+ex.Message);
            }
            Console.ReadKey();
        }
    }
}
