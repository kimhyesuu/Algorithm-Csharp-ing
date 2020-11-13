using System;

namespace DeleteDuplicatedArrayNumber
{
   class Program
   {
      static void Main(string[] args)
      {
         int[] arr = { 2 , 3 , 2 , 4 , 7 , 7 , 8 , 9 , 10 };

         int endOfList = DeleteDuplicates(arr);

         for(int i = 0; i < endOfList; i++ )
         {
            Console.WriteLine(arr[i]);
         }

         Console.ReadKey();
      }

      private static int DeleteDuplicates(int[] arr)
      {
         if (arr.Length == 0) return 0;

         int temp = 0;
         for (int i = 0; i < arr.Length - 1; i++)
         {
            for (int j = i + 1; j < arr.Length; j++)
            {
               if (arr[i] > arr[j])
               {
                  temp = arr[i];
                  arr[i] = arr[j];
                  arr[j] = temp;
               }
            }
         }

      
         int endOfList = 0;

         for (int i = 0; i < arr.Length; i++)
         {
            //같으면 뛰어넘고 같지 않으면 그 값에 맞게 넣네 
            //초기화시키네 

            //1. arr[0] arr[0] 
            //2. arr[1] arr[1]
            if (arr[endOfList] != arr[i])
            {
               endOfList++;
               arr[endOfList] = arr[i];
            }
         }

         return endOfList + 1;
      }
   }
}
