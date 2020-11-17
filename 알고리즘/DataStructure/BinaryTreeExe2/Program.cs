using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeExe2
{
   // 전위 순회 
   // 노드 방문
   // 왼쪽 서브 트리 전위 순회
   // 오른쪽 서브 트리 전위 순회

   // 중위 순회
   // 왼쪽 서브 트리 중위 순회
   // 노드
   // 오른쪽 서브트리

   // 후위 순회
   // 왼쪽 서브트리 후위 순회
   // 오른쪽 서브트리 후위 순회
   // 노드 방문

   // 레벨 순서 순회 낮은 레벨부터 높은 레벨로 각 레벨 차례대로 순회

   class Program
   {
      static void Main(string[] args)
      {
         var bt = new BinaryTree<int>(1);

         bt.Root.Left = new BinaryTreeNode<int>(2);
         bt.Root.Right = new BinaryTreeNode<int>(3);
         bt.Root.Left.Right = new BinaryTreeNode<int>(5);
         bt.Root.Left.Left = new BinaryTreeNode<int>(4);

         bt.MorePostorderIterative();
         //bt.PreorderTraversal();

         Console.ReadKey();
      }
   }

   public class BinaryTree<T>
   {
      #region 트리 구조
      
      public BinaryTreeNode<T> Root { get; private set; }

      public BinaryTree(T root)
      {
         Root = new BinaryTreeNode<T>(root);
      }

      public void PreorderTraversal()
      {
         PreorderTraversal(Root);
      }

      private void PreorderTraversal(BinaryTreeNode<T> node)
      {
         if (node is null) return;

         Console.Write($"{node.Data}");
         PreorderTraversal(node.Left);
         PreorderTraversal(node.Right);
      }

      //반복 방식으로 구현한 이진 트리 순회
      #endregion
      #region 후위

      //2. 스택이 빌 때까지 루프를 돈다.
      // - 스택에서 Pop하여 변수 N에 저장하고 N의 오른쪽 노드가 스택의 Top과
      // 동일한지 체크한다.
      // - 동일하지 않으면, 변수 N를 출력한다.
      // 3. 만약 동일하면, 스택에 루트와 오른쪽 노드가 있었다는 의미 
      // 스택의 Top에 있는 오른쪽 노드를 Pop하고 기존 루트를 다시 스택에 
      // Push한다. 다시 말하면, 스택에 처음 push할 때 오른쪽 자식 노드를 pop하고
      // 다시 스택에 push한다.
      // 다시 말하면, 스택에 처음 Push할 때 오른쪽 자식 노드와 루트 순으로 Push 하였
      // 으므로 Pop할 때 
      public void PostorderIterative()
      {
         var stack = new Stack<BinaryTreeNode<T>>();
         var node = Root;

         //1. 루트 노드에서 최좌측 노드까지 오른쪽 자식 노드의 루트 노드를 스택에 저장   
         for (; node != null;)
         {
            if (node.Right != null)
            {
               stack.Push(node.Right);
            }
            stack.Push(node);
            node = node.Left;
         }

         while (stack.Count > 0)
         {
            node = stack.Pop();

            if (node.Right != null &&
               stack.Count > 0 &&              
               node.Right == stack.Peek()) // 트리의 마지막을 오른족 값을 갖고 있기 때문에   
            {
               // 오른쪽 자식 노드를 Pop
               var right = stack.Pop();
               // 루트 노드를 다시 push 
               stack.Push(node);
               node = right;

               // Leftmost 노드까지 오른쪽 자식 노드와 루트를 스택에 저장
               while (node != null)
               {
                  if (node.Right != null)
                  {
                     stack.Push(node.Right);
                  }
                  stack.Push(node);
                  node = node.Left;
               }
            }
            else
            {
               Console.Write(node.Data);
            }
         }
      }
      public void MorePostorderIterative()
      {
         var stack = new Stack<BinaryTreeNode<T>>();
         var node = Root;

         //1. 루트 노드에서 최좌측 노드까지 오른쪽 자식 노드의 루트 노드를 스택에 저장   
         for (; node != null || stack.Count > 0;)
         {
            for(; node != null;)
            {
               if(node.Right != null)
               {
                  stack.Push(node.Right);
               }

               stack.Push(node);
               node = node.Left;
            }
          
            node = stack.Pop();

            if (node.Right != null &&
                stack.Count > 0 &&
                node.Right == stack.Peek())
            {
               var right = stack.Pop();
               stack.Push(node);
               node = right;
            }
            else
            {
               Console.Write(node.Data);
               node = null;
            }
         }

       

      }
      #endregion
      #region 전위 
      //구현 순서

      // 루트 노트를 스택에 넣는다
      // 스택이 빌때까지 루프 작동
      // 스택에서 Pop하여 노드 출력
      // 오른쪽 노드가 있으면 스택에 저장
      // 왼쪽 노드가 있으면 스택에 저장
      public void PreorderIterative()
      {
         if (Root is null) return;

         var stack = new Stack<BinaryTreeNode<T>>();
         stack.Push(Root);

         while (stack.Count > 0)
         {
            // 스택에서 노드 가져옴
            var node = stack.Pop();

            //Visit
            Console.WriteLine(node.Data);

            if (node.Right != null)
            {
               stack.Push(node.Right);
            }

            if (node.Left != null)
            {
               stack.Push(node.Left);
            }
         }

      }
      #endregion
      #region 중위
      public void InorderIterative()
      {
         if (Root is null) return;

         var stack = new Stack<BinaryTreeNode<T>>();

         var node = Root;

         for (; node != null;)
         {
            stack.Push(node);
            node = node.Left;
         }

         while (stack.Count > 0)
         {
            node = stack.Pop();

            Console.WriteLine(node.Data);

            if (node.Right != null)
            {
               node = node.Right;
            }

            while (node != null)
            {
               stack.Push(node.Left);
               node = node.Left;
            }

         }
      }

      public void MoreInorderIterative()
      {
         if (Root is null) return;

         var stack = new Stack<BinaryTreeNode<T>>();

         var node = Root;


         while (node != null || stack.Count > 0)
         {
            stack.Push(node);

            while (node != null)
            {
               stack.Push(node.Left);
               node = node.Left;
            }

            node = stack.Pop();

            Console.WriteLine(node.Data);

            if (node.Right != null)
            {
               node = node.Right;
            }
         }
      }
      #endregion
   }
}


public class BinaryTreeNode<T>
{
   public T Data { get; set; }
   public BinaryTreeNode<T> Left { get; set; }
   public BinaryTreeNode<T> Right { get; set; }

   public BinaryTreeNode(T data)
   {
      this.Data = data;
   }

}

