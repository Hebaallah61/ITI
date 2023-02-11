using D10;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static D10.ListGenerators;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Restriction Operators
            /*
             LINQ - Restriction Operators
            */

            //1. Find all products that are out of stock.
            var p1 = ProductList.Where(p => p.UnitsInStock == 0);
            foreach (var item in p1) { Console.WriteLine(item); }

            //2. Find all products that are in stock and cost more than 3.00 per unit.
            var p2 = ProductList.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3);
            foreach (var item in p2) { Console.WriteLine(item); }

            //3. Returns digits whose name is shorter than their value.
            string[] Arr1 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var n1 = Arr1.Where((name, index) => (name.Length < index));
            foreach (var item in n1) { Console.WriteLine(item); }
            #endregion

            #region Element Operators 
            /*
             LINQ - Element Operators                  
             */

            //1. Get first Product out of Stock 
            var r1 = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine(r1);

            // 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var r2 = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(r2?.ProductName ?? "NA");

            //3.Retrieve the second number greater than 5
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var r3 = Arr2.Where(x => x > 5).ElementAtOrDefault(1);
            Console.WriteLine(r3);
            #endregion

            #region Set Operators
            /*
             LINQ - Set Operators
             */

            // 1. Find the unique Category names from Product List
            var r4 = ProductList.Select(p => p.Category).Distinct();
            foreach (var r in r4) { Console.WriteLine(r); }

            // 2. Produce a Sequence containing the unique first letter from both product and customer names.
            var r5_1 = ProductList.Select(p => p.ProductName).Select(p => p.ElementAtOrDefault(0)).Distinct();
            var r5_2 = CustomerList.Select(p => p.CustomerID).Select(p => p.ElementAtOrDefault(0)).Distinct();
            r5_1 = r5_1.Concat(r5_2);
            foreach (var r in r5_1) { Console.WriteLine(r); }

            // 3. Create one sequence that contains the common first letter from both product and customer names.
            var r6_1 = ProductList.Select(p => p.ProductName).Select(p => p.ElementAtOrDefault(0));
            var r6_2 = CustomerList.Select(p => p.CustomerID).Select(p => p.ElementAtOrDefault(0));
            r6_1 = r6_1.Intersect(r6_2);
            foreach (var r in r6_1) { Console.WriteLine(r); }

            // 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var r7_1 = ProductList.Select(p => p.ProductName).Select(p => p.ElementAtOrDefault(0));
            var r7_2 = CustomerList.Select(p => p.CustomerID).Select(p => p.ElementAtOrDefault(0));
            r7_1 = r7_1.Except(r7_2);
            foreach (var r in r7_1) { Console.WriteLine(r); }

            //5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
            var r8_1 = ProductList.Select(p => p.ProductName).Select(p => p.Substring(p.Length - 3));
            var r8_2 = CustomerList.Select(p => p.CustomerID).Select(p => p.Substring(p.Length - 3));
            r8_1 = r8_1.Concat(r8_2);
            foreach (var r in r8_1) { Console.WriteLine(r); }
            #endregion

            #region Aggregate Operators
            /*
             LINQ - Aggregate Operators
             */

            //1. Uses Count to get the number of odd numbers in the array
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var r9 = Arr3.Count(num => num % 2 != 0);
            Console.WriteLine(r9);

            //2. Return a list of customers and how many orders each has.
            var r10 = CustomerList.Select(cst => new { Customer_ID = cst.CustomerID, Ords_num = cst.Orders.Length });
            foreach (var item in r10) { Console.WriteLine(item); }

            //3. Return a list of categories and how many products each has
            var r11 = from p in ProductList
                      group p by p.Category
                    into cat_
                      select new { Category = cat_.Key, Prod_num = cat_.Count() };
            foreach (var item in r11) { Console.WriteLine(item); }

            //4. Get the total of the numbers in an array.
            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var r12 = Arr4.Sum();
            Console.WriteLine(r12);

            //5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).            
            int totalCharacters = 0;
            List<string> words1 = new(File.ReadAllLines("E:\\CS problem solving\\c#pd_heba\\wpf\\Day10\\task1\\dictionary_english.txt"));
            foreach (string word in words1)
            {
                totalCharacters += word.Length;
            }
            int totalCharCount = words1.Select(x => x.Length).Sum();
            Console.WriteLine(totalCharCount);

            //6. Get the total units in stock for each product category.
            var r13 = from p in ProductList
                      group p by p.Category
                   into cat_
                      select new { Category = cat_.Key, Prodstock_num = cat_.Sum(e => e.UnitsInStock) };
            foreach (var item in r13) { Console.WriteLine(item); }

            //7.Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            var l_shortest_word = words1.Min(p => p.Length);
            Console.WriteLine(l_shortest_word);

            //8. Get the cheapest price among each category's products
            var r14 = from p in ProductList
                      group p by p.Category
                    into cat_
                      select new { Category = cat_.Key, Cheap_Price = cat_.Min(p => p.UnitPrice) };
            foreach (var item in r14) { Console.WriteLine(item); }

            //9. Get the products with the cheapest price in each category (Use Let)
            var r15 = from p in ProductList
                      group p by p.Category into cat_
                      let cheapestProducts = cat_.Aggregate((p1, p2) => (p1.UnitPrice < p2.UnitPrice) ? p1 : p2)
                      select new { Category = cat_.Key, Product_Name = cheapestProducts.ProductName, cheapestPrice = cheapestProducts.UnitPrice };
            foreach (var p in r15)
            {
                Console.WriteLine(p);
            }
            //for me
            /*  var cheapestProducts = new Dictionary<string, Product>();

              ProductList.GroupBy(p => p.Category)
                     .ToList()
                     .ForEach(g => 
                          cheapestProducts.Add(g.Key, g.OrderBy(p => p.UnitPrice).FirstOrDefault())
                     );

              foreach (var product in cheapestProducts)
              {
                  Console.WriteLine($"Category: {product.Key}/ Price:{product.Value.UnitPrice}/ Product: {product.Value.ProductName}");

              }*/

            //10.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            List<string> words2 = new(File.ReadAllLines("E:\\CS problem solving\\c#pd_heba\\wpf\\Day10\\task1\\dictionary_english.txt"));
            int l_longest_word = words2.Max(x => x.Length);
            Console.WriteLine(l_longest_word);

            //11. Get the most expensive price among each category's products.
            var r16 = from p in ProductList
                      group p by p.Category
                    into cat_
                      select new { Category = cat_.Key, Cheap_Price = cat_.Max(p => p.UnitPrice) };
            foreach (var item in r16) { Console.WriteLine(item); }

            //12. Get the products with the most expensive price in each category.
            var r17 = from p in ProductList
                      group p by p.Category into cat_
                      let mostExpensive = cat_.Aggregate((p1, p2) => (p1.UnitPrice > p2.UnitPrice) ? p1 : p2)
                      select new { Category = cat_.Key, Product_Name = mostExpensive.ProductName, MostExpensivePrice = mostExpensive.UnitPrice };

            foreach (var p in r17)
            {
                Console.WriteLine(p);
            }

            //13.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            List<string> words3 = new(File.ReadAllLines("E:\\CS problem solving\\c#pd_heba\\wpf\\Day10\\task1\\dictionary_english.txt"));
            var avg_word_len = words3.Average(word => word.Length);
            Console.WriteLine(avg_word_len);

            //14. Get the average price of each category's products.
            var r18 = from p in ProductList
                      group p by p.Category
                    into cat_
                      select new { Category = cat_.Key, AVG_Price = cat_.Average(p => p.UnitPrice) };
            foreach (var item in r18) { Console.WriteLine(item); }
            #endregion

            #region Ordering Operators 
            /*
             LINQ - Ordering Operators          
            */

            //1. Sort a list of products by name
            var r19 = ProductList.Select(p => p.ProductName).OrderBy(name => name);
            foreach (var p in r19)
            {
                Console.WriteLine(p);
            }

            //2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            string[] Arr5 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var r20 = Arr5.OrderBy(x => x);
            foreach (var p in r20)
            {
                Console.WriteLine(p);
            }

            //3. Sort a list of products by units in stock from highest to lowest.
            var r21 = ProductList.Select(p => new { Product = p.ProductName, UnitsInStock = p.UnitsInStock }).OrderByDescending(p => p.UnitsInStock);
            foreach (var p in r21)
            {
                Console.WriteLine(p);
            }

            // 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            string[] Arr6 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var r22 = from p in Arr6
                      orderby p.Length, p
                      select p;
            foreach (var p in r22)
            {
                Console.WriteLine(p);
            }

            //5. Sort first by word length and then by a case-insensitive sort of the words in an array.
            string[] words4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var r23 = from p in words4
                      orderby p.Length, p
                      select p;
            foreach (var p in r23)
            {
                Console.WriteLine(p);
            }

            //6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var r24 = from p in ProductList
                      orderby p.Category, p.UnitPrice descending
                      select p;
            foreach (var p in r24)
            {
                Console.WriteLine(p);
            }

            //7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.
            string[] words5 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var r25 = from p in words5
                      orderby p.Length, p descending
                      select p;
            foreach (var p in r25)
            {
                Console.WriteLine(p);
            }

            //8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.           
            string[] Arr7 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var r26 = Arr7.Select(p => p).Where(p => p.ElementAtOrDefault(1).Equals('i')).Reverse();
            foreach (var p in r26)
            {
                Console.WriteLine(p);
            }
            #endregion

            #region  Partitioning Operators
            /*
             LINQ - Partitioning Operators
             */


            //1. Get the first 3 orders from customers in Washington
            var r27 = CustomerList.Where(p => p.Address.Contains("Washington")).Select(p => new { CustomerName = p.CompanyName, CustomerOrder = p.Orders }).Take(3);
            foreach (var c in r27) { Console.WriteLine(c); }

            //2. Get all but the first 2 orders from customers in Washington.
            var r28 = CustomerList.Where(p => p.Address.Contains("Washington")).Take(2).Select(p => p.Orders).Concat(CustomerList.Select(p => p.Orders));
            foreach (var e in r28)
            {
                foreach (var order in e)
                    Console.WriteLine(order);
            }

            //3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.       
            int[] numbers1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var r29 = numbers1.TakeWhile((x, i) => x >= i);
            foreach (var n in r29)
            {
                Console.WriteLine(n);
            }

            //4. Get the elements of the array starting from the first element divisible by 3.
            var r30 = numbers1.SkipWhile(ele => ele % 3 != 0);
            foreach (var n in r30)
            {
                Console.WriteLine(n);
            }

            //5. Get the elements of the array starting from the first element less than its position.
            var r31 = numbers1.SkipWhile((x, i) => x >= i);
            foreach (var n in r31)
            {
                Console.WriteLine(n);
            }
            #endregion

            #region Projection Operators 
            /*
             LINQ - Projection Operators   
             */

            //1. Return a sequence of just the names of a list of products.
            var r32 = ProductList.Select(p => p.ProductName);
            foreach (var r in r32) { Console.WriteLine(r); }

            //2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).
            string[] words6 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var r33 = words6.Select(p => p.ToUpper()).Concat(words6.Select(p => p.ToLower()));
            foreach (var r in r33) { Console.WriteLine(r); }

            //3.Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            var r34 = ProductList.Select(p => new { ProductName = p.ProductName, ProductID = p.ProductID, Price = p.UnitPrice });
            foreach (var r in r34) { Console.WriteLine(r); }

            //4. Determine if the value of ints in an array match their position in the array.
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var r35 = Arr.Select((n, i) => $"{n}:{(n == i)}");
            foreach (var r in r35) { Console.WriteLine(r); }

            //5.Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; int[] numbersB = { 1, 3, 5, 7, 8 };
            var r36 = numbersA.SelectMany(n => numbersB, (n, b) => new { n, b }).Where(c => c.n < c.b).Select(c => $"{c.n} is less than {c.b}");
            foreach (var r in r36) { Console.WriteLine(r); }

            //6. Select all orders where the order total is less than 500.00.
            var r37 = CustomerList.Select(c => c.Orders.Where(c => c.Total < 500));
            foreach (var r in r37) { foreach (var i in r) Console.WriteLine(i); }

            // 7. Select all orders where the order was made in 1998 or later.
            var r38 = CustomerList.Select(c => c.Orders.Where(c => c.OrderDate.Year >= 1998));
            foreach (var r in r38) { foreach (var i in r) Console.WriteLine($"{i}\tYearDate:\t{i.OrderDate.Year}"); };
            #endregion

            #region Quantifiers
            /*
             LINQ - Quantifiers
             */

            //1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            List<string> words7 = new(File.ReadAllLines("E:\\CS problem solving\\c#pd_heba\\wpf\\Day10\\task1\\dictionary_english.txt"));
            Console.WriteLine(words7.Any(p => p.Contains("ei")));

            //2.Return a grouped a list of products only for categories that have at least one product that is out of stock.
            var r39 = from p in ProductList
                      group p by p.Category
                      into cat_
                      where (cat_.Any(p => p.UnitsInStock == 0))
                      select cat_;
            foreach (var p in r39) { foreach (var i in p) Console.WriteLine(i); }

            // 3. Return a grouped a list of products only for categories that have all of their products in stock.
            var r40 = from p in ProductList
                      group p by p.Category
                      into cat_
                      where (cat_.All(p => p.UnitsInStock != 0))
                      select cat_;
            foreach (var p in r40) { foreach (var i in p) Console.WriteLine(i); }
            #endregion

            #region Grouping Operators 
            /*
             LINQ - Grouping Operators        
             */

            //1. Use group by to partition a list of numbers by their remainder when divided by 5
            int[] Numbers6 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            var r41 = from n in Numbers6
                      group n by n % 5
                    into g5
                      select g5;
            int count = 0;
            foreach (var p in r41) { Console.WriteLine($"Numbers with a remainder of {count++} when divided by 5: "); foreach (var i in p) Console.WriteLine(i); }

            //2. Uses group by to partition a list of words by their first letter.Use dictionary_english.txt for Input
            List<string> words8 = new(File.ReadAllLines("E:\\CS problem solving\\c#pd_heba\\wpf\\Day10\\task1\\dictionary_english.txt"));
            var r42 = from k in words8
                      group k by k.ElementAt(0)
                    into g1
                      select g1;
            foreach (var p in r42) { foreach (var i in p) Console.WriteLine(i); }

            //3. Consider this Array as an Input Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            string[] Arr9 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            var r43=Arr9.GroupBy(x => new string(x.Trim().OrderBy(k=>k).ToArray()));
            foreach (var p in r43) { Console.WriteLine($"--"); foreach (var i in p) Console.WriteLine(i); }
            #endregion
        }
    }
}