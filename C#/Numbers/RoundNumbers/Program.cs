﻿/**
 * Способы округления чисел
 */

using System;

namespace HowToCSharp.Ch05.RoundNumbers
{
   internal static class Program
   {
      private static void Main()
      {
         var val = 13.45;

         Console.WriteLine("Math.Round({0}) = {1}", val, Math.Round(val));
         Console.WriteLine("Math.Round({0}, 1) = {1}", val, Math.Round(val, 1));
         Console.WriteLine("Math.Round({0}, 2) = {1}", val, Math.Round(val, 2));
         Console.WriteLine("Math.Round({0}, MidpointRounding.AwayFromZero) = {1}", val,
            Math.Round(val, MidpointRounding.AwayFromZero));
         Console.WriteLine("Math.Round({0}, 1, MidpointRounding.AwayFromZero) = {1}", val,
            Math.Round(val, 1, MidpointRounding.AwayFromZero));
         Console.WriteLine("Math.Round({0}, 2, MidpointRounding.AwayFromZero) = {1}", val,
            Math.Round(val, 2, MidpointRounding.AwayFromZero));

         Console.WriteLine("Math.Round({0}, MidpointRounding.ToEven) = {1}", val,
            Math.Round(val, MidpointRounding.AwayFromZero));
         Console.WriteLine("Math.Round({0}, 1, MidpointRounding.ToEven) = {1}", val,
            Math.Round(val, 1, MidpointRounding.ToEven));
         Console.WriteLine("Math.Round({0}, 2, MidpointRounding.ToEven) = {1}", val,
            Math.Round(val, 2, MidpointRounding.ToEven));

         Console.WriteLine();

         val = -val;

         Console.WriteLine("Math.Round({0}) = {1}", val, Math.Round(val));
         Console.WriteLine("Math.Round({0}, 1) = {1}", val, Math.Round(val, 1));
         Console.WriteLine("Math.Round({0}, 2) = {1}", val, Math.Round(val, 2));
         Console.WriteLine("Math.Round({0}, MidpointRounding.AwayFromZero) = {1}", val,
            Math.Round(val, MidpointRounding.AwayFromZero));
         Console.WriteLine("Math.Round({0}, 1, MidpointRounding.AwayFromZero) = {1}", val,
            Math.Round(val, 1, MidpointRounding.AwayFromZero));
         Console.WriteLine("Math.Round({0}, 2, MidpointRounding.AwayFromZero) = {1}", val,
            Math.Round(val, 2, MidpointRounding.AwayFromZero));

         Console.WriteLine("Math.Round({0}, MidpointRounding.ToEven) = {1}", val,
            Math.Round(val, MidpointRounding.AwayFromZero));
         Console.WriteLine("Math.Round({0}, 1, MidpointRounding.ToEven) = {1}", val,
            Math.Round(val, 1, MidpointRounding.ToEven));
         Console.WriteLine("Math.Round({0}, 2, MidpointRounding.ToEven) = {1}", val,
            Math.Round(val, 2, MidpointRounding.ToEven));

         Console.WriteLine();
         Console.WriteLine("Snap input to multiples of 10");
         for (double i = 0; i < 100; i += 6.7)
            Console.WriteLine("{0} ==> {1}", i, SnapInput(i, 10));

         Console.WriteLine();
         Console.WriteLine("Snap input to multiples of 0.5");
         for (double i = 0; i < 5; i += 0.15)
            Console.WriteLine("{0} ==> {1}", i, SnapInput(i, 0.5, 2));

         Console.ReadKey();
      }

      private static int SnapInput(double input, int multiple) => (int) (input + multiple / 2.0) / multiple * multiple;

      private static double SnapInput(double input, double multiple, int precision)
      {
         var scalar = Math.Pow(10, precision);
         return SnapInput(scalar * input, (int) (scalar * multiple)) / scalar;
      }
   }
}