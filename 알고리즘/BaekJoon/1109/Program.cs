namespace _문제풀이
{
   using System;

   class Program
   {
      static void Main(string[] args)
      {
         // 1. N의 갯수를 구하고
         int N = int.Parse(Console.ReadLine());

         string[] arr = new string[N];
         arr = Console.ReadLine().Split(' ');

         int[] arr2 = Array.ConvertAll(arr, s => int.Parse(s));

         Array.Sort(arr2);

         int min = 0;
         int max = 0;

         if (N == 1)
         {
            min = arr2[0];
            max = arr2[0];
         }
         else
         {
            min = arr2[0];
            max = arr2[N - 1];
         }

         Console.WriteLine(min * max);
      }
   } 
}


// 1 과 1이 시작점이네?
// https://www.youtube.com/watch?v=827t3uOU_dc 점화식만드는 것 보고 
// 그 점화식으로 풀기

// https://www.acmicpc.net/problem/10870