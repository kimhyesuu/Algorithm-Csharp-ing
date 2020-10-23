using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 벌집
{
    class Program
    {
        static void Main(string[] args)
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
        
            for (int min = 2, max = 7;  ;pathCount++)
            {
              // 6(2,3,4,5,6,7) 12(8,9,10,11,12,13,14,15,16,17,18,19) 18 24 순으로 갑니다. 
                if(min <= N && max >= N)
                {
                    Console.WriteLine(pathCount);
                    return;
                }

                min = max+1;
                max = max + 6 * pathCount;
            }
        }
    }
}
