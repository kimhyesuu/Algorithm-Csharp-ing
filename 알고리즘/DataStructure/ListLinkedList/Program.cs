using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<string>();

            list.AddLast("Apple");
            list.AddLast("Banana");
            list.AddLast("Lemon");

            var node = list.Find("Banana");
            var newNode = new LinkedListNode<string>("Grape");

            //새 Grape 노드를 Banana 노드 뒤에 추가
            list.AddAfter(node,newNode);

            //IEnumable에서 List로 변환 후 ForEach로 출력
            list.ToList().ForEach(p => Console.WriteLine(p));

            list.Remove("Grape");

            Console.WriteLine();

            list.ToList().ForEach(p => Console.WriteLine(p));

            Console.ReadKey();
        }
    }
}
