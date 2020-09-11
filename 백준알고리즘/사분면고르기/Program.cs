using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 사분면고르기
{
   class Program
   {
      static void Main(string[] args)
      {
         int x = int.Parse(Console.ReadLine());
         int y = int.Parse(Console.ReadLine());
         int multiply = x * y;

         if(multiply > 0)
         {
            if(x > 0 && y > 0)
            {
               Console.WriteLine(1);
            }
            else
            {
               Console.WriteLine(3);
            }
         }
         else
         {
            if (x > 0 && y < 0)
            {
               Console.WriteLine(4);
            }
            else
            {
               Console.WriteLine(2);
            }
         }
      }
   }
}
