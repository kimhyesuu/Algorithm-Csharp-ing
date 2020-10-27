using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPtrExe2
{
    class Cow
    {
        public int mooCount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var o = new Cow();
            //Cow c = o; 
            Type t;
            Cow betsy = new Cow();
            Console.Write(betsy.GetType().GetProperty("mooCount"));
            betsy.mooCount = 9;
            Cow georgy = new Cow();
            georgy.mooCount = 3;

            
        }
    }
}
