using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace task_2._2
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n < 2) { return false; }

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

            static void Main(string[] args)
            {
                FileStream fs = new FileStream(@"C:\Users\Тогжан\Desktop\PP2\task 2.2\txt.txt", System.IO.FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string s = sr.ReadLine();
                string[] arr = s.Split();
                sr.Close();
                fs.Close();
                FileStream ofs = new FileStream(@"C:\Users\Тогжан\Desktop\PP2\task 2.2\txt1.txt", System.IO.FileMode.Open, FileAccess.Write);
                StreamWriter sr1 = new StreamWriter(ofs);
                for (int i = 0; i < arr.Length; i++)
                {
                    int x = int.Parse(arr[i]);
                    if (IsPrime(x))
                    {
                        sr1.Write(x + " ");
                    } }
                sr1.Close();
                ofs.Close();
                Console.ReadKey();
            }
        }
    }


        
   

