using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 문제모음
{
   class Program
   {
      static void Main(string[] args)
      {
      }

      private static void Square()
      {
         string[] input = Console.ReadLine().Split(' ');
         int x = int.Parse(input[0]);
         int y = int.Parse(input[1]);
         int w = int.Parse(input[2]);
         int h = int.Parse(input[3]);
         int min;

         min = x < w - x ? x : w - x;
         min = y < h - y ? min > y ? y : min : min > h - y ? h - y : min;


         Console.WriteLine(min);
      }
      private static void Easy2()
      {
         int N = int.Parse(Console.ReadLine());
         var sb = new StringBuilder();

         for (int i = 1; i <= N; i++)
         {
            for (int k = 0; k < i; k++)
            {
               sb.Append("*");
            }
            sb.AppendLine();
         }

         Console.WriteLine(sb);
      }
      private static void Easy()
      {
         short N = short.Parse(Console.ReadLine());
         StringBuilder sb = new StringBuilder();

         for (int i = N; i > 0; i--)
         {
            sb.AppendLine(i.ToString());
         }

         Console.WriteLine(sb);
      }
      private static void AlphaSearch()
      {
         var inp = Console.ReadLine();
         var sb = new StringBuilder();

         for (var i = 'a'; i <= 'z'; i++)
         {
            for (var j = 0; j < inp.Length; j++)
            {
               if (inp[j] == i)
               {
                  sb.Append(j + " ");
                  break;
               }
               if (j == inp.Length - 1)
               {
                  sb.Append("-1 ");
               }
            }
         }

         Console.WriteLine(sb.ToString().TrimEnd());
      }
      private static void MeAlphaSearch()
      {
         char[] S = Console.ReadLine().ToCharArray();
         StringBuilder sb = new StringBuilder();

         bool flag;

         for (short j = 97; j < 123; j++)
         {
            flag = true;
            for (short i = 0; i < S.Length; i++)
            {
               if (S[i] == j)
               {
                  sb.Append($"{i} ");
                  flag = false;
                  break;
               }
            }
            if (flag)
               sb.Append("-1 ");
         }
         Console.WriteLine(sb);
      }
      private static void SumNumber()
      {
         int n = int.Parse(Console.ReadLine());
         char[] m = Console.ReadLine().ToCharArray();
         n = 0;
         // 아스키코드표에서 0은 48이기 때문에 뺀다면 진수 표현이 되는구만
         foreach (int i in m)
         {
            n += (i - 48);
         }
         Console.WriteLine(n);
         int N = int.Parse(Console.ReadLine());
         char[] sb = Console.ReadLine().ToCharArray();
         int result = 0;

         for (int i = 0; i < N; i++)
         {
            if (sb[i] != '0')
            {
               result += int.Parse(sb[i].ToString());
            }
         }

         Console.WriteLine(result);
      }
      private static void AplusB()
      {
         StringBuilder output = new StringBuilder();
         char count = char.Parse(Console.ReadLine());
         for (int i = 1; i <= count; i++)
         {
            string input = Console.ReadLine();
            output.Append($"Case #{i}: ");
            char c = (char)(input[0] + input[2] - '0'); // 차로 짤라서 넣었구나 
            if (c > '9') output.AppendLine("1" + (char)(c - 10));
            else output.AppendLine(c.ToString());
         }
         Console.WriteLine(output);
      }
      private static void PrimeMinMax()
      {
         short inputM = short.Parse(Console.ReadLine());
         short inputN = short.Parse(Console.ReadLine());

         ushort result = 0;
         short min = 0;

         for (short i = inputM; i < inputN + 1; i++)
         {
            if (IsPrime(i))
            {
               if (min == 0)
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
      private static void Number11022()
      {
         int N = int.Parse(Console.ReadLine());

         int[] A = new int[N];
         int[] B = new int[N];


         for (int i = 0; i < N; i++)
         {
            string[] arr = Console.ReadLine().Split(' ');
            A[i] = int.Parse(arr[0]);
            B[i] = int.Parse(arr[1]);
         }

         for (int i = 0; i < N; i++)
         {
            Console.WriteLine($"Case #{i + 1}: {A[i]} + {B[i]} = {A[i] + B[i]}");
         }


      }
      private static void NumberTemp()
      {
         int X = int.Parse(Console.ReadLine());
         int[,] arr = new int[10_000_000, X];
         int p = 1, q = 0;

         for (int i = 0; i < X; i++)
         {

         }
      }
      private static void Number8393()
      {
         int n = int.Parse(Console.ReadLine());
         int sum = 0;
         for (int i = 1; i <= n; i++)
            sum += i;

         Console.WriteLine(sum);
      }
      private static void APlusBNumber1095()
      {
         int T = int.Parse(Console.ReadLine());
         string[] values;
         int[] result = new int[T];
         // loop값을 입력받고
         // 
         for (int i = 0; i < T; i++)
         {
            values = Console.ReadLine().Split(' ');
            result[i] = int.Parse(values[0]) + int.Parse(values[1]);
         }

         for (int i = 0; i < T; i++)
         {
            Console.WriteLine(result[i]);
         }

         Console.ReadLine();
      }
   }
}
