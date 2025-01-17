﻿using System;

internal unsafe class FunctionPointerSample
{
   public static void Calc(delegate* managed<int, int, int> func)
   {
      var result = func(42, 11);
      Console.WriteLine($"function pointer result: {result}");
   }

   public static void CalcUnmanaged(delegate* unmanaged[Stdcall]<int, int, int> func)
   {
      var result = func(42, 11);
      Console.WriteLine($"function pointer result: {result}");
   }
}