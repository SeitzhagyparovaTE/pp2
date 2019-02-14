using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1 
{
    class Program
    {
            static bool isPrime(int n)
            {
                if (n < 2)
                {
                    return false;
                }
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
                int a = int.Parse(Console.ReadLine());
                string[]s = Console.ReadLine().Split();


            int[] arr = new int[1000]; // create a massiv
                int cnt = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    int x = int.Parse(s[i]);// x is ith element
                    if (isPrime(x)) 
                    {
                        arr[cnt++] = x;// if x is prime, then counter++
                    }
                }
                Console.WriteLine(cnt);
                for (int i = 0; i < cnt; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.ReadKey();
            }
        }
    }

    