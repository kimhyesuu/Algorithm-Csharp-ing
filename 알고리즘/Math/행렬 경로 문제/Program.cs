using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace 행렬_경로_문제
{
   //https://www.youtube.com/watch?v=j_sdjivoPs8 다시
   // 문제 
   // 정수들이 저장된 n*n 행렬의 좌상단에서 우하단까지 이동한다.
   // 조건
   // 오른쪽이나 아래쪽으로만 이동가능

   // 최소 정수들의 합을 구하라 
   class Program
   {
      public static int[,] m
      {
         get;
         set;
      } = new int[5, 5];

      static void Main(string[] args)
      {
         RandamArray(m);
         Console.WriteLine(mat(4,4));
         Console.ReadKey();
      }

      private static void RandamArray(int[,] m)
      {
         Random rd = new Random();
         for (int i = 1; i < 5; i++)
            for (int k = 1; k < 5; k++)
               m[i, k] = rd.Next(1,10);
      }

      public static int mat(int i, int j)
      {
         if (i == 1 && j == 1)
         {
            var a = m[i, j];
            Console.WriteLine($"(i == 1 && j == 1) {a} {i} {j}");
            return a;
         }       
         else if (i == 1)
         {
            var a = mat(1, j - 1) + m[i, j];
            Console.WriteLine($"(i == 1) {a} {i} {j}");
            return a;
         }
         else if (j == 1)
         {
            var a = mat(i - 1, 1) + m[i, j];
            Console.WriteLine($"(j == 1) {a} {i} {j}");
            return a;
         }
         else
         {
            var a = Math.Min(mat(i - 1, j), mat(1, j - 1)) + m[i, j];
            Console.WriteLine($"Math.Min {a} {i} {j}");
            return a;
         }
      }
   }
}
