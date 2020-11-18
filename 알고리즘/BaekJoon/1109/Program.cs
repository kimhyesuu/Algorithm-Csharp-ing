namespace _1109
{
   using System;

   class Program
   {
      static void Main(string[] args)
      {
         short inputM = short.Parse(Console.ReadLine());
         short inputN = short.Parse(Console.ReadLine());

         ushort result = 0;
         short min = 0;

         for (short i = inputM; i < inputN+1; i++)
         {
            if (IsPrime(i))
            {
               if(min == 0)
               {
                  min = i;
               }              
               result += (ushort)i;               
            }
         }

         if (result == 0)
         {
            Console.WriteLine(-1);
         }                 
         else
         {
            Console.WriteLine($"{result}\n{min}");
         }

         Console.Read();
      }

      private static bool IsPrime(short i)
      {
         if (i == 2)
         {
            return true;
         }              
         else if (i % 2 == 0 || i == 1)
         {
            return false;
         }
                
         for (short k = 3; k < Math.Sqrt(i) + 1; k += 2)
         {
            if (i % k == 0)
            {
               return false;
            }
                                     
         }
         return true;
      }
   }
}
//private static void Number11022()
//{
//   int N = int.Parse(Console.ReadLine());

//   int[] A = new int[N];
//   int[] B = new int[N];


//   for (int i = 0; i < N; i++)
//   {
//      string[] arr = Console.ReadLine().Split(' ');
//      A[i] = int.Parse(arr[0]);
//      B[i] = int.Parse(arr[1]);
//   }

//   for (int i = 0; i < N; i++)
//   {
//      Console.WriteLine($"Case #{i + 1}: {A[i]} + {B[i]} = {A[i] + B[i]}");
//   }


//}
//private static void NumberTemp()
//{
//   int X = int.Parse(Console.ReadLine());
//   int[,] arr = new int[10_000_000, X];
//   int p = 1, q = 0;

//   for (int i = 0; i < X; i++)
//   {

//   }
//}
//private static void Number8393()
//{
//   int n = int.Parse(Console.ReadLine());
//   int sum = 0;
//   for (int i = 1; i <= n; i++)
//      sum += i;

//   Console.WriteLine(sum);
//}
//private static void APlusBNumber1095()
//{
//   int T = int.Parse(Console.ReadLine());
//   string[] values;
//   int[] result = new int[T];
//   // loop값을 입력받고
//   // 
//   for (int i = 0; i < T; i++)
//   {
//      values = Console.ReadLine().Split(' ');
//      result[i] = int.Parse(values[0]) + int.Parse(values[1]);
//   }

//   for (int i = 0; i < T; i++)
//   {
//      Console.WriteLine(result[i]);
//   }

//   Console.ReadLine();
//}