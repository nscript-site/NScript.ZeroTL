using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NScript.ZeroTL.Demo
{
    internal unsafe class DeferTest
    {
        public static void Test()
        {
            using (Defer.Run(&DeferTest.DeferFunc));
            Console.WriteLine("Test");
        }

        private static void DeferFunc()
        {
            Console.WriteLine("DeferFunc");
        }
    }
}
