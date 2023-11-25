using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NScript.ZeroTL.Demo
{
    internal unsafe class PerfTest
    {
        public static long Test0(int num)
        {
            long val = 0;
            long* p = &val;

            for (int i = 0; i < num; i++)
            {
                *p += i;
            }
            return p[0];
        }

        public static long Test1(int num)
        {
            long* p = stackalloc long[10];
            p[0] = 0;

            for(int i = 0; i < num; i++)
            {
                p[0] += i;
            }
            return p[0];
        }

        static Object _cache;

        public static long Test2(int num)
        {
            long sum = 0;
            var obj = new Object();
            for (int i = 0; i < num; i++)
            {
                sum += i;
                _cache = obj;
            }
            return sum;
        }

        public static long Test3(int num)
        {
            var p = new long[10];

            for (int i = 0; i < num; i++)
            {
                p[0] += i;
            }
            return p[0];
        }

        public static void Measure(Action action)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static void Run()
        {
            long sum = 0;
            Object obj = new object();
            Measure(() => { sum = Test0(1000000000); });
            Measure(() => { sum = Test1(1000000000); });
            Measure(() => { sum = Test2(1000000000); });
            Measure(() => { sum = Test3(1000000000); });
        }
    }
}
