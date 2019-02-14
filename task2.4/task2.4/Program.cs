using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs= File.Create(@"C:\Users\Тогжан\Desktop\PP2\task2.4\task4.txt");
            fs.Close();
            File.Copy(@"C:\Users\Тогжан\Desktop\PP2\task2.4\task4.txt", @"C:\Users\Тогжан\Desktop\PP2\task4.12
.txt");
            File.Delete(@"C:\Users\Тогжан\Desktop\PP2\task2.4\task4.txt");
        }

    }
}
