using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.acmicpc.net/problem/3045
namespace 이중_연결_리스트
{
    // Node : N개
    // Head : 1번
    // 번호가 갈 수록 1씩 증가

    // 입력 시 : 노드 수(N) 연산 수 M
    // 출력 시 : A 1 4
    //         : B 3 5 

    // A) 노드 X를 노드 Y의 앞으로 이동
    // B) 노드 x를 노드 Y의 뒤로 이동

    // 첫째 줄에 노드의 수 N과 연산의 수 M이 주어진다. (2 ≤ N ≤ 500,000, 0 ≤ M ≤ 100,000)
    
    public class DoublyNodeLinkedList<T>
    {
        public DoublyNodeLinkedListNode<T> _head;

        //Add
        //AddAfter
        //GetIndex

        public void Add(DoublyNodeLinkedListNode<T> newNode)
        {
          
            if (_head is null)
            {
                _head = newNode;
                _head.Prev = _head;
                _head.Next = _head;                
            }
            else
            {
                var current = _head;

                var tail = current.Prev;

                current.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = current;
            }
        }

        public void AddAfter(DoublyNodeLinkedListNode<T> current, DoublyNodeLinkedListNode<T> newNode)
        {
            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }

        public DoublyNodeLinkedListNode<T> GetIndex(int index)
        {
            int cnt;
            var current = _head;
            for(cnt = 0; cnt< index && current != null; cnt++)
            {
                current = current.Next;
                if (current == _head) return null;
            }

            return current;
        }
    }

// Node 데이터
    public class DoublyNodeLinkedListNode<T>
    {
        public T Data { get; set; }

        public DoublyNodeLinkedListNode<T> Prev { get; set; }
        public DoublyNodeLinkedListNode<T> Next { get; set; }

        public DoublyNodeLinkedListNode
            (T data,
            DoublyNodeLinkedListNode<T> prev = null, 
            DoublyNodeLinkedListNode<T> next = null)
        {
            this.Data = data;
            this.Prev = prev;
            this.Next = next;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            var nodeN = int.Parse(input[0]);
            var calculateM = int.Parse(input[1]);

            Console.WriteLine();

            string[,] calculateInputs = new string[ calculateM , 3 ];

            for (int i = 0 ; i < calculateM; i++)
            {
               string[] value = Console.ReadLine().Split(' ');

                for(int j = 0; j < 3; j++)
                {
                    calculateInputs[i, j] = value[j];
                }             
            }           

            var list = new DoublyNodeLinkedList<int>();

            for (int i = 0; i < nodeN; i++)
                list.Add(new DoublyNodeLinkedListNode<int>(i + 1));

            for(int i = 0 ; i < calculateM; i++ )
            {
                //여기서 다시 하기 
            }
        }
    }
}
