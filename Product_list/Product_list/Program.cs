using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Product_list
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Göra testprojekt som testar metoderna, tex valideringsmetoden =) 
            // Lägga till skriva med röd text osv, bonus

            List<string> productList = AskUserForProducts();
            List<string> sortedProductList = SortList(productList);
            PrintProducts(sortedProductList);
        }

        private static List<string> SortList(List<string> productList)
        {
            productList.Sort();
            return productList;
        }

        private static List<string> AskUserForProducts()
        {
            List<string> productList = new List<string>();

            Console.WriteLine("Enter products. End by writing 'exit'\n");

            while (true)
            {
                Console.Write("Enter product: ");
                string product = Console.ReadLine();

                if (product.ToLower().Trim() == "exit")
                    break;

                bool isValid = CheckIfNameIsValid(product);
                if (isValid == false)
                {
                    continue;
                }
                productList.Add(product);
            }

            return productList;
        }

        private static bool CheckIfNameIsValid(string product)
        {

            if (product.Trim().Length == 0)
            {
                Console.WriteLine("You cannot enter an empty value");
                return false;
            }

            try
            {
                string[] productName = product.Split("-");

                if (!Regex.IsMatch(productName[0], @"^[a-zåäö]+$", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Wrong format on the left side of the product name");
                    return false;
                }
                else if (int.Parse(productName[1]) < 200 || int.Parse(productName[1]) > 500)
                {
                    Console.WriteLine("Wrong format on the right side of the product name");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        private static void PrintProducts(List<string> productList)
        {
            Console.WriteLine("\nYou entered the following products: \n");
            foreach (var product in productList)
            {
                Console.WriteLine($"* {product}");
            }

            Console.WriteLine();
        }
    }
}
