namespace _문제풀이
{
   using System;
   class Program
   {
      // ccaazzzz
      static void Main(string[] args)
      {
         string input = Console.ReadLine();
         int N = int.Parse(input);

         string[] words = WordInputer(N);
         int countGroupWords = 0;

         for (int i = 0; i < words.Length; i++)
         {
            if (isGroupWord(words[i]))
            {
               countGroupWords++;
            }
         }

         Console.WriteLine(countGroupWords);
         Console.ReadKey();
      }

      private static bool isGroupWord(string word)
      {
         for (int i = 0; i < word.Length; i++)
         {
            for (int j = i; j < word.Length; j++)
            {
               if (j - i > 1)
               {
                  if (word[i] == word[j])
                  {
                     return false;
                  }
               }

               if (word[i] == word[j])
               {
                  i += j - i;
               }
            }
         }
         return true;
      }

      private static string[] WordInputer(int N)
      {
         string[] words = new string[N];
         for (int i = 0; i < N; i++)
         {
            words[i] = Console.ReadLine();
         }
         return words;
      }
   } 
}


// 1 과 1이 시작점이네?
// https://www.youtube.com/watch?v=827t3uOU_dc 점화식만드는 것 보고 
// 그 점화식으로 풀기

// https://www.acmicpc.net/problem/10870