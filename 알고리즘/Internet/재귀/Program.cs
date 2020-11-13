using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 재귀
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine(FactorA(5));

         Console.ReadLine();
      }

      private static int FactorA(int v)
      {
         if(v == 1)
         {
            return 1;   
         }
         else
         {
            // v 5
            // FactorB(v - 1) = 24
            // return 5 * 24
            return v * FactorB(v - 1);

         }
      }

      private static int FactorB(int v)
      {
         if (v == 1)
         {
            return 1;
         }
         else
         {
            // v= 4
            // FactorC(v - 1) = 6
            // return 4 * 6;
            return v * FactorC(v - 1);

         }
      }

      private static int FactorC(int v)
      {
         if (v == 1)
         {
            return 1;
         }
         else
         {
            //v = 3
            // FactorD(v - 1) = 2
            // return 3 * 2;
            return v * FactorD(v - 1);
         }
      }

      private static int FactorD(int v)
      {
         if (v == 1)
         {
            return 1;
         }
         else
         {
            //v = 2
            //FactorF(v - 1) = 1
            // return 2 * 1;
            return v * FactorF(v - 1);

         }
      }

      private static int FactorF(int v)
      {
         //v = 1
         if (v == 1)
         {
            return 1;
         }
         else
         {
            return v * FactorE(v - 1);
         }
      }

      private static int FactorE(int v)
      {
         return 1;
      }
   }
}
