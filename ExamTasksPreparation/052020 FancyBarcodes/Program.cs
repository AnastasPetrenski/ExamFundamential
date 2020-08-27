using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _052020_FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"@#+([A-Z][A-Za-z0-9]{4,})[A-Z]@#+");
            Regex digit = new Regex(@"\d");
            int productsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < productsNumber; i++)
            {
                var product = pattern.Match(Console.ReadLine());
                if (product.Success)
                {
                    var group = product.Value;
                    StringBuilder result = new StringBuilder();
                    for (int j = 0; j < group.Length; j++)
                    {
                        if (char.IsDigit(group[j]))
                        {
                            result.Append((char)group[j]);
                        }
                    }

                    if (result.Length > 0)
                    {
                        Console.WriteLine($"Product group: {result.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
