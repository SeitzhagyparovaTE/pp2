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
                string[] s = Console.ReadLine().Split();
                int[] arr = new int[10000];
                int cnt = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    int x = int.Parse(s[i]);
                    if (isPrime(x))
                    {
                        arr[cnt++] = x;
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

    