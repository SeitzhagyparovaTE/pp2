using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i=1; i<=n; i++)
            {
                for(int j=1; j<=n; j++)
                {
                    if (j<= i)
                        Console.Write("[*]");
                }
                Console.WriteLine();

            }
            Console.ReadKey();
        }
    }
}
