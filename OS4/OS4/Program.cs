using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS4
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;

            var a = new int[100, 100];

            for (int i = 99; i > 0; i--)
            {
                for (int j = 99; j > 0; j--)
                {
                    a[j, i] = a[j - 1, i - 1] + 1;
                    
                }
               
            }
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    a[j, i]--;
                }
            }
            var finish = DateTime.Now;

            Console.WriteLine($"Time of work: {finish - start}");
            Console.ReadKey();
        }
    }
}
