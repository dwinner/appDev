﻿using System;
using System.Runtime.CompilerServices;

namespace JitCall
{
    class Program
    {
        static void Main(string[] args)
        {
            uint x = UInt32.MaxValue;
            int val = A();
            int val2 = A();
            Console.WriteLine(val + val2);           
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        static int A()
        {
            return 42;
        }
    }
}
