using System;

namespace TreeExeNLink
{
    // N-Link 장점
    // 1. 구조가 쉬움

    // N-Link 단점
    // 1. 공간낭비 심함


    public class TreeNode
    {
        public object Data { get; set; }
        public TreeNode[] Links { get; private set; }

        public TreeNode(object data, int maxDegree = 3 )
        {
            this.Data = data;
            Links = new TreeNode[maxDegree];
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            var A = new TreeNode('a');
            var B = new TreeNode('a');
            var C = new TreeNode('a');
            var D = new TreeNode('a');

            A.Links[0] = B;
            A.Links[1] = C;
            A.Links[2] = D;

            B.Links[0] = new TreeNode('W');
            B.Links[1] = new TreeNode('F');
            B.Links[2] = new TreeNode('G');

            foreach(var node in B.Links)
            {
                Console.WriteLine(node.Data);
            }

            Console.ReadKey();
        }
    }
}
