using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 문제모음
{
   class Program
   {
      static void Main(string[] args) { }
    
      private static void DivisorMultiple()
      {

         int m = -1;
         int n = -1;
         string[] input;
         var sb = new StringBuilder();

         for (; ; )
         {
            input = Console.ReadLine().Split(' ');
            m = int.Parse(input[0]);
            n = int.Parse(input[1]);

            if (m == 0 && n == 0)
            {
               break;
            }

            if (m % n == 0)
            {
               sb.AppendLine("multiple");
            }
            else if (n % m == 0)
            {
               sb.AppendLine("factor");
            }
            else
            {
               sb.AppendLine("neither");
            }
         }


         Console.WriteLine(sb.ToString());
      }
      private static void Temp()
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
      private static void Righttriangle()
      {
         string[] input;
         long n1, n2, n3;

         for (; ; )
         {
            input = Console.ReadLine().Split(' ');

            if (long.Parse(input[0]) == 0 && long.Parse(input[1]) == 0 && long.Parse(input[2]) == 0)
               break;

            n1 = long.Parse(input[0]) * long.Parse(input[0]);
            n2 = long.Parse(input[1]) * long.Parse(input[1]);
            n3 = long.Parse(input[2]) * long.Parse(input[2]);

            if (n1 + n2 == n3 || n2 + n3 == n1 || n1 + n3 == n2)
            {
               Console.WriteLine("right");
            }
            else
            {
               Console.WriteLine("wrong");
            }
         }
      }
      private static void Reverse()
      {
         string[] input = Console.ReadLine().Split(' ');
         char[] first = input[0].ToCharArray();
         char[] second = input[1].ToCharArray();

         //Array.Reverse(first);
         //Array.Reverse(second);
         char temp;

         temp = first[0];
         first[0] = first[2];
         first[2] = temp;

         temp = second[0];
         second[0] = second[2];
         second[2] = temp;

         input[0] = new string(first);
         input[1] = new string(second);
         if (int.Parse(input[0]) > int.Parse(input[1]))
         {
            Console.WriteLine(first);
         }
         else
         {
            Console.WriteLine(second);
         }

         Console.ReadKey();
      }
      private static void StarShootingEx3()
      {
         int input = int.Parse(Console.ReadLine());
         // 5
         var sb = new StringBuilder();
         //뎁스를 만든다.
         for (int i = 0; i < input - 1; i++)
         {
            //공백을 어떻게 줄지 쓴다. 가운데서 좌우로 퍼질때 
            // 왼쪽 공백만 한칸씩 줄여주면 되네 
            for (int j = input - 1; j > i; j--)
            {
               sb.Append(" ");
            }

            // 한 뎁스마다 홀수개로 늘어난다.
            for (int j = 0; j < 2 * i + 1; j++)
            {
               if (j == 0 || j == 2 * i)
                  sb.Append("*");
               else
                  sb.Append(" ");
            }

            sb.AppendLine();
         }

         for (int i = 0; i < 2 * input - 1; i++)
            sb.Append("*");

         Console.WriteLine(sb);
      }
      private static void WhiteSpaceDivision()
      {
         string[] input = Console.ReadLine().Split(' ');

         if (input[0] == "" && input[input.Length - 1] == "")
            Console.WriteLine(input.Length - 2);
         else if (input[0] == "" || input[input.Length - 1] == "")
            Console.WriteLine(input.Length - 1);
         else
            Console.WriteLine(input.Length);

      }
      private static void StudyLanguage()
      {
         string input = Console.ReadLine();
         int[] arr = new int[26];
         char[] inputChar;

         inputChar = input.ToLower().ToCharArray();

         for (int i = 0; i < inputChar.Length; i++)
         {
            for (int k = 97; k < 123; k++)
            {
               if (inputChar[i] == k)
               {
                  arr[k - 97] += 1;
                  break;
               }
            }
         }

         int? max = arr[0];
         foreach (var c in arr)
         {
            if (max < c)
            {
               max = c;
            }
         }

         int cnt = 0;
         int result = 0;
         for (int i = 0; i < arr.Length; i++)
         {
            if (max == arr[i])
            {
               cnt++;
               result = i;
               if (cnt > 1)
               {
                  max = null;
                  break;
               }
            }
         }

         if (max == null)
            Console.WriteLine("?");
         else
            Console.WriteLine($"{(char)(result + 65)}");
      }
      private static void StringRepetition()
      {
         int n = int.Parse(Console.ReadLine());

         string cmd_Line;
         string[] cmd_Split;

         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < n; i++)
         {
            cmd_Line = Console.ReadLine();
            cmd_Split = cmd_Line.Split('\x020');

            int _reapeat = int.Parse(cmd_Split[0]);
            string _cen = cmd_Split[1];

            string _result = "";
            for (int c = 0; c < _cen.Length; c++)
            {
               for (int r = 0; r < _reapeat; r++)
               {
                  _result += _cen.Substring(c, 2);
               }
            }

            sb = sb.AppendLine(_result);
         }

         Console.WriteLine(sb.ToString());
      }
      private static void MeStringRepetition()
      {
         int T = int.Parse(Console.ReadLine());
         string[] input;
         string[] Num = new string[T];
         string[] character = new string[T];

         for (int i = 0; i < T; i++)
         {
            input = Console.ReadLine().Split(' ');
            Num[i] = input[0];
            character[i] = input[1];
         }

         var sb = new StringBuilder();
         char[] temp;

         for (int i = 0; i < T; i++)
         {
            for (int k = 0; k < character[i].Length; k++)
            {
               temp = character[i].ToCharArray();
               for (int j = 0; j < int.Parse(Num[i]); j++)
               {
                  sb.Append(temp[k]);
               }
            }
            sb.AppendLine();
         }

         Console.WriteLine(sb);

      }
      private static void Square2()
      {
         int[] x = new int[4];
         int[] y = new int[4];

         for (int i = 0; i < 3; i++)
         {
            string[] Square = Console.ReadLine().Split(' ');

            x[i] = int.Parse(Square[0]);
            y[i] = int.Parse(Square[1]);
         }

         x[3] = x[0];
         y[3] = y[0];

         if (x[3] == x[1])
            x[3] = x[2];
         else if (x[3] == x[2])
            x[3] = x[1];

         if (y[3] == y[1])
            y[3] = y[2];
         else if (y[3] == y[2])
            y[3] = y[1];

         Console.WriteLine($"{x[3]} {y[3]}");
      }
      private static void NShooting()
      {
         int N = int.Parse(Console.ReadLine());
         var sb = new StringBuilder();

         for (int i = 1; i <= N; i++)
         {
            sb.AppendLine($"{i}");
         }
         Console.WriteLine(sb);
      }
      private static void StarShooting()
      {
         int N = int.Parse(Console.ReadLine());
         var sb = new StringBuilder();

         for (int i = 1; i <= N; i++)
         {
            for (int k = 0; k < N - i; k++)
               sb.Append(" ");
            for (int j = 0; j < i; j++)
               sb.Append("*");
            sb.AppendLine();
         }

         Console.WriteLine(sb);

         int NT = Convert.ToInt32(Console.ReadLine());

         for (int i = 0; i < N; i++)
         {
            for (int j = N - 1; j >= 0; j--)
            {
               if (i < j)
                  Console.Write(" ");
               else
                  Console.Write("*");
            }
         }
            Console.WriteLine();

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
      private static void gugudan()
      {
         int N = int.Parse(Console.ReadLine());
         StringBuilder resultgugudan = new StringBuilder();

         for (int x = 1; x < 10; x++)
         {
            resultgugudan.Append(N).Append(" * ").Append(x).Append(" = ").Append(N * x).Append('\n');
         }

         Console.WriteLine(resultgugudan.ToString());
         Console.Read();
      }
      private static void BackJon10952()
      {
         StringBuilder getNumber = new StringBuilder();
         while (true)
         {
            getNumber.AppendLine(Console.ReadLine().ToString());
            if (getNumber.ToString().Contains("0 0")) break;
         }

         StringReader readNumber = new StringReader(getNumber.ToString());
         StringBuilder outNumber = new StringBuilder();
         bool isFirst = true;

         while (true)
         {
            string[] abGet = readNumber.ReadLine().Split();
            int a = int.Parse(abGet[0]);
            int b = int.Parse(abGet[1]);
            int sum = a + b;
            if (sum == 0) break;

            if (isFirst)
            {
               isFirst = false;
               outNumber.Append(sum.ToString());
               continue;
            }

            outNumber.Append("\n").Append(sum.ToString());
         }

         Console.WriteLine(outNumber.ToString());
         Console.ReadLine();
      }
      private static void Square0()
      {
         int x = int.Parse(Console.ReadLine());
         int y = int.Parse(Console.ReadLine());
         int multiply = x * y;

         if (multiply > 0)
         {
            if (x > 0 && y > 0)
            {
               Console.WriteLine(1);
            }
            else
            {
               Console.WriteLine(3);
            }
         }
         else
         {
            if (x > 0 && y < 0)
            {
               Console.WriteLine(4);
            }
            else
            {
               Console.WriteLine(2);
            }
         }
      }
      private static void Alarm()
      {
         string[] a = Console.ReadLine().Split(' ');
         int h = int.Parse(a[0]);
         int m = int.Parse(a[1]);


         if (m < 45)
         {
            h--;
            m += 60;

            if (h < 0)
            {
               h += 24;
            }
            else if (h > 23)
            {
               h -= 24;
            }
         }

         Console.WriteLine("{0} {1}", h, m);
      }
      private static void belzip()
      {
         int N = int.Parse(Console.ReadLine());
         int pathCount = 2;

         // 1(1)
         if (N == 1)
         {
            pathCount = 1;
            Console.WriteLine(pathCount);
            return;
         }

         for (int min = 2, max = 7; ; pathCount++)
         {
            // 6(2,3,4,5,6,7) 12(8,9,10,11,12,13,14,15,16,17,18,19) 18 24 순으로 갑니다. 
            if (min <= N && max >= N)
            {
               Console.WriteLine(pathCount);
               return;
            }

            min = max + 1;
            max = max + 6 * pathCount;
         }
      }
   }
}
