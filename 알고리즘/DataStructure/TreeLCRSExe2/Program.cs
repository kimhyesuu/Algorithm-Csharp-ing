using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLCRSExe2
{
    public class LCRSTree
    {
        public LCRSNode Root { get; private set; }

        public LCRSTree(object rootData)
        {
            this.Root = new LCRSNode(rootData);
        }

        public LCRSNode AddChild(LCRSNode parent, object data)
        {
            if (parent is null) return null;

            LCRSNode child = new LCRSNode(data);

            if(parent.LeftChild is null)
            {
                parent.LeftChild = child;
            }
            else
            {
                var node = parent.LeftChild;

                for( ; node.RightSibling != null ; )
                {
                    node = node.RightSibling;
                }

                node.RightSibling = child;
            }
            return child;
        }

        public LCRSNode AddSibling(LCRSNode node, object data)
        {
            if (node is null) return null;

            for( ;node.RightSibling != null ; )
            {
                node = node.RightSibling;
            }

            var sibling = new LCRSNode(data);
            node.RightSibling = sibling;

            return sibling;
        }


        public void PrintLevelOrder()
        {
            var q = new Queue<LCRSNode>();
            q.Enqueue(this.Root);

            for( ; q.Count > 0 ; )
            {
                var node = q.Dequeue();
                for( ; node !=  null; )
                {
                    Console.Write($"{node.Data}");

                    if(node.LeftChild != null)
                    {
                        q.Enqueue(node.LeftChild);
                    }
                    node = node.RightSibling;
                }
            }
        }

        public void PrintIndentTree()
        {
            PrintIndent(this.Root,1);
        }

        private void PrintIndent(LCRSNode node, int indent)
        {
            if (node is null) return;

            // 현재 노드 출력
            string pad = " ".PadLeft(indent);
            Console.WriteLine($"{pad}{node.Data}");

            // 왼쪽 자식 
            // (자식이므로 indent 증가)
            PrintIndent(node.LeftChild, indent + 1 );

            // 오른쪽 형제
            // (형제이므로  동일 indent 사용)

            PrintIndent(node.RightSibling, indent);

        }
    }

    public class LCRSNode
    {
        public object Data { get; set; }
        public LCRSNode LeftChild { get; set; }
        public LCRSNode RightSibling { get; set; }

        public LCRSNode(object data)
        {
            this.Data = data;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            LCRSTree tree = new LCRSTree('A');

            var A = tree.Root;
            var B = tree.AddChild(A,'B');
            tree.AddChild(A,'C');
            var D = tree.AddSibling(B,'D');
            tree.AddChild(B, 'E');
            tree.AddChild(B,'F');
            tree.AddChild(D,'G');

            tree.PrintIndentTree();

            tree.PrintLevelOrder();

            Console.ReadKey();

        }
    }
}
