using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCA
{
   //https://www.codeproject.com/Articles/141999/Solving-LCA-by-Reducing-to-RMQ-in-C
   // 최소 공통 조상? 알고리즘 이해하고 백준 넣고 
   // 내일 바이너리 서치 및 알고리즘 풀이 3문제

   // 1. 모든 노드에 대한 깊이(dapth)를 계산합니다
   // 2. 최소 공통 조상을 찾을 두 노드를 확인합니다.
   // - 먼저 두 노드의 깊이(depth)가 동일하도록 거슬러 올라갑니다.
   // 이후에 부모가 같아질 때까지 반복적으로 두 노드의 부모 방향으로 
   // 거슬러 올라갑니다.
   // 3. 모든 LCA(a,b) 연산에 대하여 2번의 과정을 반복
   class Program
   {
      static void Main(string[] args)
      {
         TreeNode<int> rootNode = new TreeNode<int>(
             0,
             new TreeNode<int>(1, new TreeNode<int>(2),
             new TreeNode<int>(3),
             new TreeNode<int>(4, new TreeNode<int>(5),
             new TreeNode<int>(6))
                 ),
             new TreeNode<int>(7,
                 new TreeNode<int>(8),
                 new TreeNode<int>(9)
                 )
         );

         ITreeNode<int> x = ((rootNode.Children[0] as TreeNode<int>).Children[2] as TreeNode<int>).Children[1];
         ITreeNode<int> y = ((rootNode.Children[0] as TreeNode<int>).Children[1]);

         LeastCommonAncestorFinder<int> finder = new LeastCommonAncestorFinder<int>(rootNode);
         ITreeNode<int> result = finder.FindCommonParent(x, y);

         Console.WriteLine(result.Value);
         Console.ReadLine();
      }
   }

   public class TreeNode<T> : ITreeNode<T>
   {
      private readonly ITreeNode<T>[] _children;

      /// <summary>
      /// Initializes a new instance of the <see cref="TreeNode&lt;T&gt;"/> class.
      /// </summary>
      /// <param name="value">The value.</param>
      /// <param name="children">The children.</param>
      public TreeNode(T value, params ITreeNode<T>[] children)
      {
         Value = value;
         _children = children ?? new ITreeNode<T>[0];
      }

      /// <summary>
      /// Gets or sets the value.
      /// </summary>
      /// <value>The value.</value>
      public T Value { get; set; }

      /// <summary>
      /// Gets the children.
      /// </summary>
      /// <value>The children.</value>
      public IList<ITreeNode<T>> Children
      {
         get
         {
            return _children;
         }
      }
      /// <summary>
      /// Gets the children.
      /// </summary>
      /// <value>The children.</value>
      IEnumerable<ITreeNode<T>> ITreeNode<T>.Children
      {
         get
         {
            return _children;
         }
      }


   }
   /// <summary>
   /// Helps find the least common ancestor in a graph 
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class LeastCommonAncestorFinder<T>
   {
      private ITreeNode<T> _rootNode;
      private Dictionary<ITreeNode<T>, NodeIndex> _indexLookup = new Dictionary<ITreeNode<T>, NodeIndex>(); // n or so
      private List<ITreeNode<T>> _nodes = new List<ITreeNode<T>>();  // n
      private List<int> _values = new List<int>(); // n * 2

      /// <summary>
      /// Initializes a new instance of the <see cref="LeastCommonAncestorFinder&lt;T&gt;"/> class.
      /// </summary>
      /// <param name="rootNode">The root node.</param>
      public LeastCommonAncestorFinder(ITreeNode<T> rootNode)
      {
         if (rootNode == null)
         {
            throw new NotImplementedException("rootNode");
         }
         _rootNode = rootNode;
         PreProcess();
      }

      /// <summary>
      /// Finds the common parent between two nodes.
      /// </summary>
      /// <param name="x">The x.</param>
      /// <param name="y">The y.</param>
      /// <returns></returns>
      public ITreeNode<T> FindCommonParent(ITreeNode<T> x, ITreeNode<T> y)
      {
         // Find the first time the nodes were visited during preprocessing.
         NodeIndex nodeIndex;
         int indexX, indexY;
         if (!_indexLookup.TryGetValue(x, out nodeIndex))
         {
            throw new ArgumentException("The x node was not found in the graph.");
         }
         indexX = nodeIndex.FirstVisit;
         if (!_indexLookup.TryGetValue(y, out nodeIndex))
         {
            throw new ArgumentException("The y node was not found in the graph.");
         }
         indexY = nodeIndex.FirstVisit;

         // Adjust so X is less than Y
         int temp;
         if (indexY < indexX)
         {
            temp = indexX;
            indexX = indexY;
            indexY = temp;

         }

         // Find the lowest value.
         temp = int.MaxValue;
         for (int i = indexX; i < indexY; i++)
         {
            if (_values[i] < temp)
            {
               temp = _values[i];
            }
         }
         return _nodes[temp];
      }

      private void PreProcess()
      {
         // Eulerian path visit of graph 
         Stack<ProcessingState> lastNodeStack = new Stack<ProcessingState>();
         ProcessingState current = new ProcessingState(_rootNode);
         ITreeNode<T> next;
         lastNodeStack.Push(current);

         NodeIndex nodeIndex;
         int valueIndex;
         while (lastNodeStack.Count != 0)
         {
            current = lastNodeStack.Pop();
            if (!_indexLookup.TryGetValue(current.Value, out nodeIndex))
            {
               valueIndex = _nodes.Count;
               _nodes.Add(current.Value);
               _indexLookup[current.Value] = new NodeIndex(_values.Count, valueIndex);
            }
            else
            {
               valueIndex = nodeIndex.LookupIndex;
            }
            _values.Add(valueIndex);

            // If there is a next then push the current value on to the stack along with 
            // the current value.
            if (current.Next(out next))
            {
               lastNodeStack.Push(current);
               lastNodeStack.Push(new ProcessingState(next));
            }
         }
         _nodes.TrimExcess();
         _values.TrimExcess();
      }

      private class ProcessingState
      {

         private IEnumerator<ITreeNode<T>> _enumerator;

         /// <summary>
         /// Initializes a new instance of the <see cref="LeastCommonAncestorFinder&lt;T&gt;.ProcessingState"/> class.
         /// </summary>
         /// <param name="value">The value.</param>
         public ProcessingState(ITreeNode<T> value)
         {
            Value = value;
            _enumerator = value.Children.GetEnumerator();
         }

         /// <summary>
         /// Gets the node.
         /// </summary>
         /// <value>The value.</value>
         public ITreeNode<T> Value { get; private set; }

         /// <summary>
         /// Gets the next child.
         /// </summary>
         /// <param name="value">The value.</param>
         /// <returns></returns>
         public bool Next(out ITreeNode<T> value)
         {
            if (_enumerator.MoveNext())
            {
               value = _enumerator.Current;
               return true;
            }
            value = null;
            return false;
         }
      }
      private struct NodeIndex
      {
         public readonly int FirstVisit;
         public readonly int LookupIndex;

         public NodeIndex(int firstVisit, int lookupIndex)
         {
            FirstVisit = firstVisit;
            LookupIndex = lookupIndex;
         }
      }
   }

   /// <summary>
   /// A tree node.
   /// </summary>
   /// <typeparam name="T">The type of the value associated with this node.</typeparam>
   public interface ITreeNode<T>
   {
      /// <summary>
      /// Gets or sets the value.
      /// </summary>
      /// <value>The value.</value>
      T Value { get; set; }

      /// <summary>
      /// Gets the children.
      /// </summary>
      /// <value>The children.</value>
      IEnumerable<ITreeNode<T>> Children { get; }
   }
}
