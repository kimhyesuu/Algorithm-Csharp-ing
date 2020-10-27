using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExeNLinkDynamic
{
    // 동적 트리 
    public class TreeNode
    {
        public object Data { get; set; }
        public List<TreeNode> Links { get; private set; }

        public TreeNode(object data)
        {
            this.Data = data;
            Links = new List<TreeNode>();
        }
    }

    class Program
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

            foreach (var node in B.Links)
            {
                Console.WriteLine(node.Data);
            }

            Console.ReadKey();
        }
    }
}
