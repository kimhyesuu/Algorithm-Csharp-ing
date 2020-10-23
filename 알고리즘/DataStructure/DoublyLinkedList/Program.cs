using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    #region 설명서
    // 1. 노드 표현할 클래스 설정
    // 2. 이를 연결할 이중 연결 리스트 클래스를 만들자
    #endregion

    #region 노드를 받아서 구현하는 방식 
    // 이들을 양방향으로 연결한 이중 연결 리스트는 리스트의 처음을 가리키는 헤드(Head) 필드가 필요
    // 경우에 다라 마지막 노드를 가리키는 Tail 필드 추가

    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> _head;

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if(_head is null)
            {
                _head = newNode;
            }
            else
            {
                var current = _head;
                // urrent.Next이 for문을 돌 때마다
                // 1. 현재 값의 다음 값을 계속 불러온다.
                for ( ; current != null && current.Next != null ; )
                {
                    current = current.Next; 
                }

                // 추가할 때 양 방향 연결 
                current.Next = newNode;
                newNode.Prev = current;
                newNode.Next = null;
            }
           
        }

        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if(_head is null || current is null || newNode is null)
            {
                throw new InvalidOperationException();
            }

            //newNode의 Next에는 current의 Next를 value

            newNode.Next = current.Next;
            // 이 구문 신기하네
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }
        
        public void Remove (DoublyLinkedListNode<T> removeNode)
        {
            if(_head is null || removeNode is null)
            {
                return;
            }
                
            if(removeNode == _head)
            {
                removeNode = _head.Next;
                if(_head != null)
                {
                    _head.Prev = null;
                }            
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }
            }

            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            // 현재 head는 누구냐
            var current = _head;
            
            for(int i = 0; i< index && current != null; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public int Count()
        {
            int cnt;
            var current = _head;

            for ( cnt = 0 ; current != null ; cnt++)
            {            
                current = current.Next;
            }

            return cnt - 1;
        }
    }
    #endregion

    #region 노드 표현할 클래스 설정
    public class DoublyLinkedListNode<T>
    {
        // 노드의 value
        public T Data { get; set; }

        // 이전 노드와 다음 노드를 표현하는 2개의 포인터
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

        //this
        //
        public DoublyLinkedListNode(T data,
            DoublyLinkedListNode<T> prev = null,
            DoublyLinkedListNode<T> next = null)
        {
            this.Data = data;
            this.Prev = prev;
            this.Next = next;
        }

    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<int>();

            for(int i=0;i<100;i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2);
            list.Remove(node);

            node = list.GetNode(1);

            list.AddAfter(node, new DoublyLinkedListNode<int>(100));

            var Count = list.Count();

            for(int i = 0; i < Count; i++)
            {
                var n = list.GetNode(i);
                Console.Write($"{n.Data} ");
            }

            Console.WriteLine();

            for (int i = Count; i >= 0; i--)
            {
                var n = list.GetNode(i);
                Console.Write($"{n.Data} ");
            }

            Console.ReadKey();
        }
    }
}
