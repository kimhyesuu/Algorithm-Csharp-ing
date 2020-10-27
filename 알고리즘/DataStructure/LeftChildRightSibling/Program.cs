using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLeftChildRightSibling
{
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
            var A = new LCRSNode('A');
            var B = new LCRSNode('B');
            var C = new LCRSNode('C');
            var D = new LCRSNode('D');
            var E = new LCRSNode('E');
            var F = new LCRSNode('F');
            var G = new LCRSNode('G');

            A.LeftChild = B;
            B.LeftChild = E;
            B.RightSibling = C;
            C.RightSibling = D;
            D.LeftChild = G;
            E.RightSibling = F;

            if(A.LeftChild != null)
            {
                var tmp = A.LeftChild;
                Console.WriteLine(tmp.Data);

                for( ; tmp.RightSibling != null ; )
                {
                    tmp = tmp.RightSibling;
                    Console.WriteLine(tmp.Data);
                }
            }       
        }
    }
}
