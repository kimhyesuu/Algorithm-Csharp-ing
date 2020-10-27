using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
   class Program
   {
      [DllImport("User32.dll", CharSet = CharSet.Unicode)]
      public static extern int MessageBox(IntPtr h, string m, string c, int type);

      static void Main(string[] args)
      {
         string myString;
         Console.Write("Enter your message: ");
         myString = Console.ReadLine();
         MessageBox((IntPtr)0, myString, "My Message Box", 0);

         unsafe
         {
            int var = 20;
            int* p = &var;

            Console.WriteLine($"Data is : {var}");
            Console.WriteLine($"Data is : {*p}");
            Console.WriteLine($"Data is : {p->ToString()}");
            Console.WriteLine($"Data is : {(int)p}");
         }


         unsafe
         {

            //IntPtr p = new MyStruct("fred");

            //myStruct* sptr;

            //sptr = p;

            //Console.WriteLine(*sptr->name);

         }

         Console.ReadKey();
      }
   }
}
