using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleread
{
   class Program
   {
      static void Main(string[] args)
      {
         int a = int.Parse(Console.ReadLine());
         int r = int.Parse(Console.ReadLine());
         int b = 1_000_000_000;
         Console.WriteLine($"{r} {a}");
         Console.ReadKey();
      }
   }
}
