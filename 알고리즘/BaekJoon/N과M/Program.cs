using System;

namespace N과M
{
    class Program
    {
        static int N, M;
        static int[] arr; 
        static bool[] visited;


        static void dfs(int cnt)
        {
            arr = new int[N];
            visited = new bool[N];
            if (cnt == M)
            {
                for (int i = 0; i < M; i++)
                    Console.WriteLine(i);
                return;
            }

            for (int i = 1; i < N; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    arr[cnt] = i;
                    dfs(cnt + 1);
                    visited[i] = false;
                }
            }
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            N = Convert.ToInt32(input[0])+1;
            M = Convert.ToInt32(input[1]);

            dfs(0);

            Console.ReadKey();

        }
    }
}
