using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarayTree_수식트리
{
   // 이진 트리 활용 - 수식 트리
   // 이진 트리는 여러 다양한 분야에 활용, 수식 처리에도 이진 트리를 활용
   // 수식 트리는 수식 계산을 위한 이진 트리로서, 루트 노드와 내부 노드에는
   // 연산자가 있고
   // 단말 노드에는 피연산자가 있도록 구성
   class Program
   {
      static void Main(string[] args)
      {
         ExpressionTree expressionTree = new ExpressionTree();

         var tokens = "10 4 / 3 5 *".Split(' ');
         expressionTree.Evaluate(new Node("*"));
         Console.Read();

      }
   }

   public class ExpressionTree
   {
      public Node Root { get; set; }

      //수식 트리 구축
      // ex) tokens = 10 4 / 3 5 *
      public void Build(string[] tokens)
      {
         int index = tokens.Length - 1;
         Root = Build(tokens, ref index);
         Console.WriteLine(Root.Data);
      }

      public Node Build(string[] tokens, ref int index)
      {
         Node node = new Node(tokens[index]);

         if(tokens[index] == "+" ||
            tokens[index] == "-" ||
            tokens[index] == "*" ||
            tokens[index] == "/" 
            )
         {
            // 오른쪽 서브트리 Build
            --index;
            node.Right = Build(tokens, ref index);
            // 왼쪽 서브트리 Build
            --index;
            node.Left = Build(tokens, ref index);
         }
         Console.WriteLine(node.Data);
         return node;
      }

      public decimal Evaluate(Node root)
      {
         if (root is null) return 0;

         // 왼쪽 서브트리 계산
         var left = Evaluate(root.Left);

         // 오른쪽 서브트리 계산
         var right = Evaluate(root.Right);

         if(root.Data == "+")
         {
            return left + right;
         }
         else if (root.Data == "-")
         {
            return left - right;
         }
         else if (root.Data == "*")
         {
            return left * right;
         }
         else if (root.Data == "/")
         {
            return left / right;
         }

         //피연산자면 반환
         return decimal.Parse(root.Data);
      }
   }

   // 수식트리 노드
   public class Node
   {
      public string Data { get; set; }
      public Node Left { get; set; }
      public Node Right { get; set; }

      public Node(string data)
      {
         this.Data = data;
      }
   }
   
}
