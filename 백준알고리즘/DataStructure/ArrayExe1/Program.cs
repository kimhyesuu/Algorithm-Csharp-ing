using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExe1
{


    #region DynamicArray O(n) before
    public class DynamicArray
    {
        private object[] arr = new object[0];

        // 추가할 element를 받음
        // O(n) .. 복사해야하기때문에 
        public void Add(object element)
        {
            // 객체 생성
            var temp = new object[arr.Length + 1];

            // arr의 값을 함수 내에서 다 받은 뒤
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }

            // 다시 arr에 넣는다. 
            arr = temp;

            // 마지막으로 추가할 element를 마지막 요소에 
            // 더함
            arr[arr.Length - 1] = element;

        }
    }
    #endregion

    #region DynamicArray O(n) after
    public class DynamicArray2
    {
        private object[] arr;
        private const int GROWTH_FACTOR = 2;

        // Count는 현재값이라는데
        public int Count { get; private set; }
        
        public int Capacity
        {
            get => arr.Length;
        }

        public DynamicArray2(int capacity = 16)
        {
            arr = new object[capacity];
            Count = 0;
        }

        public void Add(object element)
        {
            // Count가 Capacity보다 크거나 같으면 이 구문 돌 것
   
            if (Count >= Capacity)
            {
                // 성장 인자(Growth Factor) : 배열이 꽉 찼을 때 배열을
                // 얼마만큼 늘려야 하는가를 정하는 인자
                // 통상 2배 혹은 1.5배 정도 사용

                int newSize = Capacity * GROWTH_FACTOR;
                var temp = new object[newSize];

                for (int i = 0; i < arr.Length; i++)
                {
                    temp[i] = arr[i];
                }

                arr = temp;
            }

            // 그외 element를 받고 count++할 것 
            arr[Count] = element;
            Count++;     
        }

        public object GetIndex(int index)
        {
            if(index > Capacity - 1)
            {
                throw new ApplicationException("Element not found");
            }

            return arr[index];
        }

    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int>()
            //{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };

            DynamicArray2 array2 = new DynamicArray2();

            for(int i = 0; i < 100000; i++)
            {
                array2.Add(16);
            }
     

            Console.WriteLine(array2.GetIndex(1));

            Console.ReadKey();


        }
    }
}
