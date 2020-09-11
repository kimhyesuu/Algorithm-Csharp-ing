using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 구구단
{
   class Program
   {
      static void Main(string[] args)
      {
         int N = int.Parse(Console.ReadLine());
         StringBuilder resultgugudan = new StringBuilder();
       
         for (int x = 1; x < 10; x ++)
         {
            resultgugudan.Append(N).Append(" * ").Append(x).Append(" = ").Append(N * x).Append('\n');
         }

         Console.WriteLine(resultgugudan.ToString());
         Console.Read();
      }
   }
}
