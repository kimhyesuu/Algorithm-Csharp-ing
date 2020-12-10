using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeExe
{
   class Program
   {
      // 이진 탐색 트리란 이진 트리 
      // left right Root
      // 1. left < Root
      // 2. right > Root

      // 이러한 값 순서는 이진 탐색 트리의 모든 서브트리에 적용
      // 이진 트리 형식은 순회할 때 중위 순회 방식을 사용
      static void Main(string[] args)
      {
      }

      public class BST<T> where T : IComparable<T>
      {
         private class Node<P>
         {
            public P Data { get; set; }
            public Node<P> Left { get; set; }
            public Node<P> Right { get; set; }

            public Node(P data)
            {
               this.Data = data;
            }

            // 루트 필드 
            private Node<T> _root;

            // 기본 메서드 골격
            // 이진 탐색 트리에 새 키 데이터를 추가하기 위해서는 
            // 먼저 루트 노드로부터 키를 비교하여 좌, 우 노드로
            // 계속 이동해 내려가면서 새 키를 추가할 장소를 찾는 다.
            // 즉 키가 루트 혹은 서브트리의 루트보다 작으면 왼쪽 노드로 이동하고,
            // 크면 오른쪽 노드로 계속 이동한다. 
            // 만약 이동한 노드가 null이 되면 그 곳이 새 노드를 넣을 곳이 된다.
            // 통상 새 노드는 부모 노드의 좌우 노드에 링크를 넣어야 하므로, 
            // 이동할 때 부모 노드에서 이동할 곳의 자식 노드가 null 인지를 먼저 체크해서
            // 부모 노드 밑에 새 노드를 연결한다. 아래는 위의 BST<T> 클래스에서 생략한
            // Add() 메서드를 구현한 예제
            public void Add(T data)
            {
               if (_root == null)
               {
                  _root = new Node<T>(data);
                  return;
               }

               var node = _root;

               for( ; node!= null ;  )
               {
                  int cmp = data.CompareTo(node.Data);
                  if(cmp == 0)
                  {
                     throw new ApplicationException("Duplicate");
                  }
                  else if(cmp < 0)
                  {
                     if(node.Left == null)
                     {
                        //비워졌으면 넣기
                        node.Left = new Node<T>(data);
                        break;
                     }
                     else
                     {
                        node = node.Left;
                     }
                  }
                  else
                  {
                     if(node.Right == null)
                     {
                        //비워졌으면 넣기
                        node.Right = new Node<T>(data);
                        break;
                     }
                     else
                     {
                        node = node.Right;
                     }
                  }
               }
            }
            public bool Search(T data) { return true; }
            public bool Remove(T data) { return true; }

         }
      }
        
   }
}
