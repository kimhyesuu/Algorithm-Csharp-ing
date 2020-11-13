using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryArray
{
   public class BinaryTreeUsingArray
   {
      private object[] arr;

      public BinaryTreeUsingArray(int capacity = 15)
      {
         arr = new object[capacity];
      }

      public object Root
      {
         get { return arr[0]; }
         set { arr[0] = value; }
      }

      public void SetLeft(int parentIndex, object data)
      {
         int leftIndex = parentIndex * 2 + 1;

         if(arr[parentIndex] is null 
            || leftIndex >= arr.Length)
         {
            throw new ApplicationException("Error");
         }

         arr[leftIndex] = data;
      }

      public void SetRight(int parentIndex, object data)
      {
         int rightIndex = parentIndex * 2 + 2;

         if (arr[parentIndex] is null
            || rightIndex >= arr.Length)
         {
            throw new ApplicationException("Error");
         }

         arr[rightIndex] = data;
      }


      public object GetParent(int childIndex)
      {
         if (childIndex is 0) return null;

         int parentIndex = (childIndex-1)/2;

         return arr[parentIndex];
      }


      public object GetLeft(int parentIndex)
      {
         int leftIndex = parentIndex * 2 + 1;

         return arr[leftIndex];
      }

      public object GetRight(int parentIndex)
      {
         int rightIndex = parentIndex * 2 + 2;

         return arr[rightIndex];
      }

      public void PrintTree()
      {
         for(int i = 0; i < arr.Length; i++)
         {
            Console.Write($"{arr[i]??"-"}");
         }
         Console.WriteLine();
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         var bt = new BinaryTreeUsingArray(7);
         bt.Root = "A";
         bt.SetLeft(0,"B");
         bt.SetRight(0,"C");
         bt.SetLeft(1,"D");
         bt.SetLeft(2,"F");

         bt.PrintTree();

         var data = bt.GetParent(5);

         Console.WriteLine(data);

         data = bt.GetLeft(2);

         Console.WriteLine(data);

         Console.ReadKey();
      }
   }
}
