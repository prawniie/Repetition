using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Product_list_TestProject
{
    public class ValidInput
    {

        public bool CheckIfInputIsValid(string product)
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

        public bool CheckIfInputIsValid2(string product)
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
                else if (int.TryParse(productName[1], out x) == false)
                {
                    Console.WriteLine("Wrong format on the right side of the product name");
                    return false;
                }
                else if (int.TryParse(productName[1], out x) == true)
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
            catch (IndexOutOfRangeException)
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

    }
}
