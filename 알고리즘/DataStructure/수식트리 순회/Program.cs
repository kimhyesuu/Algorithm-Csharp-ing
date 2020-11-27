using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 수식트리_순회
{
   public class ExpressionTree
   {
      public Node Root { get; set; }

      //수식 트리 구축
      // ex) tokens = 10 4 / 3 5 *
      public void Build(string[] tokens)
      {
         int index = tokens.Length - 1;
         Root = Build(tokens, ref index);
      }

      public Node Build(string[] tokens, ref int index)
      {
         Node node = new Node(tokens[index]);

         if (tokens[index] == "+" ||
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
         return node;
      }

      public decimal Evaluate(Node root)
      {
         if (root is null) return 0;

         // 왼쪽 서브트리 계산
         decimal left = Evaluate(root.Left);

         // 오른쪽 서브트리 계산
         decimal right = Evaluate(root.Right);

         if (root.Data == "+")
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

      // prefix
      public void Inoreder(Node node)
      {
         if (node is null) return;//null이면 여기서 끊어주네

         // 연산자이면 괄호 열기 
         if (IsOperator(node.Data))
            Console.Write("(");

         Inoreder(node.Left);
         Console.Write($"{node.Data}");
         Inoreder(node.Right);

         if (IsOperator(node.Data))
            Console.Write(")");
      }

      //후위 순회
      public void Postorder(Node node)
      {
         if (node is null) return;

         Postorder(node.Left);
         Postorder(node.Right);
         Console.Write($"{node.Data}");
      }

      private string[] op = {"+","-","*","/"};
      //연산자가 op 내에 있는 연산자라면 true로 값을 보내면서 수식 
      //을 만든다.
      private bool IsOperator(string token)
      {
         return op.Contains(token);
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

   class Program
   {
      static void Main(string[] args)
      {
         var postfix = "10 4 / 3 5 * *".Split(' ');

         var et = new ExpressionTree();
         et.Build(postfix);

         Console.Write("Inorder: ");
         et.Inoreder(et.Root);
         Console.WriteLine();

         Console.Write("Postorder: ");
         et.Postorder(et.Root);
         Console.WriteLine();


         var result = et.Evaluate(et.Root);
         Console.WriteLine($"Result : {result}");


         Console.ReadKey();
      }
   }
}
