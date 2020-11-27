using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 피보나치
{
   class Program
   {
      public static int[] f
      {
         get;
         set;
      } = new int[10000];


      static void Main(string[] args)
      {
         init(f);
         Console.WriteLine(MemorizationPibonacci(5));

         Console.ReadKey();
      }

      private static void init(int[] f)
      {
         for (int i = 0; i < f.Length; i++)
            f[i] = -1;
      }

      // After

      private static int MemorizationPibonacci(int n)
      {
         if (n == 1 || n == 2)
            return 1;
         else if (f[n] > -1)
            return f[n];
         else
         {
            f[n] = MemorizationPibonacci(n - 2) + MemorizationPibonacci(n - 1);
            return f[n];
         }
      }

      // Before
      private static int Pibonacci(int parameter)
      {
         if (parameter == 1 || parameter == 2)
            return 1;
         else
            return Pibonacci(parameter - 2) + Pibonacci(parameter - 1);
      }
   }
}
