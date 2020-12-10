using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 백준알고리즘
{
   class Program
   {
      static void Main(string[] args)
      {
         BackJon10952();
       
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
   }
}
