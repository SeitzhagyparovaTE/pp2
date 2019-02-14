using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._1
{
    class Program
    {
        public static string Reverse (string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C: \Users\Тогжан\Desktop\PP2\task2.1\task2.1.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string st1 = sr.ReadLine();
            string st2 = Reverse(st1);
            if (st1 == st2)
            {
                Console.WriteLine("Yes");
            }
            Console.WriteLine("No");
            Console.ReadKey();
        }
    }
   

}
