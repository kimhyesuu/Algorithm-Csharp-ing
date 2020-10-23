using System;

namespace CircularLinkedListExe
{

    public class CircularLinkedList<T>
    {
        private DoublyLinkedListNode<T> _head;

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (_head is null)
            {
                _head = newNode;
                _head.Next = _head;
                _head.Prev = _head;
            }
            else
            {
                var current = _head;
                var tail = _head.Prev;
                // urrent.Next이 for문을 돌 때마다
                // 1. 현재 값의 다음 값을 계속 불러온다.
               

                // 추가할 때 양 방향 연결 
                current.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = current;
            }

        }

        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (_head is null || current is null || newNode is null)
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

        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (_head is null || removeNode is null)
            {
                return;
            }

            if (removeNode == _head)
            {
                removeNode = _head.Next;
                if (_head != null)
                {
                    _head.Prev = null;
                }
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;          
                removeNode.Next.Prev = removeNode.Prev;
                
            }

            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            // 현재 head는 누구냐
            if (IsHeadNull(_head) == true) return null;

            int cnt;
            var current = _head;

            for (cnt = 0; cnt < index && current != null; cnt++)
            {
                current = current.Next;

                if (current == _head) return null;
            }

            return current;
        }

        public int Count()
        {
            if (IsHeadNull(_head) == true) return 0; 

            int cnt;
            var current = _head.Next;

            for (cnt = 0; current != _head; cnt++)
            {
                current = current.Next;
            }

            return cnt;
        }

        public static bool IsCircular(DoublyLinkedListNode<T> head)
        {
            // 필터링 하면서 내려가면서 마지막까지 없으면 false
            if(head is null) return true;
          
            var current = head;

            for( ; current != null ; )
            {
                current = current.Next;
                if (current == head) return true; 
            }

            return false;

        }

        public bool IsHeadNull(DoublyLinkedListNode<T> head)
        {
            return _head is null;
        }
    }

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
            var list = new CircularLinkedList<int>();

            for(int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2);
            list.Remove(node);

            node = list.GetNode(1);
            list.AddAfter(node , new DoublyLinkedListNode<int>(100));

            int count = list.Count();

            node = list.GetNode(0);

            for(int i = 0; i < count*2+1; i++)
            {
                Console.Write($"{node.Data} " );
                node = node.Next;
            }

            Console.ReadKey();

        }
    }
}
