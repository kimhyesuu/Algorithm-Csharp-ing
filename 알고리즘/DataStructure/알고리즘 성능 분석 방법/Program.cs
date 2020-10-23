using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 알고리즘_성능_분석_방법
{
    class Program
    {
        static void Main(string[] args)
        {

        }

//        위 코드의 경우 변수 i가 0 ~n-1 까지 n번 반복되고, 변수 j가 0 ~n-2까지 n-1번 반복 된다.

//          반복문 이외의 조건문이나 실행문의 경우 단위시간인 1 로 계산하기 때문에 위 함수의 총 실행시간은

//          n* (n-1) + 6 = n ^ 2 - n + 6이 된다.

//          배열의 크기인 n이 작을 땐 아주 작은 시간이 소모 되지만 n이 커짐에 따라 실행시간은 기하급수적으로 늘어난다.


       void bubbleSort(int[] arr, int n)
        {

            // 실행문 1 2
            int i = 0, j = 0;
            int temp;

            // 0 ~ n - 1 n번 반복하고
            for (i = 0; i < n; i++)
            {
                //0 ~ n - 2 n-1번 반복
                for (j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        //  B의 경우는 sum에 값을 대입 +1
        //  i에 값을 대입 +1
        //  n 번 만큼 i 값을 n과 비교 +n
        //  n 번 만큼 sum에 i를 더한 값을 저장 +1
        //  n 번 만큼 i 값을 늘려주는 연산을 실행한다. +1
        //  즉, 입력 n에 따라 실행 시간이 변하여, 약 2n + 2 번의 연산을 한다.

        int sum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
                sum += i;
            return sum;
        }

    }
}
