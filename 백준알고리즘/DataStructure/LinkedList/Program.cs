using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
   


    #region 단방향 연결 리스트 Control

    public class MoreSinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> head;

        // 리스트가 비어 있으면 Head에 새 노드를 할당하고 비어있지 않으면
        // 마지막 노드를 찾아 이동한 후 마지막 노드 다음에 새 노드에 추가
        public void Add(SinglyLinkedListNode<T> newNode)
        {
            // 연결 리스트가 비워있으면 
            if (head is null)
            {
                head = newNode;
            }
            else
            {
                // 1차 : 0  null
                var current = head;

                // n와 n+1이 널이 아니면 
                // n = n+1 
                // n n+1 이런식으로 다음 값에 대입할 수 있게 돈다.
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void AddAfter(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> newNode)
        {
            if (head is null || current is null || newNode is null)
                throw new InvalidOperationException();

            // 새노드의 다음 노드에 현재 노드의 다음 노드를 대입시킨다면


            // newNode :100
            // 대입 전 newNode.Next : null
            // 대입 후  newNode.Next : current.Next(3)
            // newNode.Next : current.Next

            // 1. 100 -> 3 
            newNode.Next = current.Next;
            // 2. 1 -> 100
            current.Next = newNode;

            // 3. 1 -> 100 -> 3

        }

        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            if(head is null || removeNode is null)
            {
                return;
            }
            
            // 삭제할 노드가 첫 노드이면
            if(removeNode == head)
            {
                head = head.Next;
                removeNode = null;
            }
            else //첫 노드가 아니면, 해당 노드를 검색하여 삭제
            {
                var current = head;

                // 단방향이므로 삭제할 노드의 바로 이전 노드까지 검색
                for(; current!=null && current.Next !=removeNode; )
                {
                    current = current.Next;
                }

                if(current != null)
                {
                    //이전 노드의 Next에 삭제 노드의 Next를 할당
                    current.Next = removeNode.Next;
                    removeNode = null;
                }               
            }
        }

        public SinglyLinkedListNode<T> GetNode(int index)
        {
            // 현재 head를 지역변수로 받아서 쓰는 구나 
            // 전역 변수는 단지 있는 것뿐이고 
            var current = head;

            // i < index를 받아서 current != null에 
            for (int i = 0; i < index && current != null; i++)
                current = current.Next;

            //만약 index가 리스트 카운트보다 크면 
            // null이 리턴 됨
            return current;
        }

        public int Count()
        {
            int cnt = 0;

            var current = head;
            
            for(    ; current!=null ;    )
            {
                cnt++;
                current = current.Next;
            }

            return cnt;
        }
    }

    #endregion

    #region 단방향 연결 리스트 Node Data

    public class SinglyLinkedListNode<T>
    {

        public T Data { get; set; }

        public SinglyLinkedListNode<T> Next { get; set; }


        public SinglyLinkedListNode(T data)
        {
            this.Data = data;
            //자기 자신에서 Next에 널 값 집어넣는다...
            this.Next = null;
        }

    }

    #endregion



    class Program
    {
        static void Main(string[] args)
        {
            //MoreSinglyLinkedList<int>를 instance 생성
            var list = new MoreSinglyLinkedList<int>();

            //SinglyLinkedListNode<int>를 instance 생성하고 
            // Add해버림
            for (int i = 0; i < 5; i++)
                list.Add(new SinglyLinkedListNode<int>(i));

            // index가 2인 요소 삭제
            var node = list.GetNode(2);
            list.Remove(node);

            // Index가 1인 요소 가져오기 
            node = list.GetNode(1);

            // Index가 1인 요소와 3인 요소 사이에 100 삽입
            list.AddAfter(node, new SinglyLinkedListNode<int>(100));

            // 리스트 카운트 체크
            int count = list.Count();

            // 전체 리스트 출력

            for(int i =0; i <count; i++)
            {
                var n = list.GetNode(i);
                //리턴 받은 n의 데이터를 출력
                Console.WriteLine(n.Data);
            }

            Console.ReadKey();

        }
    }
}
