using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
            static int[] Dublicate(int[] arr)
            {
                int[] arr2 = new int[2000];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr2[i * 2] = arr[i];
                    arr2[i * 2 + 1] = arr[i];
                }

                return arr2;
            }

            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                string[] s = Console.ReadLine().Split();
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arr[i] = int.Parse(s[i]);
                }

                int[] arr2 = Dublicate(arr);
                for (int i = 0; i < n * 2; i++)
                {
                    Console.Write(arr2[i] + " ");
                }

            }
        }
}
