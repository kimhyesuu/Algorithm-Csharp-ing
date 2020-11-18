using System;
namespace bjq2
{
   class Refer
   {
      static bool isPN(int n)
      {
         if (n == 1)
         {
            return false;
         }

         for (int i = 2; i <= Math.Truncate(Math.Sqrt(n)); i++)
         {
            if (n % i == 0)
            {
               return false;
            }
         }
         return true;
      }
      public static void Main(string[] args)
      {
         int m = int.Parse(Console.ReadLine());
         int n = int.Parse(Console.ReadLine());
         int sm = 0;
         int mn = 0;
         for (int i = m; i <= n; i++)
         {
            if (isPN(i))
            {
               if (mn == 0)
               {
                  mn = i;
               }
               sm += i;
            }
         }
         if (sm == 0)
         {
            Console.WriteLine(-1);
         }
         else
         {
            Console.WriteLine(sm);
            Console.WriteLine(mn);
         }
      }
   }
}