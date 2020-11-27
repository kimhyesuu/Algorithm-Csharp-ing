using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binomial_Memorization
{
   class Program
   {
      public static int[,] f
      {
         get;
         set;
      } = new int[10000, 10000];

      static void Main(string[] args)
      {
         //DefaultValueMinusOne(f);
         Console.WriteLine(BottonUp(5,3));
         //Console.WriteLine(Binomial(5,3));
         Console.ReadKey();
      }

      private static int BottonUp(int n, int r)
      {
         // n == 5 r ==3
         for(int i = 0; i <= n; i++)
            for(int j = 0; j <= r && j <= i;j++)
            {
               if (j == 0 || i == j)
                  f[i, j] = 1;
               else
                  f[i, j] = f[i - 1, j - 1] + f[i - 1, j ];
            } 
         return f[n, r];
      }

      private static void DefaultValueMinusOne(int[,] f)
      {
         for (int i = 0; i < 10000; i++)
            for (int k = 0; k < 10000; k++)
               f[i ,k] = -1;
      }

      private static int Binomial(int n, int r)
      {
         if (n == r || r == 0)
            return 1;
         else if (f[n, r] > -1)
            return f[n, r]; // 중복 수냐? 있던 값으로 전달해라
         else
         {
            f[n, r] = Binomial(n - 1, r ) + Binomial(n-1,r - 1);
            return f[n, r];
         }
      }
   }
}
