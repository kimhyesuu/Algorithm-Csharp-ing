namespace _1109
{
   using System;
   class Program
   {
      static void Main(string[] args)
      {
         
         
      }     
   }

   class Solution
   {
      int count = 0;
      int[] arr = new int[1000001];

      public Solution()
      {
         var input = Console.ReadLine();
         int n = int.Parse(input);
         this.count = Func(n);
         Console.WriteLine(count);
      }

      public int Func(int n)
      {
         if (n == 1)
         {
            return 0;
         }

         if (arr[n] > 0)
         {
            return arr[n];
         }

         arr[n] = Func(n - 1) + 1;

         if (n % 3 == 0)
         {
            var temp = Func(n / 3) + 1;
            if (arr[n] > temp)
            {
               arr[n] = temp;
            }
         }

         if (n % 2 == 0)
         {
            var temp = Func(n / 2) + 1;
            if (arr[n] > temp)
            {
               arr[n] = temp;
            }
         }


         return arr[n];
      }
   }
}
