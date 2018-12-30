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

            Console.ReadLine();
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
                int x = 0;

                if (!Regex.IsMatch(productName[0], @"^[a-zåäö]+$", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Wrong format on the left side of the product name");
                    return false;
                }
                else if (!int.TryParse(productName[1], out x))
                {
                    Console.WriteLine("Wrong format on the right side of the product name");
                    return false;
                }
                else if (int.TryParse(productName[1], out x))
                {
                    if (x < 200 || x > 500)
                    {
                        Console.WriteLine("The number must be between 200 and 500");
                        return false;
                    }

                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("You have to enter a product name with letters followed by a '-' followed by digits.");
                return false;
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

            if (productList.Count == 0)
            {
                Console.WriteLine("Oh no! There doesn't seem to be any products in the list.");
            }

            foreach (var product in productList)
            {
                Console.WriteLine($"* {product}");
            }

            Console.WriteLine();
        }
    }
}
