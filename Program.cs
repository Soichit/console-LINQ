using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] temp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var results = temp.Select(x => x * x)
                .OrderByDescending(x => x)
                .Select(x => x.ToString())
                .ToList();

            //foreach(var x in results)
            //{
            //    Console.WriteLine(x);
            //}
            Console.WriteLine("results1");
            Console.WriteLine(string.Join(",", results.ToArray()));
            Console.WriteLine("\r\n");
            

            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 2, 4, 6, 8, 12, 2, 4, 6 };
            var evenNumberHistogram = numbers
                .Where(x => x % 2 == 0)
                .GroupBy(x => x)
                .Select(x => new Tuple<int, int>(x.Key, x.ToList().Count))
                .OrderByDescending(x => x.Item1);

            Console.WriteLine("results2: tuples");
            foreach (var x in evenNumberHistogram)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\r\n");

            // prime
            var prime = numbers
                .Where(x => isPrime(x))
                .GroupBy(x => x)
                .Select(x => new Tuple<int, int>(x.Key, x.ToList().Count))
                .OrderByDescending(x => x.Item1);

            Console.WriteLine("results3: prime numbers");
            foreach (var x in prime)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\r\n");


            var input = new string[] { "hello", "info" };
            var result = input.SelectMany(x => x);
            Console.WriteLine("results4");
            Console.WriteLine(string.Join(",", result.ToArray()));
            Console.WriteLine("\r\n");


            var numbers2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 2, 4, 6, 8, 12, 2, 4, 6 };
            var result2 = numbers2.Skip(5).Take(3);
            Console.WriteLine("results5");
            Console.WriteLine(string.Join(",", result2.ToArray()));
            Console.WriteLine("\r\n");



            


            var text = File.ReadAllLines("/Users/iGuest/downloads/obama.txt");

            //Console.WriteLine(string.Join(",", text));
            var count = text.Select(x => x.Split(' '))
                .SelectMany(x => x)
                .Where(x => x.ToLower() == "obama")
                .Count();

            //Obama
            Console.WriteLine("Obama");
            Console.WriteLine(count);
            Console.WriteLine("\r\n");

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
